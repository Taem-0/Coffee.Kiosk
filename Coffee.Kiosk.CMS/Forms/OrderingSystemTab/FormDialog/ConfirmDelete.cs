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
        public ConfirmDelete()
        {
            InitializeComponent();

            AcceptButton = DeleteBtn;
            CancelButton = CancelBtn;
            DeleteBtn.Focus();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConfirmDelete_Load(object sender, EventArgs e)
        {
            DeleteBtn.Focus();
        }
    }
}
