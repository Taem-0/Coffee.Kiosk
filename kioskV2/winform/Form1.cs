using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace kioskV2
{
    public partial class Form1 : Form
    {
        string _port;
        public Form1(string port)
        {
            InitializeComponent();
            _port = port;
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async();

            var settings = webView21.CoreWebView2.Settings;

            settings.AreDefaultContextMenusEnabled = false;
            settings.AreDevToolsEnabled = false;
            settings.IsZoomControlEnabled = false;
            settings.AreBrowserAcceleratorKeysEnabled = false;

            webView21.Source = new Uri($"http://localhost:{_port}");
        }
    }
}





