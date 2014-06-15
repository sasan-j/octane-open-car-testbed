/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       IdentifyPackets.cs
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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using OpenCarTestbed.Common;

namespace OpenCarTestbed.Windows
{
    public partial class IdentifyPackets : Form
    {
        string _id, _dlc, _flag, _data, _path, _carname;
        public BusMonitorColumn BusMonitorColumnParentForm { get; set; }
        public BusMonitorCompact BusMonitorCompactParentForm { get; set; }
        
        //CommonUtils.ConfigFileType _configType;
        //public IdentifyPackets(string id, string dlc, string flag, string data, string path, string carname, CommonUtils.ConfigFileType configType)
        //***********************************
        //Written by Parnian Najafi Borazjani
        //***********************************
        public IdentifyPackets(string id, string dlc, string flag, string data)//, string path, string carname)
        {
            InitializeComponent();
            _id = id;
            _dlc = dlc;
            _flag = flag;
            _data = data;
            _path = ConfigFiles.Settings1.Default.filterURI;
            Transmit_id.Enabled = false;
            Transmit_msg0.Enabled = false;
            Transmit_msg1.Enabled = false;
            Transmit_msg2.Enabled = false;
            Transmit_msg3.Enabled = false;
            Transmit_msg4.Enabled = false;
            Transmit_msg5.Enabled = false;
            Transmit_msg6.Enabled = false;
            Transmit_msg7.Enabled = false;
            LoadListTransmit();
            //select the first item
            if (this.TransmitList.Items.Count > 0)
            {
                TransmitList.SelectedIndex = 0;
            }
        }
        //***********************************
        //Fill out the form
        //Written by Parnian Najafi Borazjani
        //***********************************
        private void LoadListTransmit()
        {
            // Clear any current items
            TransmitList.Items.Clear();

            // returns a string array of the available filter types from the XMLInterfaces
            string[] transmittypes = XMLInterfaces.ReturnTransmitTypes(_path);

            // for each string in the string array an item is added to the filterlist
            if (transmittypes != null)
            {
                for (int x = 0; x < transmittypes.Length; x++)
                {
                    TransmitList.Items.Add(transmittypes[x]);
                }

            }
            Transmit_id.Text = _id;
            try
            {
                _data = Regex.Replace(_data, @"\s", "");

                _data.Replace(" ", "");
                //MessageBox.Show(_data);
                Transmit_msg0.Text = _data.Substring(0, 2);
                Transmit_msg1.Text = _data.Substring(2, 2);
                Transmit_msg2.Text = _data.Substring(4, 2);
                Transmit_msg3.Text = _data.Substring(6, 2);
                Transmit_msg4.Text = _data.Substring(8, 2);
                Transmit_msg5.Text = _data.Substring(10, 2);
                Transmit_msg6.Text = _data.Substring(12, 2);
            }
            catch (Exception ex){
                FileLog.Log("problem using regular expression"+ex.ToString());
            }
        }

        bool flag = true;
        private string packetExists(string id, string message)
        {
            
            string packetValue ="";
            bool empty = false;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);
            XmlNodeList nodes = xmlDoc.SelectNodes(string.Format("//Packet[ID='{0}' and Message= '{1}']", id, message));
            if (nodes.Count == 0)
            {
                packetValue = "z"; //packet does not exist
                return packetValue;
            }
            //get the value of the packet

            foreach (XmlNode chldNode in nodes)
            {
                foreach (XmlNode chldNode1 in chldNode)
                {
                    if (chldNode1.Name.ToLower() == "name")
                    {
                        packetValue = chldNode1.InnerText;
                        if (packetValue == "")
                            empty = true;
                    }
                }
            }
            if (empty == true)
                packetValue = ""; //clear the packet value if it sees an instance winthout a name
                if(packetValue != "" && packetValue!="z" && flag)
                {
                    MessageBox.Show("The Packet was identified in the XML file, you can rename it if you want");
                    flag = false;
                    this.Close();
                }

                return packetValue;
        }



        private void GeneralIdentify() 
        {
            if (BusMonitorColumnParentForm != null)
            {
                BusMonitorColumnParentForm.LoopToIdentify();
            }
            else if (BusMonitorCompactParentForm != null)
            {
                BusMonitorCompactParentForm.LoopToIdentify();
            }
        }

