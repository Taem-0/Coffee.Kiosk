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
    public partial class HomePage : UserControl
    {

        internal event Action<int>? ProductClicked;

        public HomePage()
        {
            InitializeComponent();
            UI_Handling.AddBottomSpacer(flowLayoutPanel1, 1000);
            LoadProduct();
        }

        private void LoadProduct()
        {
            flowLayoutPanel1.Controls.Clear();


            foreach (var product in Models.Product.productData)
            {
                var productItem = new ProductItem(
                    product.Id,
                    product.CategoryId,
                    product.Name,
                    product.ImagePath,
                    product.Price
                    );
                productItem.productClicked += OnProductClicked;
                flowLayoutPanel1.Controls.Add(productItem);

            }
        }

        internal void OnProductClicked(int productId)
        {
            ProductClicked?.Invoke(productId);
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

            //if (flowLayoutPanel1.Controls.Count % 3 == 0)
            //    flowLayoutPanel1.SetFlowBreak(e!.Control!, true);
        }
    }
}
