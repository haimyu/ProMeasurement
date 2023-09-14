using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ProMeasurement;
using System.IO.Ports;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ProMeasurement
{
    public class IniData : SerData<IniData>
    {
        public CommunicationData Communication = new CommunicationData();
       
        internal static IniData Default()
        {
            IniData data = new IniData();
            data.Communication.ComPort = "COM1";
            return data;
        }
        public void Serialize()
        {
            Serialize(SerType.XML, ApplicationDataPath);
        }
        public static IniData Deserialize()
        {
            try
            {
                return Deserialize(SerType.XML, ApplicationDataPath);
            }
            catch
            {
                return new IniData();
            }
        }
        static string sApplicationDataPath = "";

        public static string ApplicationDataPath
        {
            get
            {
                if (sApplicationDataPath == "")
                {
                    sApplicationDataPath = System.Windows.Forms.Application.CommonAppDataPath;
                    sApplicationDataPath = sApplicationDataPath.Substring(0, sApplicationDataPath.LastIndexOf('\\'));
                    sApplicationDataPath += "\\settings.dat";
                }
                return sApplicationDataPath;
            }
        }
    }

    [Serializable]
    public class CommunicationData
    {
        public string ComPort = "COM1";
    }

    public enum SerType { Binnary, XML };
    public abstract class SerData<T> where T : SerData<T>
    {
        internal virtual void OnDeserialized() { }

        internal void Serialize(SerType type, string fileName)
        {
            switch (type)
            {
                case SerType.Binnary:
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, this);
                    stream.Close();
                    break;
                case SerType.XML:
                    StreamWriter file = new StreamWriter(fileName);
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(file, this);
                    file.Close();
                    break;
            }
        }

        internal static T Deserialize(SerType type, string fileName)
        {
            T newT = default(T);
            switch (type)
            {
                case SerType.Binnary:
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    newT = (T)formatter.Deserialize(stream);
                    stream.Close();
                    break;
                case SerType.XML:
                    StreamReader file = new StreamReader(fileName);
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    newT = (T)ser.Deserialize(file);
                    file.Close();
                    break;
            }

            newT.OnDeserialized();
            return newT;
        }
    }

    [Serializable]
    public class SerialPortSettings
    {
        public string ComPort = "COM1";
        public _BaudRate BaudRate = _BaudRate._57600;
        public Parity Parity = Parity.None;
        public _DataBits DBits = _DataBits._8;
        public StopBits StopBits = StopBits.One;
    }
}
