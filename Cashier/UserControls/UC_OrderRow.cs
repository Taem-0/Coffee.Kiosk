using Coffee.Kiosk.Cashier.ModelClassHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class UC_OrderRow : UserControl
    {
        public OrderItemModel OrderItem { get; private set; } = new();
        public event EventHandler? QuantityIncreased;
        public event EventHandler? QuantityDecreased;

        public UC_OrderRow() { InitializeComponent(); }

        public UC_OrderRow(OrderItemModel orderItem) : this()
        {
            OrderItem = orderItem;

            this.Dock = DockStyle.Top;
            this.Height = 56;
            this.BackColor = Color.FromArgb(248, 244, 240);
            this.Padding = new Padding(8, 4, 8, 4);

            btnMinus.Text = "−";
            btnMinus.Font = new Font("Arial", 12f, FontStyle.Bold);
            btnMinus.FillColor = Color.FromArgb(240, 225, 210);
            btnMinus.ForeColor = Color.FromArgb(107, 79, 58);
            btnMinus.BorderColor = Color.FromArgb(107, 79, 58);
            btnMinus.BorderThickness = 1;
            btnMinus.BorderRadius = 6;

            btnPlus.Text = "+";
            btnPlus.Font = new Font("Arial", 12f, FontStyle.Bold);
            btnPlus.FillColor = Color.FromArgb(107, 79, 58);
            btnPlus.ForeColor = Color.White;
            btnPlus.BorderColor = Color.FromArgb(107, 79, 58);
            btnPlus.BorderThickness = 1;
            btnPlus.BorderRadius = 6;

            lblItemName.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblItemName.ForeColor = Color.FromArgb(44, 34, 24);
            lblItemName.AutoSize = false;
            lblItemName.TextAlign = ContentAlignment.MiddleLeft;

            lblQty.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblQty.ForeColor = Color.FromArgb(59, 35, 20);
            lblQty.TextAlign = ContentAlignment.MiddleCenter;

            lblSubtotal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblSubtotal.ForeColor = Color.FromArgb(59, 35, 20);
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;

            var lblCustom = new Label
            {
                Name = "lblCustomSummary",
                AutoSize = false,
                Font = new Font("Segoe UI", 7f),
                ForeColor = Color.FromArgb(150, 120, 90),
                BackColor = Color.Transparent,
                Visible = false,
                TextAlign = ContentAlignment.TopLeft
            };
            this.Controls.Add(lblCustom);

            this.Resize += (s, e) => LayoutControls();
            this.Load += (s, e) => LayoutControls();

            RefreshRow();
        }

        private void LayoutControls()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int priceW = 74;
            int btnW = 28;
            int btnH = 28;
            int qtyW = 28;
            int rightGap = 6;

            int priceX = w - priceW - 4;
            int plusX = priceX - rightGap - btnW;
            int qtyX = plusX - qtyW;
            int minusX = qtyX - btnW;

            int btnY = (h - btnH) / 2;
            int priceY = (h - btnH) / 2;

            btnMinus.SetBounds(minusX, btnY, btnW, btnH);
            lblQty.SetBounds(qtyX, btnY, qtyW, btnH);
            btnPlus.SetBounds(plusX, btnY, btnW, btnH);
            lblSubtotal.SetBounds(priceX, priceY, priceW, btnH);

            int nameW = minusX - 10;

            var lblCustom = this.Controls["lblCustomSummary"] as Label;
            bool hasCustom = lblCustom != null && lblCustom.Visible;

            if (hasCustom)
            {
                lblItemName.SetBounds(8, 6, nameW, 22);
                lblCustom!.SetBounds(8, 28, nameW, 16);
            }
            else
            {
                lblItemName.SetBounds(8, (h - 22) / 2, nameW, 22);
            }
        }

        public void RefreshRow()
        {
            lblItemName.Text = OrderItem.Item.ItemName;
            lblQty.Text = OrderItem.Quantity.ToString();
            lblSubtotal.Text = $"₱{OrderItem.Subtotal:N2}";

            var lblCustom = this.Controls["lblCustomSummary"] as Label;
            if (lblCustom != null)
            {
                string summary = OrderItem.Customization.Summary();
                lblCustom.Text = summary;
                lblCustom.Visible = !string.IsNullOrEmpty(summary);

                this.Height = string.IsNullOrEmpty(summary) ? 56 : 68;
            }

            LayoutControls();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            OrderItem.Quantity++;
            RefreshRow();
            QuantityIncreased?.Invoke(this, EventArgs.Empty);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (OrderItem.Quantity > 1)
            {
                OrderItem.Quantity--;
                RefreshRow();
                QuantityDecreased?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OrderItem.Quantity = 0;
                QuantityDecreased?.Invoke(this, EventArgs.Empty);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void lblItemName_Click(object sender, EventArgs e) { }
        private void UC_OrderRow_Load(object sender, EventArgs e) { }
        private void lblQty_Click(object sender, EventArgs e) { }
        private void lblSubtotal_Click(object sender, EventArgs e) { }
    }
}