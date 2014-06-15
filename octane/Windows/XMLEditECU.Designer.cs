namespace OpenCarTestbed.Windows
{
    partial class XMLEditECU
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
            this.txtECUID = new System.Windows.Forms.TextBox();
            this.EditECU = new System.Windows.Forms.Button();
            this.RemoveECU = new System.Windows.Forms.Button();
            this.AddECU = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtECUName = new System.Windows.Forms.TextBox();
            this.TransmitBox = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtECUID
            // 
            this.txtECUID.Location = new System.Drawing.Point(447, 62);
            this.txtECUID.Name = "txtECUID";
            this.txtECUID.Size = new System.Drawing.Size(184, 20);
            this.txtECUID.TabIndex = 10;
            // 
            // EditECU
            // 
            this.EditECU.Location = new System.Drawing.Point(446, 159);
            this.EditECU.Name = "EditECU";
            this.EditECU.Size = new System.Drawing.Size(101, 23);
            this.EditECU.TabIndex = 9;
            this.EditECU.Text = "Edit ECU";
            this.EditECU.UseVisualStyleBackColor = true;
            this.EditECU.Click += new System.EventHandler(this.EditECU_Click);
            // 
            // RemoveECU
            // 
            this.RemoveECU.Location = new System.Drawing.Point(446, 208);
            this.RemoveECU.Name = "RemoveECU";
            this.RemoveECU.Size = new System.Drawing.Size(101, 23);
            this.RemoveECU.TabIndex = 8;
            this.RemoveECU.Text = "Remove ECU";
            this.RemoveECU.UseVisualStyleBackColor = true;
            this.RemoveECU.Click += new System.EventHandler(this.RemoveECU_Click);
            // 
            // AddECU
            // 
            this.AddECU.Location = new System.Drawing.Point(446, 259);
            this.AddECU.Name = "AddECU";
            this.AddECU.Size = new System.Drawing.Size(101, 23);
            this.AddECU.TabIndex = 7;
            this.AddECU.Text = "Add ECU";
            this.AddECU.UseVisualStyleBackColor = true;
            this.AddECU.Click += new System.EventHandler(this.AddECU_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ECU No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ECU Name";
            // 
            // txtECUName
            // 
            this.txtECUName.Location = new System.Drawing.Point(447, 121);
            this.txtECUName.Name = "txtECUName";
            this.txtECUName.Size = new System.Drawing.Size(184, 20);
            this.txtECUName.TabIndex = 12;
            // 
            // TransmitBox
            // 
            this.TransmitBox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.TransmitBox.FullRowSelect = true;
            this.TransmitBox.GridLines = true;
            this.TransmitBox.HideSelection = false;
            this.TransmitBox.Location = new System.Drawing.Point(29, 34);
            this.TransmitBox.MultiSelect = false;
            this.TransmitBox.Name = "TransmitBox";
            this.TransmitBox.Size = new System.Drawing.Size(383, 282);
            this.TransmitBox.TabIndex = 20;
            this.TransmitBox.UseCompatibleStateImageBehavior = false;
            this.TransmitBox.View = System.Windows.Forms.View.Details;
            this.TransmitBox.SelectedIndexChanged += new System.EventHandler(this.TransmitBox_SelectedIndexChanged);
            // 
            // XMLEditECU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 357);
            this.Controls.Add(this.TransmitBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtECUName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtECUID);
            this.Controls.Add(this.EditECU);
            this.Controls.Add(this.RemoveECU);
            this.Controls.Add(this.AddECU);
            this.Name = "XMLEditECU";
            this.Text = "XML Edit ECU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtECUID;
        private System.Windows.Forms.Button EditECU;
        private System.Windows.Forms.Button RemoveECU;
        private System.Windows.Forms.Button AddECU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtECUName;
        private System.Windows.Forms.ListView TransmitBox;
    }
}