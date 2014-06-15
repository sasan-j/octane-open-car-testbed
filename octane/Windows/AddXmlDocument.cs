/* ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       AddXmlDocument.cs
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
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace OpenCarTestbed.Windows
{
    public partial class AddXmlDocument : Form
    {
        string _id, _dlc, _flag, _data, _cartype, _packetname, _path;
       // public AddXmlDocument(string id,string dlc,string flag, string data)
        public AddXmlDocument(string id,string dlc,string flag, string data, string cartype, string packetname)
        {
            InitializeComponent();
            _id = id;
            _dlc = dlc;
            _flag = flag;
            _data = data;
            _cartype = cartype;
            _packetname = packetname;
        }

        public static XmlTextWriter GetWriterForFolder(string fileName, Encoding encoding)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return null;

            XmlTextWriter writer = new XmlTextWriter(Path.Combine(dlg.SelectedPath, fileName), encoding);
            writer.Formatting = Formatting.Indented;

            return writer;
        }

        public static XmlTextWriter GetWriterForFile(Encoding encoding)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XML Files (*.xml)|*.xml";

            if (dlg.ShowDialog() != DialogResult.OK)
                return null;

            XmlTextWriter writer = new XmlTextWriter(dlg.FileName, encoding);
            writer.Formatting = Formatting.Indented;

            return writer;
        }

        private void btnNewXmlDoc_Click(object sender, EventArgs e)
        {
            try
            {

                TextReader tr = new StringReader("<Cars><CarType></CarType></Cars>");
                XDocument xdoc = new XDocument(XDocument.Load(tr));

                saveFileDialog1.ShowDialog();
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.DefaultExt = ".xml";
                string name = saveFileDialog1.FileName;
                xdoc.Save(name);
                string _path = name;
                //bool newXML, bool defaultXML, bool chosenXML
                //Windows.IdentifyPackets newMDIChild = new Windows.IdentifyPackets(_id, _dlc, _flag, _data, _path, CommonUtils.ConfigFileType.NewDocument);
               // newMDIChild.MdiParent = MainWindow.ActiveForm;
               // newMDIChild.Show();
            }
            catch
            {
                MessageBox.Show("no path was provided");
            }
            
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;
            // Write to the file name selected.
            // ... You can write the text from a TextBox instead of a string literal.
            File.WriteAllText(name, "test");
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {

            
            // try
            //{
                //// Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
            //    XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", _cartype));
              
            //    //// Build the packet node
            //    XmlElement newPacket = xmlDoc.CreateElement("Packet");
            //    XmlElement newID = xmlDoc.CreateElement("ID");
            //    XmlElement newName = xmlDoc.CreateElement("Name");
            //    XmlElement newDLC = xmlDoc.CreateElement("DLC");
            //    XmlElement newFlag = xmlDoc.CreateElement("Flag");
            //    XmlElement newMessage = xmlDoc.CreateElement("Message");
            //    newID.InnerText = _id;
            //    newName.InnerText = _packetname;
            //    newDLC.InnerText = _dlc;
            //    if (_flag != "") //If the flag is not avaialble don't assign NULL value to it
            //    {
            //        newFlag.InnerText = _flag;
            //        newPacket.AppendChild(newFlag);
            //    }
            //    newMessage.InnerText = _data;
            //    node.AppendChild(newPacket);
            //    newPacket.AppendChild(newID);
            //    newPacket.AppendChild(newName);
            //    newPacket.AppendChild(newDLC);
            //    newPacket.AppendChild(newMessage);
            //    xmlDoc.DocumentElement.AppendChild(node);
            //    this.Close();
            //    xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            //}
            //catch (Exception)
            //{
            //    ErrorLog.NewLogEntry("Filter", "URI filename not found");
            //}
        }

        private void loadXmlFile_Click(object sender, EventArgs e)
        {
            //loads the filter
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Select an xml file";
            openFileDialog1.ShowDialog();

            txtFileLocation.Text = openFileDialog1.FileName;
            ConfigFiles.Settings1.Default.filterURI = openFileDialog1.FileName;
            ConfigFiles.Settings1.Default.Save();
            //add the node to the new filter
            //try
            //{
            //    //// Loads the XML file
            //    XmlDocument xmlDoc = new XmlDocument();
            //    xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
            //    XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", _cartype));

            //    //// Build the packet node
            //    XmlElement newPacket = xmlDoc.CreateElement("Packet");
            //    XmlElement newID = xmlDoc.CreateElement("ID");
            //    XmlElement newName = xmlDoc.CreateElement("Name");
            //    XmlElement newDLC = xmlDoc.CreateElement("DLC");
            //    XmlElement newFlag = xmlDoc.CreateElement("Flag");
            //    XmlElement newMessage = xmlDoc.CreateElement("Message");
            //    newID.InnerText = _id;
            //    newName.InnerText = _packetname;
            //    newDLC.InnerText = _dlc;
            //    if (_flag != "") //If the flag is not avaialble don't assign NULL value to it
            //    {
            //        newFlag.InnerText = _flag;
            //        newPacket.AppendChild(newFlag);
            //    }
            //    newMessage.InnerText = _data;
            //    node.AppendChild(newPacket);
            //    newPacket.AppendChild(newID);
            //    newPacket.AppendChild(newName);
            //    newPacket.AppendChild(newDLC);
            //    newPacket.AppendChild(newMessage);
            //    xmlDoc.DocumentElement.AppendChild(node);
            //    xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            //    this.Close();
            //}
            //catch (Exception)
            //{
            //    ErrorLog.NewLogEntry("Filter", "URI filename not found");
            //}


        }

        private void rbNewXML_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                TextReader tr = new StringReader("<Cars><CarType></CarType></Cars>");
                XDocument xmlDoc = new XDocument(XDocument.Load(tr));

                saveFileDialog1.ShowDialog();
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.DefaultExt = ".xml";
                string name = saveFileDialog1.FileName;
                xmlDoc.Save(name);
                _path = name;
                txtFileLocation.Text = name;
                lblCarType.Visible = true;
                txtCarType.Visible = true;
                               // ConfigFiles.Settings1.Default.filterURI = _path;
               // ConfigFiles.Settings1.Default.Save();
            
            //    //newMDIChild.Show();
            //    //add the node to the new filter
                
            //    //XmlDocument xmlDoc = new XmlDocument();
            //    //xmlDoc.Load(_path);
            //    //XmlNode node = xmlDoc.LastNode.
            //    //// Build the packet node
            //    XmlElement newCarType = xmlDoc.CreateElement("Car Type");
            //    XmlElement newPacket = xmlDoc.CreateElement("Packet");
            //    XmlElement newID = xmlDoc.CreateElement("ID");
            //    XmlElement newName = xmlDoc.CreateElement("Name");
            //    XmlElement newDLC = xmlDoc.CreateElement("DLC");
            //    XmlElement newFlag = xmlDoc.CreateElement("Flag");
            //    XmlElement newMessage = xmlDoc.CreateElement("Message");
            //    newID.InnerText = _id;
            //    newName.InnerText = _packetname;
            //    newDLC.InnerText = _dlc;
            //    if (_flag != "") //If the flag is not avaialble don't assign NULL value to it
            //    {
            //        newFlag.InnerText = _flag;
            //        newPacket.AppendChild(newFlag);
            //    }
            //    newMessage.InnerText = _data;
            //    node.AppendChild(newPacket);
            //    newPacket.AppendChild(newID);
            //    newPacket.AppendChild(newName);
            //    newPacket.AppendChild(newDLC);
            //    newPacket.AppendChild(newMessage);
            //    xmlDoc.DocumentElement.AppendChild(node);
            //    xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            //    this.Close();
               
            }
            catch
            {
                MessageBox.Show("no path was provided");
            }
        }

        private void rbLoadXML_CheckedChanged(object sender, EventArgs e)
        {
            //loads the filter
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Select an xml file";
            openFileDialog1.ShowDialog();

            txtFileLocation.Text = openFileDialog1.FileName;
            _path = openFileDialog1.FileName;
            //ConfigFiles.Settings1.Default.filterURI = openFileDialog1.FileName;
           // ConfigFiles.Settings1.Default.Save();
            //add the node to the new filter
            try
            {
                //// Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", _cartype));

                //// Build the packet node
                XmlElement newPacket = xmlDoc.CreateElement("Packet");
                XmlElement newID = xmlDoc.CreateElement("ID");
                XmlElement newName = xmlDoc.CreateElement("Name");
                XmlElement newDLC = xmlDoc.CreateElement("DLC");
                XmlElement newFlag = xmlDoc.CreateElement("Flag");
                XmlElement newMessage = xmlDoc.CreateElement("Message");
                newID.InnerText = _id;
                newName.InnerText = _packetname;
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
                this.Close();
            }
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }

        }

        private void rbDefaultXML_CheckedChanged(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(ConfigFiles.Settings1.Default.filterURI))
            {
                // try
                //{
                //// Loads the XML file
                txtFileLocation.Text = ConfigFiles.Settings1.Default.filterURI;
                _path = txtFileLocation.Text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_path);
                //    XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", _cartype));

                //    //// Build the packet node
                //    XmlElement newPacket = xmlDoc.CreateElement("Packet");
                //    XmlElement newID = xmlDoc.CreateElement("ID");
                //    XmlElement newName = xmlDoc.CreateElement("Name");
                //    XmlElement newDLC = xmlDoc.CreateElement("DLC");
                //    XmlElement newFlag = xmlDoc.CreateElement("Flag");
                //    XmlElement newMessage = xmlDoc.CreateElement("Message");
                //    newID.InnerText = _id;
                //    newName.InnerText = _packetname;
                //    newDLC.InnerText = _dlc;
                //    if (_flag != "") //If the flag is not avaialble don't assign NULL value to it
                //    {
                //        newFlag.InnerText = _flag;
                //        newPacket.AppendChild(newFlag);
                //    }
                //    newMessage.InnerText = _data;
                //    node.AppendChild(newPacket);
                //    newPacket.AppendChild(newID);
                //    newPacket.AppendChild(newName);
                //    newPacket.AppendChild(newDLC);
                //    newPacket.AppendChild(newMessage);
                //    xmlDoc.DocumentElement.AppendChild(node);
                //    this.Close();
                //    xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
                //}
                //catch (Exception)
                //{
                //    ErrorLog.NewLogEntry("Filter", "URI filename not found");
                //}
            }
            else
            {
                MessageBox.Show("Please select a default xml file.");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string _carname = txtCarType.Text;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);
            XmlNode node = xmlDoc.SelectSingleNode("/Cars/CarType");
            XmlElement newCarName = xmlDoc.CreateElement("CarName");
            newCarName.InnerText = _carname;
            node.AppendChild(newCarName);
            xmlDoc.Save(_path);
            //Windows.IdentifyPackets newMDIChild = new Windows.IdentifyPackets(_id, _dlc, _flag, _data, _path, _carname, CommonUtils.ConfigFileType.NewDocument);
            //newMDIChild.MdiParent = MainWindow.ActiveForm;
            //newMDIChild.Show();


        }
          
      
    }
        }
  
