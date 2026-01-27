using Coffee.Kiosk.OrderingSystem.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    public partial class CategoryPage : UserControl
    {

        internal event Action<int>? ProductClicked;
        internal int CategoryId { get; set; }

        public CategoryPage(int categoryId)
        {
            InitializeComponent();
            CategoryId = categoryId;
            var category = Models.Category.categoryData.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                label1.Text = category.Name;
            }

            LoadProduct();
        }

        internal void LoadProduct()
        {
            flowProducts.Controls.Clear();

            var products = Models.Product.productData.Where(p => p.CategoryId == CategoryId);

            foreach (var product in products)
            {
                var productItem = new ProductItem(
                    product.Id,
                    product.CategoryId,
                    product.Name,
                    product.ImagePath,
                    product.Price
                    );
                productItem.productClicked += OnProductClicked;

                flowProducts.Controls.Add(productItem);
            }
        }

        internal void OnProductClicked(int productId)
        {
            ProductClicked?.Invoke(productId);
        } 
    }
}
