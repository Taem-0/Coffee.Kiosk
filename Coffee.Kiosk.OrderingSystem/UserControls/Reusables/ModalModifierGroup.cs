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
        public event Action? SelectionChanged;

        private readonly Models.Product.ModifierGroup _group;
        private readonly List<Models.Product.ModifierGroup> _allGroups;
        private readonly bool _isSingle;
        public ModalModifierGroup(
            Models.Product.ModifierGroup group,
            List<Models.Product.ModifierGroup> allGroups)
        {
            InitializeComponent();

            _group = group;
            _allGroups = allGroups;
            _isSingle = group.SelectionType == Models.Product.SelectionType.Single;

            ModifierGroupName.Text = $"{group.Name} { (group.Required ? "(Required)" : "") }";



            LoadOptions();
            LoadChildGroups();
        }

        private void LoadOptions()
        {
            flowLayoutPanel1.Controls.Clear();

            var options = Models.Product.modifierOption
                .Where(o => o.GroupId == _group.Id)
                .OrderBy(o => o.SortBy);

            foreach (var option in options)
            {
                var ctrl = new ModalModifierOptions(option);
                ctrl.SelectionChanged += OnOptionSelectionChanged;
                flowLayoutPanel1.Controls.Add(ctrl);
            }
        }
        private void LoadChildGroups()
        {
            flowLayoutPanel2.Controls.Clear();

            var children = _allGroups
                .Where(g => g.ParentGroupId == _group.Id)
                .OrderBy(g => g.Id);

            foreach (var child in children)
            {
                var childCtrl = new ModalModifierGroup(child, _allGroups)
                {
                    Padding = Padding.Empty
                };
                childCtrl.ModifierGroupName.Font = new Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular);

                flowLayoutPanel2.Controls.Add(childCtrl);
            }

            UpdateChildVisibility();
        }

        private void UpdateChildVisibility()
        {
            bool show = flowLayoutPanel1
                .Controls
                .OfType<ModalModifierOptions>()
                .Any(o => o.IsSelected && o.Option.TriggersChild);

            flowLayoutPanel2.Visible = show;
        }

        private void OnOptionSelectionChanged(ModalModifierOptions selected)
        {
            if (_isSingle && selected.IsSelected)
            {
                foreach (var other in flowLayoutPanel1
                             .Controls.OfType<ModalModifierOptions>())
                {
                    if (other != selected)
                        other.Deselect();
                }
            }

            UpdateChildVisibility();
            SelectionChanged?.Invoke();
        }
        public void CollectSelections(
            Dictionary<int, List<int>> ids,
            Dictionary<string, List<string>> names
            )
        {
            var selected = flowLayoutPanel1.Controls
                .OfType<ModalModifierOptions>()
                .Where(o => o.IsSelected)
                .ToList();

            if (selected.Count > 0)
            {
                ids[_group.Id] = selected.Select(o => o.Option.Id).ToList();
                names[_group.Name] = selected.Select(o => o.Option.Name).ToList();
            }

            foreach (var child in flowLayoutPanel2.Controls.OfType<ModalModifierGroup>())
                child.CollectSelections(ids, names);
        }

        public bool IsValid()
        {
            if (_group.Required)
            {
                bool hasSelection = flowLayoutPanel1.Controls
                    .OfType<ModalModifierOptions>()
                    .Any(o => o.IsSelected);

                if (!hasSelection)
                    return false;
            }

                foreach (var child in flowLayoutPanel2.Controls.OfType<ModalModifierGroup>())
                {
                    if (child.IsValid())
                        return false;
                }

            return true;
        }



        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 6 == 0)
                flowLayoutPanel1.SetFlowBreak(e!.Control! as Control, true);
        }

        private void ModifierGroupName_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_group.ToString());
        }
    }
}
