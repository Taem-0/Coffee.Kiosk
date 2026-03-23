using Cashier;
using Coffee.Kiosk.Cashier.CashierDBHelper;
using Coffee.Kiosk.Cashier.ModelClassHelper;
using Coffee.Kiosk.Cashier.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DBHelper = Coffee.Kiosk.Cashier.CashierDBHelper.CashierDBHelper;

namespace Coffee.Kiosk.Cashier
{
    public partial class HomePage : Form
    {
        private Label _lblBadge = new();
        private UC_KioskOrders _kioskPanel = new();
        private System.Windows.Forms.Timer _pollTimer = new();
        private System.Windows.Forms.Timer _cancelTimer = new();

        public HomePage()
        {
            InitializeComponent();
            lblCashier.Text = $"Cashier Staff — {SessionManager.CurrentUser.Username}";
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
            tmrClock.Start();

            ApplyTheme();

            SetupBadge();
            SetupKioskPanel();
            SetupPollTimer();
            SetupCancelTimer();

            LoadControl(new UC_Cashier());
        }

        private void ApplyTheme()
        {
            var theme = SessionManager.Theme;

            try
            {
                ShopName.Text = theme.ShopName;
                this.Text = theme.ShopName;
                ShopName.ForeColor = Color.White;

                pnlTopBar.BackColor = theme.PrimaryColor;
                this.BackColor = theme.BackgroundColor;

                btnLogout.FillColor = theme.DarkPrimaryColor;
                btnLogout.ForeColor = Color.White;

                LoadLogo(theme.LogoPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Theme load error:\n{ex.Message}");
            }
        }

        // ✅ FIXED LOGO LOADER
        private void LoadLogo(string? logoPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(logoPath))
                    return;

                string cleanPath = logoPath.Trim();

                string fullPath = Path.IsPathRooted(cleanPath)
                    ? cleanPath
                    : Path.Combine(Application.StartupPath, cleanPath);

                if (!File.Exists(fullPath))
                {
                    MessageBox.Show($"Logo not found:\n{fullPath}");
                    return;
                }

                // Prevent file locking
                using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    LogoPath.Image = Image.FromStream(fs);
                }

                LogoPath.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading logo:\n{ex.Message}");
            }
        }

        public void LoadControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void SetupBadge()
        {
            _lblBadge.AutoSize = false;
            _lblBadge.Size = new Size(20, 20);
            _lblBadge.Location = new Point(btnBell.Right - 14, btnBell.Top - 2);
            _lblBadge.BackColor = Color.FromArgb(220, 50, 50);
            _lblBadge.ForeColor = Color.White;
            _lblBadge.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
            _lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            _lblBadge.Visible = false;

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

        private void btnBell_Click(object sender, EventArgs e)
        {
            _kioskPanel.Visible = !_kioskPanel.Visible;
            if (_kioskPanel.Visible)
                _kioskPanel.ReloadOrders();
        }

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

            string kioskPayment = summary?.Payment ?? "Cash";
            string defaultPayment = kioskPayment.Equals("Gcash", StringComparison.OrdinalIgnoreCase) ? "GCash" : "Cash";

            var payment = new UC_Payment(cart, total, orderId, defaultPayment);
            LoadControl(payment);
        }

        private void SetupPollTimer()
        {
            _pollTimer.Interval = 15_000;
            _pollTimer.Tick += (s, e) => UpdateBadge();
            _pollTimer.Start();
        }

        private void SetupCancelTimer()
        {
            _cancelTimer.Interval = 60_000;
            _cancelTimer.Tick += (s, e) =>
            {
                try { DBHelper.CancelExpiredKioskOrders(10); }
                catch { }
                UpdateBadge();
            };
            _cancelTimer.Start();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _pollTimer.Stop();
                _cancelTimer.Stop();

                try { DBHelper.CloseShift(SessionManager.ActiveSalesId); }
                catch { }

                new LogIn().Show();
                this.Close();
            }
        }

        private void lblCashier_Click(object sender, EventArgs e) { }
        private void lblClock_Click(object sender, EventArgs e) { }
    }
}