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

        public event Action<int, string, decimal, string>? EditClicked;
        public event Action<int>? DeleteClicked;

        internal event Action<int>? productClicked;

        internal int ProductId { get; set; }
        internal int CategoryId { get; set; }

        string _name = String.Empty;
        decimal _price;
        string _imagePath = String.Empty;

        private Color normalColor = ColorTranslator.FromHtml("#FFFFFF");
        private Color hoverColor = Color.FromArgb(220, 220, 220);
        private Guna2Panel? surfacePanel;

        public ProductItem(int productId, int categoryId, string name, string imagePath, decimal price)
        {
            InitializeComponent();

            ProductId = productId;
            CategoryId = categoryId;
            _name = name;
            _price = price;
            _imagePath = imagePath;

            productName.Text = name;
            productPrice.Text = $"PHP {price:0.00}";
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

            if (control != guna2Button1)
            {
                control.MouseClick += (_, _) =>
                {
                    EditClicked?.Invoke(ProductId, _name, _price, _imagePath);
                };
            }
            foreach (Control child in control.Controls)
                AttachHover(child);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(guna2Button1, new Point(0, guna2Button1.Height));
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(ProductId, _name, _price, _imagePath);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(ProductId);
        }
    }
}
