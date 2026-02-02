using Coffee.Kiosk.OrderingSystem.Helper;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem
{
    public partial class GetStartedScreen : UserControl
    {

        internal event Action? NextClicked;

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public GetStartedScreen()
        {
            InitializeComponent();
            UI_Handling.fixVisualShifts(this);
        }

        private void GetStartedScreen_Load(object sender, EventArgs e)
        {
            //button1.BackColor = UI_ColorScheme.Primary;
            //guna2Button1.FillColor = UI_ColorScheme.Primary;

            pictureBox1.Image = UI_Images.logoImage;
            this.BackgroundImage = UI_Images.loadImageFromFile("C:/Images/Kiosk/Ads/ADS1.jpg");
        }

        private void GetStartedScreen_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }

        private void guna2ShadowPanel2_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }
    }
}
