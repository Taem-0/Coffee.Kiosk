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
    public partial class PayOptionScreen : UserControl
    {
        internal event Action? BackButtonClicked;
        public PayOptionScreen()
        {
            InitializeComponent();
        }

        private void PayOptionScreen_Load(object sender, EventArgs e)
        {
            CompanyLogo.Image = UI_Images.logoImage;
            UI_Handling.centerPanel(panel3, panel8);
            UI_Handling.centerPanel(panel2, panel6);
        }

        private void PayOptionScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel3, panel8);
            UI_Handling.centerPanel(panel2, panel6);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke();
        }

        private void BackButton2_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke();
        }
    }
}
