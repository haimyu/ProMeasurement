using System;
using System.Drawing;
using System.Windows.Forms;
using ProMeasurement.Properties;
using EposCmd.Net;
using EposCmd.Net.DeviceCmdSet.Operation;
using System.Security.Policy;
using System.IO.Ports;
using static ProMeasurement.Test;
using ZedGraph;
using System.IO;
using OfficeOpenXml;


namespace ProMeasurement
{
    public partial class Pro_Measurement : Form
    {   
        //devices DLL's
        private DeviceManager _connector;
        private Device _epos4;
        private Rs232 _powerPort;

        // graph 1
        private DateTime testStartTime;
        private PointPairList forceValues = new PointPairList();
        private PointPairList positionValues = new PointPairList();
        private LineItem forceCurve;
        private LineItem positionCurve;
        GraphPane graphPane;
        private string value;
        private double force;
        private double position = 0;
        private bool startGraph = false;

        //graph 2
        private PointPairList newPositionValues = new PointPairList();
        private PointPairList newForceValues = new PointPairList();
        private LineItem newforceCurve;
        private LineItem newpositionCurve;

        // state machine 
        private int done = 0;
        private int Start_Position; 
        private int Distance;
        private int Actual_Position;
        private bool HasBeenStop = false;
        private bool HasBeenStart = false;
        private bool HasBeenRelese = false;
        private bool stop = false;
        private TestMode CurrentModeTestState = TestMode.None;
        private FreeMode CurrentFreeTestState = FreeMode.None;
        private GlueTest CurrentGlueTestState = GlueTest.Rest;
        private LineTest CurrentLineTestState = LineTest.Rest;
        private RotaryTest CurrentRotaryTestState = RotaryTest.Rest;
        
        //control to save the power meter
        private double Nforce;

        public Pro_Measurement()
        {
            InitializeComponent();

            // Set up the ZedGraphControl
            graphPane = zedGraphControl1.GraphPane;
            graphPane.Title.Text = "Force Position vs Time";
            graphPane.XAxis.Title.Text = "Time";
            graphPane.YAxis.Title.Text = "Force";
            graphPane.Y2Axis.Title.Text = "Position";

            graphPane.Y2AxisList.Add("Position");
            graphPane.Y2AxisList[0].IsVisible = true;

            forceCurve = graphPane.AddCurve("Force", forceValues, Color.Blue, SymbolType.None);
            positionCurve = graphPane.AddCurve("Position", positionValues, Color.Red, SymbolType.None);
            forceCurve.Line.Width = 2;
            positionCurve.Line.Width = 2;
            positionCurve.YAxisIndex = 0; 
            positionCurve.IsY2Axis = true;

            newforceCurve = graphPane.AddCurve("Force", newForceValues, Color.Green, SymbolType.None);
            newpositionCurve = graphPane.AddCurve("Position", newPositionValues, Color.Purple, SymbolType.None);
            newpositionCurve.Line.Width = 2;
            newforceCurve.Line.Width = 2;
            newpositionCurve.YAxisIndex = 0; 
            newpositionCurve.IsY2Axis = true;
            newpositionCurve.IsVisible = false;
            newforceCurve.IsVisible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set up the setting in the load the program
            rbtnRelative.Checked = true;
            timerEngine.Interval = 500;
            timerEngine.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnSave.Enabled = false;
            btnRelese.Enabled = false;
            comboBoxdirection.Enabled = false;
            textBoxDistance.Enabled = false;
            textBoxperiodicity.Enabled = false;
            textBoxPlace.Enabled = false;
            textBoxSpeed.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            comboBoxMode.Enabled = false;


            //starting the power meter
            _powerPort = new Rs232();
            _powerPort.DataReceived += _powerPort_DataReceived;
            deviceSetting();
            Open();
            timerPower.Enabled = true;

            Actual_Position = _epos4.Operation.MotionInfo.GetPositionIs() / (163840 / 3);

        }

