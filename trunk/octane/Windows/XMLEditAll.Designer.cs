namespace OpenCarTestbed.Windows
{
    partial class XMLEditAll
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
            this.txtCarTypes = new System.Windows.Forms.Label();
            this.TransmitList = new System.Windows.Forms.ListBox();
            this.TransmitBox = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TransmitInterfaceBox = new System.Windows.Forms.ComboBox();
            this.Transmit = new System.Windows.Forms.Button();
            this.VerboseTransmit = new System.Windows.Forms.CheckBox();
            this.toolStripStatusLabel2 = new System.Windows.Forms.StatusStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCarTypes
            // 
            this.txtCarTypes.AutoSize = true;
            this.txtCarTypes.Location = new System.Drawing.Point(12, 9);
            this.txtCarTypes.Name = "txtCarTypes";
            this.txtCarTypes.Size = new System.Drawing.Size(55, 13);
            this.txtCarTypes.TabIndex = 0;
            this.txtCarTypes.Text = "Car Types";
            // 
            // TransmitList
            // 
            this.TransmitList.FormattingEnabled = true;
            this.TransmitList.Location = new System.Drawing.Point(12, 25);
            this.TransmitList.Name = "TransmitList";
            this.TransmitList.Size = new System.Drawing.Size(120, 95);
            this.TransmitList.TabIndex = 1;
            this.TransmitList.SelectedIndexChanged += new System.EventHandler(this.TransmitList_SelectedIndexChanged);
            // 
            // TransmitBox
            // 
            this.TransmitBox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.TransmitBox.FullRowSelect = true;
            this.TransmitBox.GridLines = true;
            this.TransmitBox.Location = new System.Drawing.Point(165, 25);
            this.TransmitBox.MultiSelect = false;
            this.TransmitBox.Name = "TransmitBox";
            this.TransmitBox.Size = new System.Drawing.Size(245, 289);
            this.TransmitBox.TabIndex = 18;
            this.TransmitBox.UseCompatibleStateImageBehavior = false;
            this.TransmitBox.View = System.Windows.Forms.View.Details;
            this.TransmitBox.SelectedIndexChanged += new System.EventHandler(this.TransmitBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Available Packets";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Transmit Interface";
            // 
            // TransmitInterfaceBox
            // 
            this.TransmitInterfaceBox.FormattingEnabled = true;
            this.TransmitInterfaceBox.Location = new System.Drawing.Point(551, 369);
            this.TransmitInterfaceBox.Name = "TransmitInterfaceBox";
            this.TransmitInterfaceBox.Size = new System.Drawing.Size(253, 21);
            this.TransmitInterfaceBox.TabIndex = 65;
            // 
            // Transmit
            // 
            this.Transmit.Location = new System.Drawing.Point(162, 325);
            this.Transmit.Name = "Transmit";
            this.Transmit.Size = new System.Drawing.Size(75, 23);
            this.Transmit.TabIndex = 68;
            this.Transmit.Text = "Transmit";
            this.Transmit.UseVisualStyleBackColor = true;
            // 
            // VerboseTransmit
            // 
            this.VerboseTransmit.AutoSize = true;
            this.VerboseTransmit.Location = new System.Drawing.Point(162, 373);
            this.VerboseTransmit.Name = "VerboseTransmit";
            this.VerboseTransmit.Size = new System.Drawing.Size(143, 17);
            this.VerboseTransmit.TabIndex = 67;
            this.VerboseTransmit.Text = "Verbose Transmit Output";
            this.VerboseTransmit.UseVisualStyleBackColor = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Location = new System.Drawing.Point(0, 471);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(932, 22);
            this.toolStripStatusLabel2.TabIndex = 70;
            this.toolStripStatusLabel2.Text = "statusStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 71;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // XMLEditAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStripStatusLabel2);
            this.Controls.Add(this.Transmit);
            this.Controls.Add(this.VerboseTransmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransmitInterfaceBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TransmitBox);
            this.Controls.Add(this.TransmitList);
            this.Controls.Add(this.txtCarTypes);
            this.Name = "XMLEditAll";
            this.Text = "XMLEditAll";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtCarTypes;
        private System.Windows.Forms.ListBox TransmitList;
        private System.Windows.Forms.ListView TransmitBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TransmitInterfaceBox;
        private System.Windows.Forms.Button Transmit;
        private System.Windows.Forms.CheckBox VerboseTransmit;
        private System.Windows.Forms.StatusStrip toolStripStatusLabel2;
        private System.Windows.Forms.Button button1;
    }
}