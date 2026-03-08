using Coffee.Kiosk.CMS.Forms.InventoryTab.FormDialogs;
using Coffee.Kiosk.CMS.Forms.InventoryTab.UserControls.InventoryAsCards;
using Coffee.Kiosk.CMS.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.InventoryTab.UserControls
{
    public partial class InventoryScreen : UserControl
    {
        private InventoryAsTables? inventoryAsTables = new InventoryAsTables();
        private InventoryAsCardsFlow? inventoryAsCards = new InventoryAsCardsFlow();

        bool _showAsTables = true;
        string _search = string.Empty;

        private System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer();
        InventorySystemControl _parentControl;

        public InventoryScreen(InventorySystemControl parentControl)
        {
            InitializeComponent();
            _parentControl = parentControl;

            _searchTimer.Interval = 500;
            _searchTimer.Tick += SearchTimer_Tick;
        }

        private void AddMoreButton_Click(object sender, EventArgs e)
        {
            _parentControl.ShowDarkOverlay(true);
            using var form = new AddInventory();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                SearchInventory();
            }
            _parentControl.ShowDarkOverlay(false);
        }

        private void DisplayAsTableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _showAsTables = DisplayAsTableCheckBox.Checked;
            if (_showAsTables)
            {
                ShowInventoryAsTables();
            }
            else
            {
                ShowInventoryAsCards();
            }
        }

        private void ShowInventoryAsTables()
        {
            inventoryAsTables ??= new InventoryAsTables();
            UIhelp.CallControl(inventoryAsTables, InventoryPanel);
        }

        private void ShowInventoryAsCards()
        {
            inventoryAsCards ??= new InventoryAsCardsFlow();
            UIhelp.CallControl(inventoryAsCards, InventoryPanel);
        }

        private void SearchInventory()
        {

            if (inventoryAsTables == null) return;
            if (_showAsTables)
            {
                inventoryAsTables.SearchTable(_search);
            }
            else
            {
            }
        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            _search = SearchTxtBox.Text;

            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            SearchInventory();
        }
    }
}
