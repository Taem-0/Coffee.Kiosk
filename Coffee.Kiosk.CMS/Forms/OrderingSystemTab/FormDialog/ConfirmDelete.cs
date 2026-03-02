using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class ConfirmDelete : Form
    {
        public ConfirmDelete(string label)
        {
            InitializeComponent();

            DeleteBtn.Focus();
            label1.Text = label;
        }


        private void ConfirmDelete_Load(object sender, EventArgs e)
        {
            DeleteBtn.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
