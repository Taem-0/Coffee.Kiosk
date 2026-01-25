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
        List<Models.OrderingSystem.CategoryData> categoryData = new();

        private AddCategoryButton addCategoryButton = new AddCategoryButton();

        public KioskMenu()
        {
            InitializeComponent();

            categoryData = OrderingSystemDbManager.GetAllCategories();
            LoadCategories();
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
            using var dialog = new EditName("New Category");
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var newName = dialog.NewCategoryName.Trim();
            if (string.IsNullOrEmpty(newName)) return;

            int newId = OrderingSystemDbManager.AddCategory(newName, "../../../Resources/default_icon.png");
            if (newId == 0) return;

            categoryData.Add(new Models.OrderingSystem.CategoryData(
                newId,
                newName,
                "../../../Resources/default_icon.png",
                true
            ));

            var categoryItem = new CategoryItem(newId, newName, "C:/Images/default_icon.png", false);
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
        }

        private void OnIsDraftClicked(int categoryId, bool isDraft)
        {
            OrderingSystemDbManager.IsDraftCategory(categoryId, isDraft);
        }

        private void OnDeleteCategory(int categoryId)
        {
            using var dialog = new ConfirmDelete();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            OrderingSystemDbManager.DeleteCategory(categoryId);

            var category = categoryData.FirstOrDefault(c => c.Id == categoryId);
            if (category != null) categoryData.Remove(category);

            var item = flowCategory.Controls.OfType<CategoryItem>().FirstOrDefault(c => c.CategoryId == categoryId);
            if (item != null) flowCategory.Controls.Remove(item);

            //ReloadCategories();
        }

        private void OnCategoryDoubleClicked(int categoryId)
        {

        }

        private void OnEditCategoryName(int categoryId)
        {
            var category = categoryData.FirstOrDefault(c => c.Id == categoryId);
            if (category == null) return;

            using var dialog = new EditName(category.Name);

            if (dialog.ShowDialog() != DialogResult.OK) return;

            var newName = dialog.NewCategoryName.Trim();
            if (string.IsNullOrEmpty(newName)) return;

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
            //ReloadCategories();
        }

        private void OnChangeCategoryImage(int categoryId, string newIconPath)
        {
            // Update the database
            OrderingSystemDbManager.UpdateCategoryIcon(categoryId, newIconPath);

            // Update the categoryData in memory
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

        private void flowCategory_Paint(object sender, PaintEventArgs e)
        {
            UIhelp.drawBorderSides(e, flowCategory.ClientRectangle, UIhelp.borderSide.Right | UIhelp.borderSide.Top, Color.Black);
        }
    }
}
