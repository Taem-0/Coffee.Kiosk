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
        public event Action? BackButtonClicked;
        public event Action<Models.Orders.OrderItem>? AddToCartClicked;

        internal int productId;

        Models.Product.ProductData? productData;

        ModalCustomizeScreen? modalCustomizeScreen;

        public ModalScreen(int productId)
        {
            InitializeComponent();

            productData = Models.Product.productData.FirstOrDefault(p => p.Id == productId);

            if (productData != null)
            {
                if (productData.IsCustomizable)
                {
                    ShowCustomizeScreen(productId, productData.Name, productData.ImagePath);
                }
            }
        }

        public void ReloadModalScreen(int productId)
        {
            productData = Models.Product.productData.FirstOrDefault(p => p.Id == productId);

            if (productData != null)
            {
                if (productData.IsCustomizable)
                {
                    ShowCustomizeScreen(productId, productData.Name, productData.ImagePath);
                }
            }
        }

        private void BackBtnClicked()
        {
            BackButtonClicked?.Invoke();
        }

        private void ShowCustomizeScreen(int productId, string name, string imagePath)
        {
            if (modalCustomizeScreen == null)
            {
                modalCustomizeScreen = new ModalCustomizeScreen(productId, name, imagePath);
                modalCustomizeScreen.backBtnClicked += BackBtnClicked;
                modalCustomizeScreen.AddToCartClicked += item =>
                {
                    AddToCartClicked?.Invoke(item);
                };

            }else
            {
                modalCustomizeScreen.ReloadModalCustomize(productId, name, imagePath);
            }
                UI_Handling.loadUserControl(mainModalScreen, modalCustomizeScreen);
        }
    }
}
