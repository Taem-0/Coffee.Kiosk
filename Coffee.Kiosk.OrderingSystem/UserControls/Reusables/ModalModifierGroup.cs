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
        public event Action? SelectionChanged;

        private readonly Models.Product.ModifierGroup _group;
        private readonly List<Models.Product.ModifierGroup> _allGroups;
        private readonly bool _isSingle;

        private readonly List<ModalModifierChildGroup> _childGroups = new();

        public ModalModifierGroup(Models.Product.ModifierGroup group, List<Models.Product.ModifierGroup> allGroups)
        {
            InitializeComponent();
            _group = group;
            _allGroups = allGroups;
            _isSingle = group.SelectionType == Models.Product.SelectionType.Single;

            ModifierGroupName.Text = $"{group.Name} {(group.Required ? "(Required)" : "")}";

            LoadOptions();
            LoadChildGroups();
        }

        private void LoadOptions()
        {
            flowLayoutPanel1.Controls.Clear();

            var options =
                from opt in Models.Product.modifierOption
                where opt.GroupId == _group.Id
                orderby opt.SortBy
                select opt;

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

            var children =
                from g in _allGroups
                where g.ParentGroupId == _group.Id
                orderby g.Id
                select g;

            foreach (var child in children)
            {
                var childCtrl = new ModalModifierChildGroup(child);
                childCtrl.SelectionChanged += () => SelectionChanged?.Invoke();
                _childGroups.Add(childCtrl);
                flowLayoutPanel2.Controls.Add(childCtrl);
            }

            UpdateChildVisibility();
        }

        private void UpdateChildVisibility()
        {
            bool show = (
                from ctrl in flowLayoutPanel1.Controls.OfType<ModalModifierOptions>()
                where ctrl.IsSelected && ctrl.Option.TriggersChild
                select 1
                ).Any();

            flowLayoutPanel2.Visible = show;

            SelectionChanged?.Invoke();
        }

        private void OnOptionSelectionChanged(ModalModifierOptions selected)
        {
            if (_isSingle && selected.IsSelected)
            {
                foreach (var other in flowLayoutPanel1.Controls.OfType<ModalModifierOptions>())
                    if (other != selected) other.Deselect();
            }

            UpdateChildVisibility();
        }

        public decimal GetTotalPriceDelta()
        {
            decimal total = (
                from ctrl in flowLayoutPanel1.Controls.OfType<ModalModifierOptions>()
                where ctrl.IsSelected
                select ctrl.Option.PriceDelta
                ).Sum();


            foreach (var child in _childGroups)
            {
                if (flowLayoutPanel2.Visible)
                    total += child.GetTotalPriceDelta();
            }

            return total;
        }


        public bool IsValid()
        {
            var options = flowLayoutPanel1.Controls.OfType<ModalModifierOptions>().ToList();

            if (_group.Required && !options.Any(o => o.IsSelected) && options.Count > 0)
                return false;

            foreach (var child in _childGroups)
            {
                if (flowLayoutPanel2.Visible && !child.IsValid())
                    return false;
            }
            return true;
        }

        public void CollectSelections(Dictionary<int, List<int>> ids, Dictionary<string, List<string>> names)
        {
            var selected = (
                from ctrl in flowLayoutPanel1.Controls.OfType<ModalModifierOptions>()
                where ctrl.IsSelected
                select ctrl
                ).ToList();

            if (selected.Count > 0)
            {
                ids[_group.Id] = selected.Select(o => o.Option.Id).ToList();
                names[_group.Name] = selected.Select(o => o.Option.Name).ToList();
            }

            if (flowLayoutPanel2.Visible)
            {
                foreach (var child in _childGroups)
                    child.CollectSelections(ids, names);
            }
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 4 == 0)
                flowLayoutPanel1.SetFlowBreak(e!.Control!, true);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
