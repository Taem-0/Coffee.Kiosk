using System;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ── form setup ────────────────────────────────────
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            // ── FlowLayoutPanel settings ──────────────────────
            // DO NOT set Dock — designer handles the layout
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

            // ── auto-refresh timer (every 2 seconds) ─────────
            var refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 2_000;
            refreshTimer.Tick += (s, ev) =>
            {
                LoadPaymentOrders();
                LoadPreparingOrders();
                LoadPickupOrders();
            };
            refreshTimer.Start();

            // ── auto-complete timer (every 30 seconds) ────────
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
                LoadPaymentOrders();
                LoadPreparingOrders();
                LoadPickupOrders();
            };
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-COMPLETE TIMER
        //  Fade out expired pickup cards then archive them
        // ─────────────────────────────────────────────────────
        private async void AutoCompleteTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Step 1 — find expired pickup cards
                var expiredOrders = _db.GetExpiredPickupOrderNumbers();

                // Step 2 — fade out each expired card
                foreach (var orderNumber in expiredOrders)
                    FadeOutOrderCard(orderNumber);

                // Step 3 — wait for fade animation to finish
                if (expiredOrders.Count > 0)
                    await Task.Delay(1000);

                // Step 4 — archive expired orders in DB
                _db.AutoCompleteExpiredPickups();

                // Step 5 — refresh pickup column
                LoadPickupOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Auto-complete error: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────
        //  FADE OUT — finds card by order number and fades it
        // ─────────────────────────────────────────────────────
        private void FadeOutOrderCard(string orderNumber)
        {
            foreach (Control ctrl in flpPickup.Controls)
            {
                if (ctrl is OrderStatusUC card &&
                    card.OrderNumber == orderNumber)
                {
                    var fadeTimer = new System.Windows.Forms.Timer();
                    fadeTimer.Interval = 50;
                    double opacity = 1.0;

                    fadeTimer.Tick += (s, e) =>
                    {
                        opacity -= 0.05;

                        if (opacity <= 0)
                        {
                            fadeTimer.Stop();
                            fadeTimer.Dispose();
                            flpPickup.Controls.Remove(card);
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

        // ══════════════════════════════════════════════════════
        //  HELPER — creates and adds one card to a column
        // ══════════════════════════════════════════════════════
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

            // ── width fills the column, height fixed at 75 ────
            card.Width = flp.ClientSize.Width
            - flp.Padding.Left
            - flp.Padding.Right - 16;  // accounts for 6px left+right margin
            card.Height = 90;

            flp.Controls.Add(card);
        }

        // ══════════════════════════════════════════════════════
        //  FUNCTION 1 — PLEASE PAY
        //  Badge: Cash (blue) or GCash (purple)
        // ══════════════════════════════════════════════════════
        private void LoadPaymentOrders()
        {
            flpPay.Controls.Clear();

            try
            {
                var orders = _db.GetPaymentQueue();

                foreach (var order in orders)
                {
                    string badge;
                    Color bgColor, fgColor;

                    // case-insensitive — handles gcash/GCash/Gcash
                    if (order.PaymentMethod?.ToLower() == "gcash")
                    {
                        badge = "GCash";
                        bgColor = GCashBg;
                        fgColor = GCashFg;
                    }
                    else
                    {
                        badge = "Cash";
                        bgColor = CashBg;
                        fgColor = CashFg;
                    }

                    AddCard(flpPay,
                        order.OrderNumber ?? "",
                        order.ItemName ?? "",
                        badge,
                        BlueAccent, bgColor, fgColor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pay queue error: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════
        //  FUNCTION 2 — BEING PREPARED
        //  Badge: always Brewing
        // ══════════════════════════════════════════════════════
        private void LoadPreparingOrders()
        {
            flpPrep.Controls.Clear();

            try
            {
                var orders = _db.GetPreparingQueue();

                foreach (var order in orders)
                {
                    AddCard(flpPrep,
                        order.OrderNumber ?? "",
                        order.ItemName ?? "",
                        "Brewing",
                        AmberAccent, PrepBg, PrepFg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Prep queue error: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════
        //  FUNCTION 3 — READY FOR PICK-UP
        //  Badge: always Pick up
        // ══════════════════════════════════════════════════════
        private void LoadPickupOrders()
        {
            flpPickup.Controls.Clear();

            try
            {
                var orders = _db.GetPickupQueue();

                foreach (var order in orders)
                {
                    AddCard(flpPickup,
                        order.OrderNumber ?? "",
                        order.ItemName ?? "",
                        "Pick up",
                        GreenAccent, PickupBg, PickupFg,
                        isPickup: true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pickup queue error: " + ex.Message);
            }
        }
    }
}