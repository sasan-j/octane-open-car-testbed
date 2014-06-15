namespace OpenCarTestbed
{
    partial class BusSettings
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.noSampBox = new System.Windows.Forms.TextBox();
            this.sjwBox = new System.Windows.Forms.TextBox();
            this.tseg2Box = new System.Windows.Forms.TextBox();
            this.tseg1Box = new System.Windows.Forms.TextBox();
            this.bitrateBox = new System.Windows.Forms.TextBox();
            this.SetBus = new System.Windows.Forms.Button();
            this.RetrieveBus = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Sampling Points";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Sync Jump Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Time Segment 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Time Segment 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Freq (bitrate)";
            // 
            // noSampBox
            // 
            this.noSampBox.Location = new System.Drawing.Point(175, 189);
            this.noSampBox.Name = "noSampBox";
            this.noSampBox.Size = new System.Drawing.Size(100, 20);
            this.noSampBox.TabIndex = 30;
            // 
            // sjwBox
            // 
            this.sjwBox.Location = new System.Drawing.Point(175, 150);
            this.sjwBox.Name = "sjwBox";
            this.sjwBox.Size = new System.Drawing.Size(100, 20);
            this.sjwBox.TabIndex = 29;
            // 
            // tseg2Box
            // 
            this.tseg2Box.Location = new System.Drawing.Point(175, 111);
            this.tseg2Box.Name = "tseg2Box";
            this.tseg2Box.Size = new System.Drawing.Size(100, 20);
            this.tseg2Box.TabIndex = 28;
            // 
            // tseg1Box
            // 
            this.tseg1Box.Location = new System.Drawing.Point(175, 72);
            this.tseg1Box.Name = "tseg1Box";
            this.tseg1Box.Size = new System.Drawing.Size(100, 20);
            this.tseg1Box.TabIndex = 27;
            // 
            // bitrateBox
            // 
            this.bitrateBox.Location = new System.Drawing.Point(175, 32);
            this.bitrateBox.Name = "bitrateBox";
            this.bitrateBox.Size = new System.Drawing.Size(100, 20);
            this.bitrateBox.TabIndex = 26;
            // 
            // SetBus
            // 
            this.SetBus.Location = new System.Drawing.Point(317, 299);
            this.SetBus.Name = "SetBus";
            this.SetBus.Size = new System.Drawing.Size(130, 23);
            this.SetBus.TabIndex = 25;
            this.SetBus.Text = "Set Bus Settings";
            this.SetBus.UseVisualStyleBackColor = true;
            // 
            // RetrieveBus
            // 
            this.RetrieveBus.Location = new System.Drawing.Point(99, 299);
            this.RetrieveBus.Name = "RetrieveBus";
            this.RetrieveBus.Size = new System.Drawing.Size(130, 23);
            this.RetrieveBus.TabIndex = 24;
            this.RetrieveBus.Text = "Retrieve Bus Settings";
            this.RetrieveBus.UseVisualStyleBackColor = true;
            this.RetrieveBus.Click += new System.EventHandler(this.RetrieveBus_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(0, 333);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(488, 22);
            this.toolStripStatusLabel1.TabIndex = 36;
            this.toolStripStatusLabel1.Text = "Bus Settings";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel2.Text = "Bus Settings";
            // 
            // BusSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 355);
            this.Controls.Add(this.toolStripStatusLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noSampBox);
            this.Controls.Add(this.sjwBox);
            this.Controls.Add(this.tseg2Box);
            this.Controls.Add(this.tseg1Box);
            this.Controls.Add(this.bitrateBox);
            this.Controls.Add(this.SetBus);
            this.Controls.Add(this.RetrieveBus);
            this.Name = "BusSettings";
            this.Text = "Bus Settings";
            this.toolStripStatusLabel1.ResumeLayout(false);
            this.toolStripStatusLabel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noSampBox;
        private System.Windows.Forms.TextBox sjwBox;
        private System.Windows.Forms.TextBox tseg2Box;
        private System.Windows.Forms.TextBox tseg1Box;
        private System.Windows.Forms.TextBox bitrateBox;
        private System.Windows.Forms.Button SetBus;
        private System.Windows.Forms.Button RetrieveBus;
        private System.Windows.Forms.StatusStrip toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}