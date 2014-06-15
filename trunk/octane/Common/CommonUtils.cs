/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       CommonUtils.cs
 *  Author:     autolab-everett\ceveret3
 *  ----------------------------------------------------------------------------
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.

 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using canlibCLSNET;

using System.Diagnostics;
using System.Windows.Forms;

namespace OpenCarTestbed
{
    public class CommonUtils
    {

        public enum ConfigFileType
        {
            UserChoiceDocument,
            NewDocument
        }
        // For the array numbering in the BusMonitor
       // public enum BusFields {Packet, IdNo, Id, BitMSB, BitLSB, DLC, Flags, DataID, Data, Type, Time};
       // public enum BusFields { Packet, IdNo, Id, BitMSB, BitLSB, DLC, Flags, Data, Type, Time };
        public enum BusFields { Packet, IdNo, Id, BitMSB, BitLSB, DLC, Flags, Data, Time };
        
        // Temp until hardware support is added     
       // public static bool TransmitChannel2 = false;

        // Converts a CAN message into string format for display in the multi-column box
        // CAN message to display format
        // ***********************
        public static string[] ConvertMsgArray(CanData can, string filter, int BitMSBinput)
        {
            // Allocates the string array for return; update size as needed
            string[] msgOutput = new string[11];
            
            // Initial the msg array to blank   
            msgOutput[(int)BusFields.Data] = "";        
            msgOutput[(int)BusFields.Id] = "";
            msgOutput[(int)BusFields.Flags] = "";     

            //  Format MSB/LSB           0/11   1/10   2/9    3/8    4/7    5/6    6/7    7/4    8/3    9/2    10/1   11/0
            int[] BitMSBhex = new int[] {0x000, 0x001, 0x600, 0x700, 0x780, 0x7C0, 0x7E0, 0x7F0, 0x7F8, 0x7FC, 0x7FE, 0x7FF};
            int[] BitLSBhex = new int[] {0x7FF, 0x7FE, 0x1FF, 0x0FF, 0x07F, 0x03F, 0x01F, 0x00F, 0x007, 0x003, 0x001, 0x000};

            // Pulls the MSB and LSB from the ID for identity checking
            msgOutput[(int)BusFields.BitMSB] = String.Format("{0:X}", (can.id & BitMSBhex[BitMSBinput]));
            msgOutput[(int)BusFields.BitLSB] = String.Format("{0:X}", (can.id & BitLSBhex[BitMSBinput]));
            
            // Calls the filters
            if (filter != "")
            {
                // Checks for matches in the XML filter files for packet, ECU, and message
                string stringmsg = CommonUtils.ConvertMsgtoString(can.msg, can.dlc);

                // Filter Output processing
                msgOutput[(int)BusFields.Packet] = XMLInterfaces.ReturnPacketIdentifier(filter, can.id, stringmsg);
               //MainWindow.ErrorDisplayString("XML: " + msgOutput[(int)BusFields.Packet]);

                msgOutput[(int)BusFields.Id] = XMLInterfaces.ReturnID(filter, can.id);

                // Removed to conslidate output 
               // msgOutput[(int)BusFields.DataID] = XMLInterfaces.ReturnMsg(filter, stringmsg);

                /*
                // If Then Filter Processing
                if (IfThenActive == true)
                {
                    XMLInterfaces.CheckIfThen(filter, can.id, stringmsg);
                }
                 */

            }  

            // Hex output
            if (String.Compare(can.format, "hex", true) == 0)
            {
                // hex output
                msgOutput[(int)BusFields.IdNo] = String.Format("{0:X3}", can.id);
                msgOutput[(int)BusFields.DLC] = String.Format("{0:X}", can.dlc);
                msgOutput[(int)BusFields.Flags] = String.Format("{0}", can.flags);

                for (int i = 0; i < 8; i++)
                {
                    if (i < can.dlc)
                    {
                        msgOutput[(int)BusFields.Data] += String.Format(" {0:X2}", can.msg[i]);
                    }
                }
            }
            // Default to Decimal output if no format is given
            else
            {
                // decimal output
                msgOutput[(int)BusFields.IdNo] = String.Format("{0}", can.id);
                msgOutput[(int)BusFields.DLC] = Convert.ToString(can.dlc);
                msgOutput[(int)BusFields.Flags] = Convert.ToString(can.flags);
                for (int i = 0; i < 8; i++)
                {
                    if (i < can.dlc)
                    {
                        // decimal output
                        msgOutput[(int)BusFields.Data] += " " + Convert.ToString(can.msg[i]);
                    }


                }
            }

            if (can.errorFrame == true & can.flagString == "E")            
                msgOutput[(int)BusFields.Packet] = "Error Frame";                           
           can.errorFrame = false;
            
/*
            switch (can.flagString)
            {
                case "E":
                    msgOutput[(int)BusFields.Packet] = "Error Frame"; 
                    break;

                case "X":
                    msgOutput[(int)BusFields.Packet] = "Extended Frame"; 
                    break;

                case "R":
                    msgOutput[(int)BusFields.Packet] = "Remote Frame"; 
                    break;
              
                default:
                    msgOutput[(int)BusFields.Packet] = "Standard Frame"; 
                    break;
            }

            if (can.errorFrame == true & can.flagString == "E")
                msgOutput[(int)BusFields.Packet] = "Error Frame"; 
*/

           // msgOutput[(int)BusFields.Flags] = can.flagString;
            msgOutput[(int)BusFields.Time] = String.Format("{0}", can.time);

            return msgOutput;
        }


        // ***********************
        // Converts a string with ; delimiters to a string array
        // ***********************
        public static string[] ConvertStringtoStringArray(string msgInput)
        {
            string[] msgOutput = msgInput.Split(';');
            return msgOutput;
        }

        // ***********************
        // Converts an input string into the message format for the CAN library
        // ***********************
        public static void ConvertStringtoCAN(CanData can, string msgInput)
        {
            // msgInput --> 0=id; 1=dlc; 2=flag; 3=message
            string[] output = msgInput.Split(';');

            if (output.Count() < 0){
                ErrorLog.NewLogEntry("Convert Error:", msgInput);
                return;
            }

            // Needs input checking; revisions needed
            if (output[1] != "") can.dlc = Convert.ToInt32(output[1]);

            if (can.format == "hex")
            {
                // Converts the id to hex with the 16 (Chris please check I think it converts hex to int PNB)
                if (output[0] != "") can.id = Convert.ToInt32(output[0], 16);

                // Need error checking to ensure that flag is an int
                if (!string.IsNullOrEmpty(output[2]))
                {
                    switch (output[2].ToLower())
                    {
                        case "x":
                            output[2] = "4"; //Extended Packet
                            break;
                        case "r":
                            output[2] = "1";  // Remote Packet
                            break;
                        case "e":
                            output[2] = "20";  // Error Packet
                            break;
                        default:
                            output[2] = "2";  // Standard Packet
                            break;
                    }

                    can.flags = Convert.ToInt32(output[2], 16);
                }

                if (output[3] != "")
                {
                    string msgString0 = output[3].Replace("-", "");
                    string msgString1 = msgString0.Replace(" ", "");
                    can.msg = HexStringToByteArray(msgString1);
                }
            }
            // if not hex assume decimal
            else
            {
                if (output[0] != "") can.id = Convert.ToInt32(output[0]);
                if (output[2] != "") can.flags = Convert.ToInt32(output[2]);

                if (output[3] != "")
                {
                    string msgString0 = output[3].Replace("-", " ");
                    string[] msgString1 = msgString0.Split(' ');

                    // first part is blank
                    for (int i = 1; i < 9; i++)
                    {
                        if (i < can.dlc)
                            can.msg[i] = Convert.ToByte(msgString1[i]);
                    }
                }
            }
        }


        // ***********************
        // Returns byte array from a string of hex
        // ***********************
        public static byte[] HexStringToByteArray(string Hex)
        {
            // Error check to ensure that the input is hex; needs revisions for proper error handling
            if (Hex.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", Hex));
            }

            byte[] HexAsBytes = new byte[Hex.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = Hex.Substring(index * 2, 2);
                // Need Error checking; needs revisions for proper error handling
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber);
            }

            return HexAsBytes; 
        }

        // ***********************
        // Return a string for display in a window
        // ***********************
        public static string DisplayMsg(CanData can)
        {
            string msgOutput0 = "";
            string msgOutput1 = "";
            string msgReturn = "";

            for (int i = 0; i < 8; i++)
            {
                if (i < can.dlc)
                {
                    // hex output
                    msgOutput0 += String.Format("  {0:X}", can.msg[i]);
                    // decimal output
                    msgOutput1 += " " + Convert.ToString(can.msg[i]);
                }
            }

            msgReturn = "Transmit Item:\n ID:" + can.id + "\n DLC:" + can.dlc + "\n FLAGS:" + can.flags + "\n MSG (hex):" + msgOutput0 + "\n MSG (dec):" + msgOutput1;
            return msgReturn;    
          }

        // ***********************
        // Return a string from a byte msg
        // ***********************
        public static string ConvertMsgtoString(byte[] msg, int dlc)
        {
            string msgReturn = "";

            for (int i = 0; i < msg.Length; i++)
            {
                if (i < dlc)
                    msgReturn += String.Format("{0:X2}", msg[i]);
            }

            return msgReturn;
        }

        // ***********************
        // Return a string that includes the formatting for an ErrorMsg that can be displayed; for CAN bus
        // ***********************
        public static string ErrorMsg(string Location, Canlib.canStatus status)
        {
            string ErrorMsg = "";
          
            if (status == 0) //in can lib 0 is the OK status
            {
                ErrorMsg = Location + ": Success";
            }
            else // all other status values are errors
            {
                ErrorMsg = Location + ": Fail : Error Code:" + status;
            }

            return ErrorMsg;
        }

        //*********************************************************
        //Check if the string is Hex or not
        //*********************************************************

        public static bool CheckHexValue(string value)
        {
            int n = 0;
            if (!int.TryParse(value, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) && value != String.Empty)
            {
                return false;
            }
            return true;
        }

        //****************************
        // Checks for form duplicates, if there is an instance of the form, put the focus on it, otherwise open a new instance.
        //Written by Parnian Najafi Borazjani
        //****************************
        public static Form GetOpenedForm<T>() where T : Form
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == typeof(T))
                {
                    return openForm;
                }
            }
            return null;
        }

    }
}