/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       BusData.cs
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


// The Kvasier Can Library
using canlibCLSNET;


namespace OpenCarTestbed
{

    // **************
    // class for the BusInterface; enables passing of class to various parts for use
    // **************
    //Written by Chris Everett
    // **************
    public class BusInterface
    {
        private static Dictionary<string, int> interfaces = new Dictionary<string, int>();

        // **************
        //Written by Chris Everett
        // **************
        public static void AddInterface(string businterface, int handle)
        {
            if (interfaces.ContainsKey(businterface))
            {
                //MainWindow.ErrorDisplayString("Businterface already added" + businterface);
                return;
            }
            else
            {
                //MainWindow.ErrorDisplayString("Add Interface - BusInterface: " + businterface + " ; Handle: " + handle);
                interfaces.Add(businterface, handle);
            }
        }

        // **************
        //Written by Chris Everett
        // **************
        public static string[] ReturnInterfaces()
        {
            List<string> interfacesList = new List<string>();

            foreach (var pair in interfaces) 
		        interfacesList.Add(pair.Key);  //add the key of the dictionary to the interfaceList
		        
            return interfacesList.ToArray();
        }

        // **************
        //Written by Chris Everett
        // **************
        public static void AddHandle(string businterface, int handle)
        {
            interfaces.Remove(businterface);
            interfaces.Add(businterface, handle);
            //MainWindow.ErrorDisplayString("Add Handle - BusInterface: " + businterface + " ; Handle: " + handle);
        }

        // **************
        //Written by Chris Everett
        // **************
        public static int ReturnHandle(string businterface)
        {
            if (interfaces.ContainsKey(businterface))
            {
                //MainWindow.ErrorDisplayString("Return Handle - BusInterface: " + businterface + " ; Handle: " + interfaces[businterface]);
                return interfaces[businterface];
            }
            else
                return -1;
         }

        // **************
        //Written by Chris Everett
        // **************
        public static void ResetInterfaces()
        {
            //MainWindow.ErrorDisplayString("Clear interfaces");
            interfaces.Clear();
        }

    } // End of BusInterface Class


    // **************
    // class for the CanData; enables passing of class to various parts for use
    // Includes all available data for access to the CAN bus
    //Written by Chris Everett
    // **************
    public class CanData
    {
        // The status indicator for the Kvasier library
        public Canlib.canStatus status;
        public Canlib.canStatus status1;

        public int id;
        public int dlc;
        public int flags;
        public string flagString;
       // public byte[] msg = { 0, 0, 0, 0, 0, 0, 0, 0 };
        public byte[] msg = new byte[8];
        public long time;
        public int handle;
        public string hardware;
        public bool errorFrame = false;
        public bool bitOutput = false;
        public int number = 1;
        public int timeBtw = 0;
        public bool increment = false;

        // This is the format for the msg
        public string format = "hex";

    }


    // **************
    // class for the LinData; enables passing of class to various parts for use
    // Includes all available data for access to the LIN bus
    // TO BE IMPLEMENTED
    // **************
    public class LinData
    {


    }


    // **************
    // class for the FlexRayData; enables passing of class to various parts for use
    // Includes all available data for access to the FlexRay bus
    // TO BE IMPLEMENTED
    // **************
    public class FlexRayData
    {
    }


}