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
        public event Action? SelectionChanged;

        private readonly Models.Product.ModifierGroup _group;

        public ModalModifierChildGroup(Models.Product.ModifierGroup group)
        {
            InitializeComponent();
            _group = group;
            ModifierGroupName.Text = $"{group.Name} {(group.Required ? "(Required)" : "")}";
            LoadOptions();
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
                ctrl.SelectionChanged += (s) => SelectionChanged?.Invoke();
                flowLayoutPanel1.Controls.Add(ctrl);
            }
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
            var selected = flowLayoutPanel1.Controls.OfType<ModalModifierOptions>().Where(o => o.IsSelected).ToList();
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
