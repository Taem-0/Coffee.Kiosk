using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog;
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
        public event Action<Models.OrderingSystem.ModifierGroup>? EditClicked;
        public event Action<int>? DeleteClicked;


        private AddModifierOptionButton addModifierOptionButton = new AddModifierOptionButton();

        private List<Models.OrderingSystem.ModifierOption> modifierOptions = new();

        private Models.OrderingSystem.ModifierGroup _model;

        public ModifierGroup(Models.OrderingSystem.ModifierGroup model)
        {
            InitializeComponent();
            _model = model;

            ModifierGroupName.Text = $"ID {model.Id}: {model.Name}";
            if (model.ParentGroupId != null) ModifierGroupName.Text += $" ( Child Of ID: {model.ParentGroupId} )";
            LoadOptions();
        }

        private void LoadOptions()
        {
            flowMainGroup.Controls.Clear();
            modifierOptions.Clear();

            modifierOptions = OrderingSystemDbManager.GetModifierOptions(_model.Id);

            foreach (var options in modifierOptions)
            {
                var optionControl = new ModifierOption(options);
                optionControl.OptionClicked += EditOption;
                optionControl.DeleteClicked += DeleteOption;
                flowMainGroup.Controls.Add(optionControl);
            }

            addModifierOptionButton.AddOptionsClicked -= AddOptions;
            addModifierOptionButton.AddOptionsClicked += AddOptions;
            flowMainGroup.Controls.Add(addModifierOptionButton);

            //if (_id != null)
            //{
            //    modifierOptions = OrderingSystemDbManager.GetModifierOptions(_id.Value);

            //    foreach (var options in modifierOptions)
            //    {
            //        var optionControl = new ModifierOption(options);
            //        optionControl.OptionClicked += EditOption;
            //        flowMainGroup.Controls.Add(optionControl);
            //    }
            //}
            //else
            //{
            //}
        }

        private void LoadChildGroups(int parentGroupId)
        {
            flowLayoutPanel2.Controls.Clear();
            //TODO
            // probably wont need this and just load every groups as if theyre individual to make it able to switch different parentId's or even remove parentId's
        }

        private void AddOptions()
        {

            var newOption = new Models.OrderingSystem.ModifierOption
            {
                Id = null,
                GroupId = _model.Id,
                Name = "New Option",
                PriceDelta = 0.00m,
                InventorySubtraction = 0.00m,
                InventoryItemId = null,
                TriggersChild = true,
                SortBy = null
            };
            int newOptionId = OrderingSystemDbManager.AddModifierOption(newOption);
            newOption.Id = newOptionId;
            newOption.SortBy = newOptionId;
            modifierOptions.Add(newOption);

            var newOptionControl = new ModifierOption(newOption);

            newOptionControl.OptionClicked += EditOption;
            newOptionControl.DeleteClicked += DeleteOption;

            flowMainGroup.Controls.Remove(addModifierOptionButton);
            addModifierOptionButton.AddOptionsClicked -= AddOptions;

            flowMainGroup.Controls.Add(newOptionControl);


            flowMainGroup.Controls.Add(addModifierOptionButton);
            addModifierOptionButton.AddOptionsClicked += AddOptions;
        }

        private void EditOption(Models.OrderingSystem.ModifierOption model)
        {
            using var dialog = new EditModifierOption(model);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                OrderingSystemDbManager.UpdateModifierOption(model);
                LoadOptions();
            }
        }
        private void DeleteOption(int optionId)
        {
            using var dialog = new ConfirmDelete("Are you sure you want to delete this option?");
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                OrderingSystemDbManager.DeleteModifierOption(optionId);
                LoadOptions();
            }
        }



        // -------------------------------
        private void flowMainGroup_ControlAdded(object sender, ControlEventArgs e)
        {

            if (flowMainGroup.Controls.Count % 4 == 0)
                flowMainGroup.SetFlowBreak(e!.Control!, true);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(guna2Button1, new Point(0, guna2Button1.Height));
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(_model);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(_model.Id);
        }
    }
}
