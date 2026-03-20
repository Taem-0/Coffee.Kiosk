using Cashier;
using Coffee.Kiosk.Cashier.CashierDBHelper;
using Coffee.Kiosk.Cashier.ModelClassHelper;
using Coffee.Kiosk.Cashier.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class HomePage : Form
    {
        private Label _lblBadge = new();
        private UC_KioskOrders _kioskPanel = new();
        private System.Windows.Forms.Timer _pollTimer = new();

        public HomePage()
        {
            InitializeComponent();
            lblCashier.Text = $"Cashier Staff — {SessionManager.CurrentUser.Username}";
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
            tmrClock.Start();

            SetupBadge();
            SetupKioskPanel();
            SetupPollTimer();

            LoadControl(new UC_Cashier());
        }

        public void LoadControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        // ── Red badge on top of btnBell ──────────────────────────────────────
        private void SetupBadge()
        {
            _lblBadge.AutoSize = false;
            _lblBadge.Size = new Size(20, 20);
            _lblBadge.Location = new Point(btnBell.Right - 14, btnBell.Top - 2);
            _lblBadge.BackColor = Color.Red;
            _lblBadge.ForeColor = Color.White;
            _lblBadge.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
            _lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            _lblBadge.Visible = false;

            // Add to same parent panel as btnBell
            btnBell.Parent!.Controls.Add(_lblBadge);
            _lblBadge.BringToFront();

            UpdateBadge();
        }

        private void UpdateBadge()
        {
            try
            {
                int count = KioskOrderDbManager.GetPendingCount();
                _lblBadge.Text = count > 9 ? "9+" : count.ToString();
                _lblBadge.Visible = count > 0;
            }
            catch
            {
                _lblBadge.Visible = false;
            }
        }

        // ── Kiosk orders popup panel ─────────────────────────────────────────
        private void SetupKioskPanel()
        {
            _kioskPanel.Size = new Size(340, 480);
            _kioskPanel.Visible = false;
            _kioskPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _kioskPanel.Location = new Point(
                this.ClientSize.Width - _kioskPanel.Width - 10,
                btnBell.Bottom + 4);

            _kioskPanel.OrderSelected += LoadKioskOrderIntoPayment;

            this.Controls.Add(_kioskPanel);
            _kioskPanel.BringToFront();
        }

        // ── Bell button click — show/hide the panel ──────────────────────────
        private void btnBell_Click(object sender, EventArgs e)
        {
            _kioskPanel.Visible = !_kioskPanel.Visible;
            if (_kioskPanel.Visible)
                _kioskPanel.ReloadOrders();
        }

        // ── Load a kiosk order into the payment screen ───────────────────────
        private void LoadKioskOrderIntoPayment(int orderId)
        {
            _kioskPanel.Visible = false;

            List<KioskOrderItem> items;
            KioskOrderSummary? summary = null;

            try
            {
                items = KioskOrderDbManager.GetOrderItems(orderId);
                var allOrders = KioskOrderDbManager.GetPendingOrders();
                summary = allOrders.Find(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load order #{orderId}:\n{ex.Message}",
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (items.Count == 0)
            {
                MessageBox.Show($"Order #{orderId} not found or has no items.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convert kiosk items to cashier cart
            var cart = items.Select(ki => new OrderItemModel
            {
                Item = new MenuItemModel
                {
                    ItemName = ki.ProductName,
                    Price = ki.UnitPrice
                },
                Quantity = ki.Quantity,
                Customization = new OrderCustomization
                {
                    Notes = string.Join(" · ", ki.Modifiers)
                }
            }).ToList();

            decimal total = summary?.TotalAmount ?? cart.Sum(c => c.Subtotal);

            // Open payment screen — passes the kiosk order ID so it gets marked Paid
            var payment = new UC_Payment(cart, total, orderId);
            LoadControl(payment);
        }

        // ── Poll every 15 seconds to refresh the badge ───────────────────────
        private void SetupPollTimer()
        {
            _pollTimer.Interval = 15_000;
            _pollTimer.Tick += (s, e) => UpdateBadge();
            _pollTimer.Start();
        }

        // ── Clock ────────────────────────────────────────────────────────────
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
        }

        // ── Logout ───────────────────────────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _pollTimer.Stop();
                new LogIn().Show();
                this.Close();
            }
        }

        private void lblCashier_Click(object sender, EventArgs e) { }
        private void lblClock_Click(object sender, EventArgs e) { }
    }
}