namespace OpenCarTestbed
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileWindowsVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.actionWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorBusMultiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transmitPacketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customTransmitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidedBusControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editXMLDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.XMLEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLogWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdvancedBusControl = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGuidedBusControl = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.actionWindowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileWindowsToolStripMenuItem,
            this.tileWindowsVerticallyToolStripMenuItem,
            this.iconWindowsToolStripMenuItem,
            this.toolStripSeparator1});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade Windows";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // tileWindowsToolStripMenuItem
            // 
            this.tileWindowsToolStripMenuItem.Name = "tileWindowsToolStripMenuItem";
            this.tileWindowsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.tileWindowsToolStripMenuItem.Text = "Tile Windows Horizontally";
            this.tileWindowsToolStripMenuItem.Click += new System.EventHandler(this.tileWindowsToolStripMenuItem_Click);
            // 
            // tileWindowsVerticallyToolStripMenuItem
            // 
            this.tileWindowsVerticallyToolStripMenuItem.Name = "tileWindowsVerticallyToolStripMenuItem";
            this.tileWindowsVerticallyToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.tileWindowsVerticallyToolStripMenuItem.Text = "Tile Windows Vertically";
            this.tileWindowsVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileWindowsVerticallyToolStripMenuItem_Click);
            // 
            // iconWindowsToolStripMenuItem
            // 
            this.iconWindowsToolStripMenuItem.Name = "iconWindowsToolStripMenuItem";
            this.iconWindowsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.iconWindowsToolStripMenuItem.Text = "Icon Windows";
            this.iconWindowsToolStripMenuItem.Click += new System.EventHandler(this.iconWindowsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(209, 6);
            // 
            // actionWindowToolStripMenuItem
            // 
            this.actionWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorBusMultiToolStripMenuItem,
            this.transmitPacketsToolStripMenuItem,
            this.customTransmitToolStripMenuItem,
            this.busSettingsToolStripMenuItem,
            this.guidedBusControlToolStripMenuItem,
            this.busControlToolStripMenuItem,
            this.editXMLDataToolStripMenuItem,
            this.logWindowToolStripMenuItem});
            this.actionWindowToolStripMenuItem.Name = "actionWindowToolStripMenuItem";
            this.actionWindowToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.actionWindowToolStripMenuItem.Text = "View";
            // 
            // monitorBusMultiToolStripMenuItem
            // 
            this.monitorBusMultiToolStripMenuItem.Name = "monitorBusMultiToolStripMenuItem";
            this.monitorBusMultiToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.monitorBusMultiToolStripMenuItem.Text = "Monitor Bus";
            this.monitorBusMultiToolStripMenuItem.Click += new System.EventHandler(this.monitorBusMultiToolStripMenuItem_Click);
            // 
            // transmitPacketsToolStripMenuItem
            // 
            this.transmitPacketsToolStripMenuItem.Name = "transmitPacketsToolStripMenuItem";
            this.transmitPacketsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.transmitPacketsToolStripMenuItem.Text = "Transmit Packets";
            this.transmitPacketsToolStripMenuItem.Click += new System.EventHandler(this.transmitPacketsToolStripMenuItem_Click);
            // 
            // customTransmitToolStripMenuItem
            // 
            this.customTransmitToolStripMenuItem.Name = "customTransmitToolStripMenuItem";
            this.customTransmitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.customTransmitToolStripMenuItem.Text = "Custom Transmit";
            this.customTransmitToolStripMenuItem.Click += new System.EventHandler(this.customTransmitToolStripMenuItem_Click);
            // 
            // busSettingsToolStripMenuItem
            // 
            this.busSettingsToolStripMenuItem.Name = "busSettingsToolStripMenuItem";
            this.busSettingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.busSettingsToolStripMenuItem.Text = "Bus Settings";
            this.busSettingsToolStripMenuItem.Click += new System.EventHandler(this.busSettingsToolStripMenuItem_Click);
            // 
            // guidedBusControlToolStripMenuItem
            // 
            this.guidedBusControlToolStripMenuItem.Name = "guidedBusControlToolStripMenuItem";
            this.guidedBusControlToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.guidedBusControlToolStripMenuItem.Text = "Guided Bus Control";
            this.guidedBusControlToolStripMenuItem.Click += new System.EventHandler(this.guidedBusControlToolStripMenuItem_Click);
            // 
            // busControlToolStripMenuItem
            // 
            this.busControlToolStripMenuItem.Name = "busControlToolStripMenuItem";
            this.busControlToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.busControlToolStripMenuItem.Text = "Advanced Bus Control";
            this.busControlToolStripMenuItem.Click += new System.EventHandler(this.busControlToolStripMenuItem_Click);
            // 
            // editXMLDataToolStripMenuItem
            // 
            this.editXMLDataToolStripMenuItem.Name = "editXMLDataToolStripMenuItem";
            this.editXMLDataToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editXMLDataToolStripMenuItem.Text = "Edit XML Data";
            this.editXMLDataToolStripMenuItem.Click += new System.EventHandler(this.editXMLDataToolStripMenuItem_Click);
            // 
            // logWindowToolStripMenuItem
            // 
            this.logWindowToolStripMenuItem.Name = "logWindowToolStripMenuItem";
            this.logWindowToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.logWindowToolStripMenuItem.Text = "Log Window";
            this.logWindowToolStripMenuItem.Click += new System.EventHandler(this.logWindowToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton2,
            this.XMLEdit,
            this.toolStripButtonLogWindow,
            this.toolStripButtonAdvancedBusControl,
            this.toolStripButtonGuidedBusControl,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1035, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Bus Monitor - Multi";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton4.Text = "Compact Bus Monitor";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripButton4.ToolTipText = "Compact Bus Monitor";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Tag = "Transmit Packets";
            this.toolStripButton2.Text = "Transmit Packets";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // XMLEdit
            // 
            this.XMLEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.XMLEdit.Image = ((System.Drawing.Image)(resources.GetObject("XMLEdit.Image")));
            this.XMLEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.XMLEdit.Name = "XMLEdit";
            this.XMLEdit.Size = new System.Drawing.Size(36, 36);
            this.XMLEdit.Text = "XML Edit";
            this.XMLEdit.Click += new System.EventHandler(this.XMLEdit_Click);
            // 
            // toolStripButtonLogWindow
            // 
            this.toolStripButtonLogWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLogWindow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLogWindow.Image")));
            this.toolStripButtonLogWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLogWindow.Name = "toolStripButtonLogWindow";
            this.toolStripButtonLogWindow.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonLogWindow.Text = "Log Window";
            this.toolStripButtonLogWindow.Click += new System.EventHandler(this.toolStripButtonLogWindow_Click);
            // 
            // toolStripButtonAdvancedBusControl
            // 
            this.toolStripButtonAdvancedBusControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdvancedBusControl.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdvancedBusControl.Image")));
            this.toolStripButtonAdvancedBusControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdvancedBusControl.Name = "toolStripButtonAdvancedBusControl";
            this.toolStripButtonAdvancedBusControl.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonAdvancedBusControl.Text = "Advanced Bus Control";
            this.toolStripButtonAdvancedBusControl.Click += new System.EventHandler(this.toolStripButtonAdvancedBusControl_Click);
            // 
            // toolStripButtonGuidedBusControl
            // 
            this.toolStripButtonGuidedBusControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGuidedBusControl.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGuidedBusControl.Image")));
            this.toolStripButtonGuidedBusControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGuidedBusControl.Name = "toolStripButtonGuidedBusControl";
            this.toolStripButtonGuidedBusControl.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonGuidedBusControl.Text = "Guided Bus Control";
            this.toolStripButtonGuidedBusControl.Click += new System.EventHandler(this.toolStripButtonGuidedBusControl_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "Custom Transmit";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1035, 494);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "OCTANE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorBusMultiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transmitPacketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customTransmitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileWindowsVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem busSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editXMLDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton XMLEdit;
        private System.Windows.Forms.ToolStripMenuItem logWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogWindow;
        private System.Windows.Forms.ToolStripMenuItem guidedBusControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdvancedBusControl;
        private System.Windows.Forms.ToolStripButton toolStripButtonGuidedBusControl;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}

