using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls;
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
    public partial class EditModifierGroup : Form
    {

        private CustomToolTip currentToolTip = new CustomToolTip();
        Models.OrderingSystem.ModifierGroup _model;
        List<Models.OrderingSystem.ModifierGroup> _modifiersExceptItself;
        public Models.OrderingSystem.ModifierGroup? ResultModel { get; private set; }

        public EditModifierGroup(Models.OrderingSystem.ModifierGroup model, List<Models.OrderingSystem.ModifierGroup> modifierGroups)
        {
            InitializeComponent();

            _model = model;
            _modifiersExceptItself = modifierGroups.Where(g => g.Id != model.Id).ToList();

            GroupName.Text = model.Name;
            SelectionType.StartIndex = (model.SelectionType.ToString() == "Single" ? 0 : 1);
            RequiredSwitch.Checked = model.Required;

            foreach (var group in _modifiersExceptItself)
            {
                ParentGroupSelection.Items.Add($"ID {group.Id}: {group.Name}");
            }
            if (model.ParentGroupId != null)
            {
                ParentGroupSelection.SelectedIndex = _modifiersExceptItself.FindIndex(g => g.Id == model.ParentGroupId) + 1;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            String groupName = GroupName.Text.Trim();
            if (String.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Group name cannot be empty");
                return;
            }

            Models.OrderingSystem.SelectionType selType = (
                SelectionType.SelectedIndex == 0 
                ? Models.OrderingSystem.SelectionType.Single 
                : Models.OrderingSystem.SelectionType.Multiple);

            bool required = RequiredSwitch.Checked;

            int? parentIndex;
            if (ParentGroupSelection.SelectedIndex == 0)
            {
                parentIndex = null;
            }else
            {
                parentIndex = _modifiersExceptItself[ParentGroupSelection.SelectedIndex - 1].Id;
            }

            ResultModel = new Models.OrderingSystem.ModifierGroup
            (
                _model.Id,
                _model.ProductId,
                parentIndex,
                groupName,
                selType,
                required
            );
            if (!OrderingSystemDbManager.UpdateModifierGroup(ResultModel)) return;

            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowToolTip(String tipText)
        {
            currentToolTip.ChangeToolTipText(tipText);

            currentToolTip.ChangeToolTipText(tipText);

            Point screenPos = Cursor.Position;
            currentToolTip.Location = new Point(screenPos.X + 10, screenPos.Y + 10);

            currentToolTip.Show();
        }
        private void HideToolTip()
        {
            currentToolTip.Hide();
        }

        // ------------------------------------------

        private void SelectionTypeToolTip_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTip("""
                Select single or multiple options

                Single - Only allows one option to be selected.
                Multiple - Allows multiple option to be selected
                """);
        }

        private void SelectionTypeToolTip_MouseLeave(object sender, EventArgs e)
        {
            HideToolTip();
        }

        private void RequiredToolTip_MouseEnter(object sender, EventArgs e)
        {

        }

        private void RequiredToolTip_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
