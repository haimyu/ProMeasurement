using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OphirSim.LensTools;

namespace OphirSim
{
    public class IniData : SerData<IniData>
    {
        public CommunicationData Communication = new CommunicationData();
        public CommunicationData StageCom = new CommunicationData();
        public CommunicationData ThermotronCom = new CommunicationData();
        public CommunicationData PowerSupply1Com = new CommunicationData();
        public CommunicationData PowerSupply2Com = new CommunicationData();
        public CommunicationData PowerSupply3Com = new CommunicationData();
        public LambdaAddress PowerSupply1Address = new LambdaAddress();
        public LambdaAddress PowerSupply2Address = new LambdaAddress();
        public LambdaAddress PowerSupply3Address = new LambdaAddress();
        public CommunicationData ProbeCom = new CommunicationData();
        public LocationErrorData LocationError = new LocationErrorData();
        public DisplayData Display = new DisplayData();
        public QAData QADefualtData = new QAData();
        public TctData TctData = new TctData();
        public string HexFilePath = "";
        public string ThermotronModel = "4800";
        public int StageType = 1;

        internal static IniData Default()
        {
            IniData data = new IniData();
            data.Communication.ComPort = "COM1";
            data.ThermotronCom.ComPort = "COM1";
            data.StageCom.ComPort = "COM1";
            data.PowerSupply1Com.ComPort = "COM1";
            data.PowerSupply2Com.ComPort = "COM1";
            data.PowerSupply3Com.ComPort = "COM1";
            data.ProbeCom.ComPort = "COM1";
            data.Display.Main.Visible = data.Display.LensControl.Visible = true;
            data.QADefualtData.Delay = 100;
            data.QADefualtData.Loops = 30;
            data.QADefualtData.Tolerance = 1000;
            data.TctData.WO.Add("");
            data.TctData.SN.Add("");
            data.TctData.ComPorts.Add("COM1");
            data.TctData.SavePath = "C:\\";
            data.HexFilePath = G.Dir.ApplicationDataPath + "\\Gen3V03.25.24.hex";
            data.ThermotronModel = "4800";
            data.PowerSupply1Address.Address = 7;
            data.PowerSupply2Address.Address = 8;
            data.PowerSupply3Address.Address = 9;
            data.StageType = 1;
            return data;
        }
    }

    [Serializable]
    public class CommunicationData
    {
        public string ComPort = "COM1";
    }

    [Serializable]
    public class LambdaAddress
    {
        public int Address = 0;
    }

    [Serializable]
    public class LocationErrorData
    {
        public int Tolerance;
        public int AcceptErr;
        public int MidErr;
    }

    [Serializable]
    public class DisplayData
    {
        public FormData Main = new FormData();
        public FormData LUT = new FormData();
        public FormData LensControl = new FormData();
        public FormData MotorControl = new FormData();
        public FormData CommControl = new FormData();
        public FormData UserSetupControl = new FormData();
        public FormData UserProtocolU1 = new FormData();
    }

    [Serializable]
    public class FormData
    {
        public Point Location = new Point();
        public Size Size = new Size();
        public bool Floating;
        public bool Visible;
    }

    [Serializable]
    public class TctData
    {
        public List<string> WO = new List<string>();
        public List<string> SN = new List<string>();
        public List<string> ComPorts = new List<string>();
        public string SavePath = "C:\\";
    }
}
