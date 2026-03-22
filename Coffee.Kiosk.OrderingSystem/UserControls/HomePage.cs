using Coffee.Kiosk.OrderingSystem.Helper;
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
    public partial class HomePage : UserControl
    {
        internal event Action<int>? ProductClicked;

        private List<Models.Ads.Banners> _homeBanner1Ads = new();
        private List<Models.Ads.Banners> _homeBanner2Ads = new();
        private int _banner1Index = 0;
        private int _banner2Index = 0;
        private System.Windows.Forms.Timer _adTimer = new();

        public HomePage()
        {
            InitializeComponent();
            UI_Handling.AddBottomSpacer(flowLayoutPanel1, 1000);
            LoadProduct();
            LoadBanners();
        }

        private void LoadBanners()
        {
            _homeBanner1Ads = Models.Ads.AdsBanners
                .Where(b => b.AdPlacement == Models.Ads.AdPlacement.HOME_PAGE_BANNER_1)
                .OrderBy(b => b.DisplayOrder)
                .ToList();

            _homeBanner2Ads = Models.Ads.AdsBanners
                .Where(b => b.AdPlacement == Models.Ads.AdPlacement.HOME_PAGE_BANNER_2)
                .OrderBy(b => b.DisplayOrder)
                .ToList();

            if (_homeBanner1Ads.Count > 0)
                HomeBanner1.Image = UI_Images.loadImageFromFile(_homeBanner1Ads[0].FilePath);

            if (_homeBanner2Ads.Count > 0)
                HomeBanner2.Image = UI_Images.loadImageFromFile(_homeBanner2Ads[0].FilePath);

            _adTimer.Interval = 6000;
            _adTimer.Tick += AdTimer_Tick;
            _adTimer.Start();
        }

        private bool _tickTurn = false;

        private void AdTimer_Tick(object? sender, EventArgs e)
        {
            if (!_tickTurn)
            {
                if (_homeBanner1Ads.Count > 1)
                {
                    _banner1Index = (_banner1Index + 1) % _homeBanner1Ads.Count;
                    HomeBanner1.Image = UI_Images.loadImageFromFile(_homeBanner1Ads[_banner1Index].FilePath);
                }
            }
            else
            {
                if (_homeBanner2Ads.Count > 1)
                {
                    _banner2Index = (_banner2Index + 1) % _homeBanner2Ads.Count;
                    HomeBanner2.Image = UI_Images.loadImageFromFile(_homeBanner2Ads[_banner2Index].FilePath);
                }
            }

            _tickTurn = !_tickTurn;
        }

        private void LoadProduct()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var product in Models.Product.productData)
            {
                var productItem = new ProductItem(
                    product.Id,
                    product.CategoryId,
                    product.Name,
                    product.ImagePath,
                    product.Price
                    );
                productItem.productClicked += OnProductClicked;
                flowLayoutPanel1.Controls.Add(productItem);
            }
        }

        internal void OnProductClicked(int productId)
        {
            ProductClicked?.Invoke(productId);
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            //if (flowLayoutPanel1.Controls.Count % 3 == 0)
            //    flowLayoutPanel1.SetFlowBreak(e!.Control!, true);
        }
    }
}
