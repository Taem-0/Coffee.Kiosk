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

        public UC_OrderRow()
        {
            InitializeComponent();
        }

        public UC_OrderRow(OrderItemModel orderItem) : this()
        {
            OrderItem = orderItem;

            btnMinus.Text = "-";
            btnPlus.Text = "+";
            btnMinus.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
            btnPlus.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);

            this.Height = 52;
            lblItemName.Location = new Point(6, 4);
            lblItemName.Size = new Size(140, 18);
            btnMinus.Location = new Point(152, 14);
            btnMinus.Size = new Size(22, 22);
            lblQty.Location = new Point(178, 16);
            lblQty.Size = new Size(22, 18);
            lblQty.TextAlign = ContentAlignment.MiddleCenter;
            btnPlus.Location = new Point(204, 14);
            btnPlus.Size = new Size(22, 22);
            lblSubtotal.Location = new Point(230, 14);
            lblSubtotal.Size = new Size(60, 22);
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;

            var lblCustom = new Label
            {
                Name = "lblCustomSummary",
                AutoSize = false,
                Width = 285,
                Height = 16,
                Location = new Point(6, 24),
                Font = new Font("Poppins", 7f),
                ForeColor = Color.FromArgb(150, 120, 90),
                BackColor = Color.Transparent
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