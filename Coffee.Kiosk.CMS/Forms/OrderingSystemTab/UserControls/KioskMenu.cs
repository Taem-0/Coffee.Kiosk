using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog;
using Coffee.Kiosk.CMS.Helpers;
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
    public partial class KioskMenu : UserControl
    {
        private OrderingSystemMainControl _parent;

        List<Models.OrderingSystem.CategoryData> categoryData = new();
        List<Models.OrderingSystem.ProductData> productData = new();

        private AddCategoryButton addCategoryButton = new AddCategoryButton();
        private AddProductButton addProductButton = new AddProductButton();

        private int? selectedCategoryId = null;

        public KioskMenu(OrderingSystemMainControl parent)
        {
            _parent = parent;
            InitializeComponent();

            categoryData = OrderingSystemDbManager.GetAllCategories();
            LoadCategories();

            if (categoryData.Count > 0)
            {
                var firstCategory = categoryData.First();
                selectedCategoryId = firstCategory.Id;
                LoadProducts(firstCategory.Id);
            }
            else
            {
                ShowNoProductsState();
            }

            _parent = parent;
        }


        private void LoadCategories()
        {
            flowCategory.Controls.Clear();
            addCategoryButton.addMoreClicked += AddMoreCategory;

            foreach (var category in categoryData)
            {
                var categoryItem = new CategoryItem(
                    category.Id,
                    category.Name,
                    category.IconPath,
                    category.IsDraft
                    );
                categoryItem.OnClicked += LoadProducts;
                categoryItem.doubleClicked += OnCategoryDoubleClicked;
                categoryItem.NameEditRequest += OnEditCategoryName;
                categoryItem.DeleteRequest += OnDeleteCategory;
                categoryItem.IsDraftEditRequest += OnIsDraftClicked;
                categoryItem.IconEditRequest += OnChangeCategoryImage;

                flowCategory.Controls.Add(categoryItem);
            }
            flowCategory.Controls.Add(addCategoryButton);
        }

        private void AddMoreCategory()
        {
            var scroll = flowCategory.VerticalScroll.Value;
            _parent.ShowDarkOverlay(true);
            using var dialog = new EditName("New Category");
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                _parent.ShowDarkOverlay(false);
                return;
            }

            var newName = dialog.NewCategoryName.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                _parent.ShowDarkOverlay(false);
                return;
            }

            int newId = OrderingSystemDbManager.AddCategory(newName, "../../../Resources/default_icon.png");
            if (newId == 0)
            {
                _parent.ShowDarkOverlay(false);
                return;
            }

            categoryData.Add(new Models.OrderingSystem.CategoryData(
                newId,
                newName,
                "../../../Resources/default_icon.png",
                true
            ));

            var categoryItem = new CategoryItem(newId, newName, "C:/Images/default_icon.png", false);
            categoryItem.OnClicked += LoadProducts;
            categoryItem.doubleClicked += OnCategoryDoubleClicked;
            categoryItem.NameEditRequest += OnEditCategoryName;
            categoryItem.DeleteRequest += OnDeleteCategory;
            categoryItem.IsDraftEditRequest += OnIsDraftClicked;
            categoryItem.IconEditRequest += OnChangeCategoryImage;
            //var addButton = flowCategory.Controls.OfType<AddCategoryButton>().FirstOrDefault();
            //if (addButton != null) flowCategory.Controls.Remove(addButton);
            flowCategory.Controls.Remove(addCategoryButton);
            flowCategory.Controls.Add(categoryItem);
            flowCategory.Controls.Add(addCategoryButton);

            flowCategory.ScrollControlIntoView(addCategoryButton);

            if (selectedCategoryId == null)
            {
                var firstCategory = categoryData.Last();
                selectedCategoryId = firstCategory.Id;
                LoadProducts(firstCategory.Id);
            }
            _parent.ShowDarkOverlay(false);
        }

        private void OnIsDraftClicked(int categoryId, bool isDraft)
        {
            OrderingSystemDbManager.IsDraftCategory(categoryId, isDraft);
        }

        private void OnDeleteCategory(int categoryId)
        {
            _parent.ShowDarkOverlay(true);
            using var dialog = new ConfirmDelete("Are you sure you want to delete this category?");
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                _parent.ShowDarkOverlay(false);
                return;
            }

            OrderingSystemDbManager.DeleteCategory(categoryId);

            var category = categoryData.FirstOrDefault(c => c.Id == categoryId);
            if (category != null) categoryData.Remove(category);

            var item = flowCategory.Controls.OfType<CategoryItem>().FirstOrDefault(c => c.CategoryId == categoryId);
            if (item != null) flowCategory.Controls.Remove(item);


            if (categoryData.Count <= 0 || selectedCategoryId == categoryId)
            {
                ShowNoProductsState();
            }
            _parent.ShowDarkOverlay(false);

            //ReloadCategories();
        }

        private void OnCategoryDoubleClicked(int categoryId)
        {

        }

        private void OnEditCategoryName(int categoryId)
        {
            var category = categoryData.FirstOrDefault(c => c.Id == categoryId);
            if (category == null) return;

            _parent.ShowDarkOverlay(true);
            using var dialog = new EditName(category.Name);

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                _parent.ShowDarkOverlay(false);
                return;
            }

            var newName = dialog.NewCategoryName.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                _parent.ShowDarkOverlay(false);
                return;
            }

            OrderingSystemDbManager.UpdateCategoryName(categoryId, newName);
            category.Name = newName;

            foreach (CategoryItem item in flowCategory.Controls.OfType<CategoryItem>())
            {
                if (item.CategoryId == categoryId)
                {
                    item.UpdateCategoryName(newName);
                    break;
                }
            }
            _parent.ShowDarkOverlay(false);
            //ReloadCategories();
        }

        private void OnChangeCategoryImage(int categoryId, string newIconPath)
        {
            OrderingSystemDbManager.UpdateCategoryIcon(categoryId, newIconPath);

            var category = categoryData.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                category.IconPath = newIconPath;
            }

            //var item = flowCategory.Controls.OfType<CategoryItem>()
            //             .FirstOrDefault(c => c.CategoryId == categoryId);
            //if (item != null)
            //{
            //    item.UpdateIcon(newIconPath);
            //}
        }

        private void ReloadCategories()
        {
            var scroll = flowCategory.VerticalScroll.Value;

            categoryData = OrderingSystemDbManager.GetAllCategories();
            LoadCategories();

            flowCategory.VerticalScroll.Value = Math.Min(
                scroll,
                flowCategory.VerticalScroll.Maximum
            );
        }


        private void LoadProducts(int categoryId)
        {
            flowProduct.Controls.Clear();
            selectedCategoryId = categoryId;
            //label2.Text = $"Products : {";

            productData = OrderingSystemDbManager.GetAllProductsCategory(categoryId);

            foreach (CategoryItem item in flowCategory.Controls.OfType<CategoryItem>())
            {
                item.SetSelected(item.CategoryId == categoryId);
            }

            foreach (var product in productData)
            {
                var productItem = new ProductItem(
                    product.Id,
                    product.CategoryId,
                    product.Name,
                    product.ImagePath,
                    product.Price
                );

                productItem.EditClicked += EditProduct;
                productItem.DeleteClicked += DeleteProduct;

                flowProduct.Controls.Add(productItem);
            }

            addProductButton.ProductAddMoreClicked -= AddMoreProduct;
            addProductButton.ProductAddMoreClicked += AddMoreProduct;

            flowProduct.Controls.Add(addProductButton);
        }

        private void AddMoreProduct()
        {
            if (selectedCategoryId == null) return;

            _parent.ShowDarkOverlay(true);
            using var form = new AddProduct(selectedCategoryId.Value);

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                int productNewId = OrderingSystemDbManager.AddProduct(
                    selectedCategoryId.Value,
                    form.ProductName1,
                    form.Price,
                    form.ImagePath
                    );

                LoadProducts(selectedCategoryId.Value);
            }
            _parent.ShowDarkOverlay(false);
        }

        private void DeleteProduct(int productId)
        {
            if (selectedCategoryId == null) return;

            _parent.ShowDarkOverlay(true);
            using var dialog = new ConfirmDelete("Are you sure you want to delete this product?");
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                _parent.ShowDarkOverlay(false);
                return;
            }

            OrderingSystemDbManager.DeleteProduct(productId);
            LoadProducts(selectedCategoryId.Value);
            _parent.ShowDarkOverlay(false);
        }

        private void EditProduct(int productId, string name, decimal price, string imagePath)
        {
            if (selectedCategoryId == null) return;

            _parent.ShowDarkOverlay(true);

            using var form = new EditProduct(productId, name, price, imagePath);

            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                //TODO
                LoadProducts(selectedCategoryId.Value);
            }
            _parent.ShowDarkOverlay(false);
        }

        private void ShowNoProductsState()
        {
            selectedCategoryId = null;

            foreach (CategoryItem item in flowCategory.Controls.OfType<CategoryItem>())
            {
                item.SetSelected(false);
            }

            flowProduct.Controls.Clear();

            flowProduct.Controls.Add(new Label()
            {
                Text = "No categories selected yet",
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Roboto", 17)
            });
        }




        private void flowCategory_Paint(object sender, PaintEventArgs e)
        {
            UIhelp.drawBorderSides(e, flowCategory.ClientRectangle, UIhelp.borderSide.Right | UIhelp.borderSide.Top, Color.Black);
        }

        private void KioskMenu_Load(object sender, EventArgs e)
        {

        }

        private void KioskMenu_Resize(object sender, EventArgs e)
        {
            UIhelp.centerPanel(panel3, panel4);
        }
    }
}
