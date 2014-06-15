/* 
 * 
 * 
 * ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       BusMonitor-Column.cs
 *  Author:     autolab-everett\ceveret3--Autolab-Najafi-Borazjani\pnajafib
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
using System.Threading;
using System.Collections;
using OpenCarTestbed.Common;
using System.Xml;
using System.Text.RegularExpressions;


namespace OpenCarTestbed
{
    //Written by Chris Everett and Parnian Najafi Borazjani
    public partial class BusMonitorColumn : Form
    {
        bool TesterPresent = false;
        bool IfThenActive = false;
        string CarFilter = "";
        List<ListViewItem> filterItems = null;
        public string IdentifiedPacketName{get;set;}
        public string IdentifiedId { get; set; }
        public string IdentifiedMessage { get; set; }

        public string FormId
        {
            get { return "1"; }
        }

        public BusMonitorColumn()
        {
            InitializeComponent();

            IfThenActivateButton.Enabled = false;
            //IfThenActivateButton.BackColor = Color.Transparent;

            // Loads the filters in the IDFilter.xml file -// Loads the available filters from the xml file into the filter tab listing
            LoadFilters();

            // unchecked until a filter is loaded
            UnloadFilter.Enabled = true;

            UpdateInterfaceBox(); //Populate the availabe interfaces for transmission/receiving
            StopMonitor2.Enabled = false;

            // Enable progress reporting
            backgroundWorkerRead.WorkerReportsProgress = true;

            // Hook up event handlers
            backgroundWorkerRead.DoWork += backgroundWorkerRead_DoWork;
            backgroundWorkerRead.RunWorkerCompleted += backgroundWorkerRead_RunWorkerCompleted;
            backgroundWorkerRead.ProgressChanged += backgroundWorkerRead_ProgressChanged;
            backgroundWorkerRead.WorkerReportsProgress = true;
            // Sets up the multi-column box
            MonitorBox.Columns.Clear();

            // Setups up the columns for the MonitorBox
            MonitorBox.Columns.Add("Packet", 85, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("Identity No.", 85, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("ECU ID", 85, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("ECU", 60, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("Priority", 60, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("DLC", 35, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("Flags", 55, HorizontalAlignment.Left);
          // MonitorBox.Columns.Add("Data ID", 65, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("Data 0........................7", 180, HorizontalAlignment.Center);
           // MonitorBox.Columns.Add("Type", 45, HorizontalAlignment.Left);
            MonitorBox.Columns.Add("Time", 65, HorizontalAlignment.Left);
            filterItems = new List<ListViewItem>();
        }

        //****************************
        // Update Interface Boxes
        // Written by Chris Everett
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
                    // Creates the item for combobox
                    ReceiveInterfaceBox.Items.Add(interfaces[i]);
                    TransmitInterfaceBox.Items.Add(interfaces[i]);
                }
            }

            // Sets up the Virtual Interfaces for Transmit and Receive without User Intervention
            if (interfaces.Length == 2 && interfaces[0].IndexOf("Virtual") != -1 && interfaces[1].IndexOf("Virtual") != -1)
            {
                if (ReceiveInterfaceBox.Items.Count >= 2)
                    ReceiveInterfaceBox.SelectedIndex = 1;

                if (TransmitInterfaceBox.Items.Count >= 2)
                    TransmitInterfaceBox.SelectedIndex = 0;
            }
            // Standard Case making the first interface the selected interface
            else
            {
                if (ReceiveInterfaceBox.Items.Count > 0)
                    ReceiveInterfaceBox.SelectedIndex = 0;

                if (TransmitInterfaceBox.Items.Count > 0)
                    TransmitInterfaceBox.SelectedIndex = 0;
            }
        }


       

        //****************************
        // Monitor Bus Tab
        //Written by Chris Everett and Parnian Najafi Borazjani
        //****************************
        private void MonitorBus2_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel2.Text = "Monitor Bus On";
                //ReceiveStop = true;     

                // Assume decimal if is not checked
                string format;
                if (Monitor_Hex.Checked == true)
                    format = "hex";
                else
                    format = "decimal";

                // the arguments for the backgroundWorkerRead worker
                string[] arguments = { ReceiveInterfaceBox.SelectedItem.ToString(), format, CarFilter, Convert.ToString(numericMSB.Value), TransmitInterfaceBox.SelectedItem.ToString() };
                if (backgroundWorkerRead.IsBusy != true)
                {
                    backgroundWorkerRead.RunWorkerAsync(arguments);
                    MonitorBus2.Enabled = false;
                    StopMonitor2.Enabled = true;
                    ErrorLog.NewLogEntry("CAN", "Monitor Bus On");
                }
                else
                {
                    ErrorLog.NewLogEntry("CAN", "Monitor Bus - Background Worker Busy");
                }
            }
            catch
            {
                MessageBox.Show("No interface is turned on, please turn on the interfaces from \"Advanced Bus Control\" window");
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

        //********************************************************************************
        //check the existing monitor bus items and identify packets in the existing list
        //Witten by Parnian Najafi Borazjani
        //********************************************************************************
        public void LoopToIdentify()
        {
            foreach (ListViewItem item in MonitorBox.Items)
                if (item.SubItems[(int)CommonUtils.BusFields.IdNo].Text == IdentifiedId && (item.SubItems[(int)CommonUtils.BusFields.Data].Text).Replace(" ", "") == IdentifiedMessage)
                    item.SubItems[(int)CommonUtils.BusFields.Packet].Text = IdentifiedPacketName; //adding the packet name to the existing items in monitor bus
        }
        //*******************************************
        // The worker thread for the backgroundWorker
        //*******************************************
        private void backgroundWorkerRead_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            CanData receiveCan = new CanData();
            CanData transmitCan = new CanData();
            string[] arguments = (string[])e.Argument;

            // to get the receive interface
            receiveCan.hardware = arguments[0];
            receiveCan.format = arguments[1];

            // to get the transmit interface
            transmitCan.hardware = arguments[4];
            transmitCan.format = arguments[1];

            string CarFilter = arguments[2];
            int numericMSB = int.Parse(arguments[3]);
            string ifThenOutput = null;

            while (true)
            {
                if (GenericCanBus.GenericCanReceive(receiveCan) == true)
                {
                    count++; //counts the number of packets received
                    (sender as BackgroundWorker).ReportProgress(count, CommonUtils.ConvertMsgArray(receiveCan, CarFilter, numericMSB));

                    if (IfThenActive)
                    {
                        //   ifThenOutput = ifthenxml.UpdateIfThenMachine(receiveCan, CarFilter);

                        if (ifThenOutput != null)
                        {
                            CommonUtils.ConvertStringtoCAN(transmitCan, ifThenOutput);
                            GenericCanBus.GenericCanTransmitSingle(transmitCan);
                        }
                    }
                }

                // Higher sleep times may cause packet lose; more testing needed - CEE
                System.Threading.Thread.Sleep(80);

                if ((sender as BackgroundWorker).CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }




            
                //while (GenericCanBus.GenericCanReceive(receiveCan))
                //{
                //    count++; //counts the number of packets received
                //    (sender as BackgroundWorker).ReportProgress(count, CommonUtils.ConvertMsgArray(receiveCan, CarFilter, numericMSB));
                //    System.Threading.Thread.Sleep(220);
                //    if (IfThenActive)
                //    {
                //        //   ifThenOutput = ifthenxml.UpdateIfThenMachine(receiveCan, CarFilter);

                //        if (ifThenOutput != null)
                //        {
                //            CommonUtils.ConvertStringtoCAN(transmitCan, ifThenOutput);
                //            GenericCanBus.GenericCanTransmitSingle(transmitCan);
                //        }
                //    }
                //}

                

                //if ((sender as BackgroundWorker).CancellationPending)
                //{
                //    e.Cancel = true;
                //    //break;
                //}
            






        }
       
        //*********************************************
        // The progress ender for the backgroundWorker
        //Written by Chris Everett and Parnian Najafi Borazjani
        //*********************************************
        private void backgroundWorkerRead_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerRead.CancelAsync();
            MonitorBus2.Enabled = true;
            StopMonitor2.Enabled = false;

            if (e.Cancelled)
                ErrorLog.NewLogEntry("CAN", "Monitor Bus - Background Worker Cancelled");
        }
        
        // The progress updater for the backgroundWorker
       
        private void backgroundWorkerRead_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            string[] msgInput = (string[])e.UserState;
            if (!string.IsNullOrEmpty(IdentifiedPacketName) && IdentifiedId == msgInput[1] && IdentifiedMessage == (msgInput[7]).Replace(" ", "")) //spaces are removed
            {
                
                msgInput[0] = IdentifiedPacketName; //identify packet names
            }
            // added for having filter affect while the messages enter
            List<ListViewItem> filterResult = new List<ListViewItem>();
            if (filterFlag == true && msgInput != null)
            {
                ListView arrivedListview = new ListView();
                arrivedListview.Items.Add(new ListViewItem(msgInput));
                ListView.ListViewItemCollection lviCollection = new ListView.ListViewItemCollection(arrivedListview);
                filterResult = ProcessFilter(lviCollection);
                if (filterResult == null) // if there is nothing to filter add the arrived item to our main list (filterItems)
                {
                    filterItems.Add(arrivedListview.Items[0]);    
                }
            }
            if (msgInput != null)
            {
                if (viewLimit.Checked)
                {
                    if (MonitorBox.Items.Count > Convert.ToInt32(numericLimit.Value) && filterResult.Count > 0)
                        MonitorBox.Items.RemoveAt(0);
                }
                if (filterFlag) //if the filter is selected
                {
                    foreach (ListViewItem item in filterResult)
                    {
                        MonitorBox.Items.Add(item.Clone() as ListViewItem); //cloned because it did not allow using the same object twice in differed places
                     
                    }
                    
                    if (highlightFlag)
                        ProcessHighlight(highlightFlag, MonitorBox.Items);
                }
                else
                {
                    MonitorBox.Items.Add(new ListViewItem(msgInput));
                    ProcessHighlight(highlightFlag, MonitorBox.Items);
                }
            }
            ReceiveCount.Text = e.ProgressPercentage.ToString();
        }

        //*********************************************
        // Look for dynamic packets 
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private bool Compare(string xmlValueString, string inputValueString)
        {
            if (xmlValueString.Contains('['))
            {
                string xmlValueStartString = xmlValueString.Substring(0, xmlValueString.IndexOf("["));
                // int counter = messageString.IndexOf("[");
                inputValueString = inputValueString.Replace(" ", "");
                string inputValueStartString = inputValueString.Substring(0, xmlValueString.IndexOf("["));
                if (xmlValueStartString != inputValueStartString)
                    return false;
                else
                {
                    string xmlValueEndString = xmlValueString.Substring(xmlValueString.IndexOf("]") + 1);
                    int counter = xmlValueString.IndexOf("]") - xmlValueString.IndexOf("[") - 1;
                    string middleXmlValueString = xmlValueString.Substring(xmlValueString.IndexOf("[") + 1, counter);
                    int a = middleXmlValueString.IndexOf("/");
                    int c = Convert.ToInt32(middleXmlValueString.Substring(0, a));
                    string inputMessageEndString = inputValueString.Substring(xmlValueString.IndexOf("[") + c);
                    if (xmlValueEndString == inputMessageEndString)
                        return true;
                }
            }
            else
            {
                if (String.Format(" {0:X2}", xmlValueString) == inputValueString)
                    return true;
            }
            return false;
        }

        //*********************************************
        //returns the name of the matching packet based on the id and message
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private string GetPackets(string id, string message, string carname)
        {
            string packetName = "";
            try
            {
                message = message.Replace(" ", "");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName='{0}']", carname));
                XmlNodeList nodelist = node.ChildNodes;
                //Checking if the XML contains that packet
                foreach (XmlNode chldNode in nodelist)
                {
                    if (chldNode.Name.ToLower() == "packet")
                        packetName = findName(id, message, chldNode.ParentNode); //only checks one packet
                    if (!String.IsNullOrEmpty(packetName))
                        return packetName;

                    if (chldNode.Name.ToLower() == "sequence")
                        foreach (XmlNode chldNode1 in chldNode)
                        {
                            if (chldNode1.Name.ToLower() == "packet")
                                packetName = findName(id, message, chldNode1);
                            if (!String.IsNullOrEmpty(packetName))
                                return packetName;
                        }
                    if (chldNode.Name.ToLower() == "ifthen")
                        foreach (XmlNode chldNode1 in chldNode)
                        {
                            if (chldNode1.Name.ToLower() == "if")
                                packetName = findName(id, message, chldNode1.FirstChild);
                            if (!String.IsNullOrEmpty(packetName))
                                return packetName;
                            if (chldNode1.Name.ToLower() == "then")
                                packetName = findName(id, message, chldNode1.FirstChild);
                            if (!String.IsNullOrEmpty(packetName))
                                return packetName;

                        }
                }
                return packetName;

            }
            catch (Exception ex)
            {
                ErrorLog.NewLogEntry("Filter", string.Format("URI filename not found, {0}", ex.Message));
                FileLog.Log(ex.Message);
                return ""; //not matched
            }
        }



        

        private string findName(string id, string message, XmlNode node)
        {
            bool flagName = false;
            bool flagID = false;
            string packetname = "";
            XmlNodeList nodes = node.SelectNodes(string.Format("//Packet[ID='{0}' and Message= '{1}']", id, message));
            foreach (XmlNode chldNode1 in nodes)
            {
                foreach (XmlNode chldNode in chldNode1)
                {

                    if (chldNode.Name.ToLower() == "name")
                    //removed the check when the packet is empty otherwise it prints the previous value for filter
                    {
                        if (chldNode.InnerText != "")
                        {
                            flagName = true;
                        }
                        packetname = chldNode.InnerText;
                    }
                    if (chldNode.Name.ToLower() == "id" && flagName)
                        if (chldNode.InnerText.ToLower() == id.ToLower())
                            flagID = true;
                    if (chldNode.Name.ToLower() == "message" && flagID && flagName)
                        if (chldNode.InnerText.ToLower() == message.ToLower())
                        {
                            return packetname;
                        }
                }
                
            }
            return packetname;
        }


       
        //*********************************************
        // For the dynamic update; not yet implemented
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void StopMonitor2_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerRead.WorkerSupportsCancellation == true)
            {
                backgroundWorkerRead.CancelAsync();
            }
        }
        //*********************************************
        // Clears the Bus Monitor
        //Written by Chris Everett
        //*********************************************
        private void ClearMonitor2_Click_1(object sender, EventArgs e)
        {
            MonitorBox.Items.Clear();
            ReceiveCount.Text = "0";
        }
        //*********************************************
        // Opens Packet Transmit Window for 
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void TransmitFuzz_Click(object sender, EventArgs e)
        {
            CanData can = new CanData();
            string msgOutput = "";

            if (MonitorBox.SelectedIndices.Count > 0)
            {
                ListViewItem item = MonitorBox.SelectedItems[0];

                for (int x = 0; x < MonitorBox.Items.Count; x++)
                {
                    if (MonitorBox.Items[x].Selected)
                    {
                        msgOutput = MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text + ";" + MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.DLC].Text + ";" + MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.Flags].Text + ";";

                        // Bases conversion of message on check box; needs revison to add error checking
                        if (Monitor_Hex.Checked == true)
                        {
                            can.format = "hex";
                            msgOutput += MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.Data].Text.Replace(" ", string.Empty);
                        }
                        else
                        {
                            can.format = "decimal";
                            msgOutput += MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.Data].Text;
                        }

                        // MessageBox.Show("Data to convert:" + msgOutput);
                        CommonUtils.ConvertStringtoCAN(can, msgOutput);

                        can.hardware = TransmitInterfaceBox.SelectedItem.ToString();



                        // Verbose Output
                        //if (VerboseTransmit.Checked == true)
                        //    MessageBox.Show(CommonUtils.DisplayMsg(can));
                        break;
                    }
                }
                TransmitPackets tp = new TransmitPackets();

                tp.ShowForm(can);
                tp.MdiParent = MainWindow.ActiveForm;
                tp.Show();
                MonitorBox.SelectedIndices.Clear();


                // Status Update
                //toolStripStatusLabel2.Text = CommonUtils.ErrorMsg("Transmit Message", can.status);
                //ErrorLog.NewLogEntry("CAN", "Transmit Message: " + can.status);
            }
            
        }

        //*********************************************
        // Transmission of the packets selected by the user
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void TransmitPackets2_Click(object sender, EventArgs e)
        {
            CanData can = new CanData();
            string msgOutput = "";

            if (MonitorBox.SelectedIndices.Count > 0)
            {
                ListViewItem item = MonitorBox.SelectedItems[0];

                for (int x = 0; x < MonitorBox.Items.Count; x++)
                {
                    if (MonitorBox.Items[x].Selected)
                    {
                        msgOutput = MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text + ";" + MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.DLC].Text + ";" + MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.Flags].Text + ";";

                        // Bases conversion of message on check box; needs revison to add error checking
                        if (Monitor_Hex.Checked == true)
                        {
                            can.format = "hex";
                            msgOutput += MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.Data].Text.Replace(" ", string.Empty);
                        }
                        else
                        {
                            can.format = "decimal";
                            msgOutput += MonitorBox.Items[x].SubItems[(int)CommonUtils.BusFields.Data].Text;
                        }

                        // MessageBox.Show("Data to convert:" + msgOutput);
                        CommonUtils.ConvertStringtoCAN(can, msgOutput);

                        can.hardware = TransmitInterfaceBox.SelectedItem.ToString();
                        

                        //bgTransmit.RunWorkerAsync(can);
                        GenericCanBus.GenericCanTransmitSingle(can);

                        // Verbose Output
                        if (VerboseTransmit.Checked == true)
                            MessageBox.Show(CommonUtils.DisplayMsg(can));
                    }
                }

                // Status Update
                toolStripStatusLabel2.Text = CommonUtils.ErrorMsg("Transmit Message", can.status);
                ErrorLog.NewLogEntry("CAN", "Transmit Message: " + can.status);
                FileLog.Log("CAN Transmit Message: " + can.status);
            }
        }
        //*********************************************
        // Background Work for Transmit and Receive
        //Written by Chris Everett
        //*********************************************
        private void bgTransmit_DoWork(object sender, DoWorkEventArgs e)
        {
            CanData can = e.Argument as CanData;
            GenericCanBus.GenericCanTransmitSingle(can);
        }

        private void Monitor_Hex_CheckedChanged(object sender, EventArgs e)
        {
            MonitorBox.Items.Clear();
        }

        private void Monitor_Decimal_CheckedChanged(object sender, EventArgs e)
        {
            MonitorBox.Items.Clear();
        }


        //*****************************************
        // Filter Processing
        //Witten by Parnian Najafi Borazjani
        //***************************************

        // Refresh Filters Button
        private void FindFilters_Click(object sender, EventArgs e)
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

                toolStripStatusLabel2.Text = "Find Filters";
            }
        }

        //***************************************
        //Witten by Parnian Najafi Borazjani
        //***************************************
        private void LoadFilter_Click(object sender, EventArgs e)
        {
            if (FilterList.SelectedIndex == -1)
                MessageBox.Show("Please choose a filter from the list");
            // Loop through all items the MonitorBox. 
            for (int x = 0; x < FilterList.Items.Count; x++)
            {
                // Determine if the item is selected. 
                if (FilterList.GetSelected(x) == true)
                {
                    // Sets all of the variables for the selected filter
                    CarFilter = FilterList.Items[x].ToString();
                    FilterLoadLabel.Text = FilterList.Items[x].ToString();
                    FilterLoadStatus.Text = "Filter Loaded: " + FilterList.Items[x].ToString();
                    ErrorLog.NewLogEntry("Status", "Filter Loaded: " + FilterList.Items[x].ToString());
                    FileLog.Log("Status - Filter Loaded: " + FilterList.Items[x].ToString());
                    UnloadFilter.Enabled = true;
                    IfThenActivateButton.Enabled = true;
                    //IfThenActivateButton.BackColor = Color.Red;
                    //Change the text after filter
                    for (int y = 0; y < MonitorBox.Items.Count; y++)
                    {
                        MonitorBox.Items[y].SubItems[0].Text = GetPackets(MonitorBox.Items[y].SubItems[1].Text, MonitorBox.Items[y].SubItems[7].Text, CarFilter);
                    }


                }
            }
        }

        //***************************************
        //Witten by Parnian Najafi Borazjani
        //***************************************
        private void UnloadFilter_Click(object sender, EventArgs e)
        {
            // Resets all of the variables if no filter is selected
            CarFilter = "";
            FilterLoadLabel.Text = "None";
            FilterLoadStatus.Text = "Filter Loaded: None";
            UnloadFilter.Enabled = false;
            IfThenActivateButton.Enabled = false;
            //IfThenActivateButton.BackColor = Color.Transparent;
            for (int y = 0; y < MonitorBox.Items.Count; y++)
            {
                MonitorBox.Items[y].SubItems[0].Text = "";
            }
        }


        //*************************
        // Copy the selected messages to the clipboard
        //Written by Chris Everett
        //*************************
      
        //*************************
        // For button on form
        //Written by Chris Everett
        //*************************
        private void CopyClipboard_Click(object sender, EventArgs e)
        {
            copytoClipboard();
        }
        //*************************
        // For menu selection and keyboard shortcut
        //Written by Chris Everett
        //*************************
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copytoClipboard();
        }

        //*********************************************
        // Does the work for the copy to clipboard
        //Written by Chris Everett
        //*********************************************
        private void copytoClipboard()
        {
            string msgOutput = "";

            if (MonitorBox.SelectedIndices.Count > 0)
            {
                ListViewItem item = MonitorBox.SelectedItems[0];

                // Loops through all of the items in the monitor box
                for (int x = 0; x < MonitorBox.Items.Count; x++)
                {
                    // for the selected monitor box items, the text is added to the msgOutput string for the clipboard
                    // if no items are selected the msgOutput will be blank - ""
                    if (MonitorBox.Items[x].Selected)
                    {
                        msgOutput +=
                            MonitorBox.Items[x].SubItems[0].Text + ";" +
                            MonitorBox.Items[x].SubItems[1].Text + ";" +
                            MonitorBox.Items[x].SubItems[2].Text + ";" +
                            MonitorBox.Items[x].SubItems[3].Text + ";" +
                            MonitorBox.Items[x].SubItems[4].Text + ";" +
                            MonitorBox.Items[x].SubItems[5].Text + ";" +
                            MonitorBox.Items[x].SubItems[6].Text + ";" +
                            MonitorBox.Items[x].SubItems[7].Text + ";" +
                            MonitorBox.Items[x].SubItems[8].Text + "\n";
                    }
                }
            }

            if (msgOutput != "")
                Clipboard.SetText(msgOutput);
        }


        //*********************************************
        // For menu selection and keyboard shortcut; Copies all of the MonitorBox to clipboard
        //Written by Chris Everett
        //*********************************************
        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msgOutput = "";

            // Loops through all of the items in the monitor box
            for (int x = 0; x < MonitorBox.Items.Count; x++)
            {
                msgOutput +=
                        MonitorBox.Items[x].SubItems[0].Text + ";" +
                        MonitorBox.Items[x].SubItems[1].Text + ";" +
                        MonitorBox.Items[x].SubItems[2].Text + ";" +
                        MonitorBox.Items[x].SubItems[3].Text + ";" +
                        MonitorBox.Items[x].SubItems[4].Text + ";" +
                        MonitorBox.Items[x].SubItems[5].Text + ";" +
                        MonitorBox.Items[x].SubItems[6].Text + ";" +
                        MonitorBox.Items[x].SubItems[7].Text + ";" +
                        MonitorBox.Items[x].SubItems[8].Text + "\n";
            }

            if (msgOutput != "")
                Clipboard.SetText(msgOutput);
        }


        //*********************************************
        // Updates the LSB number displayed on the GUI
        //Written by Chris Everett
        //*********************************************
        private void numericMSB_ValueChanged(object sender, EventArgs e)
        {
            int temp = 11 - Convert.ToInt32(numericMSB.Value);
            labelLSB.Text = temp.ToString();
        }

        
     
        
       /* private void applyFilters_Click(object sender, EventArgs e)
        {

            filterItems = new List<ListViewItem>();
            List<ListViewItem> items = ProcessFilter(false);
            foreach (ListViewItem boxItem in MonitorBox.Items)
            {
                if (!items.Contains(boxItem))
                {
                    filterItems.Add(boxItem);
                }
            }
            MonitorBox.Items.Clear();
            foreach (ListViewItem item in items)
            {
                MonitorBox.Items.Add(item);
            }
        }
        */

        //*********************************************
        //Filters and highlights the filtered text as needed
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private List<ListViewItem> ProcessFilter(ListView.ListViewItemCollection mainItems)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            for (int x = 0; x < mainItems.Count; x++)
            {
                
                if (Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text, txtID.Text)
                    && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitMSB].Text, txtMSB.Text)
                    && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitLSB].Text, txtLSB.Text)
                    && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.Data].Text.ToLower(), txtMessage.Text.ToLower())
                    && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.DLC].Text, txtDLC.Text))
                {

                    items.Add(mainItems[x]);
                }
            }
            return items;
        }

        private void ProcessHighlight(bool doHighlight, ListView.ListViewItemCollection mainItems)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            for (int x = 0; x < mainItems.Count; x++)
            {
                if (!(string.IsNullOrEmpty(txtMSB.Text)) && !(string.IsNullOrEmpty(txtLSB.Text)) && !(string.IsNullOrEmpty(txtDLC.Text)))
                {
                    if (Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text, txtID.Text)
                        && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitMSB].Text, txtMSB.Text)
                        && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitLSB].Text, txtLSB.Text)
                        && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.Data].Text.ToLower(), txtMessage.Text.ToLower())
                        && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.DLC].Text, txtDLC.Text))
                    {
                        if (doHighlight && (!string.IsNullOrEmpty(txtID.Text) || !string.IsNullOrEmpty(txtMSB.Text) || !string.IsNullOrEmpty(txtLSB.Text) || !string.IsNullOrEmpty(txtMessage.Text) || !string.IsNullOrEmpty(txtDLC.Text)))
                            mainItems[x].BackColor = Color.LightBlue;
                        else
                            mainItems[x].BackColor = Color.White;
                    }
                }
                else
                {
                    if (Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text, txtID.Text)
                        && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.Data].Text.ToLower(), txtMessage.Text.ToLower()))
                    { if (doHighlight)
                       // if (doHighlight && (!string.IsNullOrEmpty(txtID.Text) || !string.IsNullOrEmpty(txtMSB.Text) || !string.IsNullOrEmpty(txtLSB.Text) || !string.IsNullOrEmpty(txtMessage.Text) || !string.IsNullOrEmpty(txtDLC.Text)))
                            mainItems[x].BackColor = Color.LightBlue;
                        else
                            mainItems[x].BackColor = Color.White;
                    }
                }
                // return items;
            }
        }

        //*********************************************
        //Returns True if the filter should be activated and false if it should not
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private bool Predicate_Filter(string monitorValue, string userValue)
        {
            if (string.IsNullOrEmpty(userValue))
            {
                return true;
            }
            else
            {
                if (monitorValue.ToLower().Replace(" ", "") == userValue.ToLower().Replace(" ", ""))
                    return true;
                else
                    return false;
            }
        }

        
        //*********************************************
        // Clear the text boxes when filter is reset
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void clearTextBoxes()
        {
            txtDLC.Clear();
            txtID.Clear();
            txtLSB.Clear();
            txtMessage.Clear();
            txtMSB.Clear();
        }


        //*********************************************
        // Sorting
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void MonitorBox_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (MonitorBox.Sorting == SortOrder.Ascending)
            {
                MonitorBox.Sorting = SortOrder.Descending;
                MonitorBox.SetSortIcon(e.Column, SortOrder.Descending); //sets the sort arrow
            }
            else
            {
                MonitorBox.Sorting = SortOrder.Ascending;
                MonitorBox.SetSortIcon(e.Column, SortOrder.Ascending); //sets the sort arrow
            }
            MonitorBox.ListViewItemSorter = new ListViewItemComparer(e.Column, MonitorBox.Sorting);
            MonitorBox.Sort();
        }

        private void IDfil_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

  
        //*********************************************
        // Highlight
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void btnHighlightFilter_Click_1(object sender, EventArgs e)
        {
            ProcessHighlight(!highlightFlag, MonitorBox.Items);
            if (highlightFlag)
            {
                highlightFlag = false;
                btnHighlightFilter.Text = "Highlight Selection";
            }
            else
            {
                btnHighlightFilter.Text = "Reset Highlight";
                highlightFlag = true;
            }
        }

        bool filterFlag=false;
        bool highlightFlag=false;
        private void applyFilters_Click_1(object sender, EventArgs e)
        {

            filterFlag = true;
            if (applyFilters.Text == "Reset Filters")
            {
                applyFilters.Text = "Apply Filters";
                filterFlag = false; //reset
                clearTextBoxes();
                foreach (ListViewItem item in filterItems)
                {
                    MonitorBox.Items.Add(item);
                }
                foreach (ListViewItem item in MonitorBox.Items)
                {
                    item.BackColor = Color.White;
                }
                MonitorBox.Sorting = SortOrder.Ascending;
                MonitorBox.ListViewItemSorter = new ListViewItemComparer(10, MonitorBox.Sorting); //sorting based on time
                MonitorBox.Sort();
                filterItems = new List<ListViewItem>();
            }
            else
            {
                applyFilters.Text = "Reset Filters";
                filterFlag = true; //apply filter
                filterItems = new List<ListViewItem>();
                List<ListViewItem> items = ProcessFilter(MonitorBox.Items); //filtered list
                foreach (ListViewItem boxItem in MonitorBox.Items)
                {
                    if (!items.Contains(boxItem))
                    {
                        filterItems.Add(boxItem); //keep it for later
                    }
                }
                MonitorBox.Items.Clear();
                foreach (ListViewItem item in items)
                {
                    MonitorBox.Items.Add(item);
                }
            }
            
        }

        //*********************************************
        // Reset
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void btnRest_Click_1(object sender, EventArgs e)
        {
            clearTextBoxes();
            foreach (ListViewItem item in filterItems)
            {
                MonitorBox.Items.Add(item);
            }
            foreach (ListViewItem item in MonitorBox.Items)
            {
                item.BackColor = Color.White;
            }
            MonitorBox.Sorting = SortOrder.Ascending;
            MonitorBox.ListViewItemSorter = new ListViewItemComparer(10, MonitorBox.Sorting); //sorting based on time
            MonitorBox.Sort();
            filterItems = new List<ListViewItem>();
        }
        //*********************************************
        // Fuzzed packet
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void identifyPacketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.IdNo].Text;
                string dlc = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.DLC].Text;
                string flag = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.Flags].Text;
                string message = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.Data].Text;
                Windows.IdentifyPackets newMDIChild = new Windows.IdentifyPackets(id, dlc, flag, message);
                newMDIChild.BusMonitorColumnParentForm = this;
                newMDIChild.MdiParent = MainWindow.ActiveForm;
                newMDIChild.Show();
                //Windows.IdentifyPackets newMDIChild = new Windows.IdentifyPackets(id, dlc, flag, message);
                //newMDIChild.MdiParent = MainWindow.ActiveForm;
                //newMDIChild.Show();
            }
            catch{
                MessageBox.Show("Please select a packet first");
                FileLog.Log("Packet was not selected");

            }
           //ListViewItem item = MonitorBox.SelectedItems[0];
          
        }

        private void XMLFilter_Click(object sender, EventArgs e)
        {

        }

        //*********************************************
        // Activate If Then for loaded filter
        //Written By Chris Everett
        //*********************************************
        private void IfThenActivate_Click(object sender, EventArgs e)
        {
            if (!IfThenActive && CarFilter != "")
            {
                IfThenActivateButton.Text = "De-Activate If Then";
                IfThenpictureBox.BackColor = Color.Green;
                IfThenActive = true;

                //ifthenxml.StartIfThenMachine(CarFilter);
            }
            else
            {
                IfThenActivateButton.Text = "Activate If Then";
                IfThenpictureBox.BackColor = Color.Red;
                IfThenActive = false;

               // ifthenxml.StopIfThenMachine();
            }

        }


        private void RefreshInterfaces_Click(object sender, EventArgs e)
        {
            UpdateInterfaceBox();
        }

       // bool testerTPFlag = false;
        //***********************************************
        // Activates or De-activates the Tester Present
        //Written By Chris Everett & Parnian Najafi Borazjani
        //*********************************************
        private void buttonTesterPresent_Click(object sender, EventArgs e)
        {
            try{

                if (!TesterPresent)
                {
                    buttonTesterPresent.Text = "De-Activate Tester Present";
                    TesterPresent = true;
                    pictureBoxTester.BackColor = Color.Green;

                    string[] arguments = { TesterPresentID.Text, TesterPresentDLC.Text, TesterPresentMessage.Text, TransmitInterfaceBox.SelectedItem.ToString() , TimeBetween.Text};
                    if (backgroundWorkerTester_C.IsBusy != true)
                    {
                       // MainWindow.ErrorDisplayString("Start Tester Present");
                        backgroundWorkerTester_C.RunWorkerAsync(arguments);
                        ErrorLog.NewLogEntry("CAN", "Monitor Bus On");
                        FileLog.Log("CAN - Monitor Bus On");

                    }
                    else
                    {
                        ErrorLog.NewLogEntry("CAN", "Monitor Bus - Background Tester Worker Busy");
                        FileLog.Log("CAN - Monitor Bus - Background Tester Worker Busy");
                    }

                    // Status Update
                    toolStripStatusLabel2.Text = "Tester Present Transmit Message";
                    ErrorLog.NewLogEntry("CAN", "Tester Present Transmit Message: ");
                    FileLog.Log("CAN - Tester Present Transmit Message: ");
                }
                else
                {
                    buttonTesterPresent.Text = "Activate Tester Present";
                    TesterPresent = false;
                    pictureBoxTester.BackColor = Color.Red;

                    if (backgroundWorkerTester_C.WorkerSupportsCancellation == true)
                    {
                        backgroundWorkerTester_C.CancelAsync();
                    }

                }

            }
            catch
            {
                MessageBox.Show("No interface is turned on, please turn on the interfaces from \"Advanced Bus Control\" window");
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
       

        // The worker thread for the backgroundWorker
        private void backgroundWorkerTester_DoWork_1(object sender, DoWorkEventArgs e)
        {
            //MainWindow.ErrorDisplayString("In Tester Present Loop");

            CanData can = new CanData();

            // TesterPresentID.Text, TesterPresentDLC.Text, TesterPresentMessage.Text, TransmitInterfaceBox.SelectedItem.ToString(), TimeBetween.Text
            string[] arguments = (string[])e.Argument;
            
            can.format = "hex";
            can.id = Convert.ToInt32(arguments[0], 16);
            can.dlc = Convert.ToInt32(arguments[1]);
            can.msg = CommonUtils.HexStringToByteArray(arguments[2]);
            can.hardware = arguments[3];

            while (true)
            {
                GenericCanBus.GenericCanTransmitSingle(can);
                System.Threading.Thread.Sleep(Convert.ToInt32(arguments[4]));

                if ((sender as BackgroundWorker).CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        // The progress ender for the backgroundWorker
        private void backgroundWorkerTester_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerRead.CancelAsync();

            if (e.Cancelled)
                ErrorLog.NewLogEntry("CAN", "Monitor Bus - Background Worker Cancelled");
                FileLog.Log("CAN - Monitor Bus - Background Worker Cancelled");

        }

        //***********************
        // Log to file
        //Written by Parnian Najafi Borazjani
        //***********************
        private void logToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            string header = "";
            string body = "";


            header = "Packet; ID; ECU ID; ECU; Priority; DLC; Flags; Data; Time; \n";
                       //MonitorBox.Items[x].SubItems[2].Text + ";" +
                       //MonitorBox.Items[x].SubItems[3].Text + ";" +
                       //MonitorBox.Items[x].SubItems[4].Text + ";" +
                       //MonitorBox.Items[x].SubItems[5].Text + ";" +
                       //MonitorBox.Items[x].SubItems[6].Text + ";" +
                       //MonitorBox.Items[x].SubItems[7].Text + ";" +
                       //MonitorBox.Items[x].SubItems[8].Text + "\n";
            // Loops through all of the items in the monitor box
            for (int x = 0; x < MonitorBox.Items.Count; x++)
            {
                body +=
                        MonitorBox.Items[x].SubItems[0].Text + ";" +
                        MonitorBox.Items[x].SubItems[1].Text + ";" +
                        MonitorBox.Items[x].SubItems[2].Text + ";" +
                        MonitorBox.Items[x].SubItems[3].Text + ";" +
                        MonitorBox.Items[x].SubItems[4].Text + ";" +
                        MonitorBox.Items[x].SubItems[5].Text + ";" +
                        MonitorBox.Items[x].SubItems[6].Text + ";" +
                        MonitorBox.Items[x].SubItems[7].Text + ";" +
                        MonitorBox.Items[x].SubItems[8].Text + "\n";
            }

            if (body != "")
                FileLog.PacketLog(header,body);
        }

        private void MonitorBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void renamePacketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.IdNo].Text;
                string dlc = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.DLC].Text;
                string flag = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.Flags].Text;
                string message = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.Data].Text;

                string packetname = MonitorBox.SelectedItems[0].SubItems[(int)CommonUtils.BusFields.Packet].Text; //packetname is not returned - load it from the XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType/Packet[Name = '{0}']", packetname));
                string carname = "";
                //add code for when the packetname is not available
                Windows.RenamePackets newMDIChild = new Windows.RenamePackets(id, dlc, flag, message,packetname,carname);


                newMDIChild.BusMonitorColumnParentForm = this;
                newMDIChild.MdiParent = MainWindow.ActiveForm;
                newMDIChild.Show();
                //Windows.IdentifyPackets newMDIChild = new Windows.IdentifyPackets(id, dlc, flag, message);
                //newMDIChild.MdiParent = MainWindow.ActiveForm;
                //newMDIChild.Show();
            }
            catch
            {
                MessageBox.Show("Please select a packet first");
                FileLog.Log("Packet was not selected");

            }
        }

        private void identifyECUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void identifyMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BusMonitorColumn_Load(object sender, EventArgs e)
        {

        }

        // Added by Chris Everett to fix error with running multiple BusMonitor windows
        private void Form1_FormClosed(Object sender, FormClosedEventArgs e)
        {

        }

        private void BusMonitorColumn_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void BusMonitorColumn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorkerTester_C.WorkerSupportsCancellation == true)
            {
                backgroundWorkerTester_C.CancelAsync();
            }

            if (backgroundWorkerRead.WorkerSupportsCancellation == true)
            {
                backgroundWorkerRead.CancelAsync();
            }


            (ParentForm as MainWindow).CurrentTPUserFormId = "";
        }
    }

    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                    ((ListViewItem)y).SubItems[col].Text);
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}