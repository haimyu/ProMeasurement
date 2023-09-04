using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ProMeasurement
{
    //public enum _COM{COM1 = 1,COM2,COM3,COM4,COM5,COM6,COM7};
    public enum _BaudRate
    {
        _110 = 110, _300 = 300, _1200 = 1200, _2400 = 2400,
        _4800 = 4800, _9600 = 9600, _19200 = 19200, _38400 = 38400, _57600 = 57600,
        _115200 = 115200, _460800 = 460800, _921600 = 921600
    };
    public enum _DataBits { _5 = 5, _6 = 6, _7 = 7, _8 = 8 };
    public delegate void DataReceivedDelegate(object sender, System.IO.Ports.SerialDataReceivedEventArgs e);
    class Rs232 : IDisposable
    {
        event SerialDataReceivedEventHandler myDataReceived;
        
        public event SerialDataReceivedEventHandler DataReceived
        {
            add
            {
                if (Port != null)
                    Port.DataReceived += value;
                myDataReceived += value;
            }
            remove
            {
                if (Port != null)
                    Port.DataReceived -= value;
                myDataReceived -= value;
            }
        }

        public SerialPort Port;
        Decoder decoder = Encoding.ASCII.GetDecoder();
        List<string> DebugCommands = new List<string>();
        private Object thisLock = new Object();


        public void Open(string com, _BaudRate baud, Parity parity, _DataBits dBits, StopBits sBits)
        {
            SerialPortFixer.Execute(com);
            Port = new SerialPort(com, (int)baud, parity, (int)dBits, sBits);
            //            Port.ReadBufferSize = 16384;
//            Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            Port.Open();
            Thread.Sleep(10);
            Port.DataReceived += myDataReceived;
            Port.ErrorReceived += new SerialErrorReceivedEventHandler(Port_ErrorReceived);
          //  Port.NewLine = (13).ToString();
        }

        public void Open(string com, _BaudRate baud, Parity parity, _DataBits dBits, StopBits sBits, Handshake hs)
        {
            SerialPortFixer.Execute(com);
            Port = new SerialPort(com, (int)baud, parity, (int)dBits, sBits);
            //            Port.ReadBufferSize = 16384;
            //            Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            Port.Handshake = hs;
            Port.Open();
            Thread.Sleep(10);
            Port.DataReceived += myDataReceived;
            Port.ErrorReceived += new SerialErrorReceivedEventHandler(Port_ErrorReceived);
            //  Port.NewLine = (13).ToString();
        }

        public void SendBreak()
        {
            DateTime start = DateTime.Now;
            Port.BreakState = true;
            while (DateTime.Now < start.AddSeconds(0.1)) ;
            Port.BreakState = false;
        }

        public void SetBreak(bool state)
        {
            Port.BreakState = state;
        }

        void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

            //            throw new Exception("The method or operation is not implemented.");
        }

        public void Write(string text)
        {
            lock (thisLock)
            {
                Port.Write(text);
            }
        }

        public void Write(byte[] text)
        {
            lock (thisLock)
            {
                Port.Write(text, 0, text.Length);
            }
        }

        public void Close()
        {
            if (Port != null && Port.IsOpen)
            {
                try
                {
                    if (myDataReceived != null)
                        Port.DataReceived -= myDataReceived;
                    Port.ErrorReceived -= Port_ErrorReceived;
              //      Port.DtrEnable = false;
             //       Port.RtsEnable = false;
                    Thread.Sleep(10);
                    //the close function getting stuck sometimes
                    // to avoid this i change the Invoke metods in the main form to BeginInvoke
                    lock (thisLock)
                    {
                       // Thread thread = new Thread(Port.Close);
                       // thread.Start();
                       // thread.Join(2000);
                        Port.Close();
                    }
                }
                catch { }
            }
        }

        public string ReadLine()
        {
            string str;
            lock (thisLock)
            {
                str = Port.ReadLine();
            }
            return str;
        }

        public string ReadAll()
        {
            string str;
            lock (thisLock)
            {
                str = Port.ReadExisting();
            }
            return str;
        }

        public byte[] Read()
        {
            if (DebugCommands.Count > 0)
            {
                byte[] buf = ASCIIEncoding.ASCII.GetBytes(DebugCommands[0]);
                DebugCommands.RemoveAt(0);
                return buf;
            }
            else
            {
                if (Port == null || !Port.IsOpen)
                    return new byte[0];
                int l = Port.BytesToRead;
                byte[] buf = new byte[l];
                try
                {
                    lock (thisLock)
                    {
                        Port.Read(buf, 0, l);
                    }
                }
                catch { }
                return buf;
            }
        }

        /*
        public void AddDebugCommand(string cmd)
        {
            DebugCommands.Add(cmd);
            if (DataReceived != null)
                DataReceived(null, null);
        }*/

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Port.Dispose();
            }
        }

        #endregion
    }
}
