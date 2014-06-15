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

namespace OpenCarTestbed
{
    public partial class CustomTransmit : Form
    {

        string TransmitFilter = "";

        public CustomTransmit()
        {
            InitializeComponent();
           // UnloadTransmit.Enabled = false;
            LoadListTransmit();
            UpdateInterfaceBox();
        }

        //****************************
        // Update Interface Boxes
        //****************************
        private void UpdateInterfaceBox()
        {
            string bitRate = "-1";

            // Populate the availabe interfaces for transmission/receiving
            string[] interfaces = BusInterface.ReturnInterfaces();

            for (int i = 0; i < interfaces.Length; i++)
            {
                bitRate = GenericCanBus.GenericCanRateReturn(interfaces[i]);

                // Creates the row with the message data and inserts the row in the ListView
                if (bitRate != null && bitRate != "" && bitRate != "0" && bitRate != "-1")
                {
                    TransmitInterfaceBox.Items.Add(interfaces[i]);
                }
            }

            if (TransmitInterfaceBox.Items.Count > 0)
                TransmitInterfaceBox.SelectedIndex = 0;
        }

        // Refreshes the list of available transmission buttons
        private void RefreshTransmit_Click(object sender, EventArgs e)
        {
            LoadListTransmit();
        }


        // Loads the available transmission buttons from the xml file into the transmit listing
        private void LoadListTransmit()
        {
            // Clear any current items
            TransmitList.Items.Clear();

            // returns a string array of the available filter types from the XMLInterfaces
            string[] transmittypes = XMLInterfaces.ReturnTransmitTypes(ConfigFiles.Settings1.Default.filterURI);

            // for each string in the string array an item is added to the filterlist
            if (transmittypes != null)
            {
                for (int x = 0; x < transmittypes.Length; x++)
                {
                    TransmitList.Items.Add(transmittypes[x]);
                }

                toolStripStatusLabel2.Text = "Find Transmit Cars";
            }
        }

        // Loads the selected transmission buttons onto the screen
        private void TransmitList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransmitBox.Columns.Clear();
            TransmitBox.Items.Clear();

            TransmitBox.Columns.Add("Name", 135, HorizontalAlignment.Left);
            TransmitBox.Columns.Add("Packet Type", 85, HorizontalAlignment.Left);

            try
            {
                string[] packets = XMLInterfaces.ReturnPackets(TransmitList.SelectedItem.ToString());

                if (packets.Length != 0)
                {
                    for (int y = 0; y < packets.Length; y++)
                    {
                        string[] output = packets[y].Split(';');
                        ListViewItem item = new ListViewItem(output);
                        TransmitBox.Items.AddRange(new ListViewItem[] { item });
                    }
                }



                // Sets all of the variables for the selected filter
                TransmitFilter = TransmitList.SelectedItem.ToString();
                TransmitLoadLabel.Text = TransmitList.SelectedItem.ToString();

            }
            catch 
            { 
                // No catch needed as no change
            }

        }


        // Loads packet based on user selection
        private void TransmitBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                PacketBox.Clear();

                if (TransmitBox.SelectedItems.Count > 0)
                {
                    packetLabel.Text = TransmitBox.SelectedItems[0].Text;

                    PacketBox.Text = XMLInterfaces.ReturnPacketDataDisplay(TransmitList.SelectedItem.ToString(), TransmitBox.SelectedItems[0].Text);
                }

                        }
            catch 
            { 
                // No catch needed as no change
            }
        }
         

        // Transmits the selected packets
        private void Transmit_Click(object sender, EventArgs e)
        {
            try
            {

                CanData can = new CanData();
                string msgOutput = "";

                // Loop through all items the MonitorBox. 
                for (int x = 0; x < TransmitBox.Items.Count; x++)
                {
                    // Determine if the item is selected. 
                    if (TransmitBox.Items[x].Selected)
                    {
                        can.hardware = TransmitInterfaceBox.SelectedItem.ToString();
                        can.format = "hex";
                        can.flags = 0;
                        int count = 1;

                        // Transmit for simple packets
                        if (TransmitBox.Items[x].SubItems[1].Text.Contains("Packet"))
                        {
                            // return string --> 0=id; 1=dlc; 2=flag; 3=message
                            msgOutput = XMLInterfaces.ReturnPacketDataTransmit(TransmitList.SelectedItem.ToString(), TransmitBox.Items[x].SubItems[0].Text);
                            CommonUtils.ConvertStringtoCAN(can, msgOutput);
                            string[] output = msgOutput.Split(';');

                            if (output[3].Equals("X"))
                                can.flags = 4; // Extended Packet

                            // if packets number or time between is blank then only send one packet
                            if (output[4] == "" || output[5] == "")
                            {
                                GenericCanBus.GenericCanTransmitSingle(can);
                                // Verbose Output
                                if (VerboseTransmit.Checked == true)
                                    MessageBox.Show(CommonUtils.DisplayMsg(can));
                            }
                            else
                            {
                                can.number = Convert.ToInt32(output[4]);
                                can.timeBtw = Convert.ToInt32(output[5]);
                                GenericCanBus.GenericCanTransmitMultiple(can);
                            }

                            // Transmit for Packet Sequences
                        }
                        else if (TransmitBox.Items[x].SubItems[1].Text.Contains("Sequence"))
                        {
                            // for execution once before the while check
                            do
                            {
                                // return string --> 0=id; 1=dlc; 2=flag; 3=message
                                msgOutput = XMLInterfaces.ReturnPacketDataSequence(count, TransmitList.SelectedItem.ToString(), TransmitBox.Items[x].SubItems[0].Text);
                                if (msgOutput.Equals("??")) return;

                                CommonUtils.ConvertStringtoCAN(can, msgOutput);
                                string[] output = msgOutput.Split(';');

                                if (output[3].Equals("X"))
                                    can.flags = 4; // Extended Packet

                                GenericCanBus.GenericCanTransmitSingle(can);

                                count++;

                                // Verbose Output
                                if (VerboseTransmit.Checked == true)
                                    MessageBox.Show(CommonUtils.DisplayMsg(can));

                            } while (msgOutput.Contains(";"));

                        }
                        else if (TransmitBox.Items[x].SubItems[1].Text.Contains("If Then"))
                        {
                            MainWindow.ErrorDisplayString("If Then Clauses are Activated in the Bus Monitor User Interface");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("No interface is turned on, please turn on the interfaces from \"Advanced Bus Control\"");
                this.Close();
                BusControl form = (BusControl)CommonUtils.GetOpenedForm<BusControl>();
                if (form == null)
                {
                    form = new BusControl();
                    form.Show();
                }
                else
                {
                    form.Select();
                }
            }
        }

        private void bgTransmit_DoWork(object sender, DoWorkEventArgs e)
        {
            CanData can = e.Argument as CanData;
            GenericCanBus.GenericCanTransmitSingle(can);
        }

        private void bgMultipleTransmit_DoWork(object sender, DoWorkEventArgs e)
        {
            CanData can = e.Argument as CanData;
            GenericCanBus.GenericCanTransmitMultiple(can);
        }

        

        private void RefreshInterfaces_Click(object sender, EventArgs e)
        {
            UpdateInterfaceBox();
        }






    }
}