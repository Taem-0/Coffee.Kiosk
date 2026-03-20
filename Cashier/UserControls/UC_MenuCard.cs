using Coffee.Kiosk.Cashier.ModelClassHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class UC_MenuCard : UserControl
    {
        public MenuItemModel Item { get; private set; } = new();
        public event EventHandler<OrderItemModel>? ItemSelected;
        private bool _isProcessing = false;

        public UC_MenuCard() { InitializeComponent(); }

        public UC_MenuCard(MenuItemModel item) : this()
        {
            Item = item;
            lblItemName.Text = item.ItemName;
            lblCategory.Text = item.Category;
            label1.Text = $"₱{item.Price:N2}";

            guna2Panel1.Click += Card_Click;
            picItem.Click += Card_Click;
            lblItemName.Click += Card_Click;
            lblCategory.Click += Card_Click;
            label1.Click += Card_Click;
            this.Click += Card_Click;
        }

        private void Card_Click(object? sender, EventArgs e)
        {
            if (_isProcessing) return;
            _isProcessing = true;
            try
            {
                var customizer = new OrderCustomizer(Item, Point.Empty);
                if (customizer.ShowDialog(this.ParentForm) == DialogResult.OK
                    && customizer.Result != null)
                {
                    ItemSelected?.Invoke(this, customizer.Result);
                }
            }
            finally
            {
                _isProcessing = false;
            }
        }

        public void SetSelected(bool selected)
        {
            guna2Panel1.FillColor = selected ? Color.FromArgb(240, 225, 210) : Color.White;
            guna2Panel1.BorderColor = selected ? Color.FromArgb(107, 79, 58) : Color.FromArgb(212, 184, 150);
        }

        public void UpdatePrice(decimal price)
        {
            label1.Text = $"₱{price:N2}";
        }

        private void picItem_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void lblItemName_Click(object sender, EventArgs e) { }
        private void lblCategory_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}