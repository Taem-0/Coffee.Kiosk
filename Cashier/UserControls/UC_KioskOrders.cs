using Coffee.Kiosk.Cashier.CashierDBHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier.UserControls
{
    public partial class UC_KioskOrders : UserControl
    {
        public event Action<int>? OrderSelected;

        private static readonly Color Brown = Color.FromArgb(107, 79, 58);
        private static readonly Color LightCream = Color.FromArgb(245, 240, 230);
        private static readonly Color Urgent = Color.FromArgb(192, 32, 32);
        private static readonly Color Warn = Color.FromArgb(180, 110, 0);
        private static readonly Color Safe = Color.FromArgb(80, 120, 60);

        private FlowLayoutPanel _pnlList = new();
        private Label _lblEmpty = new();
        private TextBox _txtOrderId = new();

        public UC_KioskOrders()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            this.BackColor = LightCream;
            this.BorderStyle = BorderStyle.FixedSingle;

            // ── Header ──────────────────────────────────────────────────────
            var pnlHeader = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = Brown };
            var lblTitle = new Label
            {
                Text = "🔔  Kiosk Orders",
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            pnlHeader.Controls.Add(lblTitle);

            // ── Search bar ──────────────────────────────────────────────────
            var pnlSearch = new Panel
            {
                Dock = DockStyle.Top,
                Height = 46,
                BackColor = Color.FromArgb(235, 228, 218),
                Padding = new Padding(8, 7, 8, 7)
            };

            _txtOrderId = new TextBox
            {
                PlaceholderText = "Enter Order ID manually…",
                Font = new Font("Segoe UI", 9f),
                Width = 200,
                Height = 30,
                Location = new Point(8, 8)
            };

            var btnSearch = new Button
            {
                Text = "Load",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                BackColor = Brown,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(70, 30),
                Location = new Point(216, 8),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += BtnSearch_Click;

            pnlSearch.Controls.Add(_txtOrderId);
            pnlSearch.Controls.Add(btnSearch);

            // ── Order list ──────────────────────────────────────────────────
            _pnlList = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(8)
            };

            _lblEmpty = new Label
            {
                Text = "No pending kiosk orders.",
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true,
                Visible = false
            };
            _pnlList.Controls.Add(_lblEmpty);

            this.Controls.Add(_pnlList);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlHeader);
        }

        public void ReloadOrders()
        {
            for (int i = _pnlList.Controls.Count - 1; i >= 0; i--)
                if (_pnlList.Controls[i] != _lblEmpty)
                    _pnlList.Controls.RemoveAt(i);

            List<KioskOrderSummary> orders;
            try { orders = KioskOrderDbManager.GetPendingOrders(); }
            catch { orders = new List<KioskOrderSummary>(); }

            _lblEmpty.Visible = orders.Count == 0;

            foreach (var order in orders)
                _pnlList.Controls.Add(BuildOrderCard(order));
        }

        private Panel BuildOrderCard(KioskOrderSummary order)
        {
            // How many minutes has this order been waiting?
            int minutesOld = (int)(DateTime.Now - order.CreatedAt).TotalMinutes;
            int minutesLeft = Math.Max(0, 10 - minutesOld);
            bool isUrgent = minutesLeft <= 2;
            bool isWarn = minutesLeft <= 5 && !isUrgent;

            Color timerColor = isUrgent ? Urgent : (isWarn ? Warn : Safe);
            string timerText = minutesLeft == 0
                ? "⚠ EXPIRING NOW"
                : $"⏱ {minutesLeft} min left";

            // Card background turns light red when urgent
            Color cardBg = isUrgent
                ? Color.FromArgb(255, 240, 240)
                : Color.White;

            var card = new Panel
            {
                Width = 310,
                Height = 72,
                BackColor = cardBg,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 0, 6)
            };

            Color borderColor = isUrgent
                ? Color.FromArgb(220, 100, 100)
                : Color.FromArgb(200, 185, 165);

            card.Paint += (s, e) =>
                e.Graphics.DrawRectangle(
                    new Pen(borderColor), 0, 0, card.Width - 1, card.Height - 1);

            // Order ID
            var lblId = new Label
            {
                Text = $"Order #{order.OrderId}",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Brown,
                Location = new Point(10, 8),
                AutoSize = true
            };

            // Order type (DineIn / TakeOut)
            var lblType = new Label
            {
                Text = order.OrderType,
                Font = new Font("Segoe UI", 8f),
                ForeColor = Color.Gray,
                Location = new Point(10, 30),
                AutoSize = true
            };

            // Countdown timer
            var lblTimer = new Label
            {
                Text = timerText,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = timerColor,
                Location = new Point(10, 50),
                AutoSize = true
            };

            // Total amount — right side
            var lblAmt = new Label
            {
                Text = $"₱{order.TotalAmount:N2}",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(59, 35, 20),
                AutoSize = false,
                Width = 100,
                Height = 72,
                Location = new Point(200, 0),
                TextAlign = ContentAlignment.MiddleRight
            };

            card.Controls.Add(lblId);
            card.Controls.Add(lblType);
            card.Controls.Add(lblTimer);
            card.Controls.Add(lblAmt);

            EventHandler handler = (s, e) => OrderSelected?.Invoke(order.OrderId);
            card.Click += handler;
            lblId.Click += handler;
            lblType.Click += handler;
            lblTimer.Click += handler;
            lblAmt.Click += handler;

            return card;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            if (int.TryParse(_txtOrderId.Text.Trim(), out int id))
            {
                OrderSelected?.Invoke(id);
                _txtOrderId.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Order ID.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}