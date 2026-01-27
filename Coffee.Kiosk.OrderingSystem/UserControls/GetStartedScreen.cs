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
            UI_Handling.centerPanelfix(this, panelButtonGetStarted);
            //button1.BackColor = UI_ColorScheme.Primary;
            //guna2Button1.FillColor = UI_ColorScheme.Primary;
        }

        private void GetStartedScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanelfix(this, panelButtonGetStarted);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }

        private void GetStartedScreen_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke();
        }
    }
}
