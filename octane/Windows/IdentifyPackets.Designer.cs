namespace OpenCarTestbed.Windows
{
    partial class IdentifyPackets
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPacketName = new System.Windows.Forms.TextBox();
            this.lblCar = new System.Windows.Forms.Label();
            this.lblPacketName = new System.Windows.Forms.Label();
            this.TransmitList = new System.Windows.Forms.ListBox();
            this.Transmit_msg7 = new System.Windows.Forms.TextBox();
            this.Transmit_msg6 = new System.Windows.Forms.TextBox();
            this.Transmit_msg5 = new System.Windows.Forms.TextBox();
            this.Transmit_msg4 = new System.Windows.Forms.TextBox();
            this.Transmit_msg3 = new System.Windows.Forms.TextBox();
            this.Transmit_msg2 = new System.Windows.Forms.TextBox();
            this.Transmit_msg1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Transmit_msg0 = new System.Windows.Forms.TextBox();
            this.Transmit_id = new System.Windows.Forms.TextBox();
            this.rbNewXML = new System.Windows.Forms.RadioButton();
            this.rbLoadXML = new System.Windows.Forms.RadioButton();
            this.txtCarType = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(134, 256);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPacketName
            // 
            this.txtPacketName.Location = new System.Drawing.Point(134, 201);
            this.txtPacketName.Name = "txtPacketName";
            this.txtPacketName.Size = new System.Drawing.Size(100, 20);
            this.txtPacketName.TabIndex = 2;
            this.txtPacketName.TextChanged += new System.EventHandler(this.txtPacketName_TextChanged);
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Location = new System.Drawing.Point(12, 26);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(53, 13);
            this.lblCar.TabIndex = 3;
            this.lblCar.Text = "Car Type:";
            this.lblCar.Click += new System.EventHandler(this.lblCar_Click);
            // 
            // lblPacketName
            // 
            this.lblPacketName.AutoSize = true;
            this.lblPacketName.Location = new System.Drawing.Point(3, 201);
            this.lblPacketName.Name = "lblPacketName";
            this.lblPacketName.Size = new System.Drawing.Size(75, 13);
            this.lblPacketName.TabIndex = 4;
            this.lblPacketName.Text = "Packet Name:";
            this.lblPacketName.Click += new System.EventHandler(this.lblPacketName_Click);
            // 
            // TransmitList
            // 
            this.TransmitList.FormattingEnabled = true;
            this.TransmitList.Location = new System.Drawing.Point(92, 26);
            this.TransmitList.Name = "TransmitList";
            this.TransmitList.Size = new System.Drawing.Size(283, 82);
            this.TransmitList.TabIndex = 5;
            this.TransmitList.SelectedIndexChanged += new System.EventHandler(this.TransmitList_SelectedIndexChanged);
            // 
            // Transmit_msg7
            // 
            this.Transmit_msg7.Location = new System.Drawing.Point(442, 167);
            this.Transmit_msg7.Name = "Transmit_msg7";
            this.Transmit_msg7.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg7.TabIndex = 65;
            this.Transmit_msg7.Text = "00";
            this.Transmit_msg7.TextChanged += new System.EventHandler(this.Transmit_msg7_TextChanged);
            // 
            // Transmit_msg6
            // 
            this.Transmit_msg6.Location = new System.Drawing.Point(398, 167);
            this.Transmit_msg6.Name = "Transmit_msg6";
            this.Transmit_msg6.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg6.TabIndex = 64;
            this.Transmit_msg6.Text = "00";
            this.Transmit_msg6.TextChanged += new System.EventHandler(this.Transmit_msg6_TextChanged);
            // 
            // Transmit_msg5
            // 
            this.Transmit_msg5.Location = new System.Drawing.Point(354, 167);
            this.Transmit_msg5.Name = "Transmit_msg5";
            this.Transmit_msg5.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg5.TabIndex = 63;
            this.Transmit_msg5.Text = "00";
            this.Transmit_msg5.TextChanged += new System.EventHandler(this.Transmit_msg5_TextChanged);
            // 
            // Transmit_msg4
            // 
            this.Transmit_msg4.Location = new System.Drawing.Point(310, 167);
            this.Transmit_msg4.Name = "Transmit_msg4";
            this.Transmit_msg4.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg4.TabIndex = 62;
            this.Transmit_msg4.Text = "00";
            this.Transmit_msg4.TextChanged += new System.EventHandler(this.Transmit_msg4_TextChanged);
            // 
            // Transmit_msg3
            // 
            this.Transmit_msg3.Location = new System.Drawing.Point(266, 167);
            this.Transmit_msg3.Name = "Transmit_msg3";
            this.Transmit_msg3.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg3.TabIndex = 61;
            this.Transmit_msg3.Text = "00";
            this.Transmit_msg3.TextChanged += new System.EventHandler(this.Transmit_msg3_TextChanged);
            // 
            // Transmit_msg2
            // 
            this.Transmit_msg2.Location = new System.Drawing.Point(222, 167);
            this.Transmit_msg2.Name = "Transmit_msg2";
            this.Transmit_msg2.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg2.TabIndex = 60;
            this.Transmit_msg2.Text = "00";
            this.Transmit_msg2.TextChanged += new System.EventHandler(this.Transmit_msg2_TextChanged);
            // 
            // Transmit_msg1
            // 
            this.Transmit_msg1.Location = new System.Drawing.Point(178, 167);
            this.Transmit_msg1.Name = "Transmit_msg1";
            this.Transmit_msg1.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg1.TabIndex = 59;
            this.Transmit_msg1.Text = "00";
            this.Transmit_msg1.TextChanged += new System.EventHandler(this.Transmit_msg1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "CAN Message";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "CAN Identifier";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // Transmit_msg0
            // 
            this.Transmit_msg0.Location = new System.Drawing.Point(134, 167);
            this.Transmit_msg0.Name = "Transmit_msg0";
            this.Transmit_msg0.Size = new System.Drawing.Size(38, 20);
            this.Transmit_msg0.TabIndex = 56;
            this.Transmit_msg0.Text = "00";
            this.Transmit_msg0.TextChanged += new System.EventHandler(this.Transmit_msg0_TextChanged);
            // 
            // Transmit_id
            // 
            this.Transmit_id.Location = new System.Drawing.Point(134, 127);
            this.Transmit_id.Name = "Transmit_id";
            this.Transmit_id.Size = new System.Drawing.Size(100, 20);
            this.Transmit_id.TabIndex = 55;
            this.Transmit_id.Text = "000";
            this.Transmit_id.TextChanged += new System.EventHandler(this.Transmit_id_TextChanged);
            // 
            // rbNewXML
            // 
            this.rbNewXML.AutoSize = true;
            this.rbNewXML.Location = new System.Drawing.Point(354, 215);
            this.rbNewXML.Name = "rbNewXML";
            this.rbNewXML.Size = new System.Drawing.Size(124, 17);
            this.rbNewXML.TabIndex = 66;
            this.rbNewXML.TabStop = true;
            this.rbNewXML.Text = "New XML Document";
            this.rbNewXML.UseVisualStyleBackColor = true;
            this.rbNewXML.CheckedChanged += new System.EventHandler(this.rbNewXML_CheckedChanged);
            // 
            // rbLoadXML
            // 
            this.rbLoadXML.AutoSize = true;
            this.rbLoadXML.Location = new System.Drawing.Point(354, 238);
            this.rbLoadXML.Name = "rbLoadXML";
            this.rbLoadXML.Size = new System.Drawing.Size(126, 17);
            this.rbLoadXML.TabIndex = 67;
            this.rbLoadXML.TabStop = true;
            this.rbLoadXML.Text = "Load XML Document";
            this.rbLoadXML.UseVisualStyleBackColor = true;
            this.rbLoadXML.CheckedChanged += new System.EventHandler(this.rbLoadXML_CheckedChanged);
            // 
            // txtCarType
            // 
            this.txtCarType.Location = new System.Drawing.Point(92, 26);
            this.txtCarType.Name = "txtCarType";
            this.txtCarType.Size = new System.Drawing.Size(100, 20);
            this.txtCarType.TabIndex = 68;
            this.txtCarType.Visible = false;
            this.txtCarType.TextChanged += new System.EventHandler(this.txtCarType_TextChanged);
            // 
            // IdentifyPackets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 291);
            this.Controls.Add(this.txtCarType);
            this.Controls.Add(this.rbLoadXML);
            this.Controls.Add(this.rbNewXML);
            this.Controls.Add(this.Transmit_msg7);
            this.Controls.Add(this.Transmit_msg6);
            this.Controls.Add(this.Transmit_msg5);
            this.Controls.Add(this.Transmit_msg4);
            this.Controls.Add(this.Transmit_msg3);
            this.Controls.Add(this.Transmit_msg2);
            this.Controls.Add(this.Transmit_msg1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Transmit_msg0);
            this.Controls.Add(this.Transmit_id);
            this.Controls.Add(this.TransmitList);
            this.Controls.Add(this.lblPacketName);
            this.Controls.Add(this.lblCar);
            this.Controls.Add(this.txtPacketName);
            this.Controls.Add(this.btnAdd);
            this.Name = "IdentifyPackets";
            this.Text = "IdentifyPackets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPacketName;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.Label lblPacketName;
        private System.Windows.Forms.ListBox TransmitList;
        private System.Windows.Forms.TextBox Transmit_msg7;
        private System.Windows.Forms.TextBox Transmit_msg6;
        private System.Windows.Forms.TextBox Transmit_msg5;
        private System.Windows.Forms.TextBox Transmit_msg4;
        private System.Windows.Forms.TextBox Transmit_msg3;
        private System.Windows.Forms.TextBox Transmit_msg2;
        private System.Windows.Forms.TextBox Transmit_msg1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Transmit_msg0;
        private System.Windows.Forms.TextBox Transmit_id;
        private System.Windows.Forms.RadioButton rbNewXML;
        private System.Windows.Forms.RadioButton rbLoadXML;
        private System.Windows.Forms.TextBox txtCarType;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}