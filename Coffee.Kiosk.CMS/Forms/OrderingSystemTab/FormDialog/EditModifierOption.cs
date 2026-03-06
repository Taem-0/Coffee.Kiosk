using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class EditModifierOption : Form
    {
        private Models.OrderingSystem.ModifierOption _model;
        public EditModifierOption(Models.OrderingSystem.ModifierOption model)
        {
            InitializeComponent();

            _model = model;

            OptionName.Text = model.Name;
            PriceTxtBox.Text = model.PriceDelta.ToString();
            TriggersChildSwitch.Checked = model.TriggersChild;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
