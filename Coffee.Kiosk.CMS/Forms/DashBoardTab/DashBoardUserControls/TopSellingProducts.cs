using Coffee.Kiosk.CMS.Models;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class TopSellingProducts : UserControl
    {
        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        public TopSellingProducts()
        {
            InitializeComponent();
            topSellingFlowLayout.HorizontalScroll.Maximum = 0;
            topSellingFlowLayout.HorizontalScroll.Visible = false;
            topSellingFlowLayout.AutoScroll = false;
            topSellingFlowLayout.VerticalScroll.Enabled = true;
        }

        public void LoadData(DashboardData data)
        {
            topSellingFlowLayout.Controls.Clear();
            topSellingFlowLayout.AutoScroll = true;
            topSellingFlowLayout.FlowDirection = FlowDirection.TopDown;
            topSellingFlowLayout.WrapContents = false;

            foreach (var product in data.TopProducts)
            {
                var container = new TopSellingProductContainer();
                container.SetProduct(product);
                container.Width = topSellingFlowLayout.ClientSize.Width - 5;
                topSellingFlowLayout.Controls.Add(container);
            }

            ShowScrollBar(topSellingFlowLayout.Handle, 0, false);
        }

        private void TopSellingProducts_Load(object sender, EventArgs e) { }
    }
}