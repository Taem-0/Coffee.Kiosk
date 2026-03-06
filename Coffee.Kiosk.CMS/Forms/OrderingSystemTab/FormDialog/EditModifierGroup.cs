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

        Models.OrderingSystem.ModifierGroup _model;
        List<Models.OrderingSystem.ModifierGroup> _modifiersExceptItselfAndChild;
        public Models.OrderingSystem.ModifierGroup? ResultModel { get; private set; }

        public EditModifierGroup(Models.OrderingSystem.ModifierGroup model, List<Models.OrderingSystem.ModifierGroup> modifierGroups)
        {
            InitializeComponent();

            _model = model;
            var descendants = GetDescendants(model, modifierGroups);
            _modifiersExceptItselfAndChild = modifierGroups.Where(g => g.Id != model.Id && !descendants.Any(d => d.Id == g.Id)).ToList();

            GroupName.Text = model.Name;
            SelectionType.StartIndex = (model.SelectionType.ToString() == "Single" ? 0 : 1);
            RequiredSwitch.Checked = model.Required;

            foreach (var group in _modifiersExceptItselfAndChild)
            {
                ParentGroupSelection.Items.Add($"ID {group.Id}: {group.Name}");
            }
            if (model.ParentGroupId != null)
            {
                ParentGroupSelection.SelectedIndex = _modifiersExceptItselfAndChild.FindIndex(g => g.Id == model.ParentGroupId) + 1;
            }
        }

        private List<Models.OrderingSystem.ModifierGroup> GetDescendants(
            Models.OrderingSystem.ModifierGroup node,
            List<Models.OrderingSystem.ModifierGroup> allGroups)
        {
            var descendants = new List<Models.OrderingSystem.ModifierGroup>();

            var directChildren = allGroups.Where(g => g.ParentGroupId == node.Id).ToList();
            foreach (var child in directChildren)
            {
                descendants.Add(child);
                descendants.AddRange(GetDescendants(child, allGroups));
            }

            return descendants;
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
                parentIndex = _modifiersExceptItselfAndChild[ParentGroupSelection.SelectedIndex - 1].Id;
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
    }
}
