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

namespace Coffee.Kiosk.CMS.Forms.InventoryTab
{
    public partial class InventorySystemControl : UserControl
    {
        private UserControls.InventoryScreen? inventoryScreen;

        public InventorySystemControl()
        {
            InitializeComponent();
        }

        private void InventorySystemControl_Load(object sender, EventArgs e)
        {
            ShowInventoryScreen();
        }


        private void ShowInventoryScreen()
        {
            if (inventoryScreen == null)
            {
                inventoryScreen = new UserControls.InventoryScreen();
            }
            UIhelp.CallControl(inventoryScreen, MainScreen);
        }

        public void ShowDarkOverlay(bool isShown)
        {
            if (isShown)
            {
                DarkOverlayPanel.Visible = true;
                DarkOverlayPanel.BringToFront();
            }
            else
            {
                DarkOverlayPanel.Visible = false;
                MainScreen.BringToFront();
            }
        }

    }
}