        //************************************
        //Add identified Packet to XML
        //Written By: Parnian Najafi Borazjani
        //************************************
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //bool flag = false;
            //bool packetExists = false;
            if (BusMonitorColumnParentForm != null)
            {
                BusMonitorColumnParentForm.IdentifiedPacketName = txtPacketName.Text;
                BusMonitorColumnParentForm.IdentifiedId = Transmit_id.Text;
                BusMonitorColumnParentForm.IdentifiedMessage = _data;//(Transmit_msg0.Text + Transmit_msg1.Text + Transmit_msg2.Text + Transmit_msg3.Text + Transmit_msg4.Text + Transmit_msg5.Text + Transmit_msg6.Text + Transmit_msg7.Text).Replace(" ", "");
            }
            else if (BusMonitorCompactParentForm != null)
            {
                BusMonitorCompactParentForm.IdentifiedPacketName = txtPacketName.Text;
                BusMonitorCompactParentForm.IdentifiedId = Transmit_id.Text;
                BusMonitorCompactParentForm.IdentifiedMessage = _data;//(Transmit_msg0.Text + Transmit_msg1.Text + Transmit_msg2.Text + Transmit_msg3.Text + Transmit_msg4.Text + Transmit_msg5.Text + Transmit_msg6.Text + Transmit_msg7.Text).Replace(" ", "");
            }
            if (rbNewXML.Checked)
            {
                _carname = txtCarType.Text;
                try
                {
                    //new xml document
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(_path);
                    XmlNode node = xmlDoc.LastChild.LastChild;
                    XmlElement newCarName = xmlDoc.CreateElement("CarName");
                    XmlElement newPacket = xmlDoc.CreateElement("Packet");
                    XmlElement newID = xmlDoc.CreateElement("ID");
                    XmlElement newName = xmlDoc.CreateElement("Name");
                    XmlElement newDLC = xmlDoc.CreateElement("DLC");
                    XmlElement newFlag = xmlDoc.CreateElement("Flag");
                    XmlElement newMessage = xmlDoc.CreateElement("Message");
                    newCarName.InnerText = txtCarType.Text;
                    newID.InnerText = _id;
                    newName.InnerText = txtPacketName.Text;
                    newDLC.InnerText = _dlc;
                    if (_flag != "") //If the flag is not avaialble don't assign NULL value to it
                    {
                        newFlag.InnerText = _flag;
                        newPacket.AppendChild(newFlag);
                    }
                    newMessage.InnerText = _data;
                    node.AppendChild(newCarName);
                    node.AppendChild(newPacket);
                    newPacket.AppendChild(newID);
                    newPacket.AppendChild(newName);
                    newPacket.AppendChild(newDLC);
                    newPacket.AppendChild(newMessage);
                    xmlDoc.DocumentElement.AppendChild(node);
                    xmlDoc.Save(_path);
                    GeneralIdentify();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("no path was provided");
                }
            }
            else //default or loaded XML
            {
                _carname = TransmitList.SelectedItem.ToString();
                string _packetname = txtPacketName.Text;
                try
                {
                    // Loads the XML file
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_path);
                    XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", _carname));
                    if (node == null) //check if there is a better way
                    {
                        MessageBox.Show("no car name?");
                    }
            
                    if (string.Compare(packetExists(_id, _data), "z") == 0) //packet does not exist
                    {
                        XmlElement newPacket = xmlDoc.CreateElement("Packet");
                        XmlElement newID = xmlDoc.CreateElement("ID");
                        XmlElement newName = xmlDoc.CreateElement("Name");
                        XmlElement newDLC = xmlDoc.CreateElement("DLC");
                        XmlElement newFlag = xmlDoc.CreateElement("Flag");
                        XmlElement newMessage = xmlDoc.CreateElement("Message");
                        newID.InnerText = _id;
                        newName.InnerText = txtPacketName.Text;
                        newDLC.InnerText = _dlc;
                        if (_flag != "") //If the flag is not avaialble don't assign NULL value to it
                        {
                            newFlag.InnerText = _flag;
                            newPacket.AppendChild(newFlag);
                        }
                        newMessage.InnerText = _data;
                        node.AppendChild(newPacket);
                        newPacket.AppendChild(newID);
                        newPacket.AppendChild(newName);
                        newPacket.AppendChild(newDLC);
                        newPacket.AppendChild(newMessage);
                        xmlDoc.DocumentElement.AppendChild(node);
                        xmlDoc.Save(_path);
                        GeneralIdentify();
                        this.Close();
                    }
                    else if(packetExists(_id, _data) == "") //packet exists but it is empty
                    {
                        XmlNodeList nodes = xmlDoc.SelectNodes(string.Format("//Packet[ID='{0}' and Message= '{1}']", _id, _data));
                        foreach (XmlNode chldNode in nodes)
                        {
                            foreach (XmlNode chldNode1 in chldNode)
                            {
                                if (chldNode1.Name.ToLower() == "name")
                                {
                                    chldNode1.InnerText = txtPacketName.Text;
                                }
                            }
                        }
                        xmlDoc.Save(_path);
                    }
                     
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    ErrorLog.NewLogEntry("Filter", "URI filename not found");
                }
            }
                
        }

        private void rbLoadXML_CheckedChanged(object sender, EventArgs e)
        {
            //loads the filter
            txtCarType.Visible = false;
            TransmitList.Visible = true;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Select an xml file";
            openFileDialog1.ShowDialog();

            _path = openFileDialog1.FileName;
            LoadListTransmit();
            
        }

        private void rbNewXML_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                //TextReader tr = new StringReader("<Cars><CarType></CarType></Cars>");
                //XDocument xmlDoc = new XDocument(XDocument.Load(tr));
                txtCarType.Visible = true;
                TransmitList.Visible = false;
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml("<Cars><CarType></CarType></Cars>");

                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.DefaultExt = ".xml";
                saveFileDialog1.ShowDialog();
                string name = saveFileDialog1.FileName;
                xmlDoc.Save(name);
                _path = name;
            }
            catch
            {
                MessageBox.Show("problem with saving the file");
            }
            

        }

        private void Transmit_msg7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_msg6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_msg5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_msg4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_msg3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_msg2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_msg1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Transmit_msg0_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void TransmitList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPacketName_Click(object sender, EventArgs e)
        {

        }

        private void lblCar_Click(object sender, EventArgs e)
        {

        }

        private void txtPacketName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCarType_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
