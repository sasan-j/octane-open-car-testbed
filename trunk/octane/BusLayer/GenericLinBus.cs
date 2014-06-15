/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       GenericLinBus.cs
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

using canlibCLSNET;

using System.Diagnostics;

namespace OpenCarTestbed
{

    //**************
    // GenericLinBus library
    // Kvasier only now; to implement all LIN adapters into class
    //**************
    public class GenericLinBus
    {
        public static int CAN_handle0;
        public static int CAN_handle1;
        public static int CAN_bitrate0 = Canlib.canBITRATE_500K;

        private static void GenericLinInitilize()
        {
            //Intilize the Kvasier Can Library
            Canlib.canInitializeLibrary();
        }

        // Pulls all of the available adapters for the CAN bus
        public static void DetectLinInterfaces(BusInterface busInterface)
        {
            int nrOfChannels;

            Canlib.canInitializeLibrary();

            //List available channels
            Canlib.canGetNumberOfChannels(out nrOfChannels);
            object o = new object();

            for (int i = 0; i < nrOfChannels; i++)
            {
                Canlib.canGetChannelData(i, Canlib.canCHANNELDATA_CHANNEL_NAME, out o);

                //  Display of data in ListView as follows
                // Network; Type; Mfg; Channel; Status
                BusInterface.AddInterface("CAN" + ";" + o.ToString() + ";" + "Kvasier" + ";" + i + ";" + "Pending", -1);

            }


        }

        public static void GenericLinTransmit(CanData can)
        {
            can.status = Canlib.canWrite(can.handle, can.id, can.msg, can.dlc, can.flags);
        }

        public static bool GenericLinReceive(CanData can)
        {

            Canlib.canStatus status;

            // status = Canlib.canRead(GenericCanBus.CAN_handle0, out can.id, can.msg, out can.dlc, out can.flags, out can.time);

            status = Canlib.canRead(can.handle, out can.id, can.msg, out can.dlc, out can.flags, out can.time);

            //Debug.WriteLine("InRead");
            //MainWindow.ErrorDisplayString(CommonUtils.DisplayMsg(can));

            if (status != Canlib.canStatus.canOK)
            {
                //Debug.WriteLine("CanReceive -- false");
                return false;
            }
            else
            {
                //Debug.WriteLine("CanReceive -- true");
                return true;
            }
        }


    }

}