using Coffee.Kiosk.OrderingSystem.Forms;
using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.UserControls;
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
using Windows.ApplicationModel.Contacts;

namespace Coffee.Kiosk.OrderingSystem
{
    public partial class KioskMenu : UserControl
    {
        internal event Action? StartOverClicked;
        internal event Action<int>? ProductSelected;
        internal event Action? ViewOrderClicked;

        private readonly Dictionary<int, UserControl> categoryPage = new();
        private UserControl? currentPage;

        private const int HOME_CATEGORY_ID = 0;
        private HomePage? homePage;

        int currentCartCount = 0;
        internal string OrderType = String.Empty;

        private List<Models.Ads.Banners> _topBanner = new();
        private System.Windows.Forms.Timer _adTimer = new();
        private int _topBannerIndex = 0;

        Point scrollPos;

        public KioskMenu(string orderType)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            flowCategories.Dock = DockStyle.Left;
            flowCategories.FlowDirection = FlowDirection.TopDown;
            flowCategories.WrapContents = false;
            flowCategories.AutoScroll = true;

            OrderType = orderType;

            guna2HtmlLabel1.Text = $"""
            <b><font size='12'>Order summary</font></b>
            <br>
            <b>Items:</b> {currentCartCount}
            <br>
            <b>{orderType.ToString()}</b>
            <br>
            <b>Total:</b> ₱
            """;
            LoadCategories();
            LoadBanners();
            ShowHome();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        private void LoadBanners()
        {
            _topBanner = Models.Ads.AdsBanners
                .Where(b => b.AdPlacement == Models.Ads.AdPlacement.TOP_BANNER)
                .OrderBy(b => b.DisplayOrder)
                .ToList();

            if (_topBanner.Count > 0)
                TopBanner.Image = UI_Images.loadImageFromFile(_topBanner[0].FilePath);

            if (_topBanner.Count > 1)
            {
                _adTimer.Interval = 5000;
                _adTimer.Tick += AdTimer_Tick;
                _adTimer.Start();
            }
        }
        private void AdTimer_Tick(object? sender, EventArgs e)
        {
            _topBannerIndex = (_topBannerIndex + 1) % _topBanner.Count;
            var newImage = UI_Images.loadImageFromFile(_topBanner[_topBannerIndex].FilePath);

            var oldImage = TopBanner.Image;
            TopBanner.Image = newImage;
            oldImage?.Dispose();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!this.Visible)
                _adTimer.Stop();
            else if (_topBanner.Count > 1)
                _adTimer.Start();
        }


        private void LoadCategories()
        {
            flowCategories.SuspendLayout();
            flowCategories.Controls.Clear();

            var homeItem = new CategoryItem(HOME_CATEGORY_ID, "Home", Properties.Resources.HOME);
            homeItem.CategoryClicked += OnCategoryClicked;
            flowCategories.Controls.Add(homeItem);

            for (int i = 0; i < Models.Category.categoryData.Count; i++)
            {
                if (Models.Category.categoryData[i].IsShown)
                {
                    var categoryItem = new CategoryItem(
                        Models.Category.categoryData[i].Id,
                        Models.Category.categoryData[i].Name,
                        UI_Images.loadImageFromFile(Models.Category.categoryData[i].IconPath)
                        );
                    categoryItem.CategoryClicked += OnCategoryClicked;
                    flowCategories.Controls.Add(categoryItem);
                }
            }
            flowCategories.ResumeLayout();
        }

        private void OnCategoryClicked(int categoryId)
        {
            if (categoryId == HOME_CATEGORY_ID)
            {
                ShowHome();
            }
            else
            {
                ShowCategory(categoryId);
            }
        }

        private void ShowHome()
        {
            if (homePage == null)
            {
                homePage = new HomePage();
                homePage.ProductClicked += OnProductClicked;
                categoryPage[HOME_CATEGORY_ID] = homePage;
            }
            ShowPage(homePage);
        }

        private void ShowCategory(int categoryId)
        {
            if (!categoryPage.TryGetValue(categoryId, out var page))
            {
                var categoryPageControl = new CategoryPage(categoryId);
                categoryPageControl.ProductClicked += OnProductClicked;
                page = categoryPageControl;
                categoryPage[categoryId] = page;
            }
            else if (page is CategoryPage cp)
            {
                cp.LoadProduct();
            }

            ShowPage(page);
        }

        private void ShowPage(UserControl page)
        {
            if (currentPage == page)
                return;

            UI_Handling.loadUserControl(ContentPanel, page);
            currentPage = page;
        }

        public void OnCartUpdated(Models.Orders orders)
        {
            currentCartCount = orders.Items.Sum(i => i.Quantity);

            checkOutBtn.Enabled = currentCartCount > 0;
            cartCounterButton.Visible = currentCartCount > 0;
            cartCounterButton.Text = currentCartCount.ToString();

            decimal total = orders.Items.Sum(item => item.ProductPrice * item.Quantity);

            guna2HtmlLabel1.Text = $"""
            <b><font size='12'>Order summary</font></b>
            <br>
            <b>Items:</b> {currentCartCount}
            <br>
            <b>{OrderType}</b>
            <br>
            <b>Total:</b> ₱{total:0.00}
            """;
        }

        internal void UpdateOrderType(string orderType)
        {
            OrderType = orderType;
            guna2HtmlLabel1.Text = $"""
            <b><font size='12'>Order summary</font></b>
            <br>
            <b>Items:</b> {currentCartCount}
            <br>
            <b>{orderType}</b>
            <br>
            <b>Total:</b> ₱
            """;
                }

        private void OnProductClicked(int prodcutId)
        {
            scrollPos = flowCategories.AutoScrollPosition;
            ProductSelected?.Invoke(prodcutId);
        }

        public void KioskScrollPosFix()
        {
            flowCategories.AutoScrollPosition =
                new Point(-scrollPos.X, -scrollPos.Y);
        }

        private void CartPicture_Click(object sender, EventArgs e)
        {
            ViewOrderClicked?.Invoke();
        }
        private void cartCounterButton_Click(object sender, EventArgs e)
        {
            ViewOrderClicked?.Invoke();
        }
        private void checkOutBtn_Click(object sender, EventArgs e)
        {
            ViewOrderClicked?.Invoke();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (var confirm = new ConfirmRemove("Start Over?"))
            {
                var result = confirm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    StartOverClicked?.Invoke();
                }
            }
        }

        // --------------------------------------------------------------------------

        private void BottomPanel_Paint(object sender, PaintEventArgs e)
        {
            UI_Handling.drawBorderSides(e, BottomPanel.ClientRectangle, UI_Handling.borderSide.Top, Color.Black, 2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            UI_Handling.drawBorderSides(e, BottomPanel.ClientRectangle, UI_Handling.borderSide.Top, Color.Black, 2);
        }

    }
}
