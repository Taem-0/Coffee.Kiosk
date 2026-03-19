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
            this.Height = 52;
            this.BackColor = Color.FromArgb(248, 244, 240);

            btnMinus.Text = "-";
            btnMinus.Font = new Font("Arial", 13f, FontStyle.Bold);
            btnMinus.FillColor = Color.FromArgb(240, 225, 210);
            btnMinus.ForeColor = Color.FromArgb(107, 79, 58);
            btnMinus.BorderColor = Color.FromArgb(107, 79, 58);
            btnMinus.BorderThickness = 1;

            btnPlus.Text = "+";
            btnPlus.Font = new Font("Arial", 13f, FontStyle.Bold);
            btnPlus.FillColor = Color.FromArgb(107, 79, 58);
            btnPlus.ForeColor = Color.White;
            btnPlus.BorderColor = Color.FromArgb(107, 79, 58);
            btnPlus.BorderThickness = 1;

            lblItemName.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblItemName.ForeColor = Color.FromArgb(44, 34, 24);
            lblItemName.AutoSize = false;

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
                Visible = false
            };
            this.Controls.Add(lblCustom);

            RefreshRow();
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

                lblCustom.Location = new Point(
                    lblItemName.Left,
                    lblItemName.Bottom + 2);
                lblCustom.Width = lblItemName.Width;
                lblCustom.Height = 14;
            }
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