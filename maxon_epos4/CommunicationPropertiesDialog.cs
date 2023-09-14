using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace ProMeasurement    
{
    public partial class CommunicationPropertiesDialog : Form
    {
        public CommunicationPropertiesDialog()
        {
            
            InitializeComponent();
        }

        public CommunicationPropertiesDialog(bool enable)
        {
            InitializeComponent();

            this.m_cbParity.Items.AddRange(new object[] {Parity.Even,Parity.Odd,
														Parity.None,Parity.Mark});
            this.m_cbBaudRate.Items.AddRange(new object[] {_BaudRate._110.ToString("d"),_BaudRate._300.ToString("d"),_BaudRate._1200.ToString("d"),
														  _BaudRate._2400.ToString("d"),_BaudRate._4800.ToString("d"),_BaudRate._9600.ToString("d"),
														  _BaudRate._19200.ToString("d"),_BaudRate._38400.ToString("d"),_BaudRate._57600.ToString("d"),
														  _BaudRate._115200.ToString("d"),_BaudRate._460800.ToString("d"),_BaudRate._921600.ToString("d")});
            this.m_cbDataBits.Items.AddRange(new object[] {_DataBits._5.ToString("d"),_DataBits._6.ToString("d"),
														  _DataBits._7.ToString("d"),_DataBits._8.ToString("d")});
            this.m_cbStopBits.Items.AddRange(new object[] { StopBits.One.ToString("d"), StopBits.Two.ToString("d") });

            m_cbComPort.Items.Clear();
            m_cbComPort.Items.AddRange(SerialPort.GetPortNames());

            panel1.Enabled = enable;
        }

        public void Set(CommunicationProperties prop, string _Com)
        {
            Com = _Com;
            BaudRate = prop.BaudRate;
            Parity = prop.Parity;
            DataBits = prop.DBits;
            DataStopBits = prop.StopBits;
        }

        private void OK_Click(object sender, System.EventArgs e)
        {
            if (m_cbComPort.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid comm port!");
                m_cbComPort.Focus();
                return;
            }

            if (m_cbBaudRate.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid baud rate!");
                m_cbBaudRate.Focus();
                return;
            }

            if (m_cbParity.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid parity!");
                m_cbParity.Focus();
                return;
            }

            if (m_cbDataBits.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid data bits!");
                m_cbDataBits.Focus();
                return;
            }

            if (m_cbStopBits.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid stop bits!");
                m_cbStopBits.Focus();
                return;
            }
        }

        private void DefaultsBtn_Click(object sender, System.EventArgs e)
        {
            Com = "COM3";
            BaudRate = _BaudRate._38400;
            Parity = Parity.None;
            DataBits = _DataBits._8;
            DataStopBits = StopBits.One;
        }

        #region Properties
        public string Com
        {
            get { return m_cbComPort.Text; }
            set { m_cbComPort.Text = value; }
        }

        public _BaudRate BaudRate
        {
            get { return (_BaudRate)Convert.ToInt32(m_cbBaudRate.Text); }
            set { m_cbBaudRate.Text = value.ToString("d"); }
        }

        public Parity Parity
        {
            get { return (Parity)Enum.Parse(typeof(Parity), m_cbParity.Text); }
            set { m_cbParity.Text = value.ToString(); }
        }

        public _DataBits DataBits
        {
            get { return (_DataBits)Convert.ToInt32(m_cbDataBits.Text); }
            set { m_cbDataBits.Text = value.ToString("d"); }
        }

        public StopBits DataStopBits
        {
            get { return (StopBits)Convert.ToInt32(m_cbStopBits.Text); }
            set { m_cbStopBits.Text = value.ToString("d"); }
        }

        public CommunicationProperties CommProp
        {
            get
            {
                return new CommunicationProperties(BaudRate, Parity, DataBits, DataStopBits);
            }
        }

        public bool BREnable
        {
            set { m_cbBaudRate.Enabled = value; }
        }

        public bool PEnable
        {
            set { m_cbParity.Enabled = value; }
        }

        public bool DBEnable
        {
            set { m_cbDataBits.Enabled = value; }
        }

        public bool SBEnable
        {
            set { m_cbStopBits.Enabled = value; }
        }

        public bool DefaultsEnable
        {
            set { DefaultsBtn.Enabled = value; }
        }

        #endregion
    }

    public class CommunicationProperties
    {
        public _BaudRate BaudRate;
        public Parity Parity;
        public _DataBits DBits;
        public StopBits StopBits;

        public CommunicationProperties(_BaudRate baudRate, Parity parity, _DataBits dBits, StopBits stopBits)
        {
            BaudRate = baudRate;
            Parity = parity;
            DBits = dBits;
            StopBits = stopBits;
        }

    }
}