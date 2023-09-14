namespace ProMeasurement
{
    partial class Pro_Measurement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pro_Measurement));
            this.btnStopP = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxPlace = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnRelative = new System.Windows.Forms.RadioButton();
            this.rbtnAbsolute = new System.Windows.Forms.RadioButton();
            this.textBoxAOM = new System.Windows.Forms.TextBox();
            this.textBoxPositionStart = new System.Windows.Forms.TextBox();
            this.timerEngine = new System.Windows.Forms.Timer(this.components);
            this.textBoxPositionActualValue = new System.Windows.Forms.TextBox();
            this.timerPower = new System.Windows.Forms.Timer(this.components);
            this.textBoxForce = new System.Windows.Forms.TextBox();
            this.btnRelese = new System.Windows.Forms.Button();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxCNum = new System.Windows.Forms.TextBox();
            this.textBoxTDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timerModeTest = new System.Windows.Forms.Timer(this.components);
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.textBoxperiodicity = new System.Windows.Forms.TextBox();
            this.comboBoxdirection = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSpringConstant = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPowerMeter = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnConnectMotor = new System.Windows.Forms.Button();
            this.btnConnectMeasurement = new System.Windows.Forms.Button();
            this.btnSettingMeasurement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStopP
            // 
            this.btnStopP.Location = new System.Drawing.Point(1264, 72);
            this.btnStopP.Name = "btnStopP";
            this.btnStopP.Size = new System.Drawing.Size(120, 45);
            this.btnStopP.TabIndex = 1;
            this.btnStopP.Text = "Stop Process";
            this.btnStopP.UseVisualStyleBackColor = true;
            this.btnStopP.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1404, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Go To Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxPlace
            // 
            this.textBoxPlace.Location = new System.Drawing.Point(174, 39);
            this.textBoxPlace.Name = "textBoxPlace";
            this.textBoxPlace.Size = new System.Drawing.Size(116, 22);
            this.textBoxPlace.TabIndex = 3;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(12, 39);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(121, 22);
            this.textBoxSpeed.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(804, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Actual Position";
            // 
            // rbtnRelative
            // 
            this.rbtnRelative.AutoSize = true;
            this.rbtnRelative.Location = new System.Drawing.Point(13, 78);
            this.rbtnRelative.Name = "rbtnRelative";
            this.rbtnRelative.Size = new System.Drawing.Size(78, 20);
            this.rbtnRelative.TabIndex = 7;
            this.rbtnRelative.TabStop = true;
            this.rbtnRelative.Text = "Relative";
            this.rbtnRelative.UseVisualStyleBackColor = true;
            // 
            // rbtnAbsolute
            // 
            this.rbtnAbsolute.AutoSize = true;
            this.rbtnAbsolute.Location = new System.Drawing.Point(97, 80);
            this.rbtnAbsolute.Name = "rbtnAbsolute";
            this.rbtnAbsolute.Size = new System.Drawing.Size(81, 20);
            this.rbtnAbsolute.TabIndex = 8;
            this.rbtnAbsolute.TabStop = true;
            this.rbtnAbsolute.Text = "Absolute";
            this.rbtnAbsolute.UseVisualStyleBackColor = true;
            // 
            // textBoxAOM
            // 
            this.textBoxAOM.Location = new System.Drawing.Point(308, 78);
            this.textBoxAOM.Name = "textBoxAOM";
            this.textBoxAOM.Size = new System.Drawing.Size(100, 22);
            this.textBoxAOM.TabIndex = 9;
            this.textBoxAOM.Text = "1";
            // 
            // textBoxPositionStart
            // 
            this.textBoxPositionStart.Location = new System.Drawing.Point(190, 76);
            this.textBoxPositionStart.Name = "textBoxPositionStart";
            this.textBoxPositionStart.Size = new System.Drawing.Size(100, 22);
            this.textBoxPositionStart.TabIndex = 10;
            this.textBoxPositionStart.Text = "0";
            // 
            // timerEngine
            // 
            this.timerEngine.Tick += new System.EventHandler(this.timerEngine_Tick);
            // 
            // textBoxPositionActualValue
            // 
            this.textBoxPositionActualValue.Location = new System.Drawing.Point(908, 26);
            this.textBoxPositionActualValue.Name = "textBoxPositionActualValue";
            this.textBoxPositionActualValue.Size = new System.Drawing.Size(76, 22);
            this.textBoxPositionActualValue.TabIndex = 11;
            // 
            // timerPower
            // 
            this.timerPower.Interval = 50;
            this.timerPower.Tick += new System.EventHandler(this.timerPower_Tick);
            // 
            // textBoxForce
            // 
            this.textBoxForce.Location = new System.Drawing.Point(890, 54);
            this.textBoxForce.Name = "textBoxForce";
            this.textBoxForce.Size = new System.Drawing.Size(94, 22);
            this.textBoxForce.TabIndex = 13;
            // 
            // btnRelese
            // 
            this.btnRelese.Location = new System.Drawing.Point(1404, 104);
            this.btnRelese.Name = "btnRelese";
            this.btnRelese.Size = new System.Drawing.Size(120, 30);
            this.btnRelese.TabIndex = 16;
            this.btnRelese.Text = "Relese";
            this.btnRelese.UseVisualStyleBackColor = true;
            this.btnRelese.Click += new System.EventHandler(this.btnRelese_Click);
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Free",
            "Glue",
            "Line",
            "Rotary"});
            this.comboBoxMode.Location = new System.Drawing.Point(1114, 26);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMode.TabIndex = 17;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 154);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1735, 401);
            this.zedGraphControl1.TabIndex = 18;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(804, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Actual Force";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Position in mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "RPM speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1111, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mode";
            // 
            // textBoxType
            // 
            this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxType.Location = new System.Drawing.Point(1596, 597);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(151, 22);
            this.textBoxType.TabIndex = 23;
            // 
            // textBoxCNum
            // 
            this.textBoxCNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCNum.Location = new System.Drawing.Point(1177, 597);
            this.textBoxCNum.Name = "textBoxCNum";
            this.textBoxCNum.Size = new System.Drawing.Size(151, 22);
            this.textBoxCNum.TabIndex = 24;
            // 
            // textBoxTDescription
            // 
            this.textBoxTDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTDescription.Location = new System.Drawing.Point(1389, 597);
            this.textBoxTDescription.Name = "textBoxTDescription";
            this.textBoxTDescription.Size = new System.Drawing.Size(151, 22);
            this.textBoxTDescription.TabIndex = 25;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 583);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 36);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1596, 575);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Type";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1386, 575);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Discription";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1174, 575);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Catalog Num";
            // 
            // timerModeTest
            // 
            this.timerModeTest.Tick += new System.EventHandler(this.timerModeTest_Tick);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(378, 16);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(54, 45);
            this.btnDown.TabIndex = 30;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown_1);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(308, 18);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(54, 45);
            this.btnUp.TabIndex = 31;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(570, 31);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(100, 22);
            this.textBoxDistance.TabIndex = 32;
            // 
            // textBoxperiodicity
            // 
            this.textBoxperiodicity.Location = new System.Drawing.Point(464, 31);
            this.textBoxperiodicity.Name = "textBoxperiodicity";
            this.textBoxperiodicity.Size = new System.Drawing.Size(100, 22);
            this.textBoxperiodicity.TabIndex = 33;
            // 
            // comboBoxdirection
            // 
            this.comboBoxdirection.FormattingEnabled = true;
            this.comboBoxdirection.Items.AddRange(new object[] {
            "Up",
            "Down"});
            this.comboBoxdirection.Location = new System.Drawing.Point(677, 29);
            this.comboBoxdirection.Name = "comboBoxdirection";
            this.comboBoxdirection.Size = new System.Drawing.Size(121, 24);
            this.comboBoxdirection.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(570, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "Distance";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(461, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 36;
            this.label10.Text = "Periodicity";
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Crimson;
            this.btnRestart.ForeColor = System.Drawing.Color.Black;
            this.btnRestart.Location = new System.Drawing.Point(1264, 19);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(120, 42);
            this.btnRestart.TabIndex = 37;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1115, 78);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 42);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "Clear Graph";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(677, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 16);
            this.label11.TabIndex = 39;
            this.label11.Text = "Direction";
            // 
            // textBoxSpringConstant
            // 
            this.textBoxSpringConstant.Location = new System.Drawing.Point(961, 596);
            this.textBoxSpringConstant.Name = "textBoxSpringConstant";
            this.textBoxSpringConstant.Size = new System.Drawing.Size(143, 22);
            this.textBoxSpringConstant.TabIndex = 40;
            this.textBoxSpringConstant.Text = "---";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(961, 575);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 16);
            this.label12.TabIndex = 41;
            this.label12.Text = "Spring Constant";
            // 
            // textBoxPowerMeter
            // 
            this.textBoxPowerMeter.Location = new System.Drawing.Point(1004, 28);
            this.textBoxPowerMeter.Name = "textBoxPowerMeter";
            this.textBoxPowerMeter.Size = new System.Drawing.Size(100, 22);
            this.textBoxPowerMeter.TabIndex = 42;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1001, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 43;
            this.label13.Text = "Force N";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(1404, 59);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 30);
            this.btnStop.TabIndex = 44;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnConnectMotor
            // 
            this.btnConnectMotor.Location = new System.Drawing.Point(1585, 19);
            this.btnConnectMotor.Name = "btnConnectMotor";
            this.btnConnectMotor.Size = new System.Drawing.Size(162, 34);
            this.btnConnectMotor.TabIndex = 45;
            this.btnConnectMotor.Text = "Connect Motor";
            this.btnConnectMotor.UseVisualStyleBackColor = true;
            this.btnConnectMotor.Click += new System.EventHandler(this.btnConnectMotor_Click);
            // 
            // btnConnectMeasurement
            // 
            this.btnConnectMeasurement.Location = new System.Drawing.Point(1585, 59);
            this.btnConnectMeasurement.Name = "btnConnectMeasurement";
            this.btnConnectMeasurement.Size = new System.Drawing.Size(162, 30);
            this.btnConnectMeasurement.TabIndex = 46;
            this.btnConnectMeasurement.Text = "Connect Power Meter";
            this.btnConnectMeasurement.UseVisualStyleBackColor = true;
            this.btnConnectMeasurement.Click += new System.EventHandler(this.btnConnectMeasurement_Click);
            // 
            // btnSettingMeasurement
            // 
            this.btnSettingMeasurement.Location = new System.Drawing.Point(1585, 95);
            this.btnSettingMeasurement.Name = "btnSettingMeasurement";
            this.btnSettingMeasurement.Size = new System.Drawing.Size(162, 30);
            this.btnSettingMeasurement.TabIndex = 47;
            this.btnSettingMeasurement.Text = "Setting Power Meter";
            this.btnSettingMeasurement.UseVisualStyleBackColor = true;
            this.btnSettingMeasurement.Click += new System.EventHandler(this.btnSettingMeasurement_Click);
            // 
            // Pro_Measurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 641);
            this.Controls.Add(this.btnSettingMeasurement);
            this.Controls.Add(this.btnConnectMeasurement);
            this.Controls.Add(this.btnConnectMotor);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxPowerMeter);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxSpringConstant);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxdirection);
            this.Controls.Add(this.textBoxperiodicity);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxTDescription);
            this.Controls.Add(this.textBoxCNum);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.btnRelese);
            this.Controls.Add(this.textBoxPositionStart);
            this.Controls.Add(this.textBoxAOM);
            this.Controls.Add(this.rbtnAbsolute);
            this.Controls.Add(this.rbtnRelative);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.textBoxPlace);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStopP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxForce);
            this.Controls.Add(this.textBoxPositionActualValue);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pro_Measurement";
            this.Text = "Pro Measurement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pro_Measurement_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerEngine;
        private System.Windows.Forms.Timer timerPower;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxCNum;
        private System.Windows.Forms.TextBox textBoxTDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timerModeTest;
        private System.Windows.Forms.Button btnStopP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxPlace;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnRelative;
        private System.Windows.Forms.RadioButton rbtnAbsolute;
        private System.Windows.Forms.TextBox textBoxAOM;
        private System.Windows.Forms.TextBox textBoxPositionStart;
        private System.Windows.Forms.TextBox textBoxPositionActualValue;
        private System.Windows.Forms.TextBox textBoxForce;
        private System.Windows.Forms.Button btnRelese;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.TextBox textBoxperiodicity;
        private System.Windows.Forms.ComboBox comboBoxdirection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSpringConstant;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPowerMeter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnConnectMotor;
        private System.Windows.Forms.Button btnConnectMeasurement;
        private System.Windows.Forms.Button btnSettingMeasurement;
    }
}

