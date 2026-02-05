using Coffee.Kiosk.OrderingSystem.Helper;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    public partial class ModalCustomizeScreen : UserControl
    {
        public event Action? backBtnClicked;
        public event Action<Models.Orders.OrderItem>? AddToCartClicked;

        int Amount = 1;
        int ProductId;
        string _ProductName = String.Empty;
        decimal TotalAmountPrice = 0;
        public ModalCustomizeScreen(int productId, string name, string ImagePath)
        {
            InitializeComponent();
            ProductId = productId;
            _ProductName = name;

            pictureBox1.Image = UI_Images.loadImageFromFile(ImagePath);
            ProductNameLbl.Text = name;
            AmountLbl.Text = Amount.ToString();

            TotalAmountLbl.Text = $"{TotalAmountPrice.ToString()}";

        }

        private void LoadModifierGroups(int productId)
        {
            flowLayoutPanel1.Controls.Clear();

            var allGroups = Models.Product.modifierGroups.Where(g => g.ProductId == ProductId).ToList();

            var rootGroups = allGroups.Where(g => g.ParentGroupId == null).OrderBy(g => g.Id);

            foreach (var group in rootGroups)
            {
                var groupControl = new ModalModifierGroup(group, allGroups);
                groupControl.SelectionChanged += UpdateAddToCartState;
                flowLayoutPanel1.Controls.Add(groupControl);
            }
        }


        private void ModalCustomizeScreen_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(topPanel, guna2ShadowPanel1);
            LoadModifierGroups(ProductId);
            UpdateAddToCartState();
        }

        private void ModalCustomizeScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(topPanel, guna2ShadowPanel1);
        }

        private void AddAmountBtn_Click(object sender, EventArgs e)
        {
            Amount++;
            AmountLbl.Text = Amount.ToString();
            UpdateAddToCartState();
        }

        private void SubtractAmountButton_Click(object sender, EventArgs e)
        {
            if (Amount > 1)
            {
                Amount--;
                AmountLbl.Text = Amount.ToString();
                UpdateAddToCartState();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Amount++;
            AmountLbl.Text = Amount.ToString();

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            backBtnClicked?.Invoke();
        }

        private bool AreAllRequiredGroupsValid()
        {
            return flowLayoutPanel1.Controls
                .OfType<ModalModifierGroup>()
                .All(g => g.IsValid());
        }

        private void UpdateAddToCartState()
        {
            bool valid = AreAllRequiredGroupsValid();
            AddToCartBtn.FillColor = valid ? Color.Green : Color.Gray;
            invalidLabel.Visible = false;

            var product = Models.Product.productData
                .FirstOrDefault(p => p.Id == ProductId);

            if (product == null) return;

            decimal modifiersTotal = CalculateModifiersTotal();

            TotalAmountPrice =
                (product.Price + modifiersTotal) * Amount;

            TotalAmountLbl.Text = TotalAmountPrice.ToString("₱0.00");
        }

        private decimal CalculateModifiersTotal()
        {
            return flowLayoutPanel1.Controls
                .OfType<ModalModifierGroup>()
                .Sum(g => g.GetTotalPriceDelta());
        }

        private async void InvalidLabelAutoHide()
        {
            invalidLabel.Visible = true;
            await Task.Delay(5000);
            invalidLabel.Visible = false;
        }

        private void AddToCartBtn_Click(object sender, EventArgs e)
        {
            if (!AreAllRequiredGroupsValid())
            {
                InvalidLabelAutoHide();
                return;
            }
            invalidLabel.Visible = false;

            var product = Models.Product.productData.FirstOrDefault(p => p.Id == ProductId);
            if (product == null) { return; }

            var item = new Models.Orders.OrderItem
            {
                ProductId = ProductId,
                ProductName = product.Name,
                ProductPrice = product.Price + CalculateModifiersTotal(),
                Quantity = Amount,
                ImagePath = product.ImagePath
            };

            foreach (var group in flowLayoutPanel1.Controls.OfType<ModalModifierGroup>())
            {
                group.CollectSelections(item.SelectedModifierOptions, item.SelectedModifiersName);
            }

            AddToCartClicked?.Invoke(item);
        }
    }
}
