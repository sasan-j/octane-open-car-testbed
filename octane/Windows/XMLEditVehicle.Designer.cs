namespace OpenCarTestbed.Windows
{
    partial class XMLEditVehicle
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
            this.RenameVehicle = new System.Windows.Forms.Button();
            this.vehicle = new System.Windows.Forms.TextBox();
            this.RemoveVehicle = new System.Windows.Forms.Button();
            this.AddVehicle = new System.Windows.Forms.Button();
            this.lblVehicleName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RenameVehicle
            // 
            this.RenameVehicle.Location = new System.Drawing.Point(113, 53);
            this.RenameVehicle.Name = "RenameVehicle";
            this.RenameVehicle.Size = new System.Drawing.Size(101, 23);
            this.RenameVehicle.TabIndex = 11;
            this.RenameVehicle.Text = "Rename Vehicle";
            this.RenameVehicle.UseVisualStyleBackColor = true;
            this.RenameVehicle.Click += new System.EventHandler(this.RenameVehicle_Click);
            // 
            // vehicle
            // 
            this.vehicle.Location = new System.Drawing.Point(113, 27);
            this.vehicle.Name = "vehicle";
            this.vehicle.Size = new System.Drawing.Size(100, 20);
            this.vehicle.TabIndex = 10;
            // 
            // RemoveVehicle
            // 
            this.RemoveVehicle.Location = new System.Drawing.Point(113, 82);
            this.RemoveVehicle.Name = "RemoveVehicle";
            this.RemoveVehicle.Size = new System.Drawing.Size(101, 23);
            this.RemoveVehicle.TabIndex = 9;
            this.RemoveVehicle.Text = "Remove Vehicle";
            this.RemoveVehicle.UseVisualStyleBackColor = true;
            this.RemoveVehicle.Click += new System.EventHandler(this.RemoveVehicle_Click);
            // 
            // AddVehicle
            // 
            this.AddVehicle.Location = new System.Drawing.Point(113, 111);
            this.AddVehicle.Name = "AddVehicle";
            this.AddVehicle.Size = new System.Drawing.Size(101, 23);
            this.AddVehicle.TabIndex = 8;
            this.AddVehicle.Text = "Add Vehicle";
            this.AddVehicle.UseVisualStyleBackColor = true;
            this.AddVehicle.Click += new System.EventHandler(this.AddVehicle_Click);
            // 
            // lblVehicleName
            // 
            this.lblVehicleName.AutoSize = true;
            this.lblVehicleName.Location = new System.Drawing.Point(18, 30);
            this.lblVehicleName.Name = "lblVehicleName";
            this.lblVehicleName.Size = new System.Drawing.Size(76, 13);
            this.lblVehicleName.TabIndex = 12;
            this.lblVehicleName.Text = "Vehicle Name:";
            // 
            // XMLEditVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 166);
            this.Controls.Add(this.lblVehicleName);
            this.Controls.Add(this.RenameVehicle);
            this.Controls.Add(this.vehicle);
            this.Controls.Add(this.RemoveVehicle);
            this.Controls.Add(this.AddVehicle);
            this.Name = "XMLEditVehicle";
            this.Text = "XMLEditVehicle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RenameVehicle;
        private System.Windows.Forms.TextBox vehicle;
        private System.Windows.Forms.Button RemoveVehicle;
        private System.Windows.Forms.Button AddVehicle;
        private System.Windows.Forms.Label lblVehicleName;
    }
}