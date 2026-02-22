using Coffee.Kiosk.CMS.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    public partial class ProductItem : UserControl
    {
        internal event Action<int>? productClicked;

        internal int ProductId { get; set; }
        internal int CategoryId { get; set; }

        private Color normalColor = ColorTranslator.FromHtml("#FFFFFF");
        private Color hoverColor = Color.FromArgb(220, 220, 220);
        private Guna2Panel? surfacePanel;

        public ProductItem(int productId, int categoryId, string name, string imagePath, decimal price)
        {
            InitializeComponent();

            ProductId = productId;
            CategoryId = categoryId;

            productName.Text = name;
            productPrice.Text = $"PHP {price:0,00}";
            pictureBox1.Image = UIhelp.loadImageFromFile(imagePath);
        }

        private void ProductItem_Load(object sender, EventArgs e)
        {
            surfacePanel = guna2Panel1;
            AttachHover(this);
            Cursor = Cursors.Hand;
        }

        private void AttachHover(Control control)
        {
            control.MouseEnter += (_, _) =>
            {
                if (surfacePanel != null)
                    surfacePanel.FillColor = hoverColor;
            };

            control.MouseLeave += (_, _) =>
            {
                if (surfacePanel != null)
                    surfacePanel.FillColor = normalColor;
            };
            foreach (Control child in control.Controls)
                AttachHover(child);
        }

    }
}
