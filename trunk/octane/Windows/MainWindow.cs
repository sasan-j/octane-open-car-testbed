/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       MainWindow.cs
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

using OpenCarTestbed.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using canlibCLSNET;


namespace OpenCarTestbed
{
    public partial class MainWindow : Form
    {
        public string CurrentTPUserFormId { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //Starts a window for the Bus Control
            BusControl newMDIChild = new BusControl();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

            //BusMonitorCompact bmc = new BusMonitorCompact();
            //bmc.ShowDialog();
            
            //Checks to see if the guided bus control should be started
            if (ConfigFiles.Settings1.Default.skipGuidedBusControl == false)
            {
                Windows.GuidedBusControl newMDIChild2 = new Windows.GuidedBusControl();
                newMDIChild2.MdiParent = this;
                newMDIChild2.Show();
            }
            
        }

        //****************************
        // Error Box for debugging
        //****************************

        public static void ErrorDisplayString(string msgInput)
        {
            MessageBox.Show("Error: \n" + msgInput, "Error Display", MessageBoxButtons.OK);
        }

        public static void ErrorDisplayByte(byte byteInput)
        {
            MessageBox.Show(String.Format("Byte Output: \n{0:X2}", byteInput));
        }

        public static void ErrorDisplayByteArray(byte[] byteInput)
        {
            string msgOutput = "";

            for (int i = 0; i < 8; i++)
            {
                msgOutput += String.Format("  {0:X2}", byteInput[i]);
            }

            MessageBox.Show("Byte Output: " + msgOutput);
        }



        //****************************
        // Menu Strip Settings Tab
        //****************************
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Close();
        }

        private void openConfigurationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Windows.Configuration newMDIChild = new Windows.Configuration();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        
        private void monitorBusMultiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusMonitorColumn newMDIChild = new BusMonitorColumn();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentTPUserFormId))
            {
                BusMonitorColumn newMDIChild = new BusMonitorColumn();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
                CurrentTPUserFormId = newMDIChild.FormId;
            }
        }

        private void transmitPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransmitPackets newMDIChild = new TransmitPackets();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TransmitPackets newMDIChild = new TransmitPackets();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void customTransmitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomTransmit newMDIChild = new CustomTransmit();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CustomTransmit newMDIChild = new CustomTransmit();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void busSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusSettings newMDIChild = new BusSettings();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void busControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusControl newMDIChild = new BusControl();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }


        private void editXMLDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Windows.XMLEdit newMDIChild = new Windows.XMLEdit();
           newMDIChild.MdiParent = this;
           newMDIChild.Show();
        }

        private void XMLEdit_Click(object sender, EventArgs e)
        {
            Windows.XMLEdit newMDIChild = new Windows.XMLEdit();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void logWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.LogWindow newMDIChild = new Windows.LogWindow();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButtonLogWindow_Click(object sender, EventArgs e)
        {
            Windows.LogWindow newMDIChild = new Windows.LogWindow();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void guidedBusControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.GuidedBusControl newMDIChild = new Windows.GuidedBusControl();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButtonAdvancedBusControl_Click(object sender, EventArgs e)
        {
            BusControl newMDIChild = new BusControl();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButtonGuidedBusControl_Click(object sender, EventArgs e)
        {
            Windows.GuidedBusControl newMDIChild = new Windows.GuidedBusControl();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }



        //*****************
        // Window layout commands from menu
        //*****************
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void iconWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void tileWindowsVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentTPUserFormId))
            {
                BusMonitorCompact newMDIChild = new BusMonitorCompact();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
                CurrentTPUserFormId = newMDIChild.FormId;
            }
        }



 













    }
}