        private void Pro_Measurement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerModeTest.Start();
            switch (comboBoxMode.Text)
            {
                case "Free":
                    CurrentModeTestState = TestMode.Free;
                    break;

                case "Glue":
                    CurrentModeTestState = TestMode.Glue;
                    HasBeenStart = false;
                    break;

                case "Line":
                    CurrentModeTestState = TestMode.Line;
                    break;

                case "Rotary":
                    CurrentModeTestState = TestMode.Rotary;
                    break;

                default:
                    CurrentModeTestState = TestMode.None;
                    break;
            }
            testStartTime = DateTime.Now;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {           
            HasBeenStart = true;

            textBoxPositionStart.Text = string.Format("{0}", _epos4.Operation.MotionInfo.GetPositionIs() / (163840 / 3));
            Start_Position = Convert.ToInt32(textBoxPositionStart.Text);

            if(CurrentLineTestState == LineTest.StartTest || CurrentRotaryTestState == RotaryTest.Testing)
                Distance = Convert.ToInt32(textBoxDistance.Text);

            switch (comboBoxMode.Text)
            {
                case "Free":
                    stop = !stop;
                    break;

                case "Rotary":
                    stop = !stop;
                    break;

                default:
                    stop = false;
                    break;
            }
        }

        private void btnRelese_Click(object sender, EventArgs e)
        {
            HasBeenRelese = true;
            CurrentGlueTestState = GlueTest.Release;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            HasBeenStop = true;
            Stop();

            if (CurrentGlueTestState == GlueTest.Testing)
            {
                timerModeTest.Start();
                CurrentModeTestState = TestMode.Free;
                CurrentFreeTestState = FreeMode.None;
                btnStart.Enabled = true;

                newpositionCurve.IsVisible = true;
                newforceCurve.IsVisible = true;
            }
            timerModeTest.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            _epos4.Operation.ProfileVelocityMode.ActivateProfileVelocityMode();
            _epos4.Operation.ProfileVelocityMode.MoveWithVelocity(1000);
        }

        private void btnDown_MouseDown_1(object sender,MouseEventArgs e)
        {
            _epos4.Operation.ProfileVelocityMode.ActivateProfileVelocityMode();
            _epos4.Operation.ProfileVelocityMode.MoveWithVelocity(-1000);
        }

        private void btnUp_MouseUp(object sender,MouseEventArgs e)
        {
            Stop();
        }

        private void btnDown_MouseUp(object sender,MouseEventArgs e)
        {
            Stop();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            CurrentModeTestState = TestMode.None;
            startGraph = false;
            Stop();

            // Clear graph and reset variables
            ClearGraph();

            // Reset state machine and variables
            CurrentModeTestState = TestMode.None;

            // Reset state machine and variables
            HasBeenStop = false;
            HasBeenStart = false;
            HasBeenRelese = false;
            CurrentGlueTestState = GlueTest.Rest;
            CurrentLineTestState = LineTest.Rest;
            CurrentRotaryTestState = RotaryTest.Rest;
            done = 0;

            // Re-enable necessary controls
            btnStart.Enabled = true;
            btnRelese.Enabled = true;
            btnDown.Enabled = false;
            btnUp.Enabled = false;
            comboBoxMode.Enabled = true;
            btnSave.Enabled = false;

            // Reset position display
            comboBoxMode.Text = string.Empty;
            textBoxPositionActualValue.Text = string.Empty;
            textBoxPositionStart.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearGraph();
        }

        private void timerEngine_Tick(object sender, EventArgs e)
        {
            position = _epos4.Operation.MotionInfo.GetPositionIs() / (163840 / 3);
            int actualValue = Convert.ToInt32(position);
            try
            {
                if (_epos4 != null)
                {
                    textBoxPositionActualValue.Text = string.Format("{0}", actualValue);
                }
            }
            catch (DeviceException a)
            {
                StopRefresh();
                ShowMessageBox(a.ErrorMessage, a.ErrorCode);
            }
            catch (Exception a)
            {
                StopRefresh();

                MessageBox.Show(a.Message);
            }
            if (textBoxPowerMeter.Text != string.Empty)
                comboBoxMode.Enabled = true;
        }

        private void timerPower_Tick(object sender, EventArgs e)
        {
            _powerPort.Write("?");

        }

        // Engine function       
        private void deviceSetting()
        {
            try
            {
                _connector = new DeviceManager();

                uint b = _connector.Baudrate;

                _connector.Baudrate = b;
                _connector.Timeout = 500;
            }
            catch (DeviceException a)
            {
                StopRefresh();
                ShowMessageBox(a.ErrorMessage, a.ErrorCode);
            }
            catch (Exception a)
            {
                StopRefresh();

                MessageBox.Show(a.Message);
            }
            ////
            try
            {
                _epos4 = _connector.CreateDevice(1);

                StateMachine sm = _epos4.Operation.StateMachine;

                if (sm.GetFaultState())
                {
                    sm.ClearFault();
                }

                sm.SetEnableState();

                timerEngine.Enabled = true;
            }
            catch (DeviceException a)
            {
                StopRefresh();
                ShowMessageBox(a.ErrorMessage, a.ErrorCode);
            }
            catch (Exception a)
            {
                StopRefresh();
                MessageBox.Show(a.Message);
            }
        }

        private void Position(float positionInmm)
        {
            if (textBoxPowerMeter.Text != string.Empty)
                Nforce = Convert.ToDouble(textBoxPowerMeter.Text);

            float stepTo_mm = 163840 / 3; // 1 mm = 54613.333 steps
            int positionInSteps = (int)Convert.ToInt64( stepTo_mm * positionInmm);
            try
            {
               ProfilePositionMode ppm = _epos4.Operation.ProfilePositionMode;

                textBoxPositionStart.Text = string.Format("{0}",Actual_Position);
                if(stop == false)
                    ppm.MoveToPosition(positionInSteps, rbtnRelative.Checked, true);

                if (Nforce - 1 <= Math.Abs(force))
                    ppm.HaltPositionMovement();

                if (stop == true)
                    ppm.HaltPositionMovement();
            }
            catch (DeviceException a)
            {
                StopRefresh();
                ShowMessageBox(a.ErrorMessage, a.ErrorCode);
            }
            catch (OverflowException a)
            {
                MessageBox.Show(a.Message);
            }
            catch (FormatException a)
            {
                MessageBox.Show(a.Message);
            }
            catch (Exception a)
            {
                StopRefresh();
                MessageBox.Show(a.Message);
            }
        }

        private void Speed(uint speed)
        {
            try
            {
                ProfilePositionMode ppm = _epos4.Operation.ProfilePositionMode;

                ppm.ActivateProfilePositionMode();
                ppm.SetPositionProfile(speed, 1000, 1000);
                textBoxAOM.Text = _epos4.Operation.OperationMode.GetOperationModeAsString();
            }
            catch (DeviceException a)
            {
                StopRefresh();
                ShowMessageBox(a.ErrorMessage, a.ErrorCode);
            }
            catch (OverflowException a)
            {
                MessageBox.Show(a.Message);
            }
            catch (FormatException a)
            {
                MessageBox.Show(a.Message);
            }
            catch (Exception a)
            {
                StopRefresh();

                MessageBox.Show(a.Message);
            }
        }

        private void Stop()
        {
            try
            {
                ProfilePositionMode ppm = _epos4.Operation.ProfilePositionMode;

                ppm.ActivateProfilePositionMode();

                textBoxAOM.Text = _epos4.Operation.OperationMode.GetOperationModeAsString();

                ppm.HaltPositionMovement();

            }
            catch (DeviceException a)
            {
                StopRefresh();
                ShowMessageBox(a.ErrorMessage, a.ErrorCode);
            }
            catch (Exception a)
            {
                StopRefresh();

                MessageBox.Show(a.Message);
            }
        }

