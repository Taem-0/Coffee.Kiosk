using System;
using System.Drawing;
using System.Windows.Forms;
namespace Coffee.Kiosk.OrderStatusDisplay
{
    public partial class OrderStatusUC : UserControl
    {
        private Color _accent;
        private bool _isPickup;

        // ── exposed property for fade-out lookup ──────────────
        public string? OrderNumber { get; private set; }

        public OrderStatusUC()
        {
            InitializeComponent();
        }
        public void SetCard(
            string orderNum,
            string itemName,
            string badge,
            Color accent,
            Color badgeBg,
            Color badgeFg,
            bool isPickup = false)
        {
            _accent = accent;
            _isPickup = isPickup;

            // ── store order number for fade lookup ────────────
            OrderNumber = orderNum;

            // ── set text ──────────────────────────────────────
            lblOrderNum.Text = orderNum;
            lblItemName.Text = itemName;
            lblBadge.Text = badge;

            // ── lblOrderNum ───────────────────────────────────
            lblOrderNum.Font = new Font("Segoe UI", 23, FontStyle.Bold);
            lblOrderNum.ForeColor = accent;
            lblOrderNum.BackColor = Color.Transparent;
            lblOrderNum.AutoSize = true;
            lblOrderNum.Location = new Point(_isPickup ? 18 : 14, 10);

            // ── lblItemName ───────────────────────────────────
            lblItemName.Font = new Font("Segoe UI", 14);
            lblItemName.ForeColor = Color.FromArgb(122, 80, 48);
            lblItemName.BackColor = Color.Transparent;
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(_isPickup ? 18 : 14, 46);

            // ── lblBadge ──────────────────────────────────────
            lblBadge.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblBadge.ForeColor = badgeFg;
            lblBadge.BackColor = badgeBg;
            lblBadge.AutoSize = true;
            lblBadge.Padding = new Padding(10, 5, 10, 5);

            // ── card shell ────────────────────────────────────
            this.Height = 75;
            this.Margin = new Padding(0, 0, 0, 10);
            this.Padding = new Padding(6, 6, 6, 6);
            this.BackColor = Color.FromArgb(245, 237, 224);

            // ── badge repositions on resize ───────────────────
            this.Resize -= OnCardResize;
            this.Resize += OnCardResize;

            // ── paint ─────────────────────────────────────────
            this.Paint -= OnCardPaint;
            this.Paint += OnCardPaint;
        }

        private void OnCardResize(object sender, EventArgs e)
        {
            if (lblBadge != null)
                lblBadge.Location = new Point(
                    this.Width - lblBadge.Width - 14, 22);
        }

        private void OnCardPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(
                new Pen(Color.FromArgb(200, 168, 112)),
                0, 0, Width - 1, Height - 1);
            if (_isPickup)
                e.Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb(150, 45, 158, 80)),
                    0, 0, 4, Height);
        }

        private void lblOrderNum_Click(object sender, EventArgs e) { }
        private void lblItemName_Click(object sender, EventArgs e) { }
        private void lblBadge_Click(object sender, EventArgs e) { }
        private void OrderStatusUC_Load(object sender, EventArgs e) { }
    }
}