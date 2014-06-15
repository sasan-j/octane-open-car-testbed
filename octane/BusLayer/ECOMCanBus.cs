/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       ECOMCanBus.cs
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

namespace OpenCarTestbed
{
   
    public class ECOMCanWrite
    {

        public void ECOMWriteMultiple(CanData can)
        {
            for (int x = 0; x < can.number; x++)
            {
                can.handle = BusInterface.ReturnHandle(can.hardware);
                //MainWindow.ErrorDisplayString("ECom Handle: " + Convert.ToString(can.handle));

                ECOMLibrary.SFFMessage txMessage = new ECOMLibrary.SFFMessage();
                ECOMLibrary.EFFMessage etxMessage = new ECOMLibrary.EFFMessage();

                // Pulls the top 3 bits for IDH and the bottom 8 bits for IDL
                txMessage.IDH = (byte)(can.id & 0x700);
                txMessage.IDL = (byte)(can.id & 0x0FF);
                // Converts the entire id into an unit for extended sending
                etxMessage.ID = (UInt32)can.id;

                txMessage.DataLength = (byte)can.dlc;
                etxMessage.DataLength = (byte)can.dlc;
                txMessage.options = (byte)can.flags;
                etxMessage.options = (byte)can.flags;

                // Puts the individual bytes into the can.msg byte array
                if (can.dlc > 0)
                {
                    txMessage.data1 = can.msg[0];
                    etxMessage.data1 = can.msg[0];
                }
                
                if (can.dlc > 1)
                {
                    txMessage.data2 = can.msg[1];
                    etxMessage.data2 = can.msg[1];
                }
                
                if (can.dlc > 2)
                {
                    txMessage.data3 = can.msg[2];
                    etxMessage.data3 = can.msg[2];
                }
                
                if (can.dlc > 3)
                {
                    txMessage.data4 = can.msg[3];
                    etxMessage.data4 = can.msg[3];
                }
                
                if (can.dlc > 4)
                {
                    txMessage.data5 = can.msg[4];
                    etxMessage.data5 = can.msg[4];
                }
                
                if (can.dlc > 5)
                {
                    txMessage.data6 = can.msg[5];
                    etxMessage.data6 = can.msg[5];
                }
                
                if (can.dlc > 6)
                {
                    txMessage.data7 = can.msg[6];
                    etxMessage.data7 = can.msg[6];
                }
                
                if (can.dlc > 7)
                {
                    txMessage.data8 = can.msg[7];
                    etxMessage.data8 = can.msg[7];
                }

                if (can.flags == 4)
                    ECOMLibrary.CANTransmitMessageEx((UInt32)can.handle, ref etxMessage);
                else
                    ECOMLibrary.CANTransmitMessage((UInt32)can.handle, ref txMessage);


               System.Threading.Thread.Sleep(can.timeBtw);

               if (can.increment == true)
                    can.id++;
            }
        }
    }
  

    //**************
    // GenericCanBus library
    //**************
    public class ECOMCanBus
    {

        // CAN return rate
        public static string CanRateReturn(string canInterface)
        {
            try
            {
                string hardwareString0 = canInterface.Replace(" ", "");
                string[] msgOutput = hardwareString0.Split(';');
                ECOMLibrary.DeviceInfo di = new ECOMLibrary.DeviceInfo();

                // ECom can return
                // NOTE: ECom API does not have a bus parameter call
                if (msgOutput[2] == "ECom")
                {
                    // Finds the open ECom Adapters
                    UInt32 deviceSearch = ECOMLibrary.StartDeviceSearch(ECOMLibrary.FIND_OPEN);

                    while (deviceSearch != 0 && ECOMLibrary.FindNextDevice(deviceSearch, ref di) == ECOMLibrary.ECI_NO_ERROR)
                    {
                        if (di.CANOpen != 0)
                            return Convert.ToString(di.SerialNumber);
                    }
                    ECOMLibrary.CloseDeviceSearch(deviceSearch);
                }

                return null;
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Adapter", "ECom library not found");
                return null;
            }
        } // End GenericCanRateReturn

        // ***************************************
        // DetectCanInterfaces
        // Pulls all of the available adapters for the CAN bus
        // ***************************************
        public static void DetectCanInterfaces()
        {
            // Detect Process for ECom devices
            try
            {
               ECOMLibrary.DeviceInfo di = new ECOMLibrary.DeviceInfo();
               UInt32 deviceSearch = ECOMLibrary.StartDeviceSearch(ECOMLibrary.FIND_ALL);
        
                while (deviceSearch != 0 && ECOMLibrary.FindNextDevice(deviceSearch, ref di) == ECOMLibrary.ECI_NO_ERROR)
                {
                    BusInterface.AddInterface("CAN;" + "CANCapture" + ";" + "ECom" + ";" + di.SerialNumber, -1);
                    ErrorLog.NewLogEntry("CAN", "Detect CAN: " + di.SerialNumber);
                }
         
                ECOMLibrary.CloseDeviceSearch(deviceSearch);
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Adapter", "ECom library not found");
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
 
            Byte ReturnError = 0;  //This will be used for all error return status codes
	        UInt32 EcomHandle; //This will be the HANDLE to our ECOM device used for all function calls	
            byte EComCANBitrate = ECOMLibrary.CAN_BAUD_500K;

            ECOMLibrary.DeviceInfo di = new ECOMLibrary.DeviceInfo();

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

            EcomHandle = ECOMLibrary.CANOpen(Convert.ToUInt32(msgOutput[3]), EComCANBitrate, ref ReturnError);
            //MainWindow.ErrorDisplayString("ECom Handle: " + Convert.ToString(EcomHandle));
            BusInterface.AddHandle(canInterface, (int)EcomHandle);

	        if (EcomHandle == 0 || ReturnError != 0)
	        {		    
                StringBuilder ErrMsg = new StringBuilder(400);
                ECOMLibrary.GetFriendlyErrorMessage(ReturnError, ErrMsg, 400);
		        MainWindow.ErrorDisplayString("CANOpen failed with error message: " + ErrMsg);
		        return -1;
	        }

            ECOMLibrary.GetDeviceInfo(EcomHandle, ref di);
            ErrorLog.NewLogEntry("CAN", "Bus On: " + di.SerialNumber);
            return 1;
        }

        // **********************
        // Turns canInterface off
        // **********************
        public static void CanBusOff(string canInterface)
        {
            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            // Need Error Checking to ensure that device closes
            ECOMLibrary.CloseDevice((UInt32)BusInterface.ReturnHandle(canInterface));
            ErrorLog.NewLogEntry("CAN", "Bus Off Success/Failed: " + msgOutput[1]);
        }

        //************************************
        // CAN Transmit for a single transmission
        //************************************
        public static void CanTransmitSingle(CanData can)
        {
            // Implementation for Standard Message & Extended Message
                
            can.handle = BusInterface.ReturnHandle(can.hardware);
            //MainWindow.ErrorDisplayString("ECom Handle: " + Convert.ToString(can.handle));

            ECOMLibrary.SFFMessage txMessage = new ECOMLibrary.SFFMessage();
            ECOMLibrary.EFFMessage etxMessage = new ECOMLibrary.EFFMessage();

            // Pulls the top 3 bits for IDH and the bottom 8 bits for IDL
            txMessage.IDH = (byte)(can.id & 0x700);
            txMessage.IDL = (byte)(can.id & 0x0FF);
            // Converts the entire id into an unit for extended sending
            etxMessage.ID = (UInt32)can.id;

            txMessage.DataLength = (byte)can.dlc;
            etxMessage.DataLength = (byte)can.dlc;
            txMessage.options = (byte)can.flags;
            etxMessage.options = (byte)can.flags;

            // Puts the individual bytes into the can.msg byte array
            if (can.dlc > 0)
            {
                txMessage.data1 = can.msg[0];
                etxMessage.data1 = can.msg[0];
            }
            
            if (can.dlc > 1)
            {
                txMessage.data2 = can.msg[1];
                etxMessage.data2 = can.msg[1];
            }
            
            if (can.dlc > 2)
            {
                txMessage.data3 = can.msg[2];
                etxMessage.data3 = can.msg[2];
            }
            
            if (can.dlc > 3)
            {
                txMessage.data4 = can.msg[3];
                etxMessage.data4 = can.msg[3];
            }
            
            if (can.dlc > 4)
            {
                txMessage.data5 = can.msg[4];
                etxMessage.data5 = can.msg[4];
            }
            
            if (can.dlc > 5)
            {
                txMessage.data6 = can.msg[5];
                etxMessage.data6 = can.msg[5];
            }
            
            if (can.dlc > 6)
            {
                txMessage.data7 = can.msg[6];
                etxMessage.data7 = can.msg[6];
            }
            if (can.dlc > 7)
            {
                txMessage.data8 = can.msg[7];
                etxMessage.data8 = can.msg[7];
            }

            // Non-threading write option
            if (can.flags == 4)
                ECOMLibrary.CANTransmitMessageEx((UInt32)can.handle, ref etxMessage);
            else
                ECOMLibrary.CANTransmitMessage((UInt32)can.handle, ref txMessage);
 
            CheckFlags(can);

        } // End GenericCanTransmitSingle

       

        // CAN Transmit for multiple transmissions
        public static void CanTransmitMultiple(CanData can)
        {
            can.handle = BusInterface.ReturnHandle(can.hardware);
            ECOMCanWrite writeCan = new ECOMCanWrite();

            Thread t2 = new Thread(delegate()
            {
                writeCan.ECOMWriteMultiple(can);
            });
            t2.IsBackground = true;
            t2.Start();

        }  // End GenericCanTransmitMultiple


        // CAN Receive
        public static bool CanReceive(CanData can)
        {
            Byte ReturnError = 0;  

            ECOMLibrary.SFFMessage RxMessage = new ECOMLibrary.SFFMessage();
            ECOMLibrary.EFFMessage ExMessage = new ECOMLibrary.EFFMessage();

            try
            {
                //ECOM library call to get a standard message
                ReturnError = ECOMLibrary.CANReceiveMessage((UInt32)BusInterface.ReturnHandle(can.hardware), ref RxMessage);
            }
            catch { 
                ErrorLog.NewLogEntry("ECOM", Convert.ToString(ReturnError));
            }

            if (ReturnError == 0)
            {
                // Converts the ID low and ID high
                can.id = Convert.ToInt32(RxMessage.IDL + RxMessage.IDH);
                can.dlc = Convert.ToInt32(RxMessage.DataLength);
                can.time = Convert.ToInt64(RxMessage.TimeStamp);

                // Puts the individual bytes into the can.msg byte array
                if (can.dlc > 0)
                    can.msg[0] = RxMessage.data1;
                if (can.dlc > 1)
                    can.msg[1] = RxMessage.data2;
                if (can.dlc > 2)
                    can.msg[2] = RxMessage.data3;
                if (can.dlc > 3)
                    can.msg[3] = RxMessage.data4;
                if (can.dlc > 4)
                    can.msg[4] = RxMessage.data5;
                if (can.dlc > 5)
                    can.msg[5] = RxMessage.data6;
                if (can.dlc > 6)
                    can.msg[6] = RxMessage.data7;
                if (can.dlc > 7)
                    can.msg[7] = RxMessage.data8;

                // Revisions Needed -- Need to pull flag information
                can.flags = Convert.ToInt32(RxMessage.options);

                //MainWindow.ErrorDisplayString(Convert.ToString(can.flags));

                // For error testing
                // MainWindow.ErrorDisplayByteArray(can.msg);
                //MainWindow.ErrorDisplayString(Convert.ToString(can.dlc));
            }
            else
            {
                ReturnError = ECOMLibrary.CANReceiveMessageEx((UInt32)BusInterface.ReturnHandle(can.hardware), ref ExMessage);

                can.id = Convert.ToInt32(ExMessage.ID);
                can.dlc = Convert.ToInt32(ExMessage.DataLength);
                can.time = Convert.ToInt64(ExMessage.TimeStamp);

                // Puts the individual bytes into the can.msg byte array
                if (can.dlc > 0)
                    can.msg[0] = ExMessage.data1;
                if (can.dlc > 1)
                    can.msg[1] = ExMessage.data2;
                if (can.dlc > 2)
                    can.msg[2] = ExMessage.data3;
                if (can.dlc > 3)
                    can.msg[3] = ExMessage.data4;
                if (can.dlc > 4)
                    can.msg[4] = ExMessage.data5;
                if (can.dlc > 5)
                    can.msg[5] = ExMessage.data6;
                if (can.dlc > 6)
                    can.msg[6] = ExMessage.data7;
                if (can.dlc > 7)
                    can.msg[7] = ExMessage.data8;

                // Revisions Needed -- Need to pull flag information
                can.flags = Convert.ToInt32(ExMessage.options);

                // For error testing
               //  MainWindow.ErrorDisplayByteArray(can.msg);

            }

            if (ReturnError != 0)
                return false;
            else
                return true;

        } // End Read



        // Checks the flags on transmitted or recieved messages
        private static void CheckFlags(CanData can)
        {
           can.flagString = "";

        } // End CheckFlags
    }
}