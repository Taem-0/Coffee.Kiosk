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

        private async void GetStartedScreen_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanelfix(this, panelButtonGetStarted);
            button1.BackColor = UI_ColorScheme.Primary;

            await changeBackground(3000);

        }

        private void GetStartedScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanelfix(this, panelButtonGetStarted);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }

        private async Task changeBackground(int delayMs)
        {
            while(true)
            {
                await Task.Delay(delayMs);
                this.BackgroundImage = UI_Images.loadImageFromFile("C:/Images/Kiosk/Ads/Cafe Brand Web Banner Design.jpg");

                await Task.Delay(delayMs * 2);
                this.BackgroundImage = UI_Images.loadImageFromFile("C:/Images/Kiosk/Ads/Café Gelado _ Lune Graphic.jpg");
            }
        }
    }
}
