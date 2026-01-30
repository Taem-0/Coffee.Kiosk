using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    public partial class ModalModifierOptions : UserControl
    {
        public ModalModifierOptions(Models.Product.ModifierOption modifierOption)
        {
            InitializeComponent();
            guna2Button1.Text = modifierOption.Name;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