        private void ClearGraph()
        {

            forceValues.Clear();
            positionValues.Clear();
            newPositionValues.Clear();
            newForceValues.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void StopRefresh()
        {
            try
            {
                timerEngine.Enabled = false;

                btnStart.Enabled = false;
                btnStopP.Enabled = false;

                _epos4 = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowMessageBox(string text, uint errorCode)
        {
            var msg = string.Format("{0}\nErrorCode: {1:X8}", text, errorCode);

            MessageBox.Show(msg, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        // power meter function
        private void Open()
        {
            _powerPort.Open("COM8", _BaudRate._38400, Parity.None, _DataBits._8, StopBits.One);
        }

        public void _powerPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                SerialDataReceivedEventHandler serialDataReceivedEventHandler = new SerialDataReceivedEventHandler(this._powerPort_DataReceived);
                this.BeginInvoke(serialDataReceivedEventHandler,new object[] {sender,e});
                return;
            }

            value = _powerPort.ReadAll();
            textBoxForce.Text = value;

            //------write to Graph-------         
            if (startGraph == true)
            {
                int indexOfN = value.IndexOf("N");
                value = value.Substring(0, indexOfN);
                force = Convert.ToDouble(value);
                double elapsedTime = (DateTime.Now - testStartTime).TotalSeconds;

                if(HasBeenStop == false)
                {
                    positionValues.Add(elapsedTime, position);
                    forceValues.Add(elapsedTime, force);
                }
                else
                {
                    newPositionValues.Add(elapsedTime, position);
                    newForceValues.Add(elapsedTime, force);

                }
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
               
            }

        }

        //save to files function
        private void SaveToExcel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Save the chart image as a PNG file
                string chartImagePath = "C:\\Users\\hy790\\Documents\\graph.png";
                zedGraphControl1.MasterPane.GetImage().Save(chartImagePath, System.Drawing.Imaging.ImageFormat.Png);

                // Load the chart image into a byte array
                byte[] chartImageBytes = System.IO.File.ReadAllBytes(chartImagePath);

                // Add the chart image to the Excel worksheet
                var excelImage = worksheet.Drawings.AddPicture("ChartImage", chartImagePath);
                excelImage.SetPosition(150, 10);

                // Populate additional data in the worksheet
                worksheet.Cells["A1"].Value = "Type";
                worksheet.Cells["B1"].Value = textBoxType.Text;

                worksheet.Cells["A2"].Value = "Description";
                worksheet.Cells["B2"].Value = textBoxTDescription.Text;

                worksheet.Cells["A3"].Value = "Catalog Num";
                worksheet.Cells["B3"].Value = textBoxCNum.Text;

                worksheet.Cells["B4"].Value = textBoxSpringConstant.Text;
                worksheet.Cells["C4"].Value = "For spring testing only!!!!!!!!!!!!!!!!!!!";
                worksheet.Cells["A4"].Value = "Spring Constant";

                worksheet.Cells["A5"].Value = "Timestamp";
                worksheet.Cells["B5"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Save the Excel file
                string excelFilePath = "C:\\measure\\data_" + DateTime.Now.ToString("yyyy_MM_dd_H_mm_ss") + ".xlsx";
                excelPackage.SaveAs(new FileInfo(excelFilePath));

                MessageBox.Show("Data saved to Excel file: " + excelFilePath);
            }
        }

        //state machine timers
        private void timerModeTest_Tick(object sender, EventArgs e)
        {
            int actual_position = _epos4.Operation.MotionInfo.GetPositionIs() / (163840 / 3);
            double spring_constant;


            switch (CurrentModeTestState)
            {
                case TestMode.Free:
                    switch (CurrentFreeTestState)
                    {
                        case FreeMode.None:
                            textBoxSpeed.Enabled = true;
                            textBoxPlace.Enabled = true;
                            textBoxDistance.Enabled = true;
                            btnStop.Enabled = true;
                            btnStart.Enabled = true;
                            btnUp.Enabled = true;
                            btnDown.Enabled = true;
                            HasBeenStart = false;
                            stop = false;
                            if (textBoxPlace.Text != string.Empty && textBoxSpeed.Text != string.Empty)
                                CurrentFreeTestState = FreeMode.Free;
                            break;
                        case FreeMode.Free:
                            if(HasBeenStart == true)
                            {
                                Speed((uint)Convert.ToInt32(textBoxSpeed.Text));
                                Position(Convert.ToInt32(textBoxPlace.Text));
                                startGraph = true;

                                if (actual_position == Convert.ToInt32(textBoxPlace.Text))
                                {
                                    startGraph = false;
                                    HasBeenStart = false;
                                }
                            }
                            if (textBoxType.Text != string.Empty && textBoxTDescription.Text != string.Empty && textBoxCNum.Text != string.Empty)
                                btnSave.Enabled = true;
                            break;
                    }
                    break;

                case TestMode.Glue:
                    switch (CurrentGlueTestState)
                    {
                        case GlueTest.Rest:
                            if (HasBeenStop == false || HasBeenStart == true)
                                CurrentGlueTestState = GlueTest.MoveToPosition;
                            btnStart.Enabled = true;
                            break;

                        case GlueTest.MoveToPosition:
                            ClearGraph();
                            Speed(1000);
                            Position(-50);
                            stop = false;
                            HasBeenStart = false;
                            if (_epos4.Operation.MotionInfo.GetPositionIs() / (163840 / 3) == -50)
                                CurrentGlueTestState = GlueTest.StartTest;
                            break;

                        case GlueTest.StartTest:
                            if (HasBeenStart == true)
                            {
                                startGraph = true;

                                Speed(1000);
                                Position(0);
                                btnRelese.Enabled = false;
                                btnStart.Enabled = false;
                                btnStop.Enabled = false;
                                comboBoxMode.Enabled = false;
                                HasBeenStart = false;
                                CurrentGlueTestState = GlueTest.Testing;
                            }
                            break;
                        case GlueTest.Testing:
                            if (_epos4.Operation.MotionInfo.GetPositionIs() / (163840 / 3) == 0)
                            {
                                CurrentGlueTestState = GlueTest.Release;
                                btnRelese.Enabled = true;
                                HasBeenRelese = false;
                                startGraph = false;
                                HasBeenStart = false;
                            }
                            break;

                        case GlueTest.Release:
                            if (_epos4.Operation.MotionInfo.GetPositionIs() / (163840 / 3) == 0 && HasBeenRelese == true)
                            {
                                Speed(1000);
                                Position(-10);
                                CurrentGlueTestState = GlueTest.Save;
                            }
                            break;
                        case GlueTest.Save:
                            if (textBoxCNum.Text != string.Empty && textBoxTDescription.Text != string.Empty && textBoxType.Text != string.Empty)
                            {
                                btnSave.Enabled = true;
                                btnStart.Enabled = true;
                                comboBoxMode.Enabled = true;
                            }
                            break;

                        default:
                            break;
                    }
                    break;

                case TestMode.Line:
                    switch (CurrentLineTestState)
                    {
                        case LineTest.Rest:
                            if (HasBeenStop == false)
                                CurrentLineTestState = LineTest.MoveToStart;
                            btnStart.Enabled = true;
                            textBoxSpeed.Enabled = true;
                            break;

                        case LineTest.MoveToStart:
                            ClearGraph();   

                            btnDown.Enabled = true;
                            btnUp.Enabled = true;

                            CurrentLineTestState = LineTest.Settings;
                            break;

                        case LineTest.Settings:
                            HasBeenStart = false;
                            comboBoxdirection.Enabled = true;
                            textBoxDistance.Enabled = true;
                            textBoxperiodicity.Enabled = true;

                            if (textBoxDistance.Text != string.Empty && textBoxperiodicity.Text != string.Empty &&
                                textBoxSpeed.Text != string.Empty && comboBoxdirection.Text != string.Empty)
                                CurrentLineTestState = LineTest.StartTest;
                            break;

                        case LineTest.StartTest:
                            if (HasBeenStart == true)
                                CurrentLineTestState = LineTest.Testing1;
                            break;

                        case LineTest.Testing1:
                            startGraph = true;
                            switch (comboBoxdirection.Text)
                            {
                                case "Up":
                                    Position(Start_Position + Distance);
                                    Speed((uint)Convert.ToInt32(textBoxSpeed.Text));
                                    break;

                                case "Down":
                                    Position(Start_Position - Distance);
                                    Speed((uint)Convert.ToInt32(textBoxSpeed.Text));
                                    break;
                            }
                            CurrentLineTestState = LineTest.Check1;
                            break;

                        case LineTest.Check1:
                            switch (comboBoxdirection.Text)
                            {
                                case "Up":
                                    if (actual_position == Start_Position + Distance)
                                        CurrentLineTestState = LineTest.Testing2;
                                    break;

                                case "Down":
                                    if (actual_position == Start_Position - Distance)
                                        CurrentLineTestState = LineTest.Testing2;
                                    break;
                            }
                            break;

                        case LineTest.Testing2:
                            Position(Start_Position);
                            Speed((uint)Convert.ToInt32(textBoxSpeed.Text));

                            CurrentLineTestState = LineTest.Check2;
                            done++;
                            break;

                        case LineTest.Check2:
                            if (actual_position == Start_Position)
                            {
                                CurrentLineTestState = LineTest.Testing1;
                            }
                            if (done == Convert.ToInt32(textBoxperiodicity.Text))
                            {
                                CurrentLineTestState = LineTest.Save;
                            }
                            break;

                        case LineTest.Save:
                            if (actual_position == Start_Position)
                                startGraph = false;
                            if (textBoxCNum.Text != string.Empty && textBoxTDescription.Text != string.Empty && textBoxType.Text != string.Empty) 
                                btnSave.Enabled = true;
                            break;

                        default:
                            break;
                    }
                    break;

                case TestMode.Rotary:
                    switch (CurrentRotaryTestState)
                    {
                        case RotaryTest.Rest:
                            CurrentRotaryTestState = RotaryTest.Settings;
                            btnDown.Enabled = true;
                            btnUp.Enabled = true;
                            break;

                        case RotaryTest.Settings:
                            if (textBoxDistance.Text != string.Empty && textBoxSpeed.Text != string.Empty )
                                CurrentRotaryTestState = RotaryTest.Testing;
                            textBoxSpeed.Enabled = true;
                            textBoxDistance.Enabled = true;
                            btnStart.Enabled = true;
                            HasBeenStart = false;
                            stop = false;
                            textBoxPositionStart.Text = textBoxPositionActualValue.Text;
                            break;

                        case RotaryTest.Testing:
                            if (HasBeenStart == true)
                            {
                                startGraph = true;
                                Position(Start_Position + Distance);
                                Speed((uint)Convert.ToInt32(textBoxSpeed.Text));
                                if (actual_position == Start_Position + Distance)
                                    CurrentRotaryTestState = RotaryTest.Release;
                            }
                            break;

                        case RotaryTest.Release:
                            startGraph = false;
                            btnDown.Enabled = true;
                            btnUp.Enabled = true;
                            CurrentRotaryTestState = RotaryTest.Save;
                            break;

                        case RotaryTest.Save:
                            if (textBoxCNum.Text != string.Empty && textBoxTDescription.Text != string.Empty && textBoxType.Text != string.Empty)
                            {
                                btnSave.Enabled = true;
                            }

                            int indexOfN = value.IndexOf("N");
                            value = value.Substring(0, indexOfN);
                            spring_constant = Convert.ToDouble(value) / Convert.ToDouble(textBoxDistance.Text);
                            textBoxSpringConstant.Text = Convert.ToString(spring_constant);
                            CurrentRotaryTestState = RotaryTest.Rest;
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
