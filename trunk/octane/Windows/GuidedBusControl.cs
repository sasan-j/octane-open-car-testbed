/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       CustomTransmit.cs
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenCarTestbed.Windows
{
    public partial class GuidedBusControl : Form
    {

        // For the use case numbering
        private enum GuidedUseCaseEnum { None, Virtual, Restart, ECom, ValueCAN};
        private int GuidedUseCaseDetected = -1;


        public GuidedBusControl()
        {
            InitializeComponent();

            CheckAvailableInterfaces();
        }

        private void ExitGuide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        // Restart the Guided Setup Process
        private void RestartGuide_Click(object sender, EventArgs e)
        {
            CheckAvailableInterfaces();
        }

        // The beginning of the Guided Interface Process
        private void CheckAvailableInterfaces()
        {

            // Reset Interfaces in Bus Intefaces
            BusInterface.ResetInterfaces();

            GenericCanBus.DetectCanInterfaces();

            // Returns the interfaces
            string[] interfaces = BusInterface.ReturnInterfaces();

            //*******************************
            // Steps through common use cases

            // Check to see if there are no interfaces
            if (interfaces.Length < 1)
            {
                guidedStatusBox.Text = "No Interfaces Detected";
                guidedActionBox.Text = "Please Connect Interfaces and Restart Guide";
                GuidedUseCaseDetected = (int)GuidedUseCaseEnum.Restart;
                return;

            }

            // Checks for use case of the 2 Kvaser Virtual Interfaces
            if (interfaces.Length == 2)
            {
                string bitRate0 = GenericCanBus.GenericCanRateReturn(interfaces[0]);
                string bitRate1 = GenericCanBus.GenericCanRateReturn(interfaces[1]);

                // NEED TO ADD BITRATE CHECK HERE
                //     if (bitRate != null && bitRate != "" && bitRate != "0" && bitRate != "-1")

                // Check to ensure that the two interfaces are virtual interfaces
                if (interfaces[0].IndexOf("Virtual") != -1 && interfaces[1].IndexOf("Virtual") != -1)
                {
                    guidedStatusBox.Text = "Detected Two Kvaser Virtual Interfaces \nNo Hardware Interfaces Detected\n";
                    guidedActionBox.Text = "Enable the Two Kvaser Virtual Interfaces for Testing Purposes";
                    GuidedUseCaseDetected = (int)GuidedUseCaseEnum.Virtual;
                    return;
                }

                //add our own interface here
            }
            
            if (interfaces.Length > 1)
            {
                for (int i = 0; i < interfaces.Length; i++)
                {
                    if (interfaces[i].IndexOf("ECom") != -1)
                    {
                        guidedStatusBox.Text = "Detected ECOM CanCapture Cable\n";
                        guidedActionBox.Text = "Enable the ECOM Cable at 500k bit rate";
                        GuidedUseCaseDetected = (int)GuidedUseCaseEnum.ECom;
                        return;
                    }

                }
            }

            if (interfaces.Length > 1)
            {
                for (int i = 0; i < interfaces.Length; i++)
                {
                    if (interfaces[i].IndexOf("ValueCAN") != -1)
                    {
                        guidedStatusBox.Text = "Detected Intrepid ValueCAN Cable\n";
                        guidedActionBox.Text = "Enable the ValueCAN Cable at 500k bit rate";
                        GuidedUseCaseDetected = (int)GuidedUseCaseEnum.ValueCAN;
                        return;
                    }

                }
            }


            // Default action if nothing is detected
            guidedStatusBox.Text = "Unable to Detect Any Guided Use Cases";
            guidedActionBox.Text = "Please use the Advanced Bus Control";
            GuidedUseCaseDetected = (int)GuidedUseCaseEnum.None;

        }
       
        // Handles the Suggested Action
        private void takeAction_Click(object sender, EventArgs e)
        {
           
            if (GuidedUseCaseDetected == (int)GuidedUseCaseEnum.Restart)
            {
                CheckAvailableInterfaces();
            }
            else if (GuidedUseCaseDetected == (int)GuidedUseCaseEnum.None)
            {
                this.Close();
            }
            else if (GuidedUseCaseDetected == (int)GuidedUseCaseEnum.Virtual)
            {
                StartVirtualInterfaces();
            }
            else if (GuidedUseCaseDetected == (int)GuidedUseCaseEnum.ECom)
            {
                StartEComInterface();
            }
            else if (GuidedUseCaseDetected == (int)GuidedUseCaseEnum.ValueCAN)
            {
                StartValueCANInterface();
            }
            // Default - no action can be taken
            else
            {
                MainWindow.ErrorDisplayString("Error: No Action Can be Taken at This Time");
            }
        }

        //******************
        // Use Case Actions are provided below
        //******************

        // Starts the two Kvaser virtual interfaces
        private void StartVirtualInterfaces()
        {

            string[] interfaces = BusInterface.ReturnInterfaces();

            int status0 = GenericCanBus.GenericCanBusOn(interfaces[0], "500K");
            int status1 = GenericCanBus.GenericCanBusOn(interfaces[1], "500K");

            if (status0 == 1 && status1 == 1)
            {
                guidedStatusBox.Text = "Success: Virtual Interfaces are On\nVirtual Interface 1 started at "
                 + GenericCanBus.GenericCanRateReturn(interfaces[0])
                 + "\nVirtual Interface 2 started at "
                 + GenericCanBus.GenericCanRateReturn(interfaces[1]);
                guidedActionBox.Text = "";
                ErrorLog.NewLogEntry("CAN", "Virtual Interfaces in Guided Setup Started");
            }
            else
            {
                guidedStatusBox.Text = "Error Starting the Virtual Interfaces";
                ErrorLog.NewLogEntry("CAN", "Error Starting the Virtual Interfaces in Guided Setup");
            }

        }

        // Starts the ECom interface at 500k
        private void StartEComInterface()
        {
            string[] interfaces = BusInterface.ReturnInterfaces();

            for (int i = 0; i < interfaces.Length; i++)
            {
                if (interfaces[i].IndexOf("ECom") != -1)
                {
                    int status = GenericCanBus.GenericCanBusOn(interfaces[i], "500K");

                    if (status == 1)
                    {
                        guidedStatusBox.Text = "Success: ECom Interface is On\nECom adapter will not return bitrate";
                        guidedActionBox.Text = "";
                        ErrorLog.NewLogEntry("CAN", "ECom Interface in Guided Setup Started");
                    }
                    else
                    {
                        guidedStatusBox.Text = "Error Starting the ECom Interface";
                        ErrorLog.NewLogEntry("CAN", "Error Starting the ECom Interface in Guided Setup");
                    }
                }
            }
        }

        // Starts the Intrepid ValueCAN interface at 500k
        private void StartValueCANInterface()
        {
            string[] interfaces = BusInterface.ReturnInterfaces();

            for (int i = 0; i < interfaces.Length; i++)
            {
                if (interfaces[i].IndexOf("ValueCAN") != -1)
                {
                    int status = GenericCanBus.GenericCanBusOn(interfaces[i], "500K");

                    if (status == 1)
                    {
                        guidedStatusBox.Text = "Success: ValueCAN Interface is On\nValueCAN Interface started at "
                        + GenericCanBus.GenericCanRateReturn(interfaces[0]);
                        guidedActionBox.Text = "";
                        ErrorLog.NewLogEntry("CAN", "ValueCAN in Guided Setup Started");
                    }
                    else
                    {
                        guidedStatusBox.Text = "Error Starting the ValueCAN Interface";
                        ErrorLog.NewLogEntry("CAN", "Error Starting the ValueCAN Interface in Guided Setup");
                    }
                }
            }
        }
    }
}
