namespace OpenCarTestbed
{
    partial class TransmitPackets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransmitPackets));
            this.IncrementIdentifier = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Transmit_Decimal = new System.Windows.Forms.RadioButton();
            this.Transmit_Hex = new System.Windows.Forms.RadioButton();
            this.Transmit_NoMsg = new System.Windows.Forms.TextBox();
            this.Transmit_dlc = new System.Windows.Forms.NumericUpDown();
            this.Transmit_msg7 = new System.Windows.Forms.TextBox();
            this.Transmit_msg6 = new System.Windows.Forms.TextBox();
            this.Transmit_msg5 = new System.Windows.Forms.TextBox();
            this.Transmit_msg4 = new System.Windows.Forms.TextBox();
            this.Transmit_msg3 = new System.Windows.Forms.TextBox();
            this.Transmit_msg2 = new System.Windows.Forms.TextBox();
            this.Transmit_msg1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Transmit_msg0 = new System.Windows.Forms.TextBox();
            this.Transmit_id = new System.Windows.Forms.TextBox();
            this.TransmitPacket = new System.Windows.Forms.Button();
            this.VerboseTransmit = new System.Windows.Forms.CheckBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Flag_Rtr = new System.Windows.Forms.RadioButton();
            this.Flag_Err = new System.Windows.Forms.RadioButton();
            this.Flag_Ext = new System.Windows.Forms.RadioButton();
            this.Flag_Std = new System.Windows.Forms.RadioButton();
            this.bgTransmit = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.TransmitInterfaceBox = new System.Windows.Forms.ComboBox();
            this.RefreshInterfaces = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transmit_dlc)).BeginInit();
            this.toolStripStatusLabel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IncrementIdentifier
            // 
            this.IncrementIdentifier.AutoSize = true;
            this.IncrementIdentifier.Location = new System.Drawing.Point(340, 24);
            this.IncrementIdentifier.Name = "IncrementIdentifier";
            this.IncrementIdentifier.Size = new System.Drawing.Size(116, 17);
            this.IncrementIdentifier.TabIndex = 54;
            this.IncrementIdentifier.Text = "Increment Identifier";
            this.IncrementIdentifier.UseVisualStyleBackColor = true;
            this.IncrementIdentifier.CheckedChanged += new System.EventHandler(this.IncrementIdentifier_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Transmit_Decimal);
            this.panel2.Controls.Add(this.Transmit_Hex);
            this.panel2.Location = new System.Drawing.Point(450, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(137, 85);
            this.panel2.TabIndex = 52;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Transmit_Decimal
            // 
            this.Transmit_Decimal.AutoSize = true;
            this.Transmit_Decimal.Enabled = false;
            this.Transmit_Decimal.Location = new System.Drawing.Point(18, 12);
            this.Transmit_Decimal.Name = "Transmit_Decimal";
            this.Transmit_Decimal.Size = new System.Drawing.Size(63, 17);
            this.Transmit_Decimal.TabIndex = 10;
            this.Transmit_Decimal.Text = "Decimal";
            this.Transmit_Decimal.UseVisualStyleBackColor = true;
            this.Transmit_Decimal.CheckedChanged += new System.EventHandler(this.Transmit_Decimal_CheckedChanged);
            // 
            // Transmit_Hex
            // 
            this.Transmit_Hex.AutoSize = true;
            this.Transmit_Hex.Checked = true;
            this.Transmit_Hex.Location = new System.Drawing.Point(18, 36);
            this.Transmit_Hex.Name = "Transmit_Hex";
            this.Transmit_Hex.Size = new System.Drawing.Size(44, 17);
            this.Transmit_Hex.TabIndex = 11;
            this.Transmit_Hex.TabStop = true;
            this.Transmit_Hex.Text = "Hex";
            this.Transmit_Hex.UseVisualStyleBackColor = true;
            this.Transmit_Hex.CheckedChanged += new System.EventHandler(this.Transmit_Hex_CheckedChanged);
            // 
            // Transmit_NoMsg
            // 
            this.Transmit_NoMsg.Location = new System.Drawing.Point(221, 152);
            this.Transmit_NoMsg.Name = "Transmit_NoMsg";
            this.Transmit_NoMsg.Size = new System.Drawing.Size(100, 20);
            this.Transmit_NoMsg.TabIndex = 51;
            this.Transmit_NoMsg.Text = "1";
            this.Transmit_NoMsg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_NoMsg.TextChanged += new System.EventHandler(this.Transmit_NoMsg_TextChanged);
            this.Transmit_NoMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Transmit_NoMsg_KeyPress);
            // 
            // Transmit_dlc
            // 
            this.Transmit_dlc.Location = new System.Drawing.Point(177, 107);
            this.Transmit_dlc.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.Transmit_dlc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Transmit_dlc.Name = "Transmit_dlc";
            this.Transmit_dlc.Size = new System.Drawing.Size(120, 20);
            this.Transmit_dlc.TabIndex = 50;
            this.Transmit_dlc.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.Transmit_dlc.ValueChanged += new System.EventHandler(this.Transmit_dlc_ValueChanged);
            // 
            // Transmit_msg7
            // 
            this.Transmit_msg7.Location = new System.Drawing.Point(485, 64);
            this.Transmit_msg7.MaxLength = 2;
            this.Transmit_msg7.Name = "Transmit_msg7";
            this.Transmit_msg7.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg7.TabIndex = 49;
            this.Transmit_msg7.Text = "00";
            this.Transmit_msg7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg7.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg7.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // Transmit_msg6
            // 
            this.Transmit_msg6.Location = new System.Drawing.Point(441, 64);
            this.Transmit_msg6.MaxLength = 2;
            this.Transmit_msg6.Name = "Transmit_msg6";
            this.Transmit_msg6.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg6.TabIndex = 48;
            this.Transmit_msg6.Text = "00";
            this.Transmit_msg6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg6.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg6.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // Transmit_msg5
            // 
            this.Transmit_msg5.Location = new System.Drawing.Point(397, 64);
            this.Transmit_msg5.MaxLength = 2;
            this.Transmit_msg5.Name = "Transmit_msg5";
            this.Transmit_msg5.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg5.TabIndex = 47;
            this.Transmit_msg5.Text = "00";
            this.Transmit_msg5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg5.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg5.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // Transmit_msg4
            // 
            this.Transmit_msg4.Location = new System.Drawing.Point(353, 64);
            this.Transmit_msg4.MaxLength = 2;
            this.Transmit_msg4.Name = "Transmit_msg4";
            this.Transmit_msg4.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg4.TabIndex = 46;
            this.Transmit_msg4.Text = "00";
            this.Transmit_msg4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg4.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg4.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // Transmit_msg3
            // 
            this.Transmit_msg3.Location = new System.Drawing.Point(309, 64);
            this.Transmit_msg3.MaxLength = 2;
            this.Transmit_msg3.Name = "Transmit_msg3";
            this.Transmit_msg3.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg3.TabIndex = 45;
            this.Transmit_msg3.Text = "00";
            this.Transmit_msg3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg3.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg3.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // Transmit_msg2
            // 
            this.Transmit_msg2.Location = new System.Drawing.Point(265, 64);
            this.Transmit_msg2.MaxLength = 2;
            this.Transmit_msg2.Name = "Transmit_msg2";
            this.Transmit_msg2.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg2.TabIndex = 44;
            this.Transmit_msg2.Text = "00";
            this.Transmit_msg2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg2.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg2.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // Transmit_msg1
            // 
            this.Transmit_msg1.Location = new System.Drawing.Point(221, 64);
            this.Transmit_msg1.MaxLength = 2;
            this.Transmit_msg1.Name = "Transmit_msg1";
            this.Transmit_msg1.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg1.TabIndex = 43;
            this.Transmit_msg1.Text = "00";
            this.Transmit_msg1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg1.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg1.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Number of Message to Transmit";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Flag";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Length of Message";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "CAN Message";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "CAN Identifier";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // Transmit_msg0
            // 
            this.Transmit_msg0.Location = new System.Drawing.Point(177, 64);
            this.Transmit_msg0.MaxLength = 2;
            this.Transmit_msg0.Name = "Transmit_msg0";
            this.Transmit_msg0.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg0.TabIndex = 36;
            this.Transmit_msg0.Text = "00";
            this.Transmit_msg0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_msg0.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            this.Transmit_msg0.Leave += new System.EventHandler(this.Transmit_msg0_Leave);
            // 
            // Transmit_id
            // 
            this.Transmit_id.Location = new System.Drawing.Point(177, 24);
            this.Transmit_id.MaxLength = 3;
            this.Transmit_id.Name = "Transmit_id";
            this.Transmit_id.Size = new System.Drawing.Size(100, 20);
            this.Transmit_id.TabIndex = 35;
            this.Transmit_id.Text = "100";
            this.Transmit_id.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Transmit_msg0_MouseClick);
            this.Transmit_id.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            // 
            // TransmitPacket
            // 
            this.TransmitPacket.Location = new System.Drawing.Point(46, 265);
            this.TransmitPacket.Name = "TransmitPacket";
            this.TransmitPacket.Size = new System.Drawing.Size(142, 29);
            this.TransmitPacket.TabIndex = 34;
            this.TransmitPacket.Text = "Transmit Packet(s)";
            this.TransmitPacket.UseVisualStyleBackColor = true;
            this.TransmitPacket.Click += new System.EventHandler(this.TransmitPacket_Click);
            // 
            // VerboseTransmit
            // 
            this.VerboseTransmit.AutoSize = true;
            this.VerboseTransmit.Location = new System.Drawing.Point(46, 318);
            this.VerboseTransmit.Name = "VerboseTransmit";
            this.VerboseTransmit.Size = new System.Drawing.Size(143, 17);
            this.VerboseTransmit.TabIndex = 55;
            this.VerboseTransmit.Text = "Verbose Transmit Output";
            this.VerboseTransmit.UseVisualStyleBackColor = true;
            this.VerboseTransmit.CheckedChanged += new System.EventHandler(this.VerboseTransmit_CheckedChanged);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(0, 346);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(631, 22);
            this.toolStripStatusLabel1.TabIndex = 56;
            this.toolStripStatusLabel1.Text = "Transmit Packets";
            this.toolStripStatusLabel1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripStatusLabel1_ItemClicked);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(97, 17);
            this.toolStripStatusLabel2.Text = "Transmit Packets";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Flag_Rtr);
            this.panel1.Controls.Add(this.Flag_Err);
            this.panel1.Controls.Add(this.Flag_Ext);
            this.panel1.Controls.Add(this.Flag_Std);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(369, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 127);
            this.panel1.TabIndex = 57;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Flag_Rtr
            // 
            this.Flag_Rtr.AutoSize = true;
            this.Flag_Rtr.Location = new System.Drawing.Point(20, 93);
            this.Flag_Rtr.Name = "Flag_Rtr";
            this.Flag_Rtr.Size = new System.Drawing.Size(62, 17);
            this.Flag_Rtr.TabIndex = 3;
            this.Flag_Rtr.TabStop = true;
            this.Flag_Rtr.Text = "Remote";
            this.Flag_Rtr.UseVisualStyleBackColor = true;
            this.Flag_Rtr.CheckedChanged += new System.EventHandler(this.Flag_Rtr_CheckedChanged);
            // 
            // Flag_Err
            // 
            this.Flag_Err.AutoSize = true;
            this.Flag_Err.Location = new System.Drawing.Point(20, 69);
            this.Flag_Err.Name = "Flag_Err";
            this.Flag_Err.Size = new System.Drawing.Size(47, 17);
            this.Flag_Err.TabIndex = 2;
            this.Flag_Err.TabStop = true;
            this.Flag_Err.Text = "Error";
            this.Flag_Err.UseVisualStyleBackColor = true;
            this.Flag_Err.CheckedChanged += new System.EventHandler(this.Flag_Err_CheckedChanged);
            // 
            // Flag_Ext
            // 
            this.Flag_Ext.AutoSize = true;
            this.Flag_Ext.Location = new System.Drawing.Point(20, 45);
            this.Flag_Ext.Name = "Flag_Ext";
            this.Flag_Ext.Size = new System.Drawing.Size(70, 17);
            this.Flag_Ext.TabIndex = 1;
            this.Flag_Ext.TabStop = true;
            this.Flag_Ext.Text = "Extended";
            this.Flag_Ext.UseVisualStyleBackColor = true;
            this.Flag_Ext.CheckedChanged += new System.EventHandler(this.Flag_Ext_CheckedChanged);
            // 
            // Flag_Std
            // 
            this.Flag_Std.AutoSize = true;
            this.Flag_Std.Checked = true;
            this.Flag_Std.Location = new System.Drawing.Point(20, 21);
            this.Flag_Std.Name = "Flag_Std";
            this.Flag_Std.Size = new System.Drawing.Size(68, 17);
            this.Flag_Std.TabIndex = 0;
            this.Flag_Std.TabStop = true;
            this.Flag_Std.Text = "Standard";
            this.Flag_Std.UseVisualStyleBackColor = true;
            this.Flag_Std.CheckedChanged += new System.EventHandler(this.Flag_Std_CheckedChanged);
            // 
            // bgTransmit
            // 
            this.bgTransmit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgTransmit_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Transmit Interface";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TransmitInterfaceBox
            // 
            this.TransmitInterfaceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TransmitInterfaceBox.FormattingEnabled = true;
            this.TransmitInterfaceBox.Location = new System.Drawing.Point(110, 187);
            this.TransmitInterfaceBox.Name = "TransmitInterfaceBox";
            this.TransmitInterfaceBox.Size = new System.Drawing.Size(253, 21);
            this.TransmitInterfaceBox.TabIndex = 58;
            this.TransmitInterfaceBox.SelectedIndexChanged += new System.EventHandler(this.TransmitInterfaceBox_SelectedIndexChanged);
            // 
            // RefreshInterfaces
            // 
            this.RefreshInterfaces.Location = new System.Drawing.Point(312, 296);
            this.RefreshInterfaces.Name = "RefreshInterfaces";
            this.RefreshInterfaces.Size = new System.Drawing.Size(132, 23);
            this.RefreshInterfaces.TabIndex = 60;
            this.RefreshInterfaces.Text = "Refresh Interfaces";
            this.RefreshInterfaces.UseVisualStyleBackColor = true;
            this.RefreshInterfaces.Click += new System.EventHandler(this.RefreshInterfaces_Click);
            // 
            // TransmitPackets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 368);
            this.Controls.Add(this.RefreshInterfaces);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransmitInterfaceBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripStatusLabel1);
            this.Controls.Add(this.VerboseTransmit);
            this.Controls.Add(this.IncrementIdentifier);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Transmit_NoMsg);
            this.Controls.Add(this.Transmit_dlc);
            this.Controls.Add(this.Transmit_msg7);
            this.Controls.Add(this.Transmit_msg6);
            this.Controls.Add(this.Transmit_msg5);
            this.Controls.Add(this.Transmit_msg4);
            this.Controls.Add(this.Transmit_msg3);
            this.Controls.Add(this.Transmit_msg2);
            this.Controls.Add(this.Transmit_msg1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Transmit_msg0);
            this.Controls.Add(this.Transmit_id);
            this.Controls.Add(this.TransmitPacket);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransmitPackets";
            this.Text = "Transmit Packets";
            this.Load += new System.EventHandler(this.TransmitPackets_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transmit_dlc)).EndInit();
            this.toolStripStatusLabel1.ResumeLayout(false);
            this.toolStripStatusLabel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox IncrementIdentifier;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton Transmit_Decimal;
        private System.Windows.Forms.RadioButton Transmit_Hex;
        private System.Windows.Forms.TextBox Transmit_NoMsg;
        private System.Windows.Forms.NumericUpDown Transmit_dlc;
        private System.Windows.Forms.TextBox Transmit_msg7;
        private System.Windows.Forms.TextBox Transmit_msg6;
        private System.Windows.Forms.TextBox Transmit_msg5;
        private System.Windows.Forms.TextBox Transmit_msg4;
        private System.Windows.Forms.TextBox Transmit_msg3;
        private System.Windows.Forms.TextBox Transmit_msg2;
        private System.Windows.Forms.TextBox Transmit_msg1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Transmit_msg0;
        private System.Windows.Forms.TextBox Transmit_id;
        private System.Windows.Forms.Button TransmitPacket;
        private System.Windows.Forms.CheckBox VerboseTransmit;
        private System.Windows.Forms.StatusStrip toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Flag_Rtr;
        private System.Windows.Forms.RadioButton Flag_Err;
        private System.Windows.Forms.RadioButton Flag_Ext;
        private System.Windows.Forms.RadioButton Flag_Std;
        private System.ComponentModel.BackgroundWorker bgTransmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TransmitInterfaceBox;
        private System.Windows.Forms.Button RefreshInterfaces;
    }
}