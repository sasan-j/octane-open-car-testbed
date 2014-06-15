/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       XMLEditECU.cs
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
using System.Xml.Linq;

namespace OpenCarTestbed.Windows
{
    public partial class XMLEditECU : Form
    {
        public string CarType { get; set; }
        public XMLEditECU(string cartype)
        {
            InitializeComponent();
            CarType = cartype;
            this.Text = "Edit XML for ECUs for " + cartype;
            DoQuery(cartype);
        }

        private void DoQuery(string carType)
        {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", carType));
                TransmitBox.Columns.Add("ID", 200, HorizontalAlignment.Left);
                TransmitBox.Columns.Add("Name", 200 , HorizontalAlignment.Left);
                try
                {
                    XmlNodeList nList = node.SelectNodes("ECU"); //written by me
                    
                    foreach(XmlNode ecu in nList)
                    {
                        if (node.SelectSingleNode("ECU") != null)
                        {
                            string ID = (ecu.SelectSingleNode("ID").InnerText);
                            string Name = (ecu.SelectSingleNode("Name").InnerText);
                            TransmitBox.Items.Add(new ListViewItem(new string[]{ID, Name}));
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
       }

        private void XMLEditECU_Load(object sender, EventArgs e)
        {

        }

        private void AddECU_Click(object sender, EventArgs e)
        {
            try
            {
                // Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                XmlElement newECU = xmlDoc.CreateElement("ECU");
                XmlElement newID = xmlDoc.CreateElement("ID");
                XmlElement newName = xmlDoc.CreateElement("Name");
                newID.InnerText = txtECUID.Text;
                newName.InnerText = txtECUName.Text;
                node.AppendChild(newECU);
                newECU.AppendChild(newID);
                newECU.AppendChild(newName);
                xmlDoc.Save( ConfigFiles.Settings1.Default.filterURI);
                TransmitBox.Items.Add(new ListViewItem(new string[] { txtECUID.Text, txtECUName.Text }));
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }


        private void ECUList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TransmitBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TransmitBox.SelectedItems.Count > 0)
            {
                txtECUID.Text = TransmitBox.SelectedItems[0].Text;
                txtECUName.Text = TransmitBox.SelectedItems[0].SubItems[1].Text;               

                //TransmitList.SelectedItem.ToString(), TransmitBox.SelectedItems[0].Text

                //PacketBox.Text = XMLInterfaces.ReturnPacketDataDisplay(TransmitList.SelectedItem.ToString(), TransmitBox.SelectedItems[0].Text);
            }
        }

        private void EditECU_Click(object sender, EventArgs e)
        {
            try
            {
                // Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                XmlNodeList nList = node.SelectNodes("ECU"); 
                foreach (XmlNode ecu in nList)
                    {
                        if (node.SelectSingleNode("ECU") != null)
                        {
                            if (ecu.SelectSingleNode("ID").InnerText == TransmitBox.SelectedItems[0].Text)
                            {
                                ecu.SelectSingleNode("Name").InnerText = txtECUName.Text;
                                ecu.SelectSingleNode("ID").InnerText = txtECUID.Text;
                                TransmitBox.SelectedItems[0].Text = txtECUID.Text;
                                TransmitBox.SelectedItems[0].SubItems[1].Text = txtECUName.Text;

                            }
                        }
                }
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }

        // Searches for the ECUs of the carType
        public static ListViewItem[] ReturnECU(string cartype)
        {

            return null;
        }

        private void RemoveECU_Click(object sender, EventArgs e)
        {
            try
            {
                // Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", CarType));
                XmlNodeList nList = node.SelectNodes("ECU");
                foreach (XmlNode ecu in nList)
                {
                    if (node.SelectSingleNode("ECU") != null)
                    {
                        if (ecu.SelectSingleNode("ID").InnerText == txtECUID.Text)
                            ecu.ParentNode.RemoveChild(ecu);
                        //TransmitBox.Items.Add(new ListViewItem(new string[]{ID, Name}));
                        foreach (ListViewItem lvitem in TransmitBox.SelectedItems)
                            TransmitBox.Items.Remove(lvitem);
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