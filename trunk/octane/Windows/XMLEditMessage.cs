/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       XMLEditMessage.cs
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
    public partial class XMLEditMessage : Form
    {
        public string CarType { get; set; }
        public XMLEditMessage(string cartype)
        {
            InitializeComponent();
            this.Text = "Edit XML of Messages for " + cartype;
            DoQuery(cartype);
        }
        private void DoQuery(string carType)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
            XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", carType));
            //TransmitBox.Columns.Add("Number", 200, HorizontalAlignment.Left);
            lvMessageBox.Columns.Add("Name", 200, HorizontalAlignment.Left);
            //TransmitBox.Columns.Add("ID", 200, HorizontalAlignment.Left);
            //TransmitBox.Columns.Add("DLC", 200, HorizontalAlignment.Left);
            lvMessageBox.Columns.Add("Message", 200, HorizontalAlignment.Left);
            // TransmitBox.Columns.Add("Flag", 200, HorizontalAlignment.Left);
            // TransmitBox.Columns.Add("Count", 200, HorizontalAlignment.Left);
            // TransmitBox.Columns.Add("TimeBetween", 200, HorizontalAlignment.Left);
          
            ////************************//
            ////later for data grid
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
                        lvMessageBox.Items.Add(new ListViewItem(new string[] { name, message }));
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
                MessageBox.Show(ex.ToString());
            }
        }

     

        private void AddMessage_Click(object sender, EventArgs e)
        {
            try
            {
                // Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                //XmlElement newMSG = xmlDoc.CreateElement("MSG");
                XmlElement newMSG = xmlDoc.CreateElement("Packet");
                XmlElement newMessage = xmlDoc.CreateElement("Message");
                XmlElement newName = xmlDoc.CreateElement("Name");
                newMessage.InnerText = txtMessage.Text;
                newName.InnerText = txtMessageName.Text;
                node.AppendChild(newMSG);
                newMSG.AppendChild(newName);
                newMSG.AppendChild(newMessage);
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
                lvMessageBox.Items.Add(new ListViewItem(new string[] { txtMessageName.Text, txtMessage.Text }));
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }

        private void EditMessage_Click(object sender, EventArgs e)
        {
            try
            {
                // Loads the XML file
                txtMessage.Enabled = false;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                XmlNodeList nList = node.SelectNodes("Packet");
                foreach (XmlNode ecu in nList)
                {
                    if (node.SelectSingleNode("Packet") != null)
                    {
                        if (ecu.SelectSingleNode("Message").InnerText == txtMessage.Text)
                            ecu.SelectSingleNode("Name").InnerText = txtMessageName.Text;
                    }
                }
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }

        }

        private void lvMessageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMessageBox.SelectedItems.Count > 0)
            {
                txtMessageName.Text = lvMessageBox.SelectedItems[0].Text;
                txtMessage.Text = lvMessageBox.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnRemoveMessage_Click(object sender, EventArgs e)
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
                        if (msg.SelectSingleNode("Message").InnerText == txtMessage.Text)
                            msg.ParentNode.RemoveChild(msg);
                        //TransmitBox.Items.Add(new ListViewItem(new string[]{ID, Name}));
                        foreach (ListViewItem lvitem in lvMessageBox.SelectedItems)
                            lvMessageBox.Items.Remove(lvitem);
                        //listBox1.Items.Remove(listBox1.SelectedItem);
                    }
                }
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }

      
    }
}