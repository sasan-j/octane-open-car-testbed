namespace OpenCarTestbed.Windows
{
    partial class GuidedBusControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuidedBusControl));
            this.ExitGuide = new System.Windows.Forms.Button();
            this.RestartGuide = new System.Windows.Forms.Button();
            this.guidedStatusBox = new System.Windows.Forms.RichTextBox();
            this.takeAction = new System.Windows.Forms.Button();
            this.guidedActionBox = new System.Windows.Forms.RichTextBox();
            this.Status = new System.Windows.Forms.Label();
            this.SuggestedAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExitGuide
            // 
            this.ExitGuide.Location = new System.Drawing.Point(298, 338);
            this.ExitGuide.Name = "ExitGuide";
            this.ExitGuide.Size = new System.Drawing.Size(104, 23);
            this.ExitGuide.TabIndex = 0;
            this.ExitGuide.Text = "Exit Guide";
            this.ExitGuide.UseVisualStyleBackColor = true;
            this.ExitGuide.Click += new System.EventHandler(this.ExitGuide_Click);
            // 
            // RestartGuide
            // 
            this.RestartGuide.Location = new System.Drawing.Point(172, 338);
            this.RestartGuide.Name = "RestartGuide";
            this.RestartGuide.Size = new System.Drawing.Size(106, 23);
            this.RestartGuide.TabIndex = 1;
            this.RestartGuide.Text = "Restart Guide";
            this.RestartGuide.UseVisualStyleBackColor = true;
            this.RestartGuide.Click += new System.EventHandler(this.RestartGuide_Click);
            // 
            // guidedStatusBox
            // 
            this.guidedStatusBox.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guidedStatusBox.Location = new System.Drawing.Point(156, 29);
            this.guidedStatusBox.Name = "guidedStatusBox";
            this.guidedStatusBox.ReadOnly = true;
            this.guidedStatusBox.Size = new System.Drawing.Size(293, 96);
            this.guidedStatusBox.TabIndex = 2;
            this.guidedStatusBox.Text = "";
            // 
            // takeAction
            // 
            this.takeAction.Location = new System.Drawing.Point(172, 275);
            this.takeAction.Name = "takeAction";
            this.takeAction.Size = new System.Drawing.Size(230, 23);
            this.takeAction.TabIndex = 3;
            this.takeAction.Text = "Take Suggested Action";
            this.takeAction.UseVisualStyleBackColor = true;
            this.takeAction.Click += new System.EventHandler(this.takeAction_Click);
            // 
            // guidedActionBox
            // 
            this.guidedActionBox.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guidedActionBox.Location = new System.Drawing.Point(156, 152);
            this.guidedActionBox.Name = "guidedActionBox";
            this.guidedActionBox.ReadOnly = true;
            this.guidedActionBox.Size = new System.Drawing.Size(293, 82);
            this.guidedActionBox.TabIndex = 4;
            this.guidedActionBox.Text = "";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(32, 29);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(37, 13);
            this.Status.TabIndex = 5;
            this.Status.Text = "Status";
            // 
            // SuggestedAction
            // 
            this.SuggestedAction.AutoSize = true;
            this.SuggestedAction.Location = new System.Drawing.Point(32, 152);
            this.SuggestedAction.Name = "SuggestedAction";
            this.SuggestedAction.Size = new System.Drawing.Size(91, 13);
            this.SuggestedAction.TabIndex = 6;
            this.SuggestedAction.Text = "Suggested Action";
            // 
            // GuidedBusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 387);
            this.Controls.Add(this.SuggestedAction);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.guidedActionBox);
            this.Controls.Add(this.takeAction);
            this.Controls.Add(this.guidedStatusBox);
            this.Controls.Add(this.RestartGuide);
            this.Controls.Add(this.ExitGuide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GuidedBusControl";
            this.Text = "Guided Bus Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitGuide;
        private System.Windows.Forms.Button RestartGuide;
        private System.Windows.Forms.RichTextBox guidedStatusBox;
        private System.Windows.Forms.Button takeAction;
        private System.Windows.Forms.RichTextBox guidedActionBox;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label SuggestedAction;
    }
}