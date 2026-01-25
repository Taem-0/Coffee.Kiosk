using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls;
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

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab
{
    public partial class OrderingSystemMainControl : UserControl
    {

        private KioskMenu? kioskMenu;

        public OrderingSystemMainControl()
        {
            InitializeComponent();
        }

        private void OrderingSystemMainControl_Load(object sender, EventArgs e)
        {
            ShowKioskMenu();
        }

        private void ShowKioskMenu()
        {
            if (kioskMenu == null)
            {
                kioskMenu = new KioskMenu();
            }
            UIhelp.CallControl(kioskMenu, MainScreen);
        }
    }
}
