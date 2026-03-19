using Coffee.Kiosk.CMS.CoffeeKDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    public partial class ProductRecipes : UserControl
    {
        public Models.OrderingSystem.ProductRecipe _model { get; private set; }

        private Models.InventorySystem.Inventory? _inventory;

        private System.Windows.Forms.Timer _updateTimer = new System.Windows.Forms.Timer();
        private decimal _currentValue;
        public ProductRecipes(Models.OrderingSystem.ProductRecipe model)
        {
            InitializeComponent();
            _model = model;
            _inventory = InventoryDbManager.GetInventoryById(model.InventoryItemId);

            if (_inventory != null)
            {
                InventoryItemNameLbl.Text = _inventory.Name;
                guna2TextBox1.Text = model.InventorySubtraction.ToString();
                UnitLbl.Text = _inventory.Unit;
                _currentValue = model.InventorySubtraction;
            }

            _updateTimer.Interval = 500;
            _updateTimer.Tick += UpdateTimer_Tick;
        }

        private void IncreaseBtn_Click(object sender, EventArgs e)
        {
            _currentValue++;

            guna2TextBox1.Text = _currentValue.ToString();
            RestartUpdateTimer();
        }

        private void DecreaseBtn_Click(object sender, EventArgs e)
        {
            if (_currentValue < 0) return;

            _currentValue--;

            guna2TextBox1.Text = _currentValue.ToString();
            RestartUpdateTimer();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as Guna.UI2.WinForms.Guna2TextBox;
            if (tb == null) return;

            string text = tb.Text;
            int dotCount = text.Count(c => c == '.');

            string filtered = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            if (dotCount > 1)
            {
                int firstDotIndex = filtered.IndexOf('.');
                filtered = filtered.Substring(0, firstDotIndex + 1) +
                           filtered.Substring(firstDotIndex + 1).Replace(".", "");
            }

            if (tb.Text != filtered)
            {
                int selStart = tb.SelectionStart;
                tb.Text = filtered;
                tb.SelectionStart = Math.Min(selStart, tb.Text.Length);
            }

            if (!decimal.TryParse(tb.Text, out _currentValue))
                _currentValue = 0;

            _updateTimer.Stop();
            _updateTimer.Start();
        }
        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            _updateTimer.Stop();
            OrderingSystemDbManager.UpdateProductRecipe(_model.Id, _currentValue);
        }
        private void RestartUpdateTimer()
        {
            _updateTimer.Stop();
            _updateTimer.Start();
        }
    }
}
