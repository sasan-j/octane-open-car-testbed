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
    public partial class TestGrid : Form
    {
        public TestGrid()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("colPacket", "Packet");
            dataGridView1.Columns.Add("colID", "ID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.Rows.Count.ToString());
            //dataGridView1.Rows[0].Cells[0].Value = "hi";
            ////dataGridView1.Rows.Add(new string[] { dataGridView1.Rows.Count.ToString() });
            dataGridView1.Rows.Add(new string[] { dataGridView1.Rows.Count.ToString() , "hi"});
           // dataGridView1.Rows[1].Cells[0].Value = "hello";
            //DataGridViewRow dgvr=new DataGridViewRow();
            //dataGridView1.Rows.Insert(dataGridView1.Rows.Count - 1, new DataGridViewRow());
            //dataGridView1.Rows[0].Cells[0].Value = "hi";
            //dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0].Value = "hi";
            //dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            
            
        }
    }
}
