using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class UC_MenuCard : UserControl
    {
        public MenuItemModel Item { get; private set; } = new();
        public event EventHandler<OrderItemModel>? ItemSelected;

        public UC_MenuCard()
        {
            InitializeComponent();
        }

        public UC_MenuCard(MenuItemModel item) : this()
        {
            Item = item;
            lblItemName.Text = item.ItemName;
            lblCategory.Text = item.Category;
            label1.Text = $"₱{item.Price:N2}";

            // ✅ FIX: Wire click ONLY once on the top-level control.
            // Removed the foreach loop over child controls and the
            // separate guna2Panel1.Click — those caused the event to
            // fire 3–4 times per click, creating duplicate orders.
            this.Click += Card_Click;
        }

        private void Card_Click(object? sender, EventArgs e)
        {
            var screen = Screen.FromControl(this).WorkingArea;
            var screenPos = this.PointToScreen(new Point(this.Width + 4, 0));

            if (screenPos.X + 500 > screen.Right)
                screenPos.X = screen.Right - 504;
            if (screenPos.Y + 640 > screen.Bottom)
                screenPos.Y = screen.Bottom - 644;

            var customizer = new OrderCustomizer(Item, screenPos);
            if (customizer.ShowDialog() == DialogResult.OK
                && customizer.Result != null)
            {
                ItemSelected?.Invoke(this, customizer.Result);
            }
        }

        public void SetSelected(bool selected)
        {
            guna2Panel1.FillColor = selected
                ? Color.FromArgb(240, 225, 210)
                : Color.White;
            guna2Panel1.BorderColor = selected
                ? Color.FromArgb(107, 79, 58)
                : Color.FromArgb(212, 184, 150);
        }

        private void picItem_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void lblItemName_Click(object sender, EventArgs e) { }
        private void lblCategory_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}