using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coffee.Kiosk.OrderStatusDisplay.OrderStatusDB;

namespace Coffee.Kiosk.OrderStatusDisplay
{
    public partial class Form1 : Form
    {
        private readonly OrderDisplayDBManager _db = new OrderDisplayDBManager();

        // ── accent colors ─────────────────────────────────────
        static readonly Color BlueAccent = Color.FromArgb(59, 79, 212);
        static readonly Color AmberAccent = Color.FromArgb(122, 74, 0);
        static readonly Color GreenAccent = Color.FromArgb(26, 92, 42);

        // ── badge colors ──────────────────────────────────────
        static readonly Color CashBg = Color.FromArgb(59, 79, 212);
        static readonly Color CashFg = Color.FromArgb(220, 226, 255);
        static readonly Color GCashBg = Color.FromArgb(91, 45, 158);
        static readonly Color GCashFg = Color.FromArgb(220, 185, 255);
        static readonly Color PrepBg = Color.FromArgb(122, 74, 0);
        static readonly Color PrepFg = Color.FromArgb(255, 208, 128);
        static readonly Color PickupBg = Color.FromArgb(26, 92, 42);
        static readonly Color PickupFg = Color.FromArgb(134, 239, 172);

        // ── snapshot tracking (prevents flicker) ─────────────
        private string _lastPaySnapshot = "";
        private string _lastPrepSnapshot = "";
        private string _lastPickupSnapshot = "";

        public Form1()
        {
            InitializeComponent();

            // ── enable double buffering on the form itself ────
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ── form setup ────────────────────────────────────
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            // ── FlowLayoutPanel settings ──────────────────────
            flpPay.FlowDirection = FlowDirection.TopDown;
            flpPay.WrapContents = false;
            flpPay.AutoScroll = false;
            flpPay.Padding = new Padding(8, 10, 8, 10);

            flpPrep.FlowDirection = FlowDirection.TopDown;
            flpPrep.WrapContents = false;
            flpPrep.AutoScroll = false;
            flpPrep.Padding = new Padding(8, 10, 8, 10);

            flpPickup.FlowDirection = FlowDirection.TopDown;
            flpPickup.WrapContents = false;
            flpPickup.AutoScroll = false;
            flpPickup.Padding = new Padding(8, 10, 8, 10);

            // ── double buffering on panels ────────────────────
            typeof(FlowLayoutPanel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(flpPay, true);

            typeof(FlowLayoutPanel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(flpPrep, true);

            typeof(FlowLayoutPanel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(flpPickup, true);

            // ── auto-refresh timer (every 2 seconds) ──────────
            var refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 2_000;
            refreshTimer.Tick += (s, ev) =>
            {
                LoadPaymentOrders();
                LoadPreparingOrders();
                LoadPickupOrders();
            };
            refreshTimer.Start();

            // ── auto-cancel timer (every 30 seconds) ──────────
            var autoCompleteTimer = new System.Windows.Forms.Timer();
            autoCompleteTimer.Interval = 30_000;
            autoCompleteTimer.Tick += AutoCompleteTimer_Tick;
            autoCompleteTimer.Start();

            // ── load cards on startup ─────────────────────────
            LoadPaymentOrders();
            LoadPreparingOrders();
            LoadPickupOrders();

            // ── reload on window resize ───────────────────────
            this.Resize += (s, ev) =>
            {
                // force full redraw on resize
                _lastPaySnapshot = "";
                _lastPrepSnapshot = "";
                _lastPickupSnapshot = "";

                LoadPaymentOrders();
                LoadPreparingOrders();
                LoadPickupOrders();
            };
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-CANCEL TIMER — runs every 30 seconds
        //  Fades out expired cards then cancels them in DB
        // ─────────────────────────────────────────────────────
        private async void AutoCompleteTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // ── pickup: fade out after 5 mins ─────────────
                var expiredPickups = _db.GetExpiredPickupOrderNumbers();
                foreach (var orderNumber in expiredPickups)
                    FadeOutCard(flpPickup, orderNumber);

                // ── payment: fade out after 10 mins ───────────
                var expiredPayments = _db.GetExpiredPaymentOrderNumbers();
                foreach (var orderNumber in expiredPayments)
                    FadeOutCard(flpPay, orderNumber);

                // ── wait for fade animation to finish ─────────
                if (expiredPickups.Count > 0 || expiredPayments.Count > 0)
                    await Task.Delay(1000);

                // ── cancel expired orders in DB ───────────────
                _db.AutoCancelExpiredPickups();
                _db.AutoCancelExpiredPayments();

                // ── 2-second refresh timer handles redraw ─────
            }
            catch (Exception ex)
            {
                MessageBox.Show("Auto-complete error: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        //  FADE OUT — works for any column
        // ─────────────────────────────────────────────────────
        private void FadeOutCard(FlowLayoutPanel flp, string orderNumber)
        {
            foreach (Control ctrl in flp.Controls)
            {
                if (ctrl is OrderStatusUC card && card.OrderNumber == orderNumber)
                {
                    var fadeTimer = new System.Windows.Forms.Timer();
                    fadeTimer.Interval = 50;
                    double opacity = 1.0;

                    fadeTimer.Tick += (s, ev) =>
                    {
                        opacity -= 0.05;

                        if (opacity <= 0)
                        {
                            fadeTimer.Stop();
                            fadeTimer.Dispose();
                            flp.Controls.Remove(card);
                            card.Dispose();
                        }
                        else
                        {
                            int alpha = (int)(opacity * 255);
                            card.BackColor = Color.FromArgb(alpha,
                                card.BackColor.R,
                                card.BackColor.G,
                                card.BackColor.B);
                        }
                    };

                    fadeTimer.Start();
                    break;
                }
            }
        }

        // ── clock ─────────────────────────────────────────────
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
        }

        // ─────────────────────────────────────────────────────
        //  HELPER — creates and adds one card to a column
        // ─────────────────────────────────────────────────────
        private void AddCard(
            FlowLayoutPanel flp,
            string orderNum,
            string itemName,
            string badge,
            Color accent,
            Color badgeBg,
            Color badgeFg,
            bool isPickup = false)
        {
            var card = new OrderStatusUC();
            card.SetCard(orderNum, itemName, badge,
                         accent, badgeBg, badgeFg, isPickup);

            card.Width = flp.ClientSize.Width
                        - flp.Padding.Left
                        - flp.Padding.Right - 16;
            card.Height = 90;

            flp.Controls.Add(card);
        }

        // ─────────────────────────────────────────────────────
        //  LOAD — PLEASE PAY column
        //  Badge: Cash (blue) or GCash (purple)
        // ─────────────────────────────────────────────────────
        private void LoadPaymentOrders()
        {
            try
            {
                var orders = _db.GetPaymentQueue();
                var snapshot = string.Join("|", orders.Select(o =>
                               $"{o.OrderNumber},{o.ItemName},{o.PaymentMethod}"));

                if (snapshot == _lastPaySnapshot) return;
                _lastPaySnapshot = snapshot;

                flpPay.Controls.Clear();

                foreach (var order in orders)
                {
                    string badge;
                    Color bgColor, fgColor;

                    if (order.PaymentMethod?.ToLower() == "gcash")
                    {
                        badge = "GCash"; bgColor = GCashBg; fgColor = GCashFg;
                    }
                    else
                    {
                        badge = "Cash"; bgColor = CashBg; fgColor = CashFg;
                    }

                    AddCard(flpPay,
                            order.OrderNumber ?? "",
                            order.ItemName ?? "",
                            badge, BlueAccent, bgColor, fgColor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pay queue error: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        //  LOAD — BEING PREPARED column
        //  Badge: always Brewing
        // ─────────────────────────────────────────────────────
        private void LoadPreparingOrders()
        {
            try
            {
                var orders = _db.GetPreparingQueue();
                var snapshot = string.Join("|", orders.Select(o =>
                               $"{o.OrderNumber},{o.ItemName}"));

                if (snapshot == _lastPrepSnapshot) return;
                _lastPrepSnapshot = snapshot;

                flpPrep.Controls.Clear();

                foreach (var order in orders)
                    AddCard(flpPrep,
                            order.OrderNumber ?? "",
                            order.ItemName ?? "",
                            "Brewing", AmberAccent, PrepBg, PrepFg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Prep queue error: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        //  LOAD — READY FOR PICK-UP column
        //  Badge: always Pick up
        // ─────────────────────────────────────────────────────
        private void LoadPickupOrders()
        {
            try
            {
                var orders = _db.GetPickupQueue();
                var snapshot = string.Join("|", orders.Select(o =>
                               $"{o.OrderNumber},{o.ItemName}"));

                if (snapshot == _lastPickupSnapshot) return;
                _lastPickupSnapshot = snapshot;

                flpPickup.Controls.Clear();

                foreach (var order in orders)
                    AddCard(flpPickup,
                            order.OrderNumber ?? "",
                            order.ItemName ?? "",
                            "Pick up", GreenAccent, PickupBg, PickupFg,
                            isPickup: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pickup queue error: " + ex.Message);
            }
        }
    }
}