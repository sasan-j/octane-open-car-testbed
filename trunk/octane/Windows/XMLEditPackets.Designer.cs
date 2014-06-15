namespace OpenCarTestbed.Windows
{
    partial class XMLEditPackets
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
            this.lvPacketBox = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPacketName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPacketMessage = new System.Windows.Forms.TextBox();
            this.btnEditPacket = new System.Windows.Forms.Button();
            this.btnRemovePacket = new System.Windows.Forms.Button();
            this.btnAddPacket = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPacketId = new System.Windows.Forms.TextBox();
            this.lblPacketDLC = new System.Windows.Forms.Label();
            this.txtPacketDLC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvPacketBox
            // 
            this.lvPacketBox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvPacketBox.FullRowSelect = true;
            this.lvPacketBox.GridLines = true;
            this.lvPacketBox.Location = new System.Drawing.Point(12, 12);
            this.lvPacketBox.MultiSelect = false;
            this.lvPacketBox.Name = "lvPacketBox";
            this.lvPacketBox.Size = new System.Drawing.Size(506, 328);
            this.lvPacketBox.TabIndex = 21;
            this.lvPacketBox.UseCompatibleStateImageBehavior = false;
            this.lvPacketBox.View = System.Windows.Forms.View.Details;
            this.lvPacketBox.SelectedIndexChanged += new System.EventHandler(this.lvPacketBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Packet Name";
            // 
            // txtPacketName
            // 
            this.txtPacketName.Location = new System.Drawing.Point(541, 203);
            this.txtPacketName.Name = "txtPacketName";
            this.txtPacketName.Size = new System.Drawing.Size(124, 20);
            this.txtPacketName.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Packet Message (in hex)";
            // 
            // txtPacketMessage
            // 
            this.txtPacketMessage.Location = new System.Drawing.Point(541, 245);
            this.txtPacketMessage.Name = "txtPacketMessage";
            this.txtPacketMessage.Size = new System.Drawing.Size(124, 20);
            this.txtPacketMessage.TabIndex = 32;
            // 
            // btnEditPacket
            // 
            this.btnEditPacket.Location = new System.Drawing.Point(546, 25);
            this.btnEditPacket.Name = "btnEditPacket";
            this.btnEditPacket.Size = new System.Drawing.Size(101, 23);
            this.btnEditPacket.TabIndex = 31;
            this.btnEditPacket.Text = "Edit Packet";
            this.btnEditPacket.UseVisualStyleBackColor = true;
            this.btnEditPacket.Click += new System.EventHandler(this.btnEditPacket_Click);
            // 
            // btnRemovePacket
            // 
            this.btnRemovePacket.Location = new System.Drawing.Point(546, 54);
            this.btnRemovePacket.Name = "btnRemovePacket";
            this.btnRemovePacket.Size = new System.Drawing.Size(101, 23);
            this.btnRemovePacket.TabIndex = 30;
            this.btnRemovePacket.Text = "Remove Packet";
            this.btnRemovePacket.UseVisualStyleBackColor = true;
            this.btnRemovePacket.Click += new System.EventHandler(this.btnRemovePacket_Click);
            // 
            // btnAddPacket
            // 
            this.btnAddPacket.Location = new System.Drawing.Point(546, 83);
            this.btnAddPacket.Name = "btnAddPacket";
            this.btnAddPacket.Size = new System.Drawing.Size(101, 23);
            this.btnAddPacket.TabIndex = 29;
            this.btnAddPacket.Text = "Add Packet";
            this.btnAddPacket.UseVisualStyleBackColor = true;
            this.btnAddPacket.Click += new System.EventHandler(this.btnAddPacket_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Packet ID";
            // 
            // txtPacketId
            // 
            this.txtPacketId.Location = new System.Drawing.Point(541, 159);
            this.txtPacketId.Name = "txtPacketId";
            this.txtPacketId.Size = new System.Drawing.Size(124, 20);
            this.txtPacketId.TabIndex = 38;
            // 
            // lblPacketDLC
            // 
            this.lblPacketDLC.AutoSize = true;
            this.lblPacketDLC.Location = new System.Drawing.Point(541, 269);
            this.lblPacketDLC.Name = "lblPacketDLC";
            this.lblPacketDLC.Size = new System.Drawing.Size(65, 13);
            this.lblPacketDLC.TabIndex = 37;
            this.lblPacketDLC.Text = "Packet DLC";
            // 
            // txtPacketDLC
            // 
            this.txtPacketDLC.Location = new System.Drawing.Point(541, 288);
            this.txtPacketDLC.Name = "txtPacketDLC";
            this.txtPacketDLC.Size = new System.Drawing.Size(124, 20);
            this.txtPacketDLC.TabIndex = 36;
            // 
            // XMLEditPackets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPacketId);
            this.Controls.Add(this.lblPacketDLC);
            this.Controls.Add(this.txtPacketDLC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPacketName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPacketMessage);
            this.Controls.Add(this.btnEditPacket);
            this.Controls.Add(this.btnRemovePacket);
            this.Controls.Add(this.btnAddPacket);
            this.Controls.Add(this.lvPacketBox);
            this.Name = "XMLEditPackets";
            this.Text = "XMLEditPackets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvPacketBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPacketName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPacketMessage;
        private System.Windows.Forms.Button btnEditPacket;
        private System.Windows.Forms.Button btnRemovePacket;
        private System.Windows.Forms.Button btnAddPacket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPacketId;
        private System.Windows.Forms.Label lblPacketDLC;
        private System.Windows.Forms.TextBox txtPacketDLC;
    }
}