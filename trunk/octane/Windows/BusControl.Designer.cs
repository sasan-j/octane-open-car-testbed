namespace OpenCarTestbed
{
    partial class BusControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusControl));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.InterfaceBox = new System.Windows.Forms.ListView();
            this.RefreshInterfaces = new System.Windows.Forms.Button();
            this.BusOn = new System.Windows.Forms.Button();
            this.BusOff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Standard = new System.Windows.Forms.TabPage();
            this.canSettings = new System.Windows.Forms.Panel();
            this.customRate = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.standardRate33K = new System.Windows.Forms.RadioButton();
            this.standardRate50K = new System.Windows.Forms.RadioButton();
            this.standardRate62K = new System.Windows.Forms.RadioButton();
            this.standardRate100K = new System.Windows.Forms.RadioButton();
            this.standardRate125K = new System.Windows.Forms.RadioButton();
            this.standardRate250K = new System.Windows.Forms.RadioButton();
            this.standardRate500K = new System.Windows.Forms.RadioButton();
            this.standardRate1M = new System.Windows.Forms.RadioButton();
            this.Custom = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bitrateBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tseg1Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tseg2Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sjwBox = new System.Windows.Forms.TextBox();
            this.noSampBox = new System.Windows.Forms.TextBox();
            this.XMLFilter = new System.Windows.Forms.TabPage();
            this.editFilter = new System.Windows.Forms.Button();
            this.filterLocation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.advancedBusControl = new System.Windows.Forms.CheckBox();
            this.backgroundWorkerRefresh = new System.ComponentModel.BackgroundWorker();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Standard.SuspendLayout();
            this.canSettings.SuspendLayout();
            this.Custom.SuspendLayout();
            this.XMLFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(789, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Bus Control";
            // 
            // InterfaceBox
            // 
            this.InterfaceBox.FullRowSelect = true;
            this.InterfaceBox.Location = new System.Drawing.Point(29, 45);
            this.InterfaceBox.MultiSelect = false;
            this.InterfaceBox.Name = "InterfaceBox";
            this.InterfaceBox.Size = new System.Drawing.Size(482, 282);
            this.InterfaceBox.TabIndex = 20;
            this.InterfaceBox.UseCompatibleStateImageBehavior = false;
            this.InterfaceBox.View = System.Windows.Forms.View.Details;
            // 
            // RefreshInterfaces
            // 
            this.RefreshInterfaces.Location = new System.Drawing.Point(29, 346);
            this.RefreshInterfaces.Name = "RefreshInterfaces";
            this.RefreshInterfaces.Size = new System.Drawing.Size(107, 37);
            this.RefreshInterfaces.TabIndex = 21;
            this.RefreshInterfaces.Text = "Refresh Interface List";
            this.RefreshInterfaces.UseVisualStyleBackColor = true;
            this.RefreshInterfaces.Click += new System.EventHandler(this.RefreshInterfaces_Click);
            // 
            // BusOn
            // 
            this.BusOn.Location = new System.Drawing.Point(142, 346);
            this.BusOn.Name = "BusOn";
            this.BusOn.Size = new System.Drawing.Size(111, 37);
            this.BusOn.TabIndex = 22;
            this.BusOn.Text = "Bus On";
            this.BusOn.UseVisualStyleBackColor = true;
            this.BusOn.Click += new System.EventHandler(this.BusOn_Click);
            // 
            // BusOff
            // 
            this.BusOff.Location = new System.Drawing.Point(259, 346);
            this.BusOff.Name = "BusOff";
            this.BusOff.Size = new System.Drawing.Size(120, 37);
            this.BusOff.TabIndex = 23;
            this.BusOff.Text = "Bus Off";
            this.BusOff.UseVisualStyleBackColor = true;
            this.BusOff.Click += new System.EventHandler(this.BusOff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Available Interfaces";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Standard);
            this.tabControl1.Controls.Add(this.Custom);
            this.tabControl1.Controls.Add(this.XMLFilter);
            this.tabControl1.Location = new System.Drawing.Point(532, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(228, 282);
            this.tabControl1.TabIndex = 46;
            // 
            // Standard
            // 
            this.Standard.Controls.Add(this.canSettings);
            this.Standard.Location = new System.Drawing.Point(4, 22);
            this.Standard.Name = "Standard";
            this.Standard.Padding = new System.Windows.Forms.Padding(3);
            this.Standard.Size = new System.Drawing.Size(220, 256);
            this.Standard.TabIndex = 0;
            this.Standard.Text = "Settings";
            this.Standard.UseVisualStyleBackColor = true;
            // 
            // canSettings
            // 
            this.canSettings.Controls.Add(this.customRate);
            this.canSettings.Controls.Add(this.label7);
            this.canSettings.Controls.Add(this.standardRate33K);
            this.canSettings.Controls.Add(this.standardRate50K);
            this.canSettings.Controls.Add(this.standardRate62K);
            this.canSettings.Controls.Add(this.standardRate100K);
            this.canSettings.Controls.Add(this.standardRate125K);
            this.canSettings.Controls.Add(this.standardRate250K);
            this.canSettings.Controls.Add(this.standardRate500K);
            this.canSettings.Controls.Add(this.standardRate1M);
            this.canSettings.Location = new System.Drawing.Point(20, 17);
            this.canSettings.Name = "canSettings";
            this.canSettings.Size = new System.Drawing.Size(147, 233);
            this.canSettings.TabIndex = 1;
            // 
            // customRate
            // 
            this.customRate.AutoSize = true;
            this.customRate.Enabled = false;
            this.customRate.Location = new System.Drawing.Point(13, 199);
            this.customRate.Name = "customRate";
            this.customRate.Size = new System.Drawing.Size(60, 17);
            this.customRate.TabIndex = 53;
            this.customRate.Text = "Custom";
            this.customRate.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Freq (bitrate)";
            // 
            // standardRate33K
            // 
            this.standardRate33K.AutoSize = true;
            this.standardRate33K.Location = new System.Drawing.Point(13, 176);
            this.standardRate33K.Name = "standardRate33K";
            this.standardRate33K.Size = new System.Drawing.Size(102, 17);
            this.standardRate33K.TabIndex = 7;
            this.standardRate33K.Text = "33K (single-wire)";
            this.standardRate33K.UseVisualStyleBackColor = true;
            // 
            // standardRate50K
            // 
            this.standardRate50K.AutoSize = true;
            this.standardRate50K.Location = new System.Drawing.Point(13, 153);
            this.standardRate50K.Name = "standardRate50K";
            this.standardRate50K.Size = new System.Drawing.Size(44, 17);
            this.standardRate50K.TabIndex = 6;
            this.standardRate50K.Text = "50K";
            this.standardRate50K.UseVisualStyleBackColor = true;
            // 
            // standardRate62K
            // 
            this.standardRate62K.AutoSize = true;
            this.standardRate62K.Location = new System.Drawing.Point(13, 130);
            this.standardRate62K.Name = "standardRate62K";
            this.standardRate62K.Size = new System.Drawing.Size(44, 17);
            this.standardRate62K.TabIndex = 5;
            this.standardRate62K.Text = "62K";
            this.standardRate62K.UseVisualStyleBackColor = true;
            // 
            // standardRate100K
            // 
            this.standardRate100K.AutoSize = true;
            this.standardRate100K.Location = new System.Drawing.Point(13, 107);
            this.standardRate100K.Name = "standardRate100K";
            this.standardRate100K.Size = new System.Drawing.Size(50, 17);
            this.standardRate100K.TabIndex = 4;
            this.standardRate100K.Text = "100K";
            this.standardRate100K.UseVisualStyleBackColor = true;
            // 
            // standardRate125K
            // 
            this.standardRate125K.AutoSize = true;
            this.standardRate125K.Location = new System.Drawing.Point(13, 84);
            this.standardRate125K.Name = "standardRate125K";
            this.standardRate125K.Size = new System.Drawing.Size(50, 17);
            this.standardRate125K.TabIndex = 3;
            this.standardRate125K.Text = "125K";
            this.standardRate125K.UseVisualStyleBackColor = true;
            // 
            // standardRate250K
            // 
            this.standardRate250K.AutoSize = true;
            this.standardRate250K.Location = new System.Drawing.Point(13, 61);
            this.standardRate250K.Name = "standardRate250K";
            this.standardRate250K.Size = new System.Drawing.Size(50, 17);
            this.standardRate250K.TabIndex = 2;
            this.standardRate250K.Text = "250K";
            this.standardRate250K.UseVisualStyleBackColor = true;
            // 
            // standardRate500K
            // 
            this.standardRate500K.AutoSize = true;
            this.standardRate500K.Checked = true;
            this.standardRate500K.Location = new System.Drawing.Point(13, 38);
            this.standardRate500K.Name = "standardRate500K";
            this.standardRate500K.Size = new System.Drawing.Size(50, 17);
            this.standardRate500K.TabIndex = 1;
            this.standardRate500K.TabStop = true;
            this.standardRate500K.Text = "500K";
            this.standardRate500K.UseVisualStyleBackColor = true;
            // 
            // standardRate1M
            // 
            this.standardRate1M.AutoSize = true;
            this.standardRate1M.Location = new System.Drawing.Point(13, 15);
            this.standardRate1M.Name = "standardRate1M";
            this.standardRate1M.Size = new System.Drawing.Size(40, 17);
            this.standardRate1M.TabIndex = 0;
            this.standardRate1M.Text = "1M";
            this.standardRate1M.UseVisualStyleBackColor = true;
            // 
            // Custom
            // 
            this.Custom.Controls.Add(this.label6);
            this.Custom.Controls.Add(this.label5);
            this.Custom.Controls.Add(this.bitrateBox);
            this.Custom.Controls.Add(this.label4);
            this.Custom.Controls.Add(this.tseg1Box);
            this.Custom.Controls.Add(this.label3);
            this.Custom.Controls.Add(this.tseg2Box);
            this.Custom.Controls.Add(this.label2);
            this.Custom.Controls.Add(this.sjwBox);
            this.Custom.Controls.Add(this.noSampBox);
            this.Custom.Location = new System.Drawing.Point(4, 22);
            this.Custom.Name = "Custom";
            this.Custom.Padding = new System.Windows.Forms.Padding(3);
            this.Custom.Size = new System.Drawing.Size(220, 256);
            this.Custom.TabIndex = 1;
            this.Custom.Text = "Custom Settings";
            this.Custom.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Freq (bitrate)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Sampling Points";
            // 
            // bitrateBox
            // 
            this.bitrateBox.Location = new System.Drawing.Point(106, 19);
            this.bitrateBox.Name = "bitrateBox";
            this.bitrateBox.Size = new System.Drawing.Size(100, 20);
            this.bitrateBox.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Sync Jump";
            // 
            // tseg1Box
            // 
            this.tseg1Box.Location = new System.Drawing.Point(106, 59);
            this.tseg1Box.Name = "tseg1Box";
            this.tseg1Box.Size = new System.Drawing.Size(100, 20);
            this.tseg1Box.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Time Segment 2";
            // 
            // tseg2Box
            // 
            this.tseg2Box.Location = new System.Drawing.Point(106, 98);
            this.tseg2Box.Name = "tseg2Box";
            this.tseg2Box.Size = new System.Drawing.Size(100, 20);
            this.tseg2Box.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Time Segment 1";
            // 
            // sjwBox
            // 
            this.sjwBox.Location = new System.Drawing.Point(106, 137);
            this.sjwBox.Name = "sjwBox";
            this.sjwBox.Size = new System.Drawing.Size(100, 20);
            this.sjwBox.TabIndex = 49;
            // 
            // noSampBox
            // 
            this.noSampBox.Location = new System.Drawing.Point(106, 176);
            this.noSampBox.Name = "noSampBox";
            this.noSampBox.Size = new System.Drawing.Size(100, 20);
            this.noSampBox.TabIndex = 50;
            // 
            // XMLFilter
            // 
            this.XMLFilter.Controls.Add(this.editFilter);
            this.XMLFilter.Controls.Add(this.filterLocation);
            this.XMLFilter.Controls.Add(this.label8);
            this.XMLFilter.Location = new System.Drawing.Point(4, 22);
            this.XMLFilter.Name = "XMLFilter";
            this.XMLFilter.Padding = new System.Windows.Forms.Padding(3);
            this.XMLFilter.Size = new System.Drawing.Size(220, 256);
            this.XMLFilter.TabIndex = 2;
            this.XMLFilter.Text = "XML Filter";
            this.XMLFilter.UseVisualStyleBackColor = true;
            this.XMLFilter.Click += new System.EventHandler(this.XMLFilter_Click);
            // 
            // editFilter
            // 
            this.editFilter.Location = new System.Drawing.Point(10, 104);
            this.editFilter.Name = "editFilter";
            this.editFilter.Size = new System.Drawing.Size(115, 23);
            this.editFilter.TabIndex = 49;
            this.editFilter.Text = "Edit Filter Location";
            this.editFilter.UseVisualStyleBackColor = true;
            this.editFilter.Click += new System.EventHandler(this.editFilter_Click);
            // 
            // filterLocation
            // 
            this.filterLocation.Location = new System.Drawing.Point(10, 32);
            this.filterLocation.Multiline = true;
            this.filterLocation.Name = "filterLocation";
            this.filterLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.filterLocation.Size = new System.Drawing.Size(204, 66);
            this.filterLocation.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Filter Location";
            // 
            // advancedBusControl
            // 
            this.advancedBusControl.AutoSize = true;
            this.advancedBusControl.Location = new System.Drawing.Point(532, 346);
            this.advancedBusControl.Name = "advancedBusControl";
            this.advancedBusControl.Size = new System.Drawing.Size(172, 17);
            this.advancedBusControl.TabIndex = 47;
            this.advancedBusControl.Text = "Skip Guided Bus Control Setup";
            this.advancedBusControl.UseVisualStyleBackColor = true;
            this.advancedBusControl.CheckedChanged += new System.EventHandler(this.advancedBusControl_CheckedChanged);
            // 
            // backgroundWorkerRefresh
            // 
            this.backgroundWorkerRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRefresh_DoWork);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // BusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 417);
            this.Controls.Add(this.advancedBusControl);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BusOff);
            this.Controls.Add(this.BusOn);
            this.Controls.Add(this.RefreshInterfaces);
            this.Controls.Add(this.InterfaceBox);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BusControl";
            this.Text = "Advanced Bus Control";
            this.Load += new System.EventHandler(this.BusControl_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Standard.ResumeLayout(false);
            this.canSettings.ResumeLayout(false);
            this.canSettings.PerformLayout();
            this.Custom.ResumeLayout(false);
            this.Custom.PerformLayout();
            this.XMLFilter.ResumeLayout(false);
            this.XMLFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListView InterfaceBox;
        private System.Windows.Forms.Button RefreshInterfaces;
        private System.Windows.Forms.Button BusOn;
        private System.Windows.Forms.Button BusOff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Standard;
        private System.Windows.Forms.TabPage Custom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bitrateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tseg1Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tseg2Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sjwBox;
        private System.Windows.Forms.TextBox noSampBox;
        private System.Windows.Forms.Panel canSettings;
        private System.Windows.Forms.RadioButton standardRate1M;
        private System.Windows.Forms.RadioButton standardRate33K;
        private System.Windows.Forms.RadioButton standardRate50K;
        private System.Windows.Forms.RadioButton standardRate62K;
        private System.Windows.Forms.RadioButton standardRate100K;
        private System.Windows.Forms.RadioButton standardRate125K;
        private System.Windows.Forms.RadioButton standardRate250K;
        private System.Windows.Forms.RadioButton standardRate500K;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton customRate;
        private System.Windows.Forms.TabPage XMLFilter;
        private System.Windows.Forms.TextBox filterLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button editFilter;
        private System.Windows.Forms.CheckBox advancedBusControl;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRefresh;
        private System.Windows.Forms.Timer timerRefresh;
    }
}