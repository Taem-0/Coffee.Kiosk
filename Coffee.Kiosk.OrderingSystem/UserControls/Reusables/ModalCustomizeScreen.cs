using Coffee.Kiosk.OrderingSystem.Helper;
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

namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    public partial class ModalCustomizeScreen : UserControl
    {
        int Amount = 1;
        int ProductId;
        public ModalCustomizeScreen(int productId, string name, string ImagePath)
        {
            InitializeComponent();
            ProductId = productId;

            pictureBox1.Image = UI_Images.loadImageFromFile(ImagePath);
            ProductNameLbl.Text = name;
            AmountLbl.Text = Amount.ToString();
        }

        private void LoadModifierGroups(int productId)
        {
            flowLayoutPanel1.Controls.Clear();

            var allGroups = Models.Product.modifierGroups;

            var rootGroups = allGroups.Where(g => g.ParentGroupId == null).OrderBy(g => g.Id);

            foreach ( var group in rootGroups )
            {
                var groupControl = new ModalModifierGroup(group, allGroups);
                flowLayoutPanel1.Controls.Add(groupControl);
            }
        }


        private void ModalCustomizeScreen_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(topPanel, guna2ShadowPanel1);
            LoadModifierGroups(ProductId);
        }

        private void ModalCustomizeScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(topPanel, guna2ShadowPanel1);
        }

        private void AddAmountBtn_Click(object sender, EventArgs e)
        {
            Amount++;
            AmountLbl.Text = Amount.ToString();
        }

        private void SubtractAmountButton_Click(object sender, EventArgs e)
        {
            Amount--;
            AmountLbl.Text = Amount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Amount++;
            AmountLbl.Text = Amount.ToString();

        }

    }
}
