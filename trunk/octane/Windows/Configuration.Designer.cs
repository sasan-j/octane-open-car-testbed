namespace OpenCarTestbed.Windows
{
    partial class Configuration
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
            this.label1 = new System.Windows.Forms.Label();
            this.filterLocation = new System.Windows.Forms.TextBox();
            this.saveSettings = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.editFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Location";
            // 
            // filterLocation
            // 
            this.filterLocation.Location = new System.Drawing.Point(222, 26);
            this.filterLocation.Multiline = true;
            this.filterLocation.Name = "filterLocation";
            this.filterLocation.Size = new System.Drawing.Size(369, 20);
            this.filterLocation.TabIndex = 1;
            // 
            // saveSettings
            // 
            this.saveSettings.Location = new System.Drawing.Point(78, 349);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(140, 23);
            this.saveSettings.TabIndex = 2;
            this.saveSettings.Text = "Save Settings";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // editFilter
            // 
            this.editFilter.Location = new System.Drawing.Point(649, 22);
            this.editFilter.Name = "editFilter";
            this.editFilter.Size = new System.Drawing.Size(115, 23);
            this.editFilter.TabIndex = 3;
            this.editFilter.Text = "Edit Filter Location";
            this.editFilter.UseVisualStyleBackColor = true;
            this.editFilter.Click += new System.EventHandler(this.editFilter_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 407);
            this.Controls.Add(this.editFilter);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.filterLocation);
            this.Controls.Add(this.label1);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filterLocation;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button editFilter;
    }
}