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
    public partial class RecipeItem : UserControl
    {

        public event Action<RecipeItem>? SelectionChanged;
        public bool IsSelected { get; private set; }

        public Models.InventorySystem.Inventory _model { get; private set; }
        public int? recipeTableId;

        public RecipeItem(Models.InventorySystem.Inventory model)
        {
            InitializeComponent();
            _model = model;
            InventoryItemBtn.Text = _model.Name;
        }


        private void UpdateVisual()
        {
            //InventoryItemBtn.FillColor = IsSelected
            //    ? ColorTranslator.FromHtml("#939393")
            //    : ColorTranslator.FromHtml("#e0e0e0")
            //    ;
            if (IsSelected)
            {
                InventoryItemBtn.FillColor = ColorTranslator.FromHtml("#7d7d7d");
                InventoryItemBtn.ForeColor = Color.White;
            }else
            {
                InventoryItemBtn.FillColor = ColorTranslator.FromHtml("#e0e0e0");
                InventoryItemBtn.ForeColor = Color.DimGray;
            }
        }

        public void Deselect()
        {
            IsSelected = false;
            UpdateVisual();
        }
        public void ForceSelect()
        {
            IsSelected = true;
            UpdateVisual();
        }

        private void InventoryItemBtn_Click(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            UpdateVisual();
            SelectionChanged?.Invoke(this);
        }
    }
}
