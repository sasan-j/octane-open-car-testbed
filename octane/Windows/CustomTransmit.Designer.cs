namespace OpenCarTestbed
{
    partial class CustomTransmit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomTransmit));
            this.toolStripStatusLabel1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.VerboseTransmit = new System.Windows.Forms.CheckBox();
            this.TransmitList = new System.Windows.Forms.ListBox();
            this.TransmitLoadLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RefreshTransmit = new System.Windows.Forms.Button();
            this.TransmitBox = new System.Windows.Forms.ListView();
            this.Transmit = new System.Windows.Forms.Button();
            this.bgTransmit = new System.ComponentModel.BackgroundWorker();
            this.bgMultipleTransmit = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.TransmitInterfaceBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PacketBox = new System.Windows.Forms.RichTextBox();
            this.packetLabel = new System.Windows.Forms.Label();
            this.RefreshInterfaces = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(0, 391);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(928, 22);
            this.toolStripStatusLabel1.TabIndex = 6;
            this.toolStripStatusLabel1.Text = "Custom Transmit";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(99, 17);
            this.toolStripStatusLabel2.Text = "Custom Transmit";
            // 
            // VerboseTransmit
            // 
            this.VerboseTransmit.AutoSize = true;
            this.VerboseTransmit.Location = new System.Drawing.Point(26, 354);
            this.VerboseTransmit.Name = "VerboseTransmit";
            this.VerboseTransmit.Size = new System.Drawing.Size(143, 17);
            this.VerboseTransmit.TabIndex = 10;
            this.VerboseTransmit.Text = "Verbose Transmit Output";
            this.VerboseTransmit.UseVisualStyleBackColor = true;
            // 
            // TransmitList
            // 
            this.TransmitList.FormattingEnabled = true;
            this.TransmitList.Location = new System.Drawing.Point(23, 34);
            this.TransmitList.Name = "TransmitList";
            this.TransmitList.Size = new System.Drawing.Size(120, 95);
            this.TransmitList.TabIndex = 11;
            this.TransmitList.SelectedIndexChanged += new System.EventHandler(this.TransmitList_SelectedIndexChanged);
            // 
            // TransmitLoadLabel
            // 
            this.TransmitLoadLabel.AutoSize = true;
            this.TransmitLoadLabel.Location = new System.Drawing.Point(23, 266);
            this.TransmitLoadLabel.Name = "TransmitLoadLabel";
            this.TransmitLoadLabel.Size = new System.Drawing.Size(33, 13);
            this.TransmitLoadLabel.TabIndex = 16;
            this.TransmitLoadLabel.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Transmit Loaded:";
            // 
            // RefreshTransmit
            // 
            this.RefreshTransmit.Location = new System.Drawing.Point(23, 145);
            this.RefreshTransmit.Name = "RefreshTransmit";
            this.RefreshTransmit.Size = new System.Drawing.Size(98, 23);
            this.RefreshTransmit.TabIndex = 12;
            this.RefreshTransmit.Text = "Refresh Transmit";
            this.RefreshTransmit.UseVisualStyleBackColor = true;
            this.RefreshTransmit.Click += new System.EventHandler(this.RefreshTransmit_Click);
            // 
            // TransmitBox
            // 
            this.TransmitBox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.TransmitBox.FullRowSelect = true;
            this.TransmitBox.GridLines = true;
            this.TransmitBox.Location = new System.Drawing.Point(237, 34);
            this.TransmitBox.MultiSelect = false;
            this.TransmitBox.Name = "TransmitBox";
            this.TransmitBox.Size = new System.Drawing.Size(245, 289);
            this.TransmitBox.TabIndex = 17;
            this.TransmitBox.UseCompatibleStateImageBehavior = false;
            this.TransmitBox.View = System.Windows.Forms.View.Details;
            this.TransmitBox.SelectedIndexChanged += new System.EventHandler(this.TransmitBox_SelectedIndexChanged);
            // 
            // Transmit
            // 
            this.Transmit.Location = new System.Drawing.Point(237, 338);
            this.Transmit.Name = "Transmit";
            this.Transmit.Size = new System.Drawing.Size(75, 23);
            this.Transmit.TabIndex = 18;
            this.Transmit.Text = "Transmit";
            this.Transmit.UseVisualStyleBackColor = true;
            this.Transmit.Click += new System.EventHandler(this.Transmit_Click);
            // 
            // bgTransmit
            // 
            this.bgTransmit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgTransmit_DoWork);
            // 
            // bgMultipleTransmit
            // 
            this.bgMultipleTransmit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMultipleTransmit_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Transmit Interface";
            // 
            // TransmitInterfaceBox
            // 
            this.TransmitInterfaceBox.FormattingEnabled = true;
            this.TransmitInterfaceBox.Location = new System.Drawing.Point(561, 340);
            this.TransmitInterfaceBox.Name = "TransmitInterfaceBox";
            this.TransmitInterfaceBox.Size = new System.Drawing.Size(253, 21);
            this.TransmitInterfaceBox.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Car Types";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Available Packets";
            // 
            // PacketBox
            // 
            this.PacketBox.Location = new System.Drawing.Point(561, 34);
            this.PacketBox.Name = "PacketBox";
            this.PacketBox.Size = new System.Drawing.Size(295, 289);
            this.PacketBox.TabIndex = 64;
            this.PacketBox.Text = "";
            // 
            // packetLabel
            // 
            this.packetLabel.AutoSize = true;
            this.packetLabel.Location = new System.Drawing.Point(558, 9);
            this.packetLabel.Name = "packetLabel";
            this.packetLabel.Size = new System.Drawing.Size(41, 13);
            this.packetLabel.TabIndex = 65;
            this.packetLabel.Text = "Packet";
            // 
            // RefreshInterfaces
            // 
            this.RefreshInterfaces.Location = new System.Drawing.Point(23, 325);
            this.RefreshInterfaces.Name = "RefreshInterfaces";
            this.RefreshInterfaces.Size = new System.Drawing.Size(146, 23);
            this.RefreshInterfaces.TabIndex = 66;
            this.RefreshInterfaces.Text = "Refresh Interfaces";
            this.RefreshInterfaces.UseVisualStyleBackColor = true;
            this.RefreshInterfaces.Click += new System.EventHandler(this.RefreshInterfaces_Click);
            // 
            // CustomTransmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 413);
            this.Controls.Add(this.RefreshInterfaces);
            this.Controls.Add(this.packetLabel);
            this.Controls.Add(this.PacketBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransmitInterfaceBox);
            this.Controls.Add(this.Transmit);
            this.Controls.Add(this.TransmitBox);
            this.Controls.Add(this.TransmitLoadLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RefreshTransmit);
            this.Controls.Add(this.TransmitList);
            this.Controls.Add(this.VerboseTransmit);
            this.Controls.Add(this.toolStripStatusLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomTransmit";
            this.Text = "Custom Transmit";
            this.toolStripStatusLabel1.ResumeLayout(false);
            this.toolStripStatusLabel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox VerboseTransmit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ListBox TransmitList;
        private System.Windows.Forms.Label TransmitLoadLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RefreshTransmit;
        private System.Windows.Forms.ListView TransmitBox;
        private System.Windows.Forms.Button Transmit;
        private System.ComponentModel.BackgroundWorker bgTransmit;
        private System.ComponentModel.BackgroundWorker bgMultipleTransmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TransmitInterfaceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox PacketBox;
        private System.Windows.Forms.Label packetLabel;
        private System.Windows.Forms.Button RefreshInterfaces;
    }
}