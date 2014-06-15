/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       BusControl.cs
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

namespace OpenCarTestbed
{
    public partial class BusControl : Form
    {

        public BusControl()
        {
            InitializeComponent();

            //StatusBox.Text = "No Status";

            // Loads the available interfaces into the ListBox
            LoadInterfaces();

            this.timerRefresh.Start();

            if (ConfigFiles.Settings1.Default.skipGuidedBusControl == true)
                advancedBusControl.Checked = true;
            else
                advancedBusControl.Checked = false;
        }


        //******************
        // Refresh Interfaces -- This refreshes the available interfaces on the system
        //******************
        private void RefreshInterfaces_Click(object sender, EventArgs e)
        {
            LoadInterfaces();
        }

        //******************
        // Load Interfaces -- This loads the selected interfaces on the machine into the interfacebox
        //******************
        private void LoadInterfaces()
        {
            string bitRate = null;
            string displayRow;

            // Sets up the multi-column box
            InterfaceBox.Items.Clear();
            InterfaceBox.Columns.Clear();
            InterfaceBox.Columns.Add("Network", 55, HorizontalAlignment.Left);
            InterfaceBox.Columns.Add("Type", 155, HorizontalAlignment.Left);
            InterfaceBox.Columns.Add("Mfg", 85, HorizontalAlignment.Left);
            InterfaceBox.Columns.Add("Channel", 35, HorizontalAlignment.Left);
            InterfaceBox.Columns.Add("BitRate", 55, HorizontalAlignment.Left);
            InterfaceBox.Columns.Add("Status", 75, HorizontalAlignment.Right);

            // Reset Interfaces in Bus Intefaces
           // BusInterface.ResetInterfaces();

            GenericCanBus.DetectCanInterfaces();

            // Find all of the LIN bus interfaces and adds to the list in busInterface   
            // GenericLinBus.DetectLinInterfaces();

            // Find all of the FlexRay bus interfaces and adds to the list in busInterface
            // GenericFlexRayBus.DetectFlexRayInterfaces();
            
            // Returns the interfaces 
            string[] interfaces = BusInterface.ReturnInterfaces();

            for (int i = 0; i < interfaces.Length; i++)
            {
                bitRate = GenericCanBus.GenericCanRateReturn(interfaces[i]);

                // Creates the row with the message data and inserts the row in the ListView
                
                if (bitRate == null || bitRate == "" || bitRate == "0")
                    displayRow = ";NA;Bus Off";
                else
                    displayRow = ";" + bitRate + ";Bus On";

                ListViewItem item = new ListViewItem(CommonUtils.ConvertStringtoStringArray(interfaces[i] + displayRow));
                InterfaceBox.Items.AddRange(new ListViewItem[] { item });
            }

        }

        // Turns on the selected busses
        private void BusOn_Click(object sender, EventArgs e)
        {
            string bitRateSetting;

            if (standardRate1M.Checked)
                bitRateSetting = "1M";
            else if (standardRate500K.Checked)
                bitRateSetting = "500K";
            else if (standardRate250K.Checked)
                bitRateSetting = "250K";
            else if (standardRate125K.Checked)
                bitRateSetting = "125K";
            else if (standardRate100K.Checked)
                bitRateSetting = "100K";
            else if (standardRate62K.Checked)
                bitRateSetting = "62K";
            else if (standardRate50K.Checked)
                bitRateSetting = "50K";
            else if (standardRate33K.Checked)
                bitRateSetting = "33K";
            else
                bitRateSetting = "NA";

            if (customRate.Checked)
            {
                MainWindow.ErrorDisplayString("Custom Settings Not Yet Implemented");
                return;
            }

            // Ensures that something is detected for turning on the interface
            if (InterfaceBox.SelectedIndices.Count > 0)
            {
                ListViewItem item = InterfaceBox.SelectedItems[0];

                // Loops through all of the Items to detect all of the selected itmes
                for (int x = 0; x < InterfaceBox.Items.Count; x++)
                {
                    // If the item is selected then turn on the interface
                    if (InterfaceBox.Items[x].Selected)
                    {
                        if (InterfaceBox.Items[x].SubItems[5].Text != "Bus On")
                        {
                            int status = GenericCanBus.GenericCanBusOn(InterfaceBox.Items[x].SubItems[0].Text + ";" +
                              InterfaceBox.Items[x].SubItems[1].Text + ";" +
                              InterfaceBox.Items[x].SubItems[2].Text + ";" +
                              InterfaceBox.Items[x].SubItems[3].Text,
                              bitRateSetting);

                            // REVISIONS -- Error with returning the data rate for the adapters
                            // This populates the data rate for the adapter
                            InterfaceBox.Items[x].SubItems[4].Text = GenericCanBus.GenericCanRateReturn(InterfaceBox.Items[x].SubItems[0].Text + ";" +
                              InterfaceBox.Items[x].SubItems[1].Text + ";" +
                              InterfaceBox.Items[x].SubItems[2].Text + ";" +
                              InterfaceBox.Items[x].SubItems[3].Text);

                            if (status == 1)
                            {
                                InterfaceBox.Items[x].SubItems[5].Text = "Bus On";
                            }
                        }
                        else
                            MainWindow.ErrorDisplayString("Bus Already On: " + InterfaceBox.Items[x].SubItems[1].Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("One of the items should be selected!");
            }
        }

        // Turns off the selected busses
        private void BusOff_Click(object sender, EventArgs e)
        {
            // Ensures that something is detected for turning on the interface
            if (InterfaceBox.SelectedIndices.Count > 0)
            {
                ListViewItem item = InterfaceBox.SelectedItems[0];

                // Loops through all of the Items to detect all of the selected itmes
                for (int x = 0; x < InterfaceBox.Items.Count; x++)
                {
                    // If the item is selected then turn on the interface
                    if (InterfaceBox.Items[x].Selected)
                    {
                        if (InterfaceBox.Items[x].SubItems[5].Text == "Bus On")
                        {
                            GenericCanBus.GenericCanBusOff(InterfaceBox.Items[x].SubItems[0].Text + ";" +
                              InterfaceBox.Items[x].SubItems[1].Text + ";" +
                              InterfaceBox.Items[x].SubItems[2].Text + ";" +
                              InterfaceBox.Items[x].SubItems[3].Text);

                            string bitRate = GenericCanBus.GenericCanRateReturn(InterfaceBox.Items[x].SubItems[0].Text + ";" +
                              InterfaceBox.Items[x].SubItems[1].Text + ";" +
                              InterfaceBox.Items[x].SubItems[2].Text + ";" +
                              InterfaceBox.Items[x].SubItems[3].Text);

                            if (bitRate == null || bitRate == "" || bitRate == "0")
                            {
                                InterfaceBox.Items[x].SubItems[4].Text = "NA";
                                InterfaceBox.Items[x].SubItems[5].Text = "Bus Off";
                            }
                            else
                            {
                                InterfaceBox.Items[x].SubItems[4].Text = bitRate;
                                InterfaceBox.Items[x].SubItems[5].Text = "Bus On";
                            }
                        }
                        else
                            MainWindow.ErrorDisplayString("Bus Not On: " + InterfaceBox.Items[x].SubItems[1].Text);
                    }
                }
            }
            else 
            {
                MessageBox.Show("One of the items should be selected!");
            }
        }

        private void BusControl_Load(object sender, EventArgs e)
        {
            filterLocation.Text = ConfigFiles.Settings1.Default.filterURI;
        }

        private void BusControl_Activated(object sender, System.EventArgs e)
        {
            LoadInterfaces();
        }


       /* private void saveSettings_Click(object sender, EventArgs e)
        {
            ConfigFiles.Settings1.Default.filterURI = filterLocation.Text;
            ConfigFiles.Settings1.Default.Save();
        }
        */

        private void editFilter_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

          //  openFileDialog1.InitialDirectory = "c:\\";
          //  openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.InitialDirectory = ConfigFiles.Settings1.Default.filterURI;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Select an xml file";
            openFileDialog1.ShowDialog();

            // For display in the form control
            filterLocation.Text = openFileDialog1.FileName;

            // Automatically saves the setting
            ConfigFiles.Settings1.Default.filterURI = openFileDialog1.FileName;
            ConfigFiles.Settings1.Default.Save();
        }

        private void XMLFilter_Click(object sender, EventArgs e)
        {
            
        }

        // sets configuration when the user changes checkbox for guided bus control
        private void advancedBusControl_CheckedChanged(object sender, EventArgs e)
        {
            if (advancedBusControl.Checked == true)
            {
                ConfigFiles.Settings1.Default.skipGuidedBusControl = true;
                ConfigFiles.Settings1.Default.Save();
            }
            else
            {
                ConfigFiles.Settings1.Default.skipGuidedBusControl = false;
                ConfigFiles.Settings1.Default.Save();
            }
        }

        // The worker thread for the backgroundWorker
        private void backgroundWorkerRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            MainWindow.ErrorDisplayString("In Background Worker");
            LoadInterfaces();  
            System.Threading.Thread.Sleep(10);
        }

        // Timer to refresh the display
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadInterfaces();
        }

    }
}