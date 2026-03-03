using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class AddProduct : Form
    {

        private string _ProductName = "ProductPlaceHolderName";
        private decimal _Price = 100.00M;
        private string _ImagePath = "../../../Resources/default_icon.png";

        public string ProductName1 => _ProductName;
        public decimal Price => _Price;
        public string ImagePath => _ImagePath;

        public AddProduct(int categoryId)
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select category icon",
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
                Multiselect = false
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            _ImagePath = dialog.FileName;
            pictureBox1.Image = UIhelp.loadImageFromFile(_ImagePath);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string name = ProductNameTxtBox.Text.Trim();
            string priceText = PriceTxtBox.Text.Trim();

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name)) errors.Add("Product name cannot be empty.");
            if (!decimal.TryParse(priceText, out decimal parsedPrice)) errors.Add("Price must be a valid number (e.g., 123.12).");
            if (parsedPrice < 0) errors.Add("Price cannot be negative.");

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors)); 
                return;
            }

            _ProductName = name;
            _Price = parsedPrice;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //---------------------------------------------

        bool isHoveredPicture = false;

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            isHoveredPicture = true;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isHoveredPicture = false;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!isHoveredPicture) return;
            UIhelp.darkenOnHover(e, pictureBox1.ClientRectangle, UIhelp.boxOrCircle.box);
        }

    }
}
