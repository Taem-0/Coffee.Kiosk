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

namespace Coffee.Kiosk.CMS.Forms.InventoryTab.FormDialogs
{
    public partial class AddInventory : Form
    {
        string _imagePath = string.Empty;
        public AddInventory()
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

            _imagePath = dialog.FileName;
            pictureBox1.Image = UIhelp.loadImageFromFile(_imagePath);
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string name = InventoryNameTxtBox.Text.Trim();
            string stock = StockTxtBox.Text.Trim();
            string unit = UnitTxtBox.Text.Trim();

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name)) errors.Add("Inventory name cannot be empty.");
            if (!decimal.TryParse(stock, out decimal parsedStock)) errors.Add("stock must be a valid number (e.g., 123.12).");
            if (string.IsNullOrWhiteSpace(unit)) errors.Add("Unit cannot be empty.");

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors)); 
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
