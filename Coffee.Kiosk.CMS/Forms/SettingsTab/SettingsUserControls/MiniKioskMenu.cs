using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class MiniKioskMenu : UserControl
    {
        public MiniKioskMenu()
        {
            InitializeComponent();
        }

        public void SetTopBanner(Image? img)
        {
            miniatureTopBanner.Image = img;
            miniatureTopBanner.Invalidate();
        }

        public void SetPromoBanner1(Image? img)
        {
            miniatureTopBanner1.Image = img;
            miniatureTopBanner1.Invalidate();
        }

        public void SetPromoBanner2(Image? img)
        {
            miniatureTopBanner2.Image = img;
            miniatureTopBanner2.Invalidate();
        }

    }
}
