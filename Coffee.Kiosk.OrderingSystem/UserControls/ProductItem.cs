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
    public partial class ProductItem : UserControl
    {

        internal event Action<int>? productClicked;

        internal int ProductId { get; set; }
        internal int CategoryId { get; set; }
        public ProductItem(int productId, int categoryId, string name, Image image, decimal price)
        {
            InitializeComponent();

            ProductId = productId;
            CategoryId = categoryId;

            productName.Text = name;
            productPrice.Text = $"PHP {price:0,00}";
            pictureBox1.Image = image;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            productClicked?.Invoke(ProductId);
        }




        // --------------------------------------------------------------------------

        bool isHovered = false;

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!isHovered) return;
            UI_Handling.darkenOnHover(e, pictureBox1.ClientRectangle, UI_Handling.boxOrCircle.box);

        }
    }
}
