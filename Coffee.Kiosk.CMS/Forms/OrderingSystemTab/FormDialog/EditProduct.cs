using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls.Modifiers;
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
    public partial class EditProduct : Form
    {

        private AddModifierGroupButton addModifierGroupButton = new AddModifierGroupButton();


        //private List<Models.OrderingSystem.ModifierGroup> modifierGroup = new ();

        int _ProductId;
        string _ProductName = String.Empty;
        decimal _ProductPrice;
        string _ImagePath = String.Empty;

        public EditProduct(int productId, string productName, decimal productPrice, string imagePath)
        {
            InitializeComponent();


            _ProductId = productId;
            _ProductName = productName;
            _ProductPrice = productPrice;
            _ImagePath = imagePath;


            ProductNameTxtBox.Text = productName;
            PriceTxtBox.Text = productPrice.ToString();
            pictureBox1.Image = UIhelp.loadImageFromFile(imagePath);

            LoadModifierGroups();
        }

        private void LoadModifierGroups()
        {
            flowLayoutPanel1.Controls.Clear();

            var modifierGroups = OrderingSystemDbManager.GetModifierGroups(_ProductId);

            foreach (var group in modifierGroups)
            {
                if (group.ParentGroupId == null)
                {
                    var groupControl = new ModifierGroup(
                        group.Id,
                        group.ProductId,
                        group.ParentGroupId,
                        group.Name,
                        group.SelectionType,
                        group.Required
                        );

                    flowLayoutPanel1.Controls.Add(groupControl);
                }
            }

            addModifierGroupButton.AddModifierClicked -= AddModifier;
            addModifierGroupButton.AddModifierClicked += AddModifier;
            flowLayoutPanel1.Controls.Add(addModifierGroupButton);
        }

        private void AddModifier()
        {

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
