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

namespace Coffee.Kiosk.OrderingSystem.UserControls.PayOption
{
    public partial class ReceiptGcashScreen : UserControl
    {
        public ReceiptGcashScreen()
        {
            InitializeComponent();
            CompanyLogo.Image = UI_Images.logoImage;
        }
    }
}
