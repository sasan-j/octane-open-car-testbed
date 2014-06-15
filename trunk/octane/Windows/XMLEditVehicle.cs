/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       XMLEditVehicle.cs
 *  Author:     Autolab-Najafi-Borazjani\pnajafib
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
    public partial class XMLEditVehicle : Form
    {
        public string Vehicle { get; set; }
        public XMLEditVehicle(string vehicle)
        {
            InitializeComponent();
            Vehicle = vehicle;
            this.Text = "Edit XML for Vehicle for " + vehicle;
        }

        private void AddVehicle_Click(object sender, EventArgs e)
        {
            if (vehicle.Text.ToString() == "")
            {
                MainWindow.ErrorDisplayString("Error Adding Vehicle: no name provided");
                return;
            }

            XMLInterfaces.AddVehicle(vehicle.Text.ToString());
            //LoadFilters(); ////***** Must be fixed
        }

        private void RemoveVehicle_Click(object sender, EventArgs e)
        {
                    XMLInterfaces.DeleteVehicle(vehicle.Text);
                    this.Close();
        }

        private void RenameVehicle_Click(object sender, EventArgs e)
        {
            if (vehicle.Text == "")
                {
                    MessageBox.Show("Please enter the new name for the vehicle");
                }
        }
           

            //LoadFilters(); ////*******Must be fixed
        }

      
    }

