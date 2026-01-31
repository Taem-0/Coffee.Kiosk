using Coffee.Kiosk.OrderingSystem.Helper;
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
        public List<ModalModifierOptions> SelectedOptions { get; private set; } = new();
        private Models.Product.ModifierGroup ModifierGroup;
        private List<Models.Product.ModifierGroup> AllGroups;
        private bool IsSingle = false;
        public ModalModifierGroup(Models.Product.ModifierGroup modifierGroup, List<Models.Product.ModifierGroup> allGroups)
        {
            InitializeComponent();
            ModifierGroup = modifierGroup;
            AllGroups = allGroups;
            IsSingle = modifierGroup.SelectionType == Models.Product.SelectionType.Single ? true : false; 

            ModifierGroupName.Text = modifierGroup.Name + (modifierGroup.Required ? " (Required)" : "");

            LoadModifierOptions(modifierGroup.Id);
        }

        private void LoadModifierOptions(int groupId)
        {
            flowLayoutPanel1.Controls.Clear();

            var options = Sql.Queries.GetProductModifierOptions(groupId).OrderBy(s => s.SortBy);

            ModalModifierOptions? lastOption = null;

            foreach (var option in options)
            {
                var optionControl = new ModalModifierOptions(option);
                optionControl.SelectChanged += OnSelectChange;
                flowLayoutPanel1.Controls.Add(optionControl);
                lastOption = optionControl;
            }

            if (lastOption != null)
            {
                flowLayoutPanel1.SetFlowBreak(lastOption, true);
            }

            LoadChildGroups();
        }
        private void LoadChildGroups()
        {
            flowLayoutPanel2.Controls.Clear();

            var children = AllGroups
                .Where(g => g.ParentGroupId == ModifierGroup.Id)
                .OrderBy(g => g.Id);

            foreach (var child in children)
            {
                var childControl = new ModalModifierGroup(child, AllGroups);
                childControl.Padding = new Padding(0);
                childControl.ModifierGroupName.Font = new Font("Segoe UI", 13F, FontStyle.Regular);

                flowLayoutPanel2.Controls.Add(childControl);
            }

            flowLayoutPanel2.Visible = SelectedOptions.Count > 0;
        }

        private void OnSelectChange(ModalModifierOptions selectedOption)
        {
            if (IsSingle)
            {
                foreach (ModalModifierOptions ctrl in flowLayoutPanel1.Controls.OfType<ModalModifierOptions>())
                {
                    if (ctrl != selectedOption)
                        ctrl.Deselect();
                }

                SelectedOptions.Clear();
                SelectedOptions.Add(selectedOption);
            }
            else
            {
                if (!SelectedOptions.Contains(selectedOption))
                    SelectedOptions.Add(selectedOption);
                else
                    SelectedOptions.Remove(selectedOption);
            }

            UpdateChildGroupsVisibility();
        }

        private void UpdateChildGroupsVisibility()
        {
            bool showChildren = SelectedOptions.Any(o => o.TriggersChild);

            flowLayoutPanel2.Visible = showChildren;

            foreach (ModalModifierGroup child in flowLayoutPanel2.Controls.OfType<ModalModifierGroup>())
            {
                child.Enabled = showChildren;
            }

        }

        //public List<int> GetAllSelectedOptionIds()
        //{
        //    var ids = SelectedOptions.Select(o => o.OptionId).ToList();

        //    foreach (var child in flowLayoutPanel2.Controls.OfType<ModalModifierGroup>())
        //        ids.AddRange(child.GetAllSelectedOptionIds());

        //    return ids;
        //}

        //public List<string> GetAllSelectedOptionNames()
        //{
        //    var names = SelectedOptions.Select(o => o.OptionName).ToList();

        //    foreach (var child in flowLayoutPanel2.Controls.OfType<ModalModifierGroup>())
        //        names.AddRange(child.GetAllSelectedOptionNames());

        //    return names;
        //}




        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 6 == 0)
                flowLayoutPanel1.SetFlowBreak(e!.Control! as Control, true);
        }
    }
}
