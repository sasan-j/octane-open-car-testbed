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
using System.Diagnostics;


namespace OpenCarTestbed.Windows
{

    public partial class BusMonitorCompact : Form
    {
        bool TesterPresent = false;
        bool IfThenActive = false;
        string CarFilter = "";
        public string IdentifiedPacketName { get; set; }
        public string IdentifiedId { get; set; }
        public string IdentifiedMessage { get; set; }

        public string FormId
        {
            get { return "2"; }
        }

        public BusMonitorCompact()
        {
            InitializeComponent();
            IfThenActivateButton.Enabled = false;
            UpdateInterfaceBox();

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


            //*************gridview woot woot
            dataGridView1.Columns.Add("colTime", "Time");
            dataGridView1.Columns.Add("colID", "ID");
            dataGridView1.Columns.Add("colMessage", "Message");
            dataGridView1.Columns.Add("colPacket", "Packet");
            dataGridView1.Columns.Add("colDlc", "DLC");
            dataGridView1.Columns.Add("colFlag", "Flag");
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


        //************************************
        // Starts monitor bus
        //Written By Parnian Najafi Borazjani
        //************************************
        private void MonitorBus2_Click(object sender, EventArgs e)
        {

            toolStripStatusLabel2.Text = "Monitor Bus On";
            MonitorBus2.Enabled = false;
            StopMonitor2.Enabled = true;
            string format;
            string[] arguments = new string[5];
            if (Monitor_Hex.Checked == true)
                format = "hex";
            else
                format = "decimal";
            try
            {
                arguments[0] = ReceiveInterfaceBox.SelectedItem.ToString();
                arguments[1] = format;
                arguments[2] = CarFilter;
                arguments[3] = Convert.ToString(numericMSB.Value);
                arguments[4] = TransmitInterfaceBox.SelectedItem.ToString();
                //arguments = {ReceiveInterfaceBox.SelectedItem.ToString();, format, CarFilter, Convert.ToString(numericMSB.Value), TransmitInterfaceBox.SelectedItem.ToString() };

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


        //********************************************************************************
        //check the existing monitor bus items and identify packets in the existing list
        //Witten by Parnian Najafi Borazjani
        //********************************************************************************
        public void LoopToIdentify()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                try
                {
                    if (!string.IsNullOrEmpty(row.Cells[1].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                    {
                        if (row.Cells[1].Value.ToString() == IdentifiedId && row.Cells[2].Value.ToString().Replace(" ", "") == IdentifiedMessage)
                            row.Cells[3].Value = IdentifiedPacketName;
                    }
                }
                catch
                {
                    ErrorLog.NewLogEntry("null Exception", "Loop to Identify");
                }

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

                System.Threading.Thread.Sleep(80);

                if ((sender as BackgroundWorker).CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        //*********************************************
        // The progress ender for the backgroundWorker
        //*********************************************
        int i = 0; // added as the counter for rows in datagrid, should be fixed
        private void backgroundWorkerRead_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerRead.CancelAsync();
            MonitorBus2.Enabled = true;
            StopMonitor2.Enabled = false;

            if (e.Cancelled)
                ErrorLog.NewLogEntry("CAN", "Monitor Bus - Background Worker Cancelled");
        }

        // The progress updater for the backgroundWorker

        Dictionary<string, RowValue> idData =
        new Dictionary<string, RowValue>();  //Table holding ID and data
        //int rowIndex = -1;
        int[] equal = new int[8];
        /// <summary>
        /// ///////////////////change here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerRead_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            string[] msgInput = (string[])e.UserState;
            if (!string.IsNullOrEmpty(IdentifiedPacketName) && IdentifiedId == msgInput[1] && IdentifiedMessage == (msgInput[7]).Replace(" ", "")) //spaces are removed
            {

                msgInput[0] = IdentifiedPacketName; //identify packet names
            }
            // added for having filter affect while the messages enter
            if (msgInput != null)
            {
                RowValue rv = new RowValue();
                String newData;
                if (idData.ContainsKey(msgInput[1]))
                {
                    i = idData[msgInput[1]].Index;
                    newData = msgInput[7].Trim();
                    dataGridView1.Rows[i].Cells[2].Value = newData; // Message
                    dataGridView1.Rows[i].Cells[0].Value = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds; // time
                    //changing here
                    dataGridView1.Rows[i].Cells[4].Value = msgInput[5]; // dlc

                    dataGridView1.Rows[i].Cells[5].Value = msgInput[6]; // flag
                    dataGridView1.Rows[i].Cells[1].Value = msgInput[1]; // ID
                    idData[msgInput[1]].Message = newData;
                }
                else
                {
                    i = idData.Keys.Count();
                    rv = new RowValue();
                    rv.Index = i;
                    rv.Message = msgInput[7].Trim();
                    idData.Add(msgInput[1], rv);
                    dataGridView1.Rows.Add((DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds, msgInput[1], msgInput[7], "", msgInput[5], msgInput[6]);

                }
                dataGridView1.AutoResizeColumns();
                ReceiveCount.Text = e.ProgressPercentage.ToString();

            } //end of background worker

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
                        packetName = findName(id, message, chldNode);
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
                                if(!String.IsNullOrEmpty(packetName))
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

        ////*********************************************
        ////returns the name of the matching packet based on the id and message
        ////Written by Parnian Najafi Borazjani
        ////*********************************************
        //private string GetPacket(string id, string message, string carname)
        //{
        //    bool flagName = false;
        //    bool flagID = false;
        //    bool flagPacket = false;

        //    try
        //    {
        //        message = message.Replace(" ", "");
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
        //        XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName='{0}']", carname));
        //        XmlNodeList nodelist = node.ChildNodes;
        //        //Checking if the XML contains that packet
        //        flagPacket = true;
        //        foreach (XmlNode chldNode in nodelist)
        //        {

        //            flagName = false;
        //            flagID = false;
        //            flagPacket = false;

        //            foreach (XmlNode chldNode1 in chldNode.ChildNodes)
        //            {
        //                if (chldNode1.Name == "Packet")
        //                {
        //                    flagPacket = true;
        //                }
        //                if (chldNode1.Name == "Name" && flagPacket)
        //                    if (chldNode1.InnerText != "")
        //                        flagName = true;
        //                if (chldNode1.Name == "ID" && flagName && flagPacket)
        //                    if (chldNode1.InnerText == id)
        //                        flagID = true;
        //                if (chldNode1.Name == "Message" && flagID && flagName && flagPacket)
        //                    if (chldNode1.InnerText == message)
        //                    {
        //                        return chldNode1.ParentNode.SelectSingleNode("Name").InnerText;
        //                    }
        //            }

        //        }
        //        return "";

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.NewLogEntry("Filter", string.Format("URI filename not found, {0}", ex.Message));
        //        FileLog.Log(ex.Message);
        //        return ""; //not matched
        //    }
        //}


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
        // Background Work for Transmit and Receive
        //Written by Chris Everett
        //*********************************************
        private void bgTransmit_DoWork(object sender, DoWorkEventArgs e)
        {
            CanData can = e.Argument as CanData;
            GenericCanBus.GenericCanTransmitSingle(can);
        }


        //***********************************
        // Does the work for the copy to clipboard
        //Written by Parnian Najafi Borazjani
        //***********************************
        private void copytoClipboard()
        {
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
        }


        // Updates the LSB number displayed on the GUI
        private void numericMSB_ValueChanged(object sender, EventArgs e)
        {
            int temp = 11 - Convert.ToInt32(numericMSB.Value);
            labelLSB.Text = temp.ToString();
        }

        //Filters and highlights the filtered text as needed
        private List<ListViewItem> ProcessFilter1(ListView.ListViewItemCollection mainItems)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            for (int x = 0; x < mainItems.Count; x++)
            {
                if (Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text, txtID.Text)
                    //  && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitMSB].Text, txtMSB.Text)
                    // && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitLSB].Text, txtLSB.Text)
                    //&& Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.Data].Text.ToLower(), txtMessage.Text.ToLower())
                    //&& Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.DLC].Text, txtDLC.Text)
                    )
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
                // if (!(string.IsNullOrEmpty(txtMSB.Text)) && !(string.IsNullOrEmpty(txtLSB.Text)) && !(string.IsNullOrEmpty(txtDLC.Text)))
                {
                    if (Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text, txtID.Text)
                        //   && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitMSB].Text, txtMSB.Text)
                        //   && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.BitLSB].Text, txtLSB.Text)
                        //   && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.Data].Text.ToLower(), txtMessage.Text.ToLower())
                        //   && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.DLC].Text, txtDLC.Text)
                        )
                    {
                        //   if (doHighlight && (!string.IsNullOrEmpty(txtID.Text) || !string.IsNullOrEmpty(txtMSB.Text) || !string.IsNullOrEmpty(txtLSB.Text) || !string.IsNullOrEmpty(txtMessage.Text) || !string.IsNullOrEmpty(txtDLC.Text)))
                        mainItems[x].BackColor = Color.LightBlue;
                        //   else
                        mainItems[x].BackColor = Color.White;
                    }
                }
                // else
                {
                    if (Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.IdNo].Text, txtID.Text)
                        //  && Predicate_Filter(mainItems[x].SubItems[(int)CommonUtils.BusFields.Data].Text.ToLower(), txtMessage.Text.ToLower())
                        )
                    {
                        if (doHighlight)
                            // if (doHighlight && (!string.IsNullOrEmpty(txtID.Text) || !string.IsNullOrEmpty(txtMSB.Text) || !string.IsNullOrEmpty(txtLSB.Text) || !string.IsNullOrEmpty(txtMessage.Text) || !string.IsNullOrEmpty(txtDLC.Text)))
                            mainItems[x].BackColor = Color.LightBlue;
                        else
                            mainItems[x].BackColor = Color.White;
                    }
                }
                // return items;
            }
        }

        //Returns True if the filter should be activated and false if it should not
        private bool Predicate_Filter(string monitorValue, string userValue)
        {
            if (string.IsNullOrEmpty(userValue))
            {
                return true;
            }
            else
            {
                if (monitorValue == userValue)
                    return true;
                else
                    return false;
            }
        }

        //Clear the text boxes when filter is reset
        private void clearTextBoxes()
        {
            txtID.Clear();
        }

        // Activate If Then for loaded filter
        private void IfThenActivate_Click(object sender, EventArgs e)
        {
            if (!IfThenActive && CarFilter != "")
            {
                IfThenActivateButton.Text = "De-Activate If Then";
                IfThenpictureBox.BackColor = Color.Green;
                IfThenActive = true;
            }
            else
            {
                IfThenActivateButton.Text = "Activate If Then";
                IfThenpictureBox.BackColor = Color.Red;
                IfThenActive = false;
            }
        }

        private void RefreshInterfaces_Click(object sender, EventArgs e)
        {
            UpdateInterfaceBox();
        }

        // Activates or De-activates the Tester Present
        private void buttonTesterPresent_Click(object sender, EventArgs e)
        {

            if (!TesterPresent)
            {
                buttonTesterPresent.Text = "De-Activate Tester Present";
                TesterPresent = true;
                pictureBoxTester.BackColor = Color.Green;

                string[] arguments = { TesterPresentID.Text, TesterPresentDLC.Text, TesterPresentMessage.Text, TransmitInterfaceBox.SelectedItem.ToString(), TimeBetween.Text };
                if (backgroundWorkerTester.IsBusy != true)
                {
                    // MainWindow.ErrorDisplayString("Start Tester Present");
                    backgroundWorkerTester.RunWorkerAsync(arguments);
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

                if (backgroundWorkerTester.WorkerSupportsCancellation == true)
                {
                    backgroundWorkerTester.CancelAsync();
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


        // Log to file
        private void logToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string header = "";
            string body = "";
            header = "Packet; ID; ECU ID; ECU; Priority; DLC; Flags; Data; Time; \n";
            if (body != "")
                FileLog.PacketLog(header, body);
        }

        private void renamePacketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void ClearMonitor2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ReceiveCount.Text = "0";
            idData.Clear();
        }

        private void StopMonitor2_Click_1(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Monitor Bus Off";
            MonitorBus2.Enabled = true;
            StopMonitor2.Enabled = false;
            if (backgroundWorkerRead.WorkerSupportsCancellation == true)
            {
                backgroundWorkerRead.CancelAsync();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        //******************************************
        //Filter the packets based on their ID
        //Written by Parnian Najafi Borazjani
        //*****************************************
        private void applyFilters_Click(object sender, EventArgs e)
        {
            try
            {
                if (applyFilters.Text == "Reset Filters")
                {
                    applyFilters.Text = "Apply Filters";
                    clearTextBoxes();
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            dataGridView1.Rows[i].Visible = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Test");
                    }

                } //end of reset
                else //start of else (filtering)
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("Please choose an ID to filter");
                    }
                    else
                    {
                        applyFilters.Text = "Reset Filters";
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString() != String.Format("{0:000}",(txtID.Text)))//txtID.Text)
                            {
                                dataGridView1.Rows[i].Visible = false;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Test");
            }
        }



        //************************************
        //Send selected packet over the network
        //written by Parnian Najafi Borazjani
        //************************************
        private void TransmitPackets2_Click_1(object sender, EventArgs e)
        {
            CanData can = new CanData();
            string msgOutput = "";

            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0] != null)
            {
                if (dataGridView1.SelectedRows[0].Cells[1].Value == null)
                    return;
                if (!(String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()))) //ID
                    msgOutput = dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + ";";
                if (!(String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()))) //DLC
                    msgOutput += dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + ";";

                if (!(String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()))) //flag
                    msgOutput += dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + ";";
                else
                    msgOutput += "S" + ";";

                if (Monitor_Hex.Checked == true)
                {
                    can.format = "hex";
                    msgOutput += dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Replace(" ", string.Empty);
                }
                else
                {
                    can.format = "decimal";
                    msgOutput += dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                }

                ////put for testing
                // MessageBox.Show("Data to convert:" + msgOutput);
                CommonUtils.ConvertStringtoCAN(can, msgOutput); //added

                can.hardware = TransmitInterfaceBox.SelectedItem.ToString();


                //bgTransmit.RunWorkerAsync(can);
                GenericCanBus.GenericCanTransmitSingle(can);

                ////            // Verbose Output
                ////            if (VerboseTransmit.Checked == true)
                ////                MessageBox.Show(CommonUtils.DisplayMsg(can));
                ////        }
                ////    }

                // Status Update
                toolStripStatusLabel2.Text = CommonUtils.ErrorMsg("Transmit Message", can.status);
                ErrorLog.NewLogEntry("CAN", "Transmit Message: " + can.status);
                FileLog.Log("CAN Transmit Message: " + can.status);

            }
        }

        //************************************
        //Identify packet names
        //written by Parnian Najafi Borazjani
        //************************************
        private void identifyPacketToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                string message = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                //dlc and flag should be added
                Windows.IdentifyPackets newMDIChild = new Windows.IdentifyPackets(id, "", "", message);
                newMDIChild.BusMonitorCompactParentForm = this;
                newMDIChild.MdiParent = MainWindow.ActiveForm;
                newMDIChild.Show();
            }
            catch
            {
                MessageBox.Show("Please select a packet first");
                FileLog.Log("Packet was not selected");
            }
        }

        //*************************
        //Rename packet names
        //written by Parnian Najafi Borazjani
        //*************************
        private void renamePacketToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                string dlc = ""; //should be added
                string message = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                string flag = ""; //should be added
                string packetname = GetPackets(id, message.Replace(" ", ""), CarFilter);
                string carname = "";
                Windows.RenamePackets newMDIChild = new Windows.RenamePackets(id, dlc, flag, message, packetname, carname);
                newMDIChild.BusMonitorCompactParentForm = this;
                newMDIChild.MdiParent = MainWindow.ActiveForm;
                newMDIChild.Show();
            }
            catch
            {
                MessageBox.Show("Please select a packet first");
                FileLog.Log("Packet was not selected");
            }
        }

        private void RefreshInterfaces_Click_1(object sender, EventArgs e)
        {
            UpdateInterfaceBox();
        }
        bool highlightFlag = false;
        private void btnHighlightFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (highlightFlag)
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("Please choose an ID to Highlight");
                    }
                    else
                    {
                        highlightFlag = false;
                        btnHighlightFilter.Text = "Reset Highlight";
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString() == txtID.Text)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }
                    }
                }

                else
                {
                    highlightFlag = true;
                    btnHighlightFilter.Text = "Highlight Selection";
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == txtID.Text || dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            txtID.Text = "";
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Test");
            }
        }
        //***********************************
        //copy to clipboard
        //Written by Parnian Najafi Borazjani
        //***********************************
        //realllll
        private void CopyClipboard_Click_1(object sender, EventArgs e)
        {
            copytoClipboard();
        }

        //***********************************
        //copy to clipboard
        //Written by Parnian Najafi Borazjani
        //***********************************
        //realllll
        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            copytoClipboard();
        }

        //***********************************
        //copy to clipboard
        //Written by Parnian Najafi Borazjani
        //***********************************
        //realllllllllll
        private void copyAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var newline = System.Environment.NewLine;
            var tab = "\t";
            var clipboard_string = "";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i == (row.Cells.Count - 1))
                        clipboard_string += row.Cells[i].Value + newline;
                    else
                        clipboard_string += row.Cells[i].Value + tab;
                }
            }

            Clipboard.SetText(clipboard_string);

        }

        private void RefreshFilters_Click(object sender, EventArgs e)
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

        //***********************************
        //Loads the filter from the XML file
        //Written by Parnian Najafi Borazjani
        //***********************************
        //reallllll
        private void LoadFilter_Click(object sender, EventArgs e)
        {
            if(FilterList.SelectedIndex ==-1)
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
                    //Change the text after filter
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Cells[3].Value = GetPackets(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), CarFilter);
                        }
                    }
                    catch
                    {
                        ErrorLog.NewLogEntry("null entry", "In LoadFilter-BusMonitorCompact");
                    }

                }
            }

        }

        //***********************************
        //Reset the XML filter
        //written by Parnian Najafi Borazjani
        //***********************************
        //realllllll
        private void UnloadFilter_Click(object sender, EventArgs e)
        {
            // Resets all of the variables if no filter is selected
            CarFilter = "";
            FilterLoadLabel.Text = "None";
            FilterLoadStatus.Text = "Filter Loaded: None";
            UnloadFilter.Enabled = false;
            IfThenActivateButton.Enabled = false;
            for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
                dataGridView1.Rows[x].Cells[3].Value = "";
        }

        //************************************
        //Send fuzzed selected packet over the network
        //written by Parnian Najafi Borazjani
        //************************************
        private void TransmitFuzz_Click_1(object sender, EventArgs e)
        {


            CanData can = new CanData();
            string msgOutput = "";

            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0] != null)
            {

                if (dataGridView1.SelectedRows[0].Cells[1].Value == null)
                    return;
                if (!(String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()))) //ID
                    msgOutput = dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + ";";
                if (!(String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()))) //DLC
                    msgOutput += dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + ";";
                
                if (!(String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()))) //flag
                    msgOutput += dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + ";";
                else
                    msgOutput += "S" + ";";

                if (Monitor_Hex.Checked == true)
                {
                    can.format = "hex";
                    msgOutput += dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Replace(" ", string.Empty);
                }
                else
                {
                    can.format = "decimal";
                    msgOutput += dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                }

                ////put for testing
                // MessageBox.Show("Data to convert:" + msgOutput);
                CommonUtils.ConvertStringtoCAN(can, msgOutput); //added

                can.hardware = TransmitInterfaceBox.SelectedItem.ToString();


                // Verbose Output
                //if (VerboseTransmit.Checked == true)
                //    MessageBox.Show(CommonUtils.DisplayMsg(can));

            }

            TransmitPackets tp = new TransmitPackets();

            tp.ShowForm(can);
            tp.MdiParent = MainWindow.ActiveForm;
            tp.Show();

        }


        private void buttonTesterPresent_Click_1(object sender, EventArgs e)
        {
            if (!TesterPresent)
            {
                buttonTesterPresent.Text = "De-Activate Tester Present";
                TesterPresent = true;
                pictureBoxTester.BackColor = Color.Green;

                string[] arguments = { TesterPresentID.Text, TesterPresentDLC.Text, TesterPresentMessage.Text, TransmitInterfaceBox.SelectedItem.ToString(), TimeBetween.Text };
                if (backgroundWorkerTester.IsBusy != true)
                {
                    // MainWindow.ErrorDisplayString("Start Tester Present");
                    backgroundWorkerTester.RunWorkerAsync(arguments);
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

                if (backgroundWorkerTester.WorkerSupportsCancellation == true)
                {
                    backgroundWorkerTester.CancelAsync();
                }

            }

        }

        //reallllllllllll
        private void backgroundWorkerTester_DoWork(object sender, DoWorkEventArgs e)
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

        private void IfThenActivateButton_Click(object sender, EventArgs e)
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

        private void BusMonitorCompact_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void BusMonitorCompact_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorkerTester.WorkerSupportsCancellation == true)
            {
                backgroundWorkerTester.CancelAsync();
            }

            if (backgroundWorkerRead.WorkerSupportsCancellation == true)
            {
                backgroundWorkerRead.CancelAsync();
            }

            (ParentForm as MainWindow).CurrentTPUserFormId = "";

        }

    }

}
