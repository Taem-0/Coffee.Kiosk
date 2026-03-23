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
            Init(cart, total, 0, "Cash");
        }

        public UC_Payment(List<OrderItemModel> cart, decimal total, int kioskOrderId) : this()
        {
            Init(cart, total, kioskOrderId, "Cash");
        }

        public UC_Payment(List<OrderItemModel> cart, decimal total, int kioskOrderId, string defaultPayment) : this()
        {
            Init(cart, total, kioskOrderId, defaultPayment);
        }

        private void Init(List<OrderItemModel> cart, decimal total, int kioskOrderId, string defaultPayment)
        {
            _cart = cart;
            _total = total;
            _kioskOrderId = kioskOrderId;

            var theme = SessionManager.Theme;
            var gcashGreen = Color.FromArgb(0, 119, 60);

            btnConfirm.Enabled = false;
            btnBack.Enabled = true;

            lblTotalAmt.Text = $"₱{_total:N2}";
            lblChangeAmt.Text = "₱0.00";

            LoadSummary();

            btnCash.Click += (s, e) => SetPaymentMethod("Cash");
            btnGcash.Click += (s, e) => SetPaymentMethod("GCash");

            btnCash.FillColor = Color.White;
            btnCash.ForeColor = theme.PrimaryColor;
            btnCash.BorderColor = theme.PrimaryColor;
            btnCash.BorderRadius = 8;

            btnGcash.FillColor = Color.White;
            btnGcash.ForeColor = gcashGreen;
            btnGcash.BorderColor = gcashGreen;
            btnGcash.BorderRadius = 8;

            string initialMethod = string.IsNullOrEmpty(defaultPayment) ? "Cash" : defaultPayment;
            SetPaymentMethod(initialMethod);
        }

        private void LoadSummary()
        {
            var theme = SessionManager.Theme;
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
                    ForeColor = theme.PrimaryColor,
                    Font = new Font("Segoe UI", 9f),
                    AutoSize = false,
                    Width = pnlSummary.Width - 110,
                    Height = rowH,
                    Location = new Point(10, y)
                });
                pnlSummary.Controls.Add(new Label
                {
                    Text = $"₱{item.Subtotal:N2}",
                    ForeColor = theme.DarkPrimaryColor,
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
                ForeColor = theme.DarkPrimaryColor,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                AutoSize = false,
                Width = pnlSummary.Width - 20,
                Height = 26,
                Location = new Point(10, y)
            });
        }

        private void SetCashControlsVisible(bool visible)
        {
            lblSummary.Visible = visible;
            pnlSummary.Visible = visible;
            lblQuick.Visible = visible;
            guna2Button2.Visible = visible;
            guna2Button3.Visible = visible;
            guna2Button4.Visible = visible;
            guna2Button5.Visible = visible;
            lblCashTend.Visible = visible;
            guna2TextBox1.Visible = visible;
        }

        private void SetPaymentMethod(string method)
        {
            _paymentMethod = method;

            var theme = SessionManager.Theme;
            var gcashGreen = Color.FromArgb(0, 119, 60);

            btnCash.FillColor = Color.White; btnCash.ForeColor = theme.PrimaryColor; btnCash.BorderColor = theme.PrimaryColor;
            btnGcash.FillColor = Color.White; btnGcash.ForeColor = gcashGreen; btnGcash.BorderColor = gcashGreen;

            switch (method)
            {
                case "Cash":
                    btnCash.FillColor = theme.PrimaryColor;
                    btnCash.ForeColor = Color.White;
                    SetCashControlsVisible(true);
                    HideEWalletInfo();
                    guna2TextBox1.Text = "";
                    lblChangeAmt.Text = "₱0.00";
                    btnConfirm.Enabled = false;
                    break;

                case "GCash":
                    btnGcash.FillColor = gcashGreen;
                    btnGcash.ForeColor = Color.White;
                    SetCashControlsVisible(false);
                    lblChangeAmt.Text = "N/A";
                    btnConfirm.Enabled = true;
                    ShowEWalletInfo("GCash", "0917-123-4567", gcashGreen);
                    break;
            }
        }

        private void ShowEWalletInfo(string method, string number, Color color)
        {
            HideEWalletInfo();

            var theme = SessionManager.Theme;
            int topY = btnCash.Bottom + 16;

            _pnlEWallet = new Panel
            {
                Location = new Point(btnCash.Left, topY),
                Width = pnlPayLeft.Width - (btnCash.Left * 2),
                Height = 160,
                BackColor = theme.BackgroundColor,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTitle = new Label { Text = $"  {method} Payment", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = color, Dock = DockStyle.Top, Height = 36, TextAlign = ContentAlignment.MiddleLeft };
            var lblNum = new Label { Text = $"  Send to:  {number}", Font = new Font("Segoe UI", 10f), ForeColor = theme.DarkPrimaryColor, Dock = DockStyle.Top, Height = 26 };
            var lblAcc = new Label { Text = $"  Account:  {SessionManager.Theme.ShopName}", Font = new Font("Segoe UI", 10f), ForeColor = theme.DarkPrimaryColor, Dock = DockStyle.Top, Height = 26 };
            var lblAmt = new Label { Text = $"  Amount:  ₱{_total:N2}", Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = color, Dock = DockStyle.Top, Height = 30 };
            var lblNote = new Label { Text = "  Ask customer to show screenshot before confirming.", Font = new Font("Segoe UI", 8f, FontStyle.Italic), ForeColor = Color.Gray, Dock = DockStyle.Top, Height = 22 };

            _pnlEWallet.Controls.Add(lblNote);
            _pnlEWallet.Controls.Add(lblAmt);
            _pnlEWallet.Controls.Add(lblAcc);
            _pnlEWallet.Controls.Add(lblNum);
            _pnlEWallet.Controls.Add(lblTitle);

            pnlPayLeft.Controls.Add(_pnlEWallet);
            _pnlEWallet.BringToFront();
        }

        private void HideEWalletInfo()
        {
            if (_pnlEWallet == null) return;
            pnlPayLeft.Controls.Remove(_pnlEWallet);
            _pnlEWallet.Dispose();
            _pnlEWallet = null;
        }

        private void CalcChange()
        {
            var theme = SessionManager.Theme;
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
                lblChangeAmt.ForeColor = theme.PrimaryColor;
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

            if (_paymentMethod == "GCash")
            {
                var ok = MessageBox.Show(
                    $"Confirm GCash payment of ₱{_total:N2}?\n\nCustomer has shown the GCash screenshot?",
                    "Confirm GCash Payment",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok != DialogResult.Yes) return;
            }

            string dbPayment = _paymentMethod == "GCash" ? "Gcash" : "Cash";

            int savedOrderId;

            if (_kioskOrderId > 0)
            {
                savedOrderId = _kioskOrderId;
                try { KioskOrderDbManager.MarkOrderPaid(_kioskOrderId, dbPayment); }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Payment confirmed but could not update order status:\n{ex.Message}",
                        "DB Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                savedOrderId = 0;
                try { savedOrderId = KioskOrderDbManager.SaveCashierOrder(_cart, _total, "DineIn", dbPayment); }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Payment confirmed but could not save order to database:\n{ex.Message}",
                        "DB Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            string orderNumber = savedOrderId > 0
                ? savedOrderId.ToString("D3")
                : SessionManager.OrderNumber.ToString("D3");

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
            ((HomePage)this.ParentForm!).LoadControl(new UC_Cashier(_cart));
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