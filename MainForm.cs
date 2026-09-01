using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace KEZ_GPS_Windows
{
    public class MainForm : Form
    {
        private ChromiumWebBrowser browser;

        public MainForm()
        {
            Text = "КЕЦ Карлово GPS";
            Width = 1280; Height = 800;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Icon = null;

            browser = new ChromiumWebBrowser();
            browser.Dock = DockStyle.Fill;
            browser.MenuHandler = new NoContextMenuHandler();
            Controls.Add(browser);

            Load += MainForm_Load;
            FormClosing += (s, e) => browser?.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string html = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "www", "index.html");
            browser.Load(new Uri(html).AbsoluteUri);
        }
    }

    public class NoContextMenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model) { model.Clear(); }
        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags) { return false; }
        public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame) { }
        public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback) { return false; }
    }
}
