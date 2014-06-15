/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       GenericCanBus.cs
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
    //**************
    // GenericCanBus library
    //**************
    public class GenericCanBus
    {
        // ***************************************
        // CAN return rate
        // ***************************************
        public static string GenericCanRateReturn(string canInterface)
        {

            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            // Kvaser can return
            if (msgOutput[2] == "Kvaser")
            {
                return KvaserCanBus.CanRateReturn(canInterface);
            } else if (msgOutput[2] == "ECom")
            {
                return ECOMCanBus.CanRateReturn(canInterface);
            }

            return null;
        } // End GenericCanRateReturn

        // ***************************************
        // DetectCanInterfaces
        // Pulls all of the available adapters for the CAN bus
        // ***************************************
        public static void DetectCanInterfaces()
        {
            try
            {
                KvaserCanBus.DetectCanInterfaces();
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Adapter", "Kvaser library not found");
            }

            try
            {
                IntrepidCanBus.DetectCanInterfaces();
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Adapter", "Intrepid library not found");
            }

            try
            {
                ECOMCanBus.DetectCanInterfaces();
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
        public static int GenericCanBusOn(string canInterface, string bitRateSetting)
        {
            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            if (msgOutput[2] == "Kvaser"){
                return KvaserCanBus.CanBusOn(canInterface, bitRateSetting);
            } else if (msgOutput[2] == "ECom"){
                return ECOMCanBus.CanBusOn(canInterface, bitRateSetting);
            } else if (msgOutput[2] == "Intrepid"){
                return IntrepidCanBus.CanBusOn(canInterface, bitRateSetting);
            }

            return -1;
        }

        // **********************
        // Turns canInterface off
        // **********************
        public static void GenericCanBusOff(string canInterface)
        {
            string hardwareString0 = canInterface.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            if (msgOutput[2] == "Kvaser"){
                KvaserCanBus.CanBusOff(canInterface);
            } else if (msgOutput[2] == "ECom") {
                ECOMCanBus.CanBusOff(canInterface);
            } else if (msgOutput[2] == "Intrepid") {
                IntrepidCanBus.CanBusOff(canInterface);
            }
        }

        //************************************
        // CAN Transmit for a single transmission
        //************************************
        public static void GenericCanTransmitSingle(CanData can)
        {
            string hardwareString0 = can.hardware.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            if (msgOutput[2] == "Kvaser") {
                KvaserCanBus.CanTransmitSingle(can);
            } else if (msgOutput[2] == "ECom") {
                ECOMCanBus.CanTransmitSingle(can);
            } else if (msgOutput[2] == "Intrepid"){
                IntrepidCanBus.CanTransmitSingle(can);
            }

        } // End GenericCanTransmitSingle

        // CAN Transmit for multiple transmissions
        public static void GenericCanTransmitMultiple(CanData can)
        {
                string hardwareString0 = can.hardware.Replace(" ", "");
                string[] msgOutput = hardwareString0.Split(';');

                if (msgOutput[2] == "Kvaser")
                {
                    KvaserCanBus.CanTransmitMultiple(can);
                }
                else if (msgOutput[2] == "ECom")
                {
                    ECOMCanBus.CanTransmitMultiple(can);
                }
                else if (msgOutput[2] == "Intrepid")
                {
                    IntrepidCanBus.CanTransmitMultiple(can);
                }
           

        }  // End GenericCanTransmitMultiple

        // CAN Receive
        public static bool GenericCanReceive(CanData can)
        {
            string hardwareString0 = can.hardware.Replace(" ", "");
            string[] msgOutput = hardwareString0.Split(';');

            // Kvaser receive section
            if (msgOutput[2] == "Kvaser") {
                return KvaserCanBus.CanReceive(can);
            } else if (msgOutput[2] == "ECom") {
                return ECOMCanBus.CanReceive(can);
            }

            return false;

        } // End Read

    }
}