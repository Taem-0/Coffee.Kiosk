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
    public partial class EditName : Form
    {
        public string NewCategoryName { get; private set; } = string.Empty;

        public EditName(string categoryName)
        {
            InitializeComponent();
            txtName.Text = categoryName;
            txtName.SelectAll();
            txtName.Focus();

            AcceptButton = SaveButton;
            CancelButton = CancelBtn;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var value = txtName.Text.Trim();

            if(string.IsNullOrEmpty(value) )
            {
                MessageBox.Show("Name should not be empty");
                return;
            }

            NewCategoryName = value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
