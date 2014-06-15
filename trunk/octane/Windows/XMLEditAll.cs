/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       XMLEditAll.cs
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

namespace OpenCarTestbed.Windows
{
    public partial class XMLEditAll : Form
    {
        public XMLEditAll()
        {
            InitializeComponent();
            LoadListTransmit();
        }

        // Loads the available transmission buttons from the xml file into the transmit listing
        private void LoadListTransmit()
        {
            // Clear any current items
            TransmitList.Items.Clear();

            // returns a string array of the available filter types from the XMLInterfaces
            string[] transmittypes = XMLInterfaces.ReturnTransmitTypes(ConfigFiles.Settings1.Default.filterURI);

            // for each string in the string array an item is added to the filterlist
            if (transmittypes != null)
            {
                for (int x = 0; x < transmittypes.Length; x++)
                {
                    TransmitList.Items.Add(transmittypes[x]);
                }

                toolStripStatusLabel2.Text = "Find Transmit Cars";
            }
        }

        private void TransmitList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransmitBox.Columns.Clear();
            TransmitBox.Items.Clear();

            TransmitBox.Columns.Add("Name", 135, HorizontalAlignment.Left);
            TransmitBox.Columns.Add("Packet Type", 85, HorizontalAlignment.Left);

            string[] packets = XMLInterfaces.ReturnPackets(TransmitList.SelectedItem.ToString());

            for (int y = 0; y < packets.Length; y++)
            {
                string[] output = packets[y].Split(';');
                ListViewItem item = new ListViewItem(output);
                TransmitBox.Items.AddRange(new ListViewItem[] { item });
            }

            //// Sets all of the variables for the selected filter
            //TransmitFilter = TransmitList.SelectedItem.ToString();
            //TransmitLoadLabel.Text = TransmitList.SelectedItem.ToString();
        }

        private void TransmitBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
