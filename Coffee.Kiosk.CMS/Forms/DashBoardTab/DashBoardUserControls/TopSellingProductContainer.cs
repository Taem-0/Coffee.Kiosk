using Coffee.Kiosk.CMS.Models;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class TopSellingProductContainer : UserControl
    {
        public TopSellingProductContainer()
        {
            InitializeComponent();
        }

        public void SetProduct(TopSellingProduct product)
        {
            productRankNo.Text = $"#{product.Rank}";
            productName.Text = product.Name;
            productQt.Text = product.Quantity.ToString();
        }
    }
}