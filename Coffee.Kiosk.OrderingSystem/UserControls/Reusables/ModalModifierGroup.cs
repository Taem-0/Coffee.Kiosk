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
    public partial class ModalModifierGroup : UserControl
    {
        public ModalModifierGroup(Models.Product.ModifierGroup modifierGroup)
        {
            InitializeComponent();

            ModifierGroupName.Text = modifierGroup.Name;

            LoadModifierOptions(modifierGroup.Id);
        }

        private void LoadModifierOptions(int groupId)
        {
            flowLayoutPanel1.Controls.Clear();

            var options = Sql.Queries.GetProductModifierOptions(groupId);

            foreach (var option in options)
            {
                var optionControl = new ModalModifierOptions(option);
                flowLayoutPanel1.Controls.Add(optionControl);
            }
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 6 == 0)
                flowLayoutPanel1.SetFlowBreak(e!.Control! as Control, true);
        }
    }
}
