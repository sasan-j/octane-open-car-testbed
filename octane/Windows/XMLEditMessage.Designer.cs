namespace OpenCarTestbed.Windows
{
    partial class XMLEditMessage
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
            this.lvMessageBox = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessageName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnEditMessage = new System.Windows.Forms.Button();
            this.btnRemoveMessage = new System.Windows.Forms.Button();
            this.btnAddMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMessageBox
            // 
            this.lvMessageBox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvMessageBox.FullRowSelect = true;
            this.lvMessageBox.GridLines = true;
            this.lvMessageBox.Location = new System.Drawing.Point(21, 23);
            this.lvMessageBox.Name = "lvMessageBox";
            this.lvMessageBox.Size = new System.Drawing.Size(493, 262);
            this.lvMessageBox.TabIndex = 20;
            this.lvMessageBox.UseCompatibleStateImageBehavior = false;
            this.lvMessageBox.View = System.Windows.Forms.View.Details;
            this.lvMessageBox.SelectedIndexChanged += new System.EventHandler(this.lvMessageBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Message Name";
            // 
            // txtMessageName
            // 
            this.txtMessageName.Location = new System.Drawing.Point(549, 101);
            this.txtMessageName.Name = "txtMessageName";
            this.txtMessageName.Size = new System.Drawing.Size(100, 20);
            this.txtMessageName.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Message (in hex)";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(549, 42);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(100, 20);
            this.txtMessage.TabIndex = 32;
            // 
            // btnEditMessage
            // 
            this.btnEditMessage.Location = new System.Drawing.Point(549, 139);
            this.btnEditMessage.Name = "btnEditMessage";
            this.btnEditMessage.Size = new System.Drawing.Size(101, 23);
            this.btnEditMessage.TabIndex = 31;
            this.btnEditMessage.Text = "Edit Message";
            this.btnEditMessage.UseVisualStyleBackColor = true;
            // 
            // btnRemoveMessage
            // 
            this.btnRemoveMessage.Location = new System.Drawing.Point(549, 183);
            this.btnRemoveMessage.Name = "btnRemoveMessage";
            this.btnRemoveMessage.Size = new System.Drawing.Size(101, 23);
            this.btnRemoveMessage.TabIndex = 30;
            this.btnRemoveMessage.Text = "Remove Message";
            this.btnRemoveMessage.UseVisualStyleBackColor = true;
            // 
            // btnAddMessage
            // 
            this.btnAddMessage.Location = new System.Drawing.Point(549, 228);
            this.btnAddMessage.Name = "btnAddMessage";
            this.btnAddMessage.Size = new System.Drawing.Size(101, 23);
            this.btnAddMessage.TabIndex = 29;
            this.btnAddMessage.Text = "Add Message";
            this.btnAddMessage.UseVisualStyleBackColor = true;
            // 
            // XMLEditMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 310);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMessageName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnEditMessage);
            this.Controls.Add(this.btnRemoveMessage);
            this.Controls.Add(this.btnAddMessage);
            this.Controls.Add(this.lvMessageBox);
            this.Name = "XMLEditMessage";
            this.Text = "XML Edit Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMessageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessageName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnEditMessage;
        private System.Windows.Forms.Button btnRemoveMessage;
        private System.Windows.Forms.Button btnAddMessage;
    }
}