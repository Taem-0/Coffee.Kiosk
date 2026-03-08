using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.InventoryTab.UserControls
{
    public partial class InventoryItem : UserControl
    {
        public InventoryItem()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(guna2Button1, new Point(0, guna2Button1.Height));
        }
    }
}
