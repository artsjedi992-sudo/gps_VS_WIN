using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace KEZ_GPS_Windows
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Cef.EnableHighDPISupport();
            var settings = new CefSettings();
            settings.CachePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KEZ_GPS", "Cache");
            Cef.Initialize(settings);
            Application.Run(new MainForm());
            Cef.Shutdown();
        }
    }
}
