using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.InventoryTab.FormDialogs;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog;
using Guna.UI2.WinForms;
using Microsoft.Win32;
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
    public partial class InventoryAsTables : UserControl
    {

        private Color _darkBrown = ColorTranslator.FromHtml("#3d211a");
        private Color _mediumBrown = ColorTranslator.FromHtml("#6f4d38");
        private Color _lightBrown = ColorTranslator.FromHtml("#a07856");
        private Color _beige = ColorTranslator.FromHtml("#cbb799");
        private Color _background = ColorTranslator.FromHtml("#f5f5dc");

        private List<Models.InventorySystem.Inventory> _inventory;
        InventorySystemControl _parentControl;

        string _currentSearch = string.Empty;
        DataGridViewRow? _currentSelectedRow = null;
        public InventoryAsTables(InventorySystemControl parentControl)
        {
            InitializeComponent();
            _parentControl = parentControl;

            _inventory = InventoryDbManager.GetInventory();
            ApplyDataGridTheme(guna2DataGridView1);
            LoadInventoryToTable();
        }

        public void SearchTable(string search)
        {
            _inventory = InventoryDbManager.GetInventory(search);
            _currentSearch = search;
            LoadInventoryToTable();
        }

        private void LoadInventoryToTable()
        {
            guna2DataGridView1.Rows.Clear();

            foreach (var item in _inventory)
            {
                int rowIndex = guna2DataGridView1.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Stocks,
                    item.Unit
                    );
                guna2DataGridView1.Rows[rowIndex].Tag = item;
            }
        }

        private Models.InventorySystem.Inventory? GetRowItem(int rowIndex)
        {
            if (rowIndex < 0) return null;
            return guna2DataGridView1.Rows[rowIndex].Tag as Models.InventorySystem.Inventory;
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = GetRowItem(e.RowIndex);
            if (item == null) return;

            _currentSelectedRow = guna2DataGridView1.Rows[e.RowIndex];
            EditInventory(item);
        }

        private void guna2DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = guna2DataGridView1.Rows[e.RowIndex];
            var item = row.Tag as Models.InventorySystem.Inventory;
            if (item == null) return;

            string name = row.Cells[1].Value?.ToString() ?? "";
            string stock = row.Cells[2].Value?.ToString() ?? "";
            string unit = row.Cells[3].Value?.ToString()?.ToUpper() ?? "";

            if (!ValidateEditCell(name, stock, unit))
            {
                LoadInventoryToTable();
                return;
            }

            decimal parsedStock = decimal.Parse(stock);

            bool updateName = item.Name != name;
            bool updateStock = item.Stocks != parsedStock;
            bool updateUnit = item.Unit != unit;

            if (!updateName && !updateStock && !updateUnit)
                return;

            if (e.ColumnIndex == 3)
            {
                var value = row.Cells[3].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    row.Cells[3].Value = value.ToUpper();
                }
            }

            item.Name = name;
            item.Stocks = parsedStock;
            item.Unit = unit;

            InventoryDbManager.EditInventory(
                item,
                updateName,
                updateStock,
                updateUnit,
                false
            );
        }

        private void guna2DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;

            guna2DataGridView1.ClearSelection();
            guna2DataGridView1.Rows[e.RowIndex].Selected = true;

            if (e.ColumnIndex >= 0)
                guna2DataGridView1.CurrentCell =
                    guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            _currentSelectedRow = guna2DataGridView1.Rows[e.RowIndex];

            contextMenuStrip1.Show(MousePosition);
        }
        private Models.InventorySystem.Inventory? GetSelectedItem()
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
                return null;

            return guna2DataGridView1.SelectedRows[0].Tag as Models.InventorySystem.Inventory;
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null) return;

            EditInventory(item);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null || item.Id == null) return;

            _parentControl.ShowDarkOverlay(true);

            using var form = new ConfirmDelete("Are you sure you want to delete this inventory item?");
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                InventoryDbManager.DeleteInventory(item.Id.Value);
                _inventory = InventoryDbManager.GetInventory(_currentSearch);
                LoadInventoryToTable();
            }

            _parentControl.ShowDarkOverlay(false);
        }

        private void EditInventory(Models.InventorySystem.Inventory item)
        {
            var editForm = new EditInventoryForm(item);
            _parentControl.ShowDarkOverlay(true);

            if (editForm.ShowDialog() == DialogResult.OK && _currentSelectedRow != null)
            {
                item.Name = editForm.InventoryName;
                item.Stocks = editForm.InventoryStock;
                item.Unit = editForm.InventoryUnit;

                _currentSelectedRow.Cells[1].Value = item.Name;
                _currentSelectedRow.Cells[2].Value = item.Stocks;
                _currentSelectedRow.Cells[3].Value = item.Unit;

                _currentSelectedRow.Tag = item;
            }
            _parentControl.ShowDarkOverlay(false);
        }

        private bool ValidateEditCell(string name, string stock, string unit)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name)) errors.Add("Inventory name cannot be empty.");
            if (!decimal.TryParse(stock, out decimal parsedStock)) errors.Add("stock must be a valid number (e.g., 123.12).");
            if (string.IsNullOrWhiteSpace(unit)) errors.Add("Unit cannot be empty.");

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            return true;

            //if (!InventoryDbManager.EditInventory(new Models.InventorySystem.Inventory(
            //    _item.Id,
            //    name,
            //    parsedStock,
            //    unit,
            //    _imagePath
            //    )))
            //    {
            //        return;
            //    }

        }

        private void ApplyDataGridTheme(Guna2DataGridView gunaDataGrid)
        {
            // Configure DataGridView theme
            gunaDataGrid.BackgroundColor = _beige;
            gunaDataGrid.GridColor = _mediumBrown;

            // Header styling
            gunaDataGrid.ColumnHeadersDefaultCellStyle.BackColor = _mediumBrown;
            gunaDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gunaDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            gunaDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gunaDataGrid.ColumnHeadersHeight = 50;

            gunaDataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = _mediumBrown;


            // Row styling
            gunaDataGrid.DefaultCellStyle.BackColor = Color.White;
            gunaDataGrid.DefaultCellStyle.ForeColor = _darkBrown;
            gunaDataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 220);
            gunaDataGrid.DefaultCellStyle.SelectionForeColor = _darkBrown;
            gunaDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 15F);

            gunaDataGrid.RowTemplate.Height = 50;

            // Alternating rows
            gunaDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 240);
            gunaDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = _darkBrown;

            // Border styling
            gunaDataGrid.BorderStyle = BorderStyle.None;
            gunaDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gunaDataGrid.GridColor = _mediumBrown;

            // Row headers (if visible)
            gunaDataGrid.RowHeadersVisible = false;

            // Enable visual styles for better appearance
            gunaDataGrid.EnableHeadersVisualStyles = false;
        }

    }
}
