/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       LogWindow.cs
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

namespace OpenCarTestbed.Windows
{
    public partial class LogWindow : Form
    {
        public LogWindow()
        {
            InitializeComponent();
            RefreshLog();
        }

        // Refreshes the display with the new log entries
        private void RefreshLog()
        {

            // Clears the columns and items from the logView
            logView.Columns.Clear();
            logView.Items.Clear();

            // Setups up the columns for the logView
            logView.Columns.Add("Log Type", 85, HorizontalAlignment.Left);
            logView.Columns.Add("Message", 350, HorizontalAlignment.Left);

            string[] errors = ErrorLog.ReturnErrors();

            for (int x = 0; x < errors.Length; x++)
            {
                string[] output = errors[x].Split(';');
                ListViewItem item = new ListViewItem(output);
                logView.Items.AddRange(new ListViewItem[] { item });
            }
        }

        // Clears the log messages
        private void clearLog_Click(object sender, EventArgs e)
        {
            ErrorLog.ResetErrors();
            RefreshLog();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshLog();
        }

    }
}