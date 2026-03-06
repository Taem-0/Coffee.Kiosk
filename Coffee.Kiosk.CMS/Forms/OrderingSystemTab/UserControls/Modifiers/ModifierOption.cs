using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls.Modifiers
{
    public partial class ModifierOption : UserControl
    {
        public event Action<Models.OrderingSystem.ModifierOption>? OptionClicked;
        public event Action<int>? DeleteClicked;

        private Models.OrderingSystem.ModifierOption _model;

        public ModifierOption(Models.OrderingSystem.ModifierOption model)
        {
            InitializeComponent();

            _model = model;

            guna2Button1.Text = _model.Name;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OptionClicked?.Invoke(_model);
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            OptionClicked?.Invoke(_model);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
