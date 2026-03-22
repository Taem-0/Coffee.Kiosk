using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    public partial class GetStartedScreenV2 : UserControl
    {
        internal event Action? NextClicked;

        public GetStartedScreenV2()
        {
            InitializeComponent();

        }

        private void webView21_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }

        private async void GetStartedScreenV2_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async();
            var settings = webView21.CoreWebView2.Settings;
            settings.AreDefaultContextMenusEnabled = false;
            settings.AreDevToolsEnabled = false;
            settings.IsZoomControlEnabled = false;
            settings.AreBrowserAcceleratorKeysEnabled = false;

            webView21.CoreWebView2.WebMessageReceived += (s, args) =>
            {
                if (args.TryGetWebMessageAsString() == "TAP")
                    NextClicked?.Invoke();
            };

            webView21.Source = new Uri($"http://localhost:{Starter.Starter.Port}");
        }

        private void GetStartedScreenV2_Click(object sender, EventArgs e)
        {
           NextClicked?.Invoke();
        }

        public void RefreshScreen()
        {
            webView21.CoreWebView2.Reload();
        }
    }
}
