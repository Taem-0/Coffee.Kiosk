using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.InventoryTab.FormDialogs
{
    public partial class EditInventoryForm : Form
    {
        private Models.InventorySystem.Inventory _item;
        public EditInventoryForm(Models.InventorySystem.Inventory item)
        {
            InitializeComponent();
            _item = item;
        }
    }
}
