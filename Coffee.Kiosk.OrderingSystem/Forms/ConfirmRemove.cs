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

namespace Coffee.Kiosk.OrderingSystem.Forms
{
    public partial class ConfirmRemove : Form
    {
        public ConfirmRemove(string dialog)
        {
            InitializeComponent();
            label1.Text = dialog;
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void ConfirmRemove_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel2, label1);
        }

        private void ConfirmRemove_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel2, label1);
        }
    }
}
