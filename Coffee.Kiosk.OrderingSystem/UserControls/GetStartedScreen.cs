using Coffee.Kiosk.OrderingSystem.Helper;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem
{
    public partial class GetStartedScreen : UserControl
    {

        internal event Action? NextClicked;
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        private List<Models.Ads.Banners> _startingScreenAds = new();
        private int _currentAdIndex = 0;
        private System.Windows.Forms.Timer _adTimer = new();

        public GetStartedScreen()
        {
            InitializeComponent();
            UI_Handling.fixVisualShifts(this);
        }

        private void GetStartedScreen_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = UI_Images.logoImage;

            _startingScreenAds = Models.Ads.AdsBanners
                .Where(b => b.AdPlacement == Models.Ads.AdPlacement.STARTING_SCREEN)
                .OrderBy(b => b.DisplayOrder)
                .ToList();

            if (_startingScreenAds.Count > 0)
            {
                this.BackgroundImage = UI_Images.loadImageFromFile(_startingScreenAds[0].FilePath);

                if (_startingScreenAds.Count > 1)
                {
                    _adTimer.Interval = 6700;
                    _adTimer.Tick += AdTimer_Tick;
                    _adTimer.Start();
                }
            }
            else
            {
                this.BackgroundImage = UI_Images.loadImageFromFile("../../../Resources/ADS1.jpg");
            }
        }

        private void AdTimer_Tick(object? sender, EventArgs e)
        {
            _currentAdIndex = (_currentAdIndex + 1) % _startingScreenAds.Count;
            this.BackgroundImage = UI_Images.loadImageFromFile(_startingScreenAds[_currentAdIndex].FilePath);
        }

        private void GetStartedScreen_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }

        private void guna2ShadowPanel2_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }
        private void GetStartedScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(guna2ShadowPanel2, panel1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }
    }
}
