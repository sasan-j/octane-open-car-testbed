/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       XMLEditPackets.cs
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
using System.Xml;

namespace OpenCarTestbed.Windows
{
    public partial class XMLEditPackets : Form
    {
        public string CarType { get; set; }   
        public XMLEditPackets(string cartype)
        {
            InitializeComponent();
            this.Text = "Edit XML of Packets for " + cartype;
            CarType = cartype;
            DoQuery(cartype);
        }

        private void DoQuery(string carType)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
            XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", carType));
            //TransmitBox.Columns.Add("Number", 200, HorizontalAlignment.Left);
            lvPacketBox.Columns.Add("ID", 100, HorizontalAlignment.Left);
            lvPacketBox.Columns.Add("Name", 100, HorizontalAlignment.Left);
            lvPacketBox.Columns.Add("DLC", 100, HorizontalAlignment.Left);
            lvPacketBox.Columns.Add("Message", 200, HorizontalAlignment.Left);
            // TransmitBox.Columns.Add("Flag", 200, HorizontalAlignment.Left);
            // TransmitBox.Columns.Add("Count", 200, HorizontalAlignment.Left);
            // TransmitBox.Columns.Add("TimeBetween", 200, HorizontalAlignment.Left);
            try
            {
                //    /***********************/
                //    DataTable dt = new DataTable();
                //    dt.Columns.Add("Name");
                //    dt.Columns.Add("Message");
                //    DataRow row = null;

                //    /***********************/
                XmlNodeList nList = node.SelectNodes("Packet");
                foreach (XmlNode msg in nList)
                {
                    if (node.SelectSingleNode("Packet") != null)
                    {
                        string message = (msg.SelectSingleNode("Message").InnerText);
                        string name = (msg.SelectSingleNode("Name").InnerText);
                        string id = (msg.SelectSingleNode("ID").InnerText);
                        string dlc = (msg.SelectSingleNode("DLC").InnerText);
                        lvPacketBox.Items.Add(new ListViewItem(new string[] { id, name, dlc, message }));
                        //            row = dt.NewRow();
                        //            row["Name"] = name;
                        //            row["Message"] = message;
                        //            dt.Rows.Add(row);
                    }
                }
                //    dtGridPacket.DataSource = dt;

            }
            catch (Exception ex)
            {
                ErrorLog.NewLogEntry("edit packet", ex.ToString());
            }
        }

      
        private void btnEditPacket_Click(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(txtPacketDLC.Text) != txtPacketMessage.Text.Length/2)
                    MessageBox.Show("Please match the length of the message with DLC");

                // Loads the XML file
                //txtPacketMessage.Enabled = false;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                XmlNodeList nList = node.SelectNodes("Packet");
                foreach (XmlNode pkt in nList)
                {
                    if (node.SelectSingleNode("Packet") != null)
                    {
                        if (pkt.SelectSingleNode("ID").InnerText == lvPacketBox.SelectedItems[0].Text && pkt.SelectSingleNode("Message").InnerText == lvPacketBox.SelectedItems[0].SubItems[3].Text)
                        {
                            pkt.SelectSingleNode("ID").InnerText = txtPacketId.Text;
                            pkt.SelectSingleNode("Name").InnerText = txtPacketName.Text;
                            pkt.SelectSingleNode("Message").InnerText = txtPacketMessage.Text;
                            pkt.SelectSingleNode("DLC").InnerText = txtPacketDLC.Text;
                            lvPacketBox.SelectedItems[0].Text = txtPacketId.Text;
                            lvPacketBox.SelectedItems[0].SubItems[1].Text = txtPacketName.Text;
                            lvPacketBox.SelectedItems[0].SubItems[2].Text = txtPacketDLC.Text;
                            lvPacketBox.SelectedItems[0].SubItems[3].Text = txtPacketMessage.Text;
                        }
                    }
                   
                }
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }
            catch (Exception ex)
            {
                ErrorLog.NewLogEntry("edit packet", ex.ToString()+"The XML may be malformed");
               
            }
        }
//added
        private bool packetExists()
        {
            try
            {
                bool flag = false;
                bool packetExists = false;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                if (node == null) //check if there is a better way
                {
                    MessageBox.Show("no car name?");
                }
                XmlNodeList nodelist = node.ChildNodes;
                //Checking if the XML contains that packet
                flag = false;
                foreach (XmlNode chldNode in nodelist)
                {
                    foreach (XmlNode chldNode1 in chldNode.ChildNodes)
                    {
                        if (chldNode1.Name == "ID")
                            if (chldNode1.InnerText.ToLower() == txtPacketId.Text.ToLower())
                                flag = true;
                        if (chldNode1.Name == "Message" && flag)
                            if (chldNode1.InnerText.ToLower() == txtPacketMessage.Text.ToLower())
                            {
                                MessageBox.Show("The Packet was identified in the XML file, you can rename or modify it if you want");
                                packetExists = true;
                                break;
                            }
                    }
                }
                return packetExists;
            }
            catch (Exception ex)
            {
                ErrorLog.NewLogEntry("packet exits-XMLedit-packets", ex.ToString());
                return false;
            }
        }

        private void btnAddPacket_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPacketId.Text) && string.IsNullOrEmpty(txtPacketName.Text) && string.IsNullOrEmpty(txtPacketMessage.Text) && string.IsNullOrEmpty(txtPacketDLC.Text))
                    MessageBox.Show("Please fill out all the fields");
                  
                else
                {
                    if (int.Parse(txtPacketDLC.Text) != txtPacketMessage.Text.Length / 2)
                        MessageBox.Show("Please match the length of the message with DLC");
                    else
                    {
                        if (!packetExists())
                        {
                            // Loads the XML file
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                            XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                            //XmlElement newMSG = xmlDoc.CreateElement("MSG");
                            XmlElement newPacket = xmlDoc.CreateElement("Packet");
                            XmlElement newMessage = xmlDoc.CreateElement("Message");
                            XmlElement newName = xmlDoc.CreateElement("Name");
                            XmlElement newID = xmlDoc.CreateElement("ID");
                            XmlElement newDLC = xmlDoc.CreateElement("DLC");
                            newMessage.InnerText = txtPacketMessage.Text;
                            newName.InnerText = txtPacketName.Text;
                            newID.InnerText = txtPacketId.Text;
                            newDLC.InnerText = txtPacketDLC.Text;
                            node.AppendChild(newPacket);
                            newPacket.AppendChild(newID);
                            newPacket.AppendChild(newName);
                            newPacket.AppendChild(newDLC);
                            newPacket.AppendChild(newMessage);
                            xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
                            lvPacketBox.Items.Add(new ListViewItem(new string[] { txtPacketId.Text, txtPacketName.Text, txtPacketDLC.Text, txtPacketMessage.Text }));
                        }
                    }
                }
                
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }

        private void btnRemovePacket_Click(object sender, EventArgs e)
        {
            try
            {
                // Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                XmlNodeList nList = node.SelectNodes("Packet");
                foreach (XmlNode msg in nList)
                {
                    if (node.SelectSingleNode("Packet") != null)
                    {
                        if (msg.SelectSingleNode("Message").InnerText == txtPacketMessage.Text && msg.SelectSingleNode("Message").InnerText == lvPacketBox.SelectedItems[0].SubItems[3].Text)
                        {
                            msg.ParentNode.RemoveChild(msg);
                            foreach (ListViewItem lvitem in lvPacketBox.SelectedItems)
                                lvPacketBox.Items.Remove(lvitem);
                        }
                    }
                }
                txtPacketDLC.Text = "";
                txtPacketId.Text = "";
                txtPacketMessage.Text = "";
                txtPacketName.Text = "";
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found"+"The XML file maybe malformed");
            }
        }

        private void lvPacketBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPacketBox.SelectedItems.Count > 0)
            {
                txtPacketId.Text = lvPacketBox.SelectedItems[0].Text;
                txtPacketName.Text = lvPacketBox.SelectedItems[0].SubItems[1].Text;
                txtPacketDLC.Text = lvPacketBox.SelectedItems[0].SubItems[2].Text;
                txtPacketMessage.Text = lvPacketBox.SelectedItems[0].SubItems[3].Text;
                
            }
        }


      
    }
}
