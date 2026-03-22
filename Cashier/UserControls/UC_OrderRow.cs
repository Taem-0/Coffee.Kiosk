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

            var theme = SessionManager.Theme;

            this.Dock = DockStyle.Top;
            this.Height = 56;
            this.BackColor = theme.PrimaryColor;
            this.Padding = new Padding(8, 4, 8, 4);

            lblItemName.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblItemName.ForeColor = Color.White;
            lblItemName.AutoSize = false;
            lblItemName.TextAlign = ContentAlignment.MiddleLeft;

            lblQty.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblQty.ForeColor = Color.White;
            lblQty.TextAlign = ContentAlignment.MiddleCenter;

            lblSubtotal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblSubtotal.ForeColor = theme.AccentColor;
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;

            var lblCustom = new Label
            {
                Name = "lblCustomSummary",
                AutoSize = false,
                Font = new Font("Segoe UI", 7f),
                ForeColor = theme.AccentColor,
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