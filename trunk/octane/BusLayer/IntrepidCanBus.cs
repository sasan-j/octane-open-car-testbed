/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       IntrepidCanBus.cs
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
using System.Threading;
using System.Windows.Forms;

using System.Diagnostics;

//************************
// Not yet Complete - CEE
// Work in Progress
//************************


namespace OpenCarTestbed
{
    /*
    public class CanWrite
    {
        // Not being used since single transmission does not need threading at this time
        public void KvaserWrite(CanData can)
        {
           // Canlib.canWrite(can.handle, can.id, can.msg, can.dlc, can.flags);
           // Canlib.canWriteSync(can.handle, 10000);
           Canlib.canWriteWait(can.handle, can.id, can.msg, can.dlc, can.flags,1000);
        }

        public void KvaserWriteMultiple(CanData can)
        {
            for (int x = 0; x < can.number; x++)
            {
                // MainWindow.ErrorDisplayString("can message: " + CommonUtils.DisplayMsg(can));
                can.status = Canlib.canWrite(can.handle, can.id, can.msg, can.dlc, can.flags);
                // MainWindow.ErrorDisplayString("can status: " + can.status);
                can.status1 = Canlib.canWriteSync(can.handle, 10000);
                //CheckFlags(can);
                System.Threading.Thread.Sleep(can.timeBtw);

                if (can.increment == true)
                    can.id++;
            }
        }
    }
     */

    //**************
    // GenericCanBus library
    //**************
    public class IntrepidCanBus
    {

        // CAN return rate
        public static string CanRateReturn(string canInterface)
        {
            /*
            long bitrate;
            int tseg1;
            int tseg2;
            int sjw;
            int noSamp;
            int syncmode;

            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            // Kvaser can return
            if (msgOutput[2] == "Kvaser")
            {
                Canlib.canGetBusParams(Convert.ToInt32(msgOutput[3]), out bitrate, out tseg1, out tseg2, out sjw, out noSamp, out syncmode);
                return bitrate.ToString();
            }
            */

            return null;
        } // End GenericCanRateReturn
 

        // CAN initilization
        public static void GenericCanInitilize()
        {

        } // End GenericCanInitilize

        // ***************************************
        // DetectCanInterfaces
        // Pulls all of the available adapters for the CAN bus
        // ***************************************
        public static void DetectCanInterfaces()
        {
          
            // Detect Process for Intrepid devices
            try
            {
                int iResult;
                neoCSNet2003.NeoDevice ndNeoToOpen = new neoCSNet2003.NeoDevice();	//Struct holding detected hardware information
                int iNumberOfDevices;   //Number of hardware devices to look for 
                string neoDevice;

                //Set the number of devices to find
                iNumberOfDevices = 1;

                // Revision needed to search for multiple devices
                //Search for connected hardware
                iResult = neoCSNet2003.icsNeoDll.icsneoFindNeoDevices(65535, ref ndNeoToOpen, ref iNumberOfDevices);

                // Obtain the name of the Interpid device -- Device names from Intrepid Sample code
                switch(ndNeoToOpen.DeviceType)
	            {
		            case 1:
			            neoDevice = "neoVI Blue SN " + Convert.ToString(ndNeoToOpen.SerialNumber);
			            break;
		            case 4:
                        neoDevice = "Value CAN 2 SN " + Convert.ToString(ndNeoToOpen.SerialNumber);
			            break;
		            case 8:
                        neoDevice = "neoVI FIRE SN " + Convert.ToString(ndNeoToOpen.SerialNumber);
			            break;
		            case 16:
                        neoDevice = "ValueCAN 3 SN " + Convert.ToString(ndNeoToOpen.SerialNumber);
			            break;
		            default:
                        neoDevice = "Unknown neoVI SN " + Convert.ToString(ndNeoToOpen.SerialNumber);
			            break;
	            }

                if (iNumberOfDevices < 1 || iResult == 0)                   
                    ErrorLog.NewLogEntry("CAN", "Detect CAN: No Intrepid devices detected ");
                else 
                {
                    BusInterface.AddInterface("CAN;" + neoDevice + ";" + "Intrepid" + ";" + 0, -1);
                    ErrorLog.NewLogEntry("CAN", "Detect CAN: " + neoDevice);
                }
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Adapter", "Intrepid library not found");
            }
        } // End DetectCanInterfaces


        // ***************************************
        // GenericCanBusOn
        // Turns canInterface on based on User Selection
        // ***************************************
        public static int CanBusOn(string canInterface, string bitRateSetting)
        {
            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

           // int ReturnError = 0;  //This will be used for all error return status codes
	      
            
           
            /*

            // Assigns settings for the adapter
            if (bitRateSetting == "1M")
                EComCANBitrate = ECOMLibrary.CAN_BAUD_1MB;
            else if (bitRateSetting == "500K")
                EComCANBitrate = ECOMLibrary.CAN_BAUD_500K;
            else if (bitRateSetting == "250K")
                EComCANBitrate = ECOMLibrary.CAN_BAUD_250K;
            else if (bitRateSetting == "125K")
                EComCANBitrate = ECOMLibrary.CAN_BAUD_125K;
            else if (bitRateSetting == "100K" || msgOutput[4] == "62K" || msgOutput[4] == "50K" || msgOutput[4] == "33K")
            {
                MainWindow.ErrorDisplayString("ECom Adapter does not support low speed CAN (100K, 62K, 50K, 33K)");
                return -1;
            }
             */

            //EcomHandle = ECOMLibrary.CANOpen(Convert.ToUInt32(msgOutput[3]), EComCANBitrate, ref ReturnError);
           // BusInterface.AddHandle(canInterface, (int)EcomHandle);

            /*
            ReturnError = icsNeoDll.icsneoOpenNeoDevice(ref ndNeoToOpen, ref m_hObject, ref bNetwork[0], 1, 0);
            if (ReturnError == 1)
            {
                ErrorLog.NewLogEntry("CAN", "Bus On: ");
                return 1;
            }
            else
            {
                ErrorLog.NewLogEntry("CAN", "Error Starting Bus");
                return 0;
            }
            */

            return 1;
        }

        // **********************
        // Turns canInterface off
        // **********************
        public static void CanBusOff(string canInterface)
        {
            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            int iResult;
            int iNumberOfErrors = 0;

            iResult = neoCSNet2003.icsNeoDll.icsneoClosePort(BusInterface.ReturnHandle(canInterface), ref iNumberOfErrors);
                
            if (iResult == 1)
                ErrorLog.NewLogEntry("CAN", "Bus Off Success: " + msgOutput[1]);
            else
                ErrorLog.NewLogEntry("CAN", "Bus Off Failed: " + msgOutput[1]);
        }

        //************************************
        // CAN Transmit for a single transmission
        //************************************
        public static void CanTransmitSingle(CanData can)
        {
            string hardwareString0 = can.hardware.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');


        } // End GenericCanTransmitSingle

       

        // CAN Transmit for multiple transmissions
        public static void CanTransmitMultiple(CanData can)
        {
            string hardwareString0 = can.hardware.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

        }  // End GenericCanTransmitMultiple


        // CAN Receive
        public static bool CanReceive(CanData can)
        {
            string hardwareString0 = can.hardware.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            return false;

        } // End Read



        // Checks the flags on transmitted or recieved messages
        private static void CheckFlags(CanData can)
        {
           can.flagString = "";

        } // End CheckFlags
    }
}