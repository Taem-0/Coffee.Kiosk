using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Coffee.Kiosk.CMS.Models.InventorySystem;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class AddRecipe : Form
    {
        private int _productId;
        private List<Models.InventorySystem.Inventory> _inventory;
        private List<Models.OrderingSystem.ProductRecipe> _productRecipe = new();

        private System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer();
        private string _currentSearch = String.Empty;

        public AddRecipe(int productId)
        {
            InitializeComponent();
            _productId = productId;
            _inventory = InventoryDbManager.GetInventory();
            _productRecipe = OrderingSystemDbManager.GetAllProductsRecipe(productId);

            LoadInventory();
            LoadProductRecipe();

            _searchTimer.Interval = 250;
            _searchTimer.Tick += SearchTimer_Tick;

        }

        private void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            SearchInventory(SearchTxtBox.Text.Trim());
        }

        private void SearchInventory(string search)
        {
            _inventory = InventoryDbManager.GetInventory(search);
            _currentSearch = search;
            LoadInventory();
        }


        private void LoadInventory()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in _inventory)
            {
                var itemControl = new RecipeItem(item);
                itemControl.SelectionChanged += SelectionChanged;

                if (_productRecipe.Any(i => i.InventoryItemId == item.Id))
                {
                    itemControl.ForceSelect();
                }

                flowLayoutPanel1.Controls.Add(itemControl);
            }
        }

        private void LoadProductRecipe()
        {
            flowLayoutPanel2.Controls.Clear();

            foreach (var recipe in _productRecipe)
            {
                var productRecipe = new ProductRecipes(recipe);
                flowLayoutPanel2.Controls.Add(productRecipe);
            }
        }

        private void SelectionChanged(RecipeItem recipeItemControl)
        {
            if (recipeItemControl._model.Id == null) return;
            int inventoryId = recipeItemControl._model.Id.Value;

            if (recipeItemControl.IsSelected)
            {
                if (_productRecipe.Any(r => r.InventoryItemId == inventoryId)) return;

                int id = OrderingSystemDbManager.AddProductRecipe(_productId, recipeItemControl._model);

                var newRecipe = new Models.OrderingSystem.ProductRecipe
                {
                    Id = id,
                    ProductId = _productId,
                    InventoryItemId = inventoryId,
                    InventorySubtraction = 1
                };

                _productRecipe.Add(newRecipe);

                UpdateProductRecipeControl(newRecipe, true);
            }
            else
            {
                var recipe = _productRecipe.FirstOrDefault(r => r.InventoryItemId == inventoryId);

                if (recipe == null) return;

                OrderingSystemDbManager.DeleteProductRecipe(recipe.Id);
                _productRecipe.Remove(recipe);

                UpdateProductRecipeControl(recipe, false);
            }
        }
        private void UpdateProductRecipeControl(Models.OrderingSystem.ProductRecipe recipe, bool isSelected)
        {
            if (isSelected)
            {
                bool exists = flowLayoutPanel2.Controls
                    .OfType<ProductRecipes>()
                    .Any(c => c._model.Id == recipe.Id);

                if (!exists)
                {
                    var productRecipeControl = new ProductRecipes(recipe);
                    flowLayoutPanel2.Controls.Add(productRecipeControl);
                }
            }
            else
            {
                var controlToRemove = flowLayoutPanel2.Controls
                    .OfType<ProductRecipes>()
                    .FirstOrDefault(c => c._model.Id == recipe.Id);

                if (controlToRemove != null)
                {
                    flowLayoutPanel2.Controls.Remove(controlToRemove);
                    controlToRemove.Dispose();
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }


        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Text = String.Empty;
        }
    }
}
