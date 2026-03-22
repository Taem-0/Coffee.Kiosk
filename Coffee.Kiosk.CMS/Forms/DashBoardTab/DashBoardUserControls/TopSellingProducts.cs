using Coffee.Kiosk.CMS.Models;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class TopSellingProducts : UserControl
    {
        public TopSellingProducts()
        {
            InitializeComponent();
        }

        public void LoadData(DashboardData data)
        {
            topSellingFlowLayout.Controls.Clear();
            topSellingFlowLayout.AutoScroll = true;

            foreach (var product in data.TopProducts)
            {
                var container = new TopSellingProductContainer();
                container.SetProduct(product);
                topSellingFlowLayout.Controls.Add(container);
            }
        }


        private void TopSellingProducts_Load(object sender, EventArgs e) { }
    }
}