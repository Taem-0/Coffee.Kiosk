using Coffee.Kiosk.Cashier.CashierDBHelper;
using Coffee.Kiosk.Cashier.ModelClassHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DBHelper = Coffee.Kiosk.Cashier.CashierDBHelper.CashierDBHelper;

namespace Coffee.Kiosk.Cashier
{
    public partial class UC_Payment : UserControl
    {
        private List<OrderItemModel> _cart = new();
        private decimal _total = 0;
        private string _paymentMethod = "Cash";
        private Panel? _pnlEWallet;
        private int _kioskOrderId = 0;

        public UC_Payment() { InitializeComponent(); }

        public UC_Payment(List<OrderItemModel> cart, decimal total) : this()
        {
            Init(cart, total, 0);
        }

        public UC_Payment(List<OrderItemModel> cart, decimal total, int kioskOrderId) : this()
        {
            Init(cart, total, kioskOrderId);
        }

        private void Init(List<OrderItemModel> cart, decimal total, int kioskOrderId)
        {
            _cart = cart;
            _total = total;
            _kioskOrderId = kioskOrderId;

            btnConfirm.Enabled = false;
            btnBack.Enabled = true;

            lblTotalAmt.Text = $"₱{_total:N2}";
            lblChangeAmt.Text = "₱0.00";

            LoadSummary();

            btnCash.Click += (s, e) => SetPaymentMethod("Cash");
            btnGcash.Click += (s, e) => SetPaymentMethod("GCash");

            var brown = Color.FromArgb(107, 79, 58);
            var green = Color.FromArgb(0, 119, 60);

            btnCash.FillColor = Color.White; btnCash.ForeColor = brown; btnCash.BorderColor = brown; btnCash.BorderRadius = 8;
            btnGcash.FillColor = Color.White; btnGcash.ForeColor = green; btnGcash.BorderColor = green; btnGcash.BorderRadius = 8;

            SetPaymentMethod(_kioskOrderId > 0 ? "GCash" : "Cash");
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

                pnlSummary.Controls.Add(new Label
                {
                    Text = display,
                    ForeColor = Color.FromArgb(107, 79, 58),
                    Font = new Font("Segoe UI", 9f),
                    AutoSize = false,
                    Width = pnlSummary.Width - 110,
                    Height = rowH,
                    Location = new Point(10, y)
                });
                pnlSummary.Controls.Add(new Label
                {
                    Text = $"₱{item.Subtotal:N2}",
                    ForeColor = Color.FromArgb(59, 35, 20),
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    AutoSize = false,
                    Width = 90,
                    Height = rowH,
                    Location = new Point(pnlSummary.Width - 106, y),
                    TextAlign = ContentAlignment.MiddleRight
                });
                y += rowH + 4;
            }

            pnlSummary.Controls.Add(new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                Height = 2,
                Width = pnlSummary.Width - 20,
                Location = new Point(10, y + 4)
            });
            y += 14;

