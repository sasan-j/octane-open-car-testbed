/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       KvaserCanBus.cs
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


// The Kvasier Can Library
using canlibCLSNET;

using System.Diagnostics;

namespace OpenCarTestbed
{

    public class KvaserWriteCan
    {
        // Not being used since single transmission does not need threading at this time
        /*public void KvaserWrite(CanData can)
        {
           // Canlib.canWrite(can.handle, can.id, can.msg, can.dlc, can.flags);
           // Canlib.canWriteSync(can.handle, 10000);
           Canlib.canWriteWait(can.handle, can.id, can.msg, can.dlc, can.flags,1000);
        }*/

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

    //**************
    // GenericCanBus library
    //**************
    public class KvaserCanBus
    {

        // CAN return rate
        public static string CanRateReturn(string canInterface)
        {
            long bitrate;
            int tseg1;
            int tseg2;
            int sjw;
            int noSamp;
            int syncmode;

            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            Canlib.canGetBusParams(Convert.ToInt32(msgOutput[3]), out bitrate, out tseg1, out tseg2, out sjw, out noSamp, out syncmode);
            return bitrate.ToString();
         
        } // End KvaserCanRateReturn

        // ***************************************
        // DetectCanInterfaces
        // Pulls all of the available adapters for the CAN bus
        // ***************************************
        public static void DetectCanInterfaces()
        {
            // Detect Process for Kvaser CAN devices
            try
            {
                int nrOfChannels;
                object o = new object();

                Canlib.canInitializeLibrary();

                //List available channels
                Canlib.canGetNumberOfChannels(out nrOfChannels);

                for (int i = 0; i < nrOfChannels; i++)
                {
                    Canlib.canGetChannelData(i, Canlib.canCHANNELDATA_CHANNEL_NAME, out o);
                    //  Display of data in ListView as follows
                    // Network; Type; Mfg; Channel; Status; canHandle
                    BusInterface.AddInterface("CAN;" + o.ToString() + ";" + "Kvaser" + ";" + i, -1);
                    ErrorLog.NewLogEntry("CAN", "Detect CAN: " + o.ToString());
                }

            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Adapter", "Kvaser library not found");
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

            int canHandle;
            int channelFlags;
            int KvaserCANBitrate = Canlib.canBITRATE_500K;
            Canlib.canStatus status;

            // Assigns settings for the adapter
            if (bitRateSetting == "1M")
                KvaserCANBitrate = Canlib.canBITRATE_1M;
            else if (bitRateSetting == "500K")
                KvaserCANBitrate = Canlib.canBITRATE_500K;
            else if (bitRateSetting == "250K")
                KvaserCANBitrate = Canlib.canBITRATE_250K;
            else if (bitRateSetting == "125K")
                KvaserCANBitrate = Canlib.canBITRATE_125K;
            else if (bitRateSetting == "100K")
                KvaserCANBitrate = Canlib.canBITRATE_100K;
            else if (bitRateSetting == "62K")
                KvaserCANBitrate = Canlib.canBITRATE_62K;
            else if (bitRateSetting == "50K")
                KvaserCANBitrate = Canlib.canBITRATE_50K;
            else if (bitRateSetting == "33K")
                KvaserCANBitrate = 33000;

            // Checks for Virtual Flag
            if (msgOutput[1].IndexOf("Virtual") != -1)
                channelFlags = Canlib.canOPEN_ACCEPT_VIRTUAL;
            else
                channelFlags = 0;

            // Opens CAN channel
            canHandle = Canlib.canOpenChannel(Convert.ToInt32(msgOutput[3]), channelFlags);
          
            // Sets parameters for the CAN channel; special parameters for 33K, single-wire operation
            if (bitRateSetting == "33K")
                status = Canlib.canSetBusParams(canHandle, 33000, 5, 2, 2, 1, 0);
            else
                // Standard settings for other operations
                status = Canlib.canSetBusParams(canHandle, KvaserCANBitrate, 0, 0, 0, 0, 0);

            if (status < 0)
            {
                ErrorLog.NewLogEntry("CAN", "Kvaser bus setting parameters failed: " + KvaserCANBitrate);
                return -1;
            }
            else
                ErrorLog.NewLogEntry("CAN", "Kvaser bus setting parameters success: " + KvaserCANBitrate);

            // possible configuration for 33K single-wire operation; above settings work
            //Canlib.canSetBusParamsC200(canHandle, 0x5D, 0x05);

            status = Canlib.canBusOn(canHandle);
            if (status < 0)
            {
                ErrorLog.NewLogEntry("CAN", "Bus On Failed: " + msgOutput[1]);
                return -1;
            }
            else
                ErrorLog.NewLogEntry("CAN", "Bus On Success: " + msgOutput[1]);
                
            // Associates the int holder for the Kvaser interface back with the interface dictionary structure
            BusInterface.AddHandle(canInterface, canHandle);

            //MainWindow.ErrorDisplayString("Bus On - BusInterface: " + canInterface + " ; Handle: " + canHandle);

            return 1;
        }

        // **********************
        // Turns canInterface off
        // **********************
        public static void CanBusOff(string canInterface)
        {
            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            Canlib.canStatus status;
           // MainWindow.ErrorDisplayString("Bus Off - BusInterface: " + canInterface + " ; Handle: " + BusInterface.ReturnHandle(canInterface));
           // Canlib.canClose(BusInterface.ReturnHandle(canInterface));
           // status = Canlib.canBusOff(BusInterface.ReturnHandle(canInterface));
   
            Canlib.canClose(Convert.ToInt32(msgOutput[3]));
            status = Canlib.canBusOff(Convert.ToInt32(msgOutput[3]));

            if (status < 0)
                ErrorLog.NewLogEntry("CAN", "Bus Off Failed: " + msgOutput[1]);
            else
                ErrorLog.NewLogEntry("CAN", "Bus Off Success: " + msgOutput[1]);
        }

        //************************************
        // CAN Transmit for a single transmission
        //************************************
        public static void CanTransmitSingle(CanData can)
        {
            string hardwareString0 = can.hardware.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            can.handle = BusInterface.ReturnHandle(can.hardware);
                
            // Threading Part
            /*CanWrite writeCan = new CanWrite();

            // Starts the Kvaser threading
            Thread t2 = new Thread(delegate()
            {
                writeCan.KvaserWrite(can);
            });
            t2.Start();
                */

            // Non-threading write option
            Canlib.canWriteWait(can.handle, can.id, can.msg, can.dlc, can.flags, 1000);
            CheckFlags(can);

        } // End GenericCanTransmitSingle

        //************************************
        // CAN Transmit for multiple transmissions
        //************************************
        public static void CanTransmitMultiple(CanData can)
        {
            can.handle = BusInterface.ReturnHandle(can.hardware);
            KvaserWriteCan writeCan = new KvaserWriteCan();

            Thread t2 = new Thread(delegate()
            {
                writeCan.KvaserWriteMultiple(can);
            });
            t2.IsBackground = true;
            t2.Start();

        }  // End GenericCanTransmitMultiple


        // CAN Receive
        public static bool CanReceive(CanData can)
        {
           // string hardwareString0 = can.hardware.Replace(" ", "");
           // string[] msgOutput = hardwareString0.Split(';');

            // to pull the can.handle from the hardware selection
            can.handle = BusInterface.ReturnHandle(can.hardware);
            //MainWindow.ErrorDisplayString("can.handle: " + can.handle + " ; msg: " + msgOutput[3]);

            // Kvaser CAN Read
            Array.Clear(can.msg, 0, 8);
            can.status = Canlib.canRead(can.handle, out can.id, can.msg, out can.dlc, out can.flags, out can.time);
            // MainWindow.ErrorDisplayString("can.handle in receive: " + can.handle);
            CheckFlags(can);

            if (can.status != Canlib.canStatus.canOK)
                return false;
            else
                return true;

        } // End Read



        // Checks the flags on transmitted or recieved messages
        private static void CheckFlags(CanData can)
        {
           can.flagString = "";

           if (can.hardware.IndexOf("Kvaser") != -1)
           {
               if ((can.flags & Canlib.canMSG_ERROR_FRAME) == Canlib.canMSG_ERROR_FRAME)
               {
                   can.errorFrame = true;
                   can.flagString += "E";
               } 
               else if ((can.flags & Canlib.canMSG_EXT) == Canlib.canMSG_EXT)
                   can.flagString += "X";
               else if ((can.flags & Canlib.canMSG_RTR) == Canlib.canMSG_RTR)
                   can.flagString += "R";
               else if ((can.flags & Canlib.canMSG_TXACK) == Canlib.canMSG_TXACK)
                   can.flagString += "A";
               else if ((can.flags & Canlib.canMSG_WAKEUP) == Canlib.canMSG_WAKEUP)
                   can.flagString += "W";
           }
        } // End CheckFlags
    }
}