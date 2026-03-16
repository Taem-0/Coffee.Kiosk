using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class UC_Payment : UserControl
    {
        private List<OrderItemModel> _cart = new();
        private decimal _total = 0;

        public UC_Payment()
        {
            InitializeComponent();
        }

        public UC_Payment(List<OrderItemModel> cart, decimal total) : this()
        {
            _cart = cart;
            _total = total;

            this.Enabled = true;
            pnlPayLeft.Enabled = true;
            pnlPayRight.Enabled = true;
            guna2TextBox1.Enabled = true;
            guna2Button2.Enabled = true;
            guna2Button3.Enabled = true;
            guna2Button4.Enabled = true;
            guna2Button5.Enabled = true;
            btnConfirm.Enabled = false;
            btnBack.Enabled = true;

            lblTotalAmt.Text = $"₱{_total:N2}";
            lblChangeAmt.Text = "₱0.00";

            LoadSummary();
        }

        private void LoadSummary()
        {
            pnlSummary.Controls.Clear();
            int y = 8;

            foreach (var item in _cart)
            {
                string summary = item.Customization.Summary();
                string display = string.IsNullOrEmpty(summary)
                    ? $"{item.Item.ItemName}  x{item.Quantity}"
                    : $"{item.Item.ItemName}  x{item.Quantity}\n  {summary}";
                int rowH = string.IsNullOrEmpty(summary) ? 24 : 40;

                var row = new Label
                {
                    Text = display,
                    ForeColor = Color.FromArgb(107, 79, 58),
                    Font = new Font("Poppins", 9f),
                    AutoSize = false,
                    Width = pnlSummary.Width - 110,
                    Height = rowH,
                    Location = new Point(10, y)
                };

                var rowPrice = new Label
                {
                    Text = $"₱{item.Subtotal:N2}",
                    ForeColor = Color.FromArgb(59, 35, 20),
                    Font = new Font("Poppins", 9f, FontStyle.Bold),
                    AutoSize = false,
                    Width = 90,
                    Height = rowH,
                    Location = new Point(pnlSummary.Width - 106, y),
                    TextAlign = ContentAlignment.MiddleRight
                };

                pnlSummary.Controls.Add(row);
                pnlSummary.Controls.Add(rowPrice);
                y += rowH + 4;
            }

            var divider = new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                Height = 2,
                Width = pnlSummary.Width - 20,
                Location = new Point(10, y + 4)
            };
            pnlSummary.Controls.Add(divider);
            y += 14;

            var lblTot = new Label
            {
                Text = $"Total:   ₱{_total:N2}",
                ForeColor = Color.FromArgb(59, 35, 20),
                Font = new Font("Poppins", 10f, FontStyle.Bold),
                AutoSize = false,
                Width = pnlSummary.Width - 20,
                Height = 26,
                Location = new Point(10, y)
            };
            pnlSummary.Controls.Add(lblTot);
        }

        private void CalcChange()
        {
            if (decimal.TryParse(guna2TextBox1.Text, out decimal cash))
            {
                decimal change = cash - _total;
                lblChangeAmt.Text = $"₱{Math.Abs(change):N2}";
                lblChangeAmt.ForeColor = change >= 0
                    ? Color.FromArgb(46, 125, 82)
                    : Color.FromArgb(192, 96, 122);
                btnConfirm.Enabled = change >= 0;
            }
            else
            {
                lblChangeAmt.Text = "₱0.00";
                lblChangeAmt.ForeColor = Color.FromArgb(107, 79, 58);
                btnConfirm.Enabled = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        { guna2TextBox1.Text = "100"; CalcChange(); }

        private void guna2Button3_Click(object sender, EventArgs e)
        { guna2TextBox1.Text = "500"; CalcChange(); }

        private void guna2Button4_Click(object sender, EventArgs e)
        { guna2TextBox1.Text = "1000"; CalcChange(); }

        private void guna2Button5_Click(object sender, EventArgs e)
        { guna2TextBox1.Text = _total.ToString("N2"); CalcChange(); }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
            => CalcChange();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(guna2TextBox1.Text, out decimal cash)) return;
            decimal change = cash - _total;
            SessionManager.OrderNumber++;
            var receipt = new UC_Receipt(_cart, _total, cash, change);
            ((HomePage)this.ParentForm!).LoadControl(receipt);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ((HomePage)this.ParentForm!).LoadControl(new UC_Cashier());
        }

        private void lblChangeAmt_Click(object sender, EventArgs e) { }
        private void lblSummary_Click(object sender, EventArgs e) { }
        private void pnlSummary_Paint(object sender, PaintEventArgs e) { }
        private void pnlPayLeft_Paint(object sender, PaintEventArgs e) { }
        private void lblQuick_Click(object sender, EventArgs e) { }
        private void lblCashTend_Click(object sender, EventArgs e) { }
        private void pnlPayRight_Paint(object sender, PaintEventArgs e) { }
        private void lblTotalAmt_Click(object sender, EventArgs e) { }
    }
}