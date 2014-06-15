using OpenCarTestbed.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace OpenCarTestbed.Windows
{
    public partial class RenamePackets : Form

    {
        public string _id, _dlc, _flag, _data, _path, _carname,_packetname; 
        public BusMonitorColumn BusMonitorColumnParentForm { get; set; }
        public BusMonitorCompact BusMonitorCompactParentForm { get; set; }

        
       public RenamePackets(string id, string dlc, string flag, string data, string packetName, string carname)
        {

            InitializeComponent();
            _id = id;
            _dlc = dlc;
            _flag = flag;
            _data = data;
            _path = ConfigFiles.Settings1.Default.filterURI;
            _packetname = packetName;
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
        }

        private void LoadListTransmit()
        {
            // returns a string array of the available filter types from the XMLInterfaces
            string[] transmittypes = XMLInterfaces.ReturnTransmitTypes(_path);
            Transmit_id.Text = _id;
            txtPacketName.Text = _packetname;
            try
            {
                _data = Regex.Replace(_data, @"\s", "");

                _data.Replace(" ", "");
                Transmit_msg0.Text = _data.Substring(0, 2);
                Transmit_msg1.Text = _data.Substring(2, 2);
                Transmit_msg2.Text = _data.Substring(4, 2);
                Transmit_msg3.Text = _data.Substring(6, 2);
                Transmit_msg4.Text = _data.Substring(8, 2);
                Transmit_msg5.Text = _data.Substring(10, 2);
                Transmit_msg6.Text = _data.Substring(12, 2);
                txtCarType.Text = findCarName(_id,_data);
                //txtCarType.Visible = true; //useful for next versions

            }
            catch (Exception ex)
            {
                FileLog.Log("problem using regular expression" + ex.ToString());
            }
        }


        //*********************************************
        //find the name of the car that has the specific id and message
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private string findCarName(string id, string message)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes(string.Format("//Packet[ID='{0}' and Message= '{1}']", id, message));
            foreach (XmlNode node in nodes)
                return node.ParentNode.InnerText;
            return "";
        }





        //*********************************************
        //change the name of the matching packet based on the id and message
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void changeName(string id, string message)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);
            XmlNodeList nodes = xmlDoc.SelectNodes(string.Format("//Packet[ID='{0}' and Message= '{1}']", id, message));
            foreach (XmlNode chldNode1 in nodes)
            {
                foreach (XmlNode chldNode in chldNode1)
                {
                    if (chldNode.Name.ToLower() == "name")
                        chldNode.InnerText = txtPacketName.Text;
                }
            }
            xmlDoc.Save(_path);
        }


        //*********************************************
        //show the new name of the matching packet based on the id and message in the monitor bus
        //Written by Parnian Najafi Borazjani
        //*********************************************
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


        //*********************************************
        //change the name of the matching packet based on the id and message
        //Written by Parnian Najafi Borazjani
        //*********************************************
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtPacketName.Text)) && (BusMonitorColumnParentForm != null))
                {
                    BusMonitorColumnParentForm.IdentifiedPacketName = txtPacketName.Text;
                    BusMonitorColumnParentForm.IdentifiedId = Transmit_id.Text;
                    BusMonitorColumnParentForm.IdentifiedMessage = _data;// (Transmit_msg0.Text + Transmit_msg1.Text + Transmit_msg2.Text + Transmit_msg3.Text + Transmit_msg4.Text + Transmit_msg5.Text + Transmit_msg6.Text + Transmit_msg7.Text).Replace(" ", "");
                }
                if (!(string.IsNullOrEmpty(txtPacketName.Text)) && (BusMonitorCompactParentForm != null))
                {
                    BusMonitorCompactParentForm.IdentifiedPacketName = txtPacketName.Text;
                    BusMonitorCompactParentForm.IdentifiedId = Transmit_id.Text;
                    BusMonitorCompactParentForm.IdentifiedMessage = _data;//(Transmit_msg0.Text + Transmit_msg1.Text + Transmit_msg2.Text + Transmit_msg3.Text + Transmit_msg4.Text + Transmit_msg5.Text + Transmit_msg6.Text + Transmit_msg7.Text).Replace(" ", "");
                }
                changeName(Transmit_id.Text, _data);//(Transmit_msg0.Text + Transmit_msg1.Text + Transmit_msg2.Text + Transmit_msg3.Text + Transmit_msg4.Text + Transmit_msg5.Text + Transmit_msg6.Text + Transmit_msg7.Text).Replace(" ", ""));//, findCarNameNode(Transmit_id.Text, (Transmit_msg0.Text + Transmit_msg1.Text + Transmit_msg2.Text + Transmit_msg3.Text + Transmit_msg4.Text + Transmit_msg5.Text + Transmit_msg6.Text + Transmit_msg7.Text).Replace(" ", "")));
                GeneralIdentify();
                this.Close();
            }
            catch (Exception ex)
            {
                FileLog.Log(ex.ToString());
            }
            
        }
    }
}
