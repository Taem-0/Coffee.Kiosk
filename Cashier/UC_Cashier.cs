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
    public partial class UC_Cashier : UserControl
    {
        private List<OrderItemModel> _cart = new();
        private string _activeCategory = "All";

        private readonly List<MenuItemModel> _menu = new()
        {
            new(){ItemID=1,  ItemName="Caffe Americano",        Category="Drinks", Price=119},
            new(){ItemID=2,  ItemName="Caffe Latte",            Category="Drinks", Price=129},
            new(){ItemID=3,  ItemName="Vanilla Cream",          Category="Drinks", Price=149},
            new(){ItemID=4,  ItemName="Cappuccino",             Category="Drinks", Price=129},
            new(){ItemID=5,  ItemName="Spanish Latte",          Category="Drinks", Price=149},
            new(){ItemID=6,  ItemName="Dark Coffee Mocha",      Category="Drinks", Price=149},
            new(){ItemID=7,  ItemName="Caramel Machiatto",      Category="Drinks", Price=149},
            new(){ItemID=8,  ItemName="White Choco Mocha",      Category="Drinks", Price=139},
            new(){ItemID=9,  ItemName="Dirty Matcha Latte",     Category="Drinks", Price=139},
            new(){ItemID=10, ItemName="Biscoff Caffe Latte",    Category="Drinks", Price=149},
            new(){ItemID=11, ItemName="Caramel",                Category="Drinks", Price=139},
            new(){ItemID=12, ItemName="Salted Caramel",         Category="Drinks", Price=139},
            new(){ItemID=13, ItemName="Dark Chocolate",         Category="Drinks", Price=139},
            new(){ItemID=14, ItemName="White Chocolate",        Category="Drinks", Price=139},
            new(){ItemID=15, ItemName="Matcha Latte",           Category="Drinks", Price=149},
            new(){ItemID=16, ItemName="Biscoff Latte",          Category="Drinks", Price=159},
            new(){ItemID=17, ItemName="Strawberry Matcha",      Category="Drinks", Price=159},
            new(){ItemID=18, ItemName="Ube Latte",              Category="Drinks", Price=159},
            new(){ItemID=19, ItemName="Coffee Frappe",          Category="Drinks", Price=139},
            new(){ItemID=20, ItemName="Coffee Caramel Frappe",  Category="Drinks", Price=139},
            new(){ItemID=21, ItemName="Matcha Frappe",          Category="Drinks", Price=139},
            new(){ItemID=22, ItemName="Nutella Frappe",         Category="Drinks", Price=139},
            new(){ItemID=23, ItemName="Milky Milo Frappe",      Category="Drinks", Price=179},
            new(){ItemID=24, ItemName="Lotus Biscoff Frappe",   Category="Drinks", Price=180},
            new(){ItemID=25, ItemName="Pearl Milk Tea",         Category="Drinks", Price=99},
            new(){ItemID=26, ItemName="Wintermelon",            Category="Drinks", Price=89},
            new(){ItemID=27, ItemName="Okinawa",                Category="Drinks", Price=99},
            new(){ItemID=28, ItemName="Taro",                   Category="Drinks", Price=99},
            new(){ItemID=29, ItemName="Matcha Milk Tea",        Category="Drinks", Price=99},
            new(){ItemID=30, ItemName="Dark Choco Milk Tea",    Category="Drinks", Price=99},
            new(){ItemID=31, ItemName="Cookies and Cream",      Category="Drinks", Price=99},
            new(){ItemID=32, ItemName="Strawberry Milk Tea",    Category="Drinks", Price=99},
            new(){ItemID=33, ItemName="Grapes Fruit Tea",       Category="Drinks", Price=89},
            new(){ItemID=34, ItemName="Mango Fruit Tea",        Category="Drinks", Price=89},
            new(){ItemID=35, ItemName="Lemon Fruit Tea",        Category="Drinks", Price=89},
            new(){ItemID=36, ItemName="Lychee Fruit Tea",       Category="Drinks", Price=89},
            new(){ItemID=37, ItemName="Passionfruit Tea",       Category="Drinks", Price=89},
            new(){ItemID=38, ItemName="Strawberry Fruit Tea",   Category="Drinks", Price=89},
            new(){ItemID=39, ItemName="Blueberry Fruit Tea",    Category="Drinks", Price=89},
            new(){ItemID=40, ItemName="Green Tea",              Category="Drinks", Price=69},
            new(){ItemID=41, ItemName="Black Tea",              Category="Drinks", Price=69},
            new(){ItemID=42, ItemName="Nutella Ferrero",        Category="Drinks", Price=179},
            new(){ItemID=43, ItemName="Nutella Kitkat",         Category="Drinks", Price=179},
            new(){ItemID=44, ItemName="Nutella Cadbury",        Category="Drinks", Price=179},
            new(){ItemID=45, ItemName="Strawberry Meiji",       Category="Drinks", Price=179},
            new(){ItemID=46, ItemName="Strawberry Chocolatier", Category="Drinks", Price=179},
            new(){ItemID=47, ItemName="Butterscotch Biscoff",   Category="Drinks", Price=189},
            new(){ItemID=48, ItemName="Classic Affogato",       Category="Drinks", Price=149},
            new(){ItemID=49, ItemName="Caramel Affogato",       Category="Drinks", Price=159},
            new(){ItemID=50, ItemName="Chocolate Affogato",     Category="Drinks", Price=159},
            new(){ItemID=51, ItemName="Strawberry Waffle",      Category="Pastry", Price=89},
            new(){ItemID=52, ItemName="Choco Oreo Waffle",      Category="Pastry", Price=89},
            new(){ItemID=53, ItemName="Caramel Biscoff Waffle", Category="Pastry", Price=99},
            new(){ItemID=54, ItemName="Special Cheese Sticks",  Category="Snacks", Price=49},
            new(){ItemID=55, ItemName="Regular Fries",          Category="Snacks", Price=69},
            new(){ItemID=56, ItemName="Special Potato Fries",   Category="Snacks", Price=99},
            new(){ItemID=57, ItemName="Corndog",                Category="Snacks", Price=69},
            new(){ItemID=58, ItemName="Hotdog Sandwich",        Category="Snacks", Price=98},
            new(){ItemID=59, ItemName="Chicken Fingers",        Category="Snacks", Price=59},
            new(){ItemID=60, ItemName="Bacon",                  Category="Foods",  Price=159},
            new(){ItemID=61, ItemName="Tocino",                 Category="Foods",  Price=129},
            new(){ItemID=62, ItemName="Jumbo Sausage",          Category="Foods",  Price=129},
            new(){ItemID=63, ItemName="Cheesy Sausage",         Category="Foods",  Price=139},
            new(){ItemID=64, ItemName="Corned Beef",            Category="Foods",  Price=139},
            new(){ItemID=65, ItemName="Lumpiang Shanghai",      Category="Foods",  Price=129},
            new(){ItemID=66, ItemName="Chicken Fingers BF",     Category="Foods",  Price=139},
            new(){ItemID=67, ItemName="Bangus",                 Category="Foods",  Price=139},
            new(){ItemID=68, ItemName="Porkchop",               Category="Foods",  Price=159},
            new(){ItemID=69, ItemName="Special Burger",         Category="Foods",  Price=129},
            new(){ItemID=70, ItemName="Bacon Burger",           Category="Foods",  Price=189},
            new(){ItemID=71, ItemName="Chicken Burger",         Category="Foods",  Price=109},
            new(){ItemID=72, ItemName="Aloha Burger",           Category="Foods",  Price=109},
            new(){ItemID=73, ItemName="Jalapeno Burger",        Category="Foods",  Price=149},
            new(){ItemID=74, ItemName="Overload Burger",        Category="Foods",  Price=199},
        };

        public UC_Cashier()
        {
            InitializeComponent();

            pnlOrderItems.Padding = new Padding(6, 6, 6, 6);
            flpMenuGrid.Padding = new Padding(6, 6, 6, 6);
            flpCategories.AutoScroll = false;
            flpCategories.WrapContents = false;

            lblOrderNum.Text = $"Order #{SessionManager.OrderNumber:D3}";
            LoadCategories();
            LoadMenuCards(_menu);
            UpdateTotals();
        }

        private void LoadCategories()
        {
            flpCategories.Controls.Clear();
            var cats = new List<string> { "All" };
            cats.AddRange(_menu.Select(i => i.Category).Distinct());

            foreach (var cat in cats)
            {
                var btn = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = cat,
                    Size = new Size(cat.Length > 6 ? 100 : 80, 32),
                    BorderRadius = 16,
                    FillColor = cat == "All"
                                     ? Color.FromArgb(107, 79, 58)
                                     : Color.Transparent,
                    ForeColor = cat == "All"
                                     ? Color.White
                                     : Color.FromArgb(107, 79, 58),
                    BorderColor = Color.FromArgb(107, 79, 58),
                    Font = new Font("Segoe UI", 8f),
                    Margin = new Padding(0, 0, 6, 0),
                    Tag = cat
                };
                btn.Click += CategoryBtn_Click;
                flpCategories.Controls.Add(btn);
            }
        }

        private void CategoryBtn_Click(object? sender, EventArgs e)
        {
            if (sender is not Guna.UI2.WinForms.Guna2Button btn) return;
            _activeCategory = btn.Tag?.ToString() ?? "All";

            foreach (Guna.UI2.WinForms.Guna2Button b in flpCategories.Controls)
            {
                bool active = b.Tag?.ToString() == _activeCategory;
                b.FillColor = active ? Color.FromArgb(107, 79, 58) : Color.Transparent;
                b.ForeColor = active ? Color.White : Color.FromArgb(107, 79, 58);
            }
            FilterMenu();
        }

        private void FilterMenu()
        {
            var q = txtSearch.Text.Trim().ToLower();
            var filtered = _menu.Where(i =>
                (_activeCategory == "All" || i.Category == _activeCategory) &&
                (string.IsNullOrEmpty(q) || i.ItemName.ToLower().Contains(q))
            ).ToList();
            LoadMenuCards(filtered);
        }

        private void LoadMenuCards(List<MenuItemModel> items)
        {
            flpMenuGrid.Controls.Clear();
            foreach (var item in items)
            {
                var card = new UC_MenuCard(item)
                {
                    Margin = new Padding(6, 6, 6, 6)
                };
                card.SetSelected(_cart.Any(c => c.Item.ItemID == item.ItemID));
                card.ItemSelected += Card_ItemSelected;
                flpMenuGrid.Controls.Add(card);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => FilterMenu();

        private void Card_ItemSelected(object? sender, OrderItemModel orderItem)
        {
            var existing = _cart.FirstOrDefault(c =>
                c.Item.ItemID == orderItem.Item.ItemID &&
                c.Customization.Summary() == orderItem.Customization.Summary());

            if (existing != null)
            {
                existing.Quantity += orderItem.Quantity;
                RefreshOrderRow(existing);
            }
            else
            {
                _cart.Add(orderItem);
                AddOrderRow(orderItem);
            }

            if (sender is UC_MenuCard card) card.SetSelected(true);
            UpdateTotals();
        }

        private void AddOrderRow(OrderItemModel orderItem)
        {
            var row = new UC_OrderRow(orderItem)
            {
                Width = pnlOrderItems.Width - 16,
                Margin = new Padding(0, 0, 0, 4)
            };
            row.QuantityIncreased += (s, e) => UpdateTotals();
            row.QuantityDecreased += (s, e) =>
            {
                if (orderItem.Quantity == 0)
                    RemoveFromCart(orderItem);
                else
                    UpdateTotals();
            };
            pnlOrderItems.Controls.Add(row);
        }

        private void RefreshOrderRow(OrderItemModel orderItem)
        {
            var row = pnlOrderItems.Controls
                .OfType<UC_OrderRow>()
                .FirstOrDefault(r =>
                    r.OrderItem.Item.ItemID == orderItem.Item.ItemID &&
                    r.OrderItem.Customization.Summary() == orderItem.Customization.Summary());
            row?.RefreshRow();
        }

        private void RemoveFromCart(OrderItemModel orderItem)
        {
            _cart.Remove(orderItem);

            var row = pnlOrderItems.Controls
                .OfType<UC_OrderRow>()
                .FirstOrDefault(r =>
                    r.OrderItem.Item.ItemID == orderItem.Item.ItemID &&
                    r.OrderItem.Customization.Summary() == orderItem.Customization.Summary());
            if (row != null) pnlOrderItems.Controls.Remove(row);

            var card = flpMenuGrid.Controls
                .OfType<UC_MenuCard>()
                .FirstOrDefault(c => c.Item.ItemID == orderItem.Item.ItemID);
            if (card != null && !_cart.Any(c => c.Item.ItemID == orderItem.Item.ItemID))
                card.SetSelected(false);

            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal total = _cart.Sum(c => c.Subtotal);
            lblSubtotal.Text = $"Subtotal:  ₱{total:N2}";
            lblTax.Text = $"Tax:          ₱0.00";
            label2.Text = $"Total:        ₱{total:N2}";
            btnPay.Enabled = _cart.Count > 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _cart.Clear();
            pnlOrderItems.Controls.Clear();
            LoadMenuCards(_menu);
            UpdateTotals();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            decimal total = _cart.Sum(c => c.Subtotal);
            var payment = new UC_Payment(_cart, total);
            ((HomePage)this.ParentForm!).LoadControl(payment);
        }

        private void flpCategories_Paint(object sender, PaintEventArgs e) { }
        private void flpMenuGrid_Paint(object sender, PaintEventArgs e) { }
        private void lblOrderNum_Click(object sender, EventArgs e) { }
        private void pnlOrderItems_Paint(object sender, PaintEventArgs e) { }
        private void lblSubtotal_Click(object sender, EventArgs e) { }
        private void lblTax_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void pnlOrderFooter_Paint(object sender, PaintEventArgs e) { }
    }
}