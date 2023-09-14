namespace OphirSim
{
    partial class CommunicationPropertiesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationPropertiesDialog));
            this.DefaultsBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.m_cbStopBits = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.m_cbParity = new System.Windows.Forms.ComboBox();
            this.m_cbDataBits = new System.Windows.Forms.ComboBox();
            this.m_cbBaudRate = new System.Windows.Forms.ComboBox();
            this.m_cbComPort = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DefaultsBtn
            // 
            this.DefaultsBtn.Location = new System.Drawing.Point(192, 14);
            this.DefaultsBtn.Name = "DefaultsBtn";
            this.DefaultsBtn.Size = new System.Drawing.Size(79, 39);
            this.DefaultsBtn.TabIndex = 39;
            this.DefaultsBtn.Text = "Defaults";
            this.DefaultsBtn.Click += new System.EventHandler(this.DefaultsBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("CancelBtn.Image")));
            this.CancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelBtn.Location = new System.Drawing.Point(192, 110);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(79, 39);
            this.CancelBtn.TabIndex = 38;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Image = ((System.Drawing.Image)(resources.GetObject("OKBtn.Image")));
            this.OKBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKBtn.Location = new System.Drawing.Point(192, 62);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(79, 39);
            this.OKBtn.TabIndex = 37;
            this.OKBtn.Text = "&OK";
            this.OKBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OKBtn.Click += new System.EventHandler(this.OK_Click);
            // 
            // m_cbStopBits
            // 
            this.m_cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbStopBits.Location = new System.Drawing.Point(104, 126);
            this.m_cbStopBits.Name = "m_cbStopBits";
            this.m_cbStopBits.Size = new System.Drawing.Size(74, 21);
            this.m_cbStopBits.TabIndex = 36;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(19, 130);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(51, 13);
            this.Label5.TabIndex = 35;
            this.Label5.Text = "&Stop bits:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(19, 102);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(52, 13);
            this.Label4.TabIndex = 33;
            this.Label4.Text = "&Data bits:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(19, 74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 13);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "&Parity:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(19, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 13);
            this.Label2.TabIndex = 29;
            this.Label2.Text = "&Baud rate:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(19, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 13);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "&COM Port:";
            // 
            // m_cbParity
            // 
            this.m_cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbParity.Location = new System.Drawing.Point(104, 70);
            this.m_cbParity.Name = "m_cbParity";
            this.m_cbParity.Size = new System.Drawing.Size(74, 21);
            this.m_cbParity.TabIndex = 32;
            // 
            // m_cbDataBits
            // 
            this.m_cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbDataBits.Location = new System.Drawing.Point(104, 98);
            this.m_cbDataBits.Name = "m_cbDataBits";
            this.m_cbDataBits.Size = new System.Drawing.Size(74, 21);
            this.m_cbDataBits.TabIndex = 34;
            // 
            // m_cbBaudRate
            // 
            this.m_cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBaudRate.Location = new System.Drawing.Point(104, 42);
            this.m_cbBaudRate.Name = "m_cbBaudRate";
            this.m_cbBaudRate.Size = new System.Drawing.Size(74, 21);
            this.m_cbBaudRate.TabIndex = 30;
            // 
            // m_cbComPort
            // 
            this.m_cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbComPort.Location = new System.Drawing.Point(104, 14);
            this.m_cbComPort.Name = "m_cbComPort";
            this.m_cbComPort.Size = new System.Drawing.Size(72, 21);
            this.m_cbComPort.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.DefaultsBtn);
            this.panel1.Controls.Add(this.m_cbComPort);
            this.panel1.Controls.Add(this.CancelBtn);
            this.panel1.Controls.Add(this.m_cbBaudRate);
            this.panel1.Controls.Add(this.OKBtn);
            this.panel1.Controls.Add(this.m_cbDataBits);
            this.panel1.Controls.Add(this.m_cbStopBits);
            this.panel1.Controls.Add(this.m_cbParity);
            this.panel1.Controls.Add(this.Label5);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label4);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 176);
            this.panel1.TabIndex = 40;
            // 
            // CommunicationPropertiesDialog
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(308, 176);
            this.Controls.Add(this.panel1);
            this.Name = "CommunicationPropertiesDialog";
            this.Text = " UART Properties";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DefaultsBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.ComboBox m_cbStopBits;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox m_cbParity;
        private System.Windows.Forms.ComboBox m_cbDataBits;
        private System.Windows.Forms.ComboBox m_cbBaudRate;
        private System.Windows.Forms.ComboBox m_cbComPort;
        private System.Windows.Forms.Panel panel1;
    }
}