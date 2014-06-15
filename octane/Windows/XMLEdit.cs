/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       XMLEdit.cs
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
    public partial class XMLEdit : Form
    {
        public XMLEdit()
        {
            InitializeComponent();
        }

        private void XMLEdit_Load(object sender, EventArgs e)
        {
            LoadFilters();
        }

        // Loads the available filters from the xml file into the filter tab listing
        private void LoadFilters()
        {
            // Clear any current items
            FilterList.Items.Clear();

            // returns a string array of the available filter types from the XMLInterfaces
            string[] cartypes = XMLInterfaces.ReturnCarTypes();

            // for each string in the string array an item is added to the filterlist
            if (cartypes != null)
            {
                for (int x = 0; x < cartypes.Length; x++)
                {
                    FilterList.Items.Add(cartypes[x]);
                }

                toolStripStatusLabel1.Text = "Find Filters";
            }
        }

        //// Adds a Vehicle to the XML file
        //private void AddVehicle_Click(object sender, EventArgs e)
        //{
        //    if (vehicle.Text.ToString() == "")
        //    {
        //        MainWindow.ErrorDisplayString("Error Adding Vehicle: no name provided");
        //        return;
        //    }

        //    XMLInterfaces.AddVehicle(vehicle.Text.ToString());
        //    LoadFilters();
        //}

        //// Removes a Vehicle from the XML file
        //private void RemoveVehicle_Click(object sender, EventArgs e)
        //{
        //    if (FilterList.SelectedIndices.Count > 0)
        //    {
        //        foreach (Object selecteditem in FilterList.SelectedItems)
        //        {
        //            XMLInterfaces.DeleteVehicle(selecteditem as String);
        //        }
        //    }
        //    else
        //        MainWindow.ErrorDisplayString("Error Removing Vehicle: no vehicle selected");


        //    LoadFilters();
        //}

        //// Renames Vehicle Name
        //private void RenameVehicle_Click(object sender, EventArgs e)
        //{
            

        //    if (FilterList.SelectedIndices.Count > 0)
        //    {
        //        if (vehicle.Text == "")
        //        {
        //            MessageBox.Show("Please enter the new name for the vehicle");
        //        }
        //        else
        //        {
        //            foreach (Object selecteditem in FilterList.SelectedItems)
        //            {
        //                XMLInterfaces.RenameVehicle(selecteditem as String, vehicle.Text);
        //            }
        //        }
        //    }
        //    else
        //        MainWindow.ErrorDisplayString("Error Renaming Vehicle: no vehicle selected");

        //    LoadFilters();
        //}

        // Enables ECUs of vehicle to be edited
        private void EditVehicle_Click(object sender, EventArgs e)
        {
            if (FilterList.SelectedIndices.Count > 0)
            {
                foreach (Object selecteditem in FilterList.SelectedItems)
                {
                    Windows.XMLEditECU newMDIChild = new Windows.XMLEditECU(selecteditem as String);
                    newMDIChild.MdiParent = MainWindow.ActiveForm;
                    newMDIChild.Show();
                }
            }
            else
                MainWindow.ErrorDisplayString("Error Editing Vehicle: no vehicle selected");
        }

        // Enables Mesages of vehicle to be edited
        private void EditMessage_Click(object sender, EventArgs e)
        {
            if (FilterList.SelectedIndices.Count > 0)
            {
                foreach (Object selecteditem in FilterList.SelectedItems)
                {
                    Windows.XMLEditMessage newMDIChild = new Windows.XMLEditMessage(selecteditem as String);
                    newMDIChild.MdiParent = MainWindow.ActiveForm;
                    newMDIChild.Show();
                }
            }
            else
                MainWindow.ErrorDisplayString("Error Editing Vehicle: no vehicle selected");
        }

        private void button1_Click(object sender, EventArgs e) //edit packets button
        {
            if (FilterList.SelectedIndices.Count > 0)
            {
                foreach (Object selecteditem in FilterList.SelectedItems)
                {
                    Windows.XMLEditMessage newMDIChild = new Windows.XMLEditMessage(selecteditem as String);
                    newMDIChild.MdiParent = MainWindow.ActiveForm;
                    newMDIChild.Show();
                }
            }
            else
                MainWindow.ErrorDisplayString("Error Editing Vehicle: no vehicle selected");
        }

        private void btnEditVehicle_Click(object sender, EventArgs e)
        {
            if (FilterList.SelectedIndices.Count > 0)
            {
                foreach (Object selecteditem in FilterList.SelectedItems)
                {
                    Windows.XMLEditVehicle newMDIChild = new Windows.XMLEditVehicle(selecteditem as String);
                    newMDIChild.MdiParent = MainWindow.ActiveForm;
                    newMDIChild.Show();
                }
            }
            else
                MainWindow.ErrorDisplayString("Error Editing Vehicle: no vehicle selected");
        }

        private void editECUToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
             if (FilterList.SelectedIndices.Count > 0)
            {
                foreach (Object selecteditem in FilterList.SelectedItems)
                {
                    Windows.XMLEditECU newMDIChild = new Windows.XMLEditECU(selecteditem as String);
                    newMDIChild.MdiParent = MainWindow.ActiveForm;
                    newMDIChild.Show();
                }
            }
            else
                MainWindow.ErrorDisplayString("Error Editing Vehicle: no vehicle selected");
          * */
        }

        private void editPacketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
                    {
            if (FilterList.SelectedIndices.Count > 0)
            {
                foreach (Object selecteditem in FilterList.SelectedItems)
                {
                    
                        Windows.XMLEditPackets newMDIChild = new Windows.XMLEditPackets(selecteditem as String);
                        newMDIChild.MdiParent = MainWindow.ActiveForm;
                        newMDIChild.Show();
                    
                }
            }
            else
                MainWindow.ErrorDisplayString("Error Editing Vehicle: no vehicle selected");
                    }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void editVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilterList.SelectedIndices.Count > 0)
            {
                foreach (Object selecteditem in FilterList.SelectedItems)
                {
                    Windows.XMLEditVehicle newMDIChild = new Windows.XMLEditVehicle(selecteditem as String);
                    newMDIChild.MdiParent = MainWindow.ActiveForm;
                    newMDIChild.Show();
                }
            }
            else
                MainWindow.ErrorDisplayString("Error Editing Vehicle: no vehicle selected");
        }
        


    }
}