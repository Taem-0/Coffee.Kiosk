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

namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    public partial class ModalCustomizeScreen : UserControl
    {
        int Amount = 1;
        public ModalCustomizeScreen(int productId, string name, string ImagePath)
        {
            InitializeComponent();

            pictureBox1.Image = UI_Images.loadImageFromFile(ImagePath);
            ProductNameLbl.Text = name;
            AmountLbl.Text = Amount.ToString();

        }

        private void ModalCustomizeScreen_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(topPanel, panel1);
        }

        private void ModalCustomizeScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(topPanel, panel1);
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
