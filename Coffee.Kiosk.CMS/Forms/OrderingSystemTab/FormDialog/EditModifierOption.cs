using Coffee.Kiosk.CMS.CoffeeKDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class EditModifierOption : Form
    {
        private Models.OrderingSystem.ModifierOption _model;
        private List<Models.InventorySystem.Inventory> _inventory;
        string _currentSearch = string.Empty;


        private System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer();

        public EditModifierOption(Models.OrderingSystem.ModifierOption model)
        {
            InitializeComponent();

            _model = model;
            _inventory = InventoryDbManager.GetInventory();

            OptionName.Text = model.Name;
            PriceTxtBox.Text = model.PriceDelta.ToString();
            guna2TextBox3.Text = model.InventorySubtraction.ToString();
            TriggersChildSwitch.Checked = model.TriggersChild;

            LoadInventory();

            _searchTimer.Interval = 100;
            _searchTimer.Tick += SearchTimer_Tick;
        }

        private void SearchInventory()
        {
            _inventory = InventoryDbManager.GetInventory(_currentSearch);
            LoadInventory();
        }

        private void LoadInventory()
        {
            InventoryItemSelection.Items.Clear();
            InventoryItemSelection.Items.Add("None");

            int selectedIndex = 0;

            for (int i = 0; i < _inventory.Count; i++)
            {
                var item = _inventory[i];
                InventoryItemSelection.Items.Add($"ID {item.Id}: {item.Name} ({item.Unit})");

                if (_model.InventoryItemId != null && item.Id == _model.InventoryItemId)
                {
                    selectedIndex = i + 1;
                }
            }

            InventoryItemSelection.SelectedIndex = selectedIndex;
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string optionName = OptionName.Text.Trim();
            string priceTxt = PriceTxtBox.Text.Trim();
            bool triggersChild = TriggersChildSwitch.Checked;
            decimal inventorySubtraction = 0.00m;

            if (String.IsNullOrEmpty(optionName))
            {
                MessageBox.Show("Invalid Name");
                return;
            }

            if (!decimal.TryParse(priceTxt, out decimal parsedPrice))
            {
                MessageBox.Show("Invalid Price");
                return;
            }

            int? selectedInventoryItemId;
            if (InventoryItemSelection.SelectedIndex == 0)
            {
                selectedInventoryItemId = null;
            }
            else
            {
                selectedInventoryItemId = _inventory[InventoryItemSelection.SelectedIndex - 1].Id;

                var inventorySubtractionTxt = guna2TextBox3.Text.Trim();
                if (!String.IsNullOrEmpty(inventorySubtractionTxt))
                {
                    if (decimal.TryParse(inventorySubtractionTxt, out decimal parsedSubtraciton))
                    {
                        inventorySubtraction = parsedSubtraciton;
                    }
                }
            }

            if (!OrderingSystemDbManager.UpdateModifierOption(new Models.OrderingSystem.ModifierOption
            {
                Id = _model.Id,
                GroupId = _model.GroupId,
                Name = optionName,
                PriceDelta = parsedPrice,
                InventorySubtraction = inventorySubtraction,
                InventoryItemId = selectedInventoryItemId,
                TriggersChild = triggersChild,
                SortBy = _model.SortBy
            }))
            {
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowSubtraction(bool show)
        {
            label5.Visible = show;
            guna2TextBox3.Visible = show;
            tipButton5.Visible = show;
        }

        private void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            SearchInventory();
        }

        private void InventorySearchTxtBox_TextChanged(object sender, EventArgs e)
        {

            _currentSearch = InventorySearchTxtBox.Text.Trim();

            _searchTimer.Stop();
            _searchTimer.Start();

        }

        private void InventoryItemSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InventoryItemSelection.SelectedIndex == 0)
            {
                ShowSubtraction(false);
            }
            else
            {
                ShowSubtraction(true);
            }
        }

        private void tipButton5_Load(object sender, EventArgs e)
        {

        }
    }
}
