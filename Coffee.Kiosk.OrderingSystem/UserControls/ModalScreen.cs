using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.UserControls.Reusables;
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
    public partial class ModalScreen : UserControl
    {
        internal event Action? BackButtonClicked;

        internal int productId;

        Models.Product.ProductData? productData;

        ModalCustomizeScreen? modalCustomizeScreen;

        public ModalScreen(int productId)
        {
            InitializeComponent();
            label1.Text = "Product ID:" + productId.ToString();

            productData = Sql.Queries.GetProductData(productId);

            if (productData != null)
            {
                if (productData.IsCustomizable)
                {
                    ShowCustomizeScreen(productId, productData.Name, productData.ImagePath);
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke();
        }

        private void ShowCustomizeScreen(int productId, string name, string imagePath)
        {
            if (modalCustomizeScreen == null)
            {
                modalCustomizeScreen = new ModalCustomizeScreen(productId, name, imagePath);
            }
            UI_Handling.loadUserControl(mainModalScreen, modalCustomizeScreen);
        }

    }
}
