using Coffee.Kiosk.Cashier.CashierDBHelper;
using Coffee.Kiosk.Cashier.ModelClassHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class UC_Cashier : UserControl
    {
        private List<OrderItemModel> _cart = new();
        private List<MenuItemModel> _menu = new();
        private string _activeCategory = "All";

        public UC_Cashier()
        {
            InitializeComponent();

            pnlOrderItems.AutoScroll = true;
            pnlOrderItems.Padding = new Padding(4, 4, 4, 4);
            flpMenuGrid.Padding = new Padding(6, 6, 6, 6);
            flpCategories.AutoScroll = false;
            flpCategories.WrapContents = false;

            lblOrderNum.Text = $"Order #{SessionManager.OrderNumber:D3}";

            LoadMenuFromDatabase();
            UpdateTotals();
        }

        // ── Pull products from CoffeeKioskDB ─────────────────────────────────
        private void LoadMenuFromDatabase()
        {
            try
            {
                _menu = KioskOrderDbManager.GetMenuItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not load menu from database:\n{ex.Message}\n\n" +
                    "Make sure MySQL is running and the CMS has been launched at least once.",
                    "Menu Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _menu = new List<MenuItemModel>();
            }

            LoadCategories();
            LoadMenuCards(_menu);
        }

        // ── Category filter buttons ───────────────────────────────────────────
        private void LoadCategories()
        {
            flpCategories.Controls.Clear();

            var cats = new List<string> { "All" };
            cats.AddRange(_menu.Select(i => i.Category).Distinct().OrderBy(c => c));

            foreach (var cat in cats)
            {
                var btn = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = cat,
                    Size = new Size(cat.Length > 6 ? 100 : 80, 32),
                    BorderRadius = 16,
                    FillColor = cat == "All" ? Color.FromArgb(107, 79, 58) : Color.Transparent,
                    ForeColor = cat == "All" ? Color.White : Color.FromArgb(107, 79, 58),
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

            if (items.Count == 0)
            {
                flpMenuGrid.Controls.Add(new Label
                {
                    Text = "No products found.",
                    Font = new Font("Segoe UI", 10f, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(12)
                });
                return;
            }

            foreach (var item in items)
            {
                var card = new UC_MenuCard(item) { Margin = new Padding(6, 6, 6, 6) };
                card.SetSelected(_cart.Any(c => c.Item.ItemID == item.ItemID));
                card.ItemSelected += Card_ItemSelected;
                flpMenuGrid.Controls.Add(card);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => FilterMenu();

        // ── Cart management ───────────────────────────────────────────────────
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
            var row = new UC_OrderRow(orderItem);
            row.Margin = new Padding(0, 0, 0, 2);

            row.QuantityIncreased += (s, e) => UpdateTotals();
            row.QuantityDecreased += (s, e) =>
            {
                if (orderItem.Quantity == 0) RemoveFromCart(orderItem);
                else UpdateTotals();
            };

            pnlOrderItems.Controls.Add(row);
            pnlOrderItems.PerformLayout();
            pnlOrderItems.Invalidate();
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