using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    public partial class AddProductButton : UserControl
    {
        public event Action? ProductAddMoreClicked;
        
        public AddProductButton()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ProductAddMoreClicked?.Invoke();
        }
    }
}
