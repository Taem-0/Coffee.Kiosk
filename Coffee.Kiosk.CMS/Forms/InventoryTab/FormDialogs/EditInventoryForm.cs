using Coffee.Kiosk.CMS.CoffeeKDB;
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
    public partial class EditInventoryForm : Form
    {
        private Models.InventorySystem.Inventory _item;

        private string _imagePath = "../../../Resources/default_icon.png";

        public string InventoryName = String.Empty;
        public decimal InventoryStock = 0.00m;
        public string InventoryUnit = String.Empty;

        public EditInventoryForm(Models.InventorySystem.Inventory item)
        {
            InitializeComponent();
            _item = item;

            if (!String.IsNullOrEmpty(item.ImagePath)) pictureBox1.Image = UIhelp.loadImageFromFile(item.ImagePath);
            InventoryNameTxtBox.Text = item.Name;
            StockTxtBox.Text = item.Stocks.ToString();
            UnitTxtBox.Text = item.Unit.ToString().ToUpper();
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

            if (!InventoryDbManager.EditInventory(new Models.InventorySystem.Inventory(
                _item.Id,
                name,
                parsedStock,
                unit,
                _imagePath
                )))
                {
                    return;
                }
            InventoryName = name;
            InventoryStock = parsedStock;
            InventoryUnit = unit;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
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
