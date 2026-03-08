using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.InventoryTab.FormDialogs;
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

        private List<Models.InventorySystem.Inventory> _inventory;
        public InventoryAsTables()
        {
            InitializeComponent();

            _inventory = InventoryDbManager.GetInventory();
        }

        public void SearchTable(string search)
        {
            _inventory = InventoryDbManager.GetInventory(search);
            LoadInventoryToTable();
        }

        private void LoadInventoryToTable()
        {
            guna2DataGridView1.Rows.Clear();

            foreach (var item in _inventory)
            {
                guna2DataGridView1.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Unit,
                    item.Stocks
                    );
            }
        }

        private void guna2DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = _inventory[e.RowIndex];

            var editForm = new EditInventoryForm(item);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                //TODO
                LoadInventoryToTable();
            }
        }
    }
}
