namespace OpenCarTestbed.Windows
{
    partial class AddXmlDocument
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
            this.loadXmlFile = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.lblXMLFile = new System.Windows.Forms.Label();
            this.btnNewXmlDoc = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rbNewXML = new System.Windows.Forms.RadioButton();
            this.txtCarType = new System.Windows.Forms.TextBox();
            this.rbDefaultXML = new System.Windows.Forms.RadioButton();
            this.rbLoadXML = new System.Windows.Forms.RadioButton();
            this.lblCarType = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadXmlFile
            // 
            this.loadXmlFile.Location = new System.Drawing.Point(476, 165);
            this.loadXmlFile.Name = "loadXmlFile";
            this.loadXmlFile.Size = new System.Drawing.Size(138, 23);
            this.loadXmlFile.TabIndex = 6;
            this.loadXmlFile.Text = "Load XML File";
            this.loadXmlFile.UseVisualStyleBackColor = true;
            this.loadXmlFile.Click += new System.EventHandler(this.loadXmlFile_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(254, 49);
            this.txtFileLocation.Multiline = true;
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(334, 20);
            this.txtFileLocation.TabIndex = 5;
            // 
            // lblXMLFile
            // 
            this.lblXMLFile.AutoSize = true;
            this.lblXMLFile.Location = new System.Drawing.Point(156, 52);
            this.lblXMLFile.Name = "lblXMLFile";
            this.lblXMLFile.Size = new System.Drawing.Size(92, 13);
            this.lblXMLFile.TabIndex = 4;
            this.lblXMLFile.Text = "XML File Location";
            // 
            // btnNewXmlDoc
            // 
            this.btnNewXmlDoc.Location = new System.Drawing.Point(476, 107);
            this.btnNewXmlDoc.Name = "btnNewXmlDoc";
            this.btnNewXmlDoc.Size = new System.Drawing.Size(138, 23);
            this.btnNewXmlDoc.TabIndex = 7;
            this.btnNewXmlDoc.Text = "New XML Document";
            this.btnNewXmlDoc.UseVisualStyleBackColor = true;
            this.btnNewXmlDoc.Click += new System.EventHandler(this.btnNewXmlDoc_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(476, 136);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(138, 23);
            this.btnDefault.TabIndex = 8;
            this.btnDefault.Text = "Use Default File";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // rbNewXML
            // 
            this.rbNewXML.AutoSize = true;
            this.rbNewXML.Location = new System.Drawing.Point(12, 21);
            this.rbNewXML.Name = "rbNewXML";
            this.rbNewXML.Size = new System.Drawing.Size(124, 17);
            this.rbNewXML.TabIndex = 9;
            this.rbNewXML.TabStop = true;
            this.rbNewXML.Text = "New XML Document";
            this.rbNewXML.UseVisualStyleBackColor = true;
            this.rbNewXML.CheckedChanged += new System.EventHandler(this.rbNewXML_CheckedChanged);
            // 
            // txtCarType
            // 
            this.txtCarType.Location = new System.Drawing.Point(254, 83);
            this.txtCarType.Name = "txtCarType";
            this.txtCarType.Size = new System.Drawing.Size(100, 20);
            this.txtCarType.TabIndex = 10;
            this.txtCarType.Visible = false;
            // 
            // rbDefaultXML
            // 
            this.rbDefaultXML.AutoSize = true;
            this.rbDefaultXML.Location = new System.Drawing.Point(12, 63);
            this.rbDefaultXML.Name = "rbDefaultXML";
            this.rbDefaultXML.Size = new System.Drawing.Size(106, 17);
            this.rbDefaultXML.TabIndex = 11;
            this.rbDefaultXML.TabStop = true;
            this.rbDefaultXML.Text = "Use Default XML";
            this.rbDefaultXML.UseVisualStyleBackColor = true;
            this.rbDefaultXML.CheckedChanged += new System.EventHandler(this.rbDefaultXML_CheckedChanged);
            // 
            // rbLoadXML
            // 
            this.rbLoadXML.AutoSize = true;
            this.rbLoadXML.Location = new System.Drawing.Point(12, 107);
            this.rbLoadXML.Name = "rbLoadXML";
            this.rbLoadXML.Size = new System.Drawing.Size(90, 17);
            this.rbLoadXML.TabIndex = 12;
            this.rbLoadXML.TabStop = true;
            this.rbLoadXML.Text = "Load XML file";
            this.rbLoadXML.UseVisualStyleBackColor = true;
            this.rbLoadXML.CheckedChanged += new System.EventHandler(this.rbLoadXML_CheckedChanged);
            // 
            // lblCarType
            // 
            this.lblCarType.AutoSize = true;
            this.lblCarType.Location = new System.Drawing.Point(198, 86);
            this.lblCarType.Name = "lblCarType";
            this.lblCarType.Size = new System.Drawing.Size(50, 13);
            this.lblCarType.TabIndex = 13;
            this.lblCarType.Text = "Car Type";
            this.lblCarType.Visible = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(254, 124);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // AddXmlDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 193);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblCarType);
            this.Controls.Add(this.rbLoadXML);
            this.Controls.Add(this.rbDefaultXML);
            this.Controls.Add(this.txtCarType);
            this.Controls.Add(this.rbNewXML);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnNewXmlDoc);
            this.Controls.Add(this.loadXmlFile);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.lblXMLFile);
            this.Name = "AddXmlDocument";
            this.Text = "AddXmlDocument";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadXmlFile;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Label lblXMLFile;
        private System.Windows.Forms.Button btnNewXmlDoc;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton rbNewXML;
        private System.Windows.Forms.TextBox txtCarType;
        private System.Windows.Forms.RadioButton rbDefaultXML;
        private System.Windows.Forms.RadioButton rbLoadXML;
        private System.Windows.Forms.Label lblCarType;
        private System.Windows.Forms.Button btnSubmit;

    }
}