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
        private Models.OrderingSystem.ModifierOption _model;

        public event Action<int>? OptionClicked;

        public ModifierOption(Models.OrderingSystem.ModifierOption model)
        {
            InitializeComponent();

            _model = model;

            guna2Button1.Text = _model.Name;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (_model.Id == null) return;
            OptionClicked?.Invoke(_model.Id.Value);
        }
    }
}
