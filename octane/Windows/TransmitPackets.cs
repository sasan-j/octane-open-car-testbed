/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       TransmitPackets.cs
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
using canlibCLSNET;

namespace OpenCarTestbed
{
    public partial class TransmitPackets : Form
    {
        public void ShowForm(CanData can)
        {
            _can = can;
            
            List<TextBox> textboxes = new List<TextBox>();
            textboxes.Add(Transmit_msg0);
            textboxes.Add(Transmit_msg1);
            textboxes.Add(Transmit_msg2);
            textboxes.Add(Transmit_msg3);
            textboxes.Add(Transmit_msg4);
            textboxes.Add(Transmit_msg5);
            textboxes.Add(Transmit_msg6);
            textboxes.Add(Transmit_msg7);

            Transmit_id.Text = String.Format("{0:X3}",_can.id);
            Transmit_dlc.Value = _can.dlc;
            TransmitInterfaceBox.SelectedItem = _can.hardware;
            for (int i = 0; i < _can.dlc; i++)
            {
                textboxes[i].Text = String.Format("{0:X2}", _can.msg[i]);
            }
            if (_can.flags == 2)
                Flag_Std.Checked = true;
            if (_can.flags == 4)
                Flag_Ext.Checked = true;
            if (_can.flags == 32)
                Flag_Err.Checked = true;
            if (_can.flags == 1)
                Flag_Rtr.Checked = true;
        }

        protected CanData _can;
        public TransmitPackets()
        {
            InitializeComponent();

            Transmit_msg0.GotFocus += delegate
            {
                Transmit_msg0.SelectAll();
            };

            
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

        //****************************
        // Transmit Settings Tab
        // Written by Parnian Najafi Borazjani
        //****************************
        private void TransmitPacket_Click(object sender, EventArgs e)
        {
            CanData can = new CanData();
            int number_messages = 1;
            string msgOutput = "";
            string flag;
            //if (Transmit_dlc.Value>8)
            //    MessageBox.Show("Messages can have a maximum of 8");
            // For the various flags
            // Need to implement an enumerated keyword to replace these numbers
            // These numbers are from the Kvaser library documentation and may not work on other CAN systems
            if (Flag_Ext.Checked == true)
                flag = "X";                     // Extended 
            else if (Flag_Err.Checked == true)
                flag = "E";                     // Error
            else if (Flag_Rtr.Checked == true)
                flag = "R";                     // Remote
            else
                flag = "S";                     // Standard

            if (InputTests.IsStringNumeric(Transmit_NoMsg.Text) == true)
                number_messages = Convert.ToInt32(Transmit_NoMsg.Text);
            else
                MessageBox.Show("Error: Number of Messages is not Numeric", "Error", MessageBoxButtons.OK);

            msgOutput = Transmit_id.Text + ";" + Transmit_dlc.Text + ";" + flag + ";" + Transmit_msg0.Text + "-" + Transmit_msg1.Text + "-" + Transmit_msg2.Text + "-" + Transmit_msg3.Text + "-" + Transmit_msg4.Text + "-" + Transmit_msg5.Text + "-" + Transmit_msg6.Text + "-" + Transmit_msg7.Text;

            if (Transmit_Hex.Checked == true)
                can.format = "hex";
            else
                can.format = "decimal";

            CommonUtils.ConvertStringtoCAN(can, msgOutput);    

            can.number = number_messages;
            can.timeBtw = 0;
            try
            {
                can.hardware = TransmitInterfaceBox.SelectedItem.ToString();

            if (IncrementIdentifier.Checked == true)
                    can.increment = true;

            GenericCanBus.GenericCanTransmitMultiple(can);
            //bgTransmit.RunWorkerAsync(can);  

            toolStripStatusLabel2.Text = CommonUtils.ErrorMsg("Transmit Message", can.status);
            ErrorLog.NewLogEntry("CAN", "Transmit Message: " + can.status);

            if (VerboseTransmit.Checked == true)
                MessageBox.Show(CommonUtils.DisplayMsg(can));
            }
            catch
            {
                MessageBox.Show("No interface is turned on, please turn on the interfaces from \"Advanced Bus Control\" Window");
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
            GenericCanBus.GenericCanTransmitMultiple(can);
        }

        private void TransmitPackets_Load(object sender, EventArgs e)
        {

        }

        //Gives an error message if the textbox is filled with something other than hex values
        private void Transmit_msg0_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string value = textBox.Text;
            if (!CommonUtils.CheckHexValue(value))
            {
                textBox.Text = value.Remove(value.Length - 1, 1);
                textBox.SelectionStart = textBox.Text.Length;
                MessageBox.Show("Please enter a valid hex value!");
            }
        }

        //Selects the text when mouse is clicked to make the overwrite easy
        private void Transmit_msg0_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void Transmit_msg0_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string value = textBox.Text;
             if (textBox.TextLength != 2)
            {
                MessageBox.Show("Only two digits hex values are allowed");
                textBox.Clear();
                textBox.Focus();
            }
        }

        private void Transmit_NoMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (!Char.IsDigit(e.KeyChar))
                {
                    MessageBox.Show("Please enter digits only");
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Transmit_Decimal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_Hex_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_NoMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void Transmit_dlc_ValueChanged(object sender, EventArgs e)
        {
            if (Transmit_dlc.Value > 8)
                MessageBox.Show("The length of the message can have a maximum of 8");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void IncrementIdentifier_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void VerboseTransmit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Flag_Rtr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Flag_Err_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Flag_Ext_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Flag_Std_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TransmitInterfaceBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshInterfaces_Click(object sender, EventArgs e)
        {

        }

    }
}