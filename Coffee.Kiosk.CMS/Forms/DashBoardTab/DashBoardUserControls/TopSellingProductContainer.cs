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

            if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
            {
                try
                {
                    using var fs = new FileStream(product.ImagePath, FileMode.Open, FileAccess.Read);
                    itemPictureBox.Image = Image.FromStream(fs);
                    itemPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    itemPictureBox.Image = null;
                }
            }
            else
            {
                itemPictureBox.Image = null;
            }
        }

        private void itemPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}