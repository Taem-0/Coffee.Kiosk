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

    public partial class ModalModifierChildGroup : UserControl
    {
        private readonly bool _isSingle;

        public event Action? SelectionChanged;

        private readonly Models.Product.ModifierGroup _group;

        public ModalModifierChildGroup(Models.Product.ModifierGroup group)
        {
            InitializeComponent();
            _group = group;
            _isSingle = group.SelectionType == Models.Product.SelectionType.Single;
            ModifierGroupName.Text = $"{group.Name} {(group.Required ? "(Required)" : "")}";
            LoadOptions();
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
                ctrl.SelectionChanged += selected =>
                {
                    if (_isSingle && selected.IsSelected)
                    {
                        foreach (var other in flowLayoutPanel1.Controls
                                     .OfType<ModalModifierOptions>())
                        {
                            if (other != selected)
                                other.Deselect();
                        }
                    }

                    SelectionChanged?.Invoke();
                };
                flowLayoutPanel1.Controls.Add(ctrl);
            }
        }
        public decimal GetTotalPriceDelta()
        {
            decimal total = (
                from ctrl in flowLayoutPanel1.Controls.OfType<ModalModifierOptions>()
                where ctrl.IsSelected
                select ctrl.Option.PriceDelta
                ).Sum();

            return total;
        }

        public bool IsValid()
        {
            if (_group.Required)
            {
                return flowLayoutPanel1.Controls.OfType<ModalModifierOptions>().Any(o => o.IsSelected);
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
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 6 == 0)
                flowLayoutPanel1.SetFlowBreak(e!.Control!, true);
        }

    }
}