            pnlSummary.Controls.Add(new Label
            {
                Text = $"Total:   ₱{_total:N2}",
                ForeColor = Color.FromArgb(59, 35, 20),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                AutoSize = false,
                Width = pnlSummary.Width - 20,
                Height = 26,
                Location = new Point(10, y)
            });
        }

        private void SetPaymentMethod(string method)
        {
            _paymentMethod = method;

            var brown = Color.FromArgb(107, 79, 58);
            var green = Color.FromArgb(0, 119, 60);

            btnCash.FillColor = Color.White; btnCash.ForeColor = brown; btnCash.BorderColor = brown;
            btnGcash.FillColor = Color.White; btnGcash.ForeColor = green; btnGcash.BorderColor = green;

            switch (method)
            {
                case "Cash":
                    btnCash.FillColor = brown;
                    btnCash.ForeColor = Color.White;
                    pnlPayLeft.Visible = true;
                    HideEWalletInfo();
                    guna2TextBox1.Text = "";
                    lblChangeAmt.Text = "₱0.00";
                    btnConfirm.Enabled = false;
                    break;

                case "GCash":
                    btnGcash.FillColor = green;
                    btnGcash.ForeColor = Color.White;
                    pnlPayLeft.Visible = false;
                    lblChangeAmt.Text = "N/A";
                    btnConfirm.Enabled = true;
                    ShowEWalletInfo("GCash", "0917-123-4567", green);
                    break;
            }
        }

        private void ShowEWalletInfo(string method, string number, Color color)
        {
            HideEWalletInfo();
            _pnlEWallet = new Panel
            {
                Width = pnlPayLeft.Width,
                Height = 160,
                Location = pnlPayLeft.Location,
                BackColor = Color.FromArgb(245, 250, 255),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblNote = new Label { Text = "  Ask customer to show screenshot before confirming.", Font = new Font("Segoe UI", 8f, FontStyle.Italic), ForeColor = Color.Gray, Dock = DockStyle.Top, Height = 22 };
            var lblAmt = new Label { Text = $"  Amount:  ₱{_total:N2}", Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = color, Dock = DockStyle.Top, Height = 30 };
            var lblAcc = new Label { Text = "  Account:  Café Filipino", Font = new Font("Segoe UI", 10f), ForeColor = Color.FromArgb(44, 34, 24), Dock = DockStyle.Top, Height = 26 };
            var lblNum = new Label { Text = $"  Send to:  {number}", Font = new Font("Segoe UI", 10f), ForeColor = Color.FromArgb(44, 34, 24), Dock = DockStyle.Top, Height = 26 };
            var lblTitle = new Label { Text = $"  {method} Payment", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = color, Dock = DockStyle.Top, Height = 36, TextAlign = ContentAlignment.MiddleLeft };

            _pnlEWallet.Controls.Add(lblNote);
            _pnlEWallet.Controls.Add(lblAmt);
            _pnlEWallet.Controls.Add(lblAcc);
            _pnlEWallet.Controls.Add(lblNum);
            _pnlEWallet.Controls.Add(lblTitle);

            pnlPayLeft.Parent!.Controls.Add(_pnlEWallet);
            _pnlEWallet.BringToFront();
        }

        private void HideEWalletInfo()
        {
            if (_pnlEWallet == null) return;
            _pnlEWallet.Parent?.Controls.Remove(_pnlEWallet);
            _pnlEWallet.Dispose();
            _pnlEWallet = null;
        }

        private void CalcChange()
        {
            if (decimal.TryParse(guna2TextBox1.Text, out decimal cash))
            {
                decimal change = cash - _total;
                lblChangeAmt.Text = $"₱{Math.Abs(change):N2}";
                lblChangeAmt.ForeColor = change >= 0
                    ? Color.FromArgb(46, 125, 82) : Color.FromArgb(192, 96, 122);
                btnConfirm.Enabled = change >= 0;
            }
            else
            {
                lblChangeAmt.Text = "₱0.00";
                lblChangeAmt.ForeColor = Color.FromArgb(107, 79, 58);
                btnConfirm.Enabled = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) { guna2TextBox1.Text = "100"; CalcChange(); }
        private void guna2Button3_Click(object sender, EventArgs e) { guna2TextBox1.Text = "500"; CalcChange(); }
        private void guna2Button4_Click(object sender, EventArgs e) { guna2TextBox1.Text = "1000"; CalcChange(); }
        private void guna2Button5_Click(object sender, EventArgs e) { guna2TextBox1.Text = _total.ToString("N2"); CalcChange(); }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) => CalcChange();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(guna2TextBox1.Text, out decimal cash))
                cash = _total;

            decimal change = _paymentMethod == "Cash" ? cash - _total : 0;

            if (_paymentMethod != "Cash")
            {
                var ok = MessageBox.Show(
                    $"Confirm {_paymentMethod} payment of ₱{_total:N2}?\n\nCustomer has shown the screenshot?",
                    $"Confirm {_paymentMethod}",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok != DialogResult.Yes) return;
            }

            string orderNumber;
            string itemSummary = string.Join(", ", _cart.Select(c => c.Item.ItemName));

            if (_kioskOrderId > 0)
            {
                orderNumber = _kioskOrderId.ToString("D3");

                try { KioskOrderDbManager.MarkOrderPaid(_kioskOrderId); }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Payment confirmed but could not update order status:\n{ex.Message}",
                        "DB Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try { DBHelper.MoveToDisplayPreparingQueue(orderNumber, itemSummary); }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Payment confirmed but could not update display:\n{ex.Message}",
                        "DB Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                orderNumber = $"C{SessionManager.OrderNumber:D3}";

                try { KioskOrderDbManager.SaveCashierOrder(_cart, _total); }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Payment confirmed but could not save order to database:\n{ex.Message}",
                        "DB Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try { DBHelper.MoveToDisplayPreparingQueue(orderNumber, itemSummary); }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Payment confirmed but could not update display:\n{ex.Message}",
                        "DB Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            try { DBHelper.AddToSales(SessionManager.ActiveSalesId, _total); }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Sale recorded but could not update employee sales:\n{ex.Message}",
                    "DB Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SessionManager.OrderNumber++;
            var receipt = new UC_Receipt(_cart, _total, cash, change, _paymentMethod, orderNumber);
            ((HomePage)this.ParentForm!).LoadControl(receipt);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HideEWalletInfo();
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
        private void label1_Click(object sender, EventArgs e) { }
    }
}