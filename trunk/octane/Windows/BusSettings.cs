/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       BusSettings.cs
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
    public partial class BusSettings : Form
    {

        public BusSettings()
        {
            InitializeComponent();
        }

        //****************************
        // Bus Settings Tab
        //****************************
        private void RetrieveBus_Click(object sender, EventArgs e)
        {

            Canlib.canStatus status;
            long bitrate;
            int tseg1;
            int tseg2;
            int sjw;
            int noSamp;
            int syncmode;
            int canHandle = 0;

            status = Canlib.canGetBusParams(canHandle, out bitrate, out tseg1, out tseg2, out sjw, out noSamp, out syncmode);
            toolStripStatusLabel1.Text = CommonUtils.ErrorMsg("Retrieve Bus", status);

            if (status == 0)
            {
                bitrateBox.Text = bitrate.ToString();
                tseg1Box.Text = tseg1.ToString();
                tseg2Box.Text = tseg2.ToString();
                sjwBox.Text = sjw.ToString();
                noSampBox.Text = noSamp.ToString();
            }
        }

        private void SetBus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Set Bus Pending");
        }
    }
}