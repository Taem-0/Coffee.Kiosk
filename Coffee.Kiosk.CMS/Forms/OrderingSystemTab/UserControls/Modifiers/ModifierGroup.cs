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
    public partial class ModifierGroup : UserControl
    {
        public ModifierGroup(
            int id,
            int productId,
            int? parentGroupId,
            string modifierName,
            Models.OrderingSystem.SelectionType selType,
            bool required
            )
        {
            InitializeComponent();
        }

        private void LoadOptions(int modifierId)
        {
            flowMainGroup.Controls.Clear();
        }

        public void LoadChildGroups(int parentGroupId)
        {
            flowLayoutPanel2.Controls.Clear();
        }

        // -------------------------------
        private void flowMainGroup_ControlAdded(object sender, ControlEventArgs e)
        {

            if (flowMainGroup.Controls.Count % 5 == 0)
                flowMainGroup.SetFlowBreak(e!.Control!, true);
        }
    }
}
