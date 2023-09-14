using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using JoystickInterface;
using System.Security.Permissions;

//[assembly:SecurityPermissionAttribute(SecurityAction.RequestMinimum, UnmanagedCode  = true)]

namespace OphirSim
{
    static class Program
    {
        public static IniData INI = IniData.Default();// new IniData();
        public static DataManager Data = new DataManager();
        public static LensDefinitions LensDef = new LensDefinitions();
        public static Communication Comm = new Communication();
        public static MotorsControl MotorsController;
        public static LensControl LensController;
        public static UserProtocolU1 ProtocolControlU1;
        public static UsersManager Users = new UsersManager();
        //        public static LUTForm LUT;
        public static ScriptCore Script;
        public static Joystick Joy;

        public static string OphirSimVersion
        {
            get { return Application.ProductVersion; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            SplashScreen.ShowSplashScreen();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            if (args != null && args.Length > 0)
            {
                if (args[0].EndsWith(G.Dir.DebugFileExt))
                {
                    Script = new ScriptCore(args[0], out args);
                }
            }
            try
            {
                Application.Run(new Form1(args));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static void OpenLut()
        {
        }
    }
}