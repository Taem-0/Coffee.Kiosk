using Coffee.Kiosk.Cashier.ModelClassHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class UC_Receipt : UserControl
    {
        private List<OrderItemModel> _cart = new();
        private decimal _total = 0;
        private decimal _cash = 0;
        private decimal _change = 0;

        public UC_Receipt() { InitializeComponent(); }

        public UC_Receipt(List<OrderItemModel> cart, decimal total,
                          decimal cash, decimal change) : this()
        {
            _cart = cart;
            _total = total;
            _cash = cash;
            _change = change;
            BuildReceipt();
        }

        private void BuildReceipt()
        {
            pnlReceipt.Controls.Clear();
            int y = 12;

            AddReceiptLine("CAFÉ FILIPINO", true, ref y, centered: true, size: 13);
            AddReceiptLine("123 Espresso St., QC", false, ref y, centered: true, size: 8);
            AddReceiptLine("", false, ref y);
            AddReceiptLine(
                $"Order #{SessionManager.OrderNumber:D3}  ·  {DateTime.Now:MMM dd, yyyy  hh:mm tt}",
                false, ref y, centered: true, size: 8);
            AddReceiptLine(
                $"Cashier: {SessionManager.CurrentUser.Username}",
                false, ref y, centered: true, size: 8);
            AddReceiptLine(new string('-', 38), false, ref y, size: 8);

            foreach (var item in _cart)
            {
                AddTwoColLine(
                    $"{item.Item.ItemName} x{item.Quantity}",
                    $"₱{item.Subtotal:N2}", ref y);

                string summary = item.Customization.Summary();
                if (!string.IsNullOrEmpty(summary))
                    AddReceiptLine($"  {summary}", false, ref y, size: 7, muted: true);
            }

            AddReceiptLine(new string('-', 38), false, ref y, size: 8);
            AddTwoColLine("TOTAL", $"₱{_total:N2}", ref y, bold: true, size: 11);
            AddReceiptLine(new string('-', 38), false, ref y, size: 8);
            AddTwoColLine("Cash Tendered", $"₱{_cash:N2}", ref y, muted: true);
            AddTwoColLine("Change", $"₱{_change:N2}", ref y, muted: true);
            AddReceiptLine(new string('-', 38), false, ref y, size: 8);
            AddReceiptLine("Thank you for visiting!", false, ref y, centered: true, size: 8);

            pnlReceipt.Height = y + 20;
        }

        private void AddReceiptLine(string text, bool bold, ref int y,
            bool centered = false, int size = 9, bool muted = false)
        {
            var lbl = new Label
            {
                Text = text,
                Font = new Font("Courier New", size, bold ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = muted ? Color.FromArgb(150, 120, 90) : Color.FromArgb(44, 34, 24),
                AutoSize = false,
                Width = pnlReceipt.Width - 24,
                Height = string.IsNullOrEmpty(text) ? 8 : size + 10,
                Location = new Point(12, y),
                TextAlign = centered ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft
            };
            pnlReceipt.Controls.Add(lbl);
            y += lbl.Height + 2;
        }

        private void AddTwoColLine(string left, string right, ref int y,
            bool muted = false, bool bold = false, int size = 9)
        {
            var color = muted ? Color.FromArgb(150, 120, 90) : Color.FromArgb(44, 34, 24);
            var font = new Font("Courier New", size, bold ? FontStyle.Bold : FontStyle.Regular);
            int w = pnlReceipt.Width - 24;

            pnlReceipt.Controls.Add(new Label
            {
                Text = left,
                Font = font,
                ForeColor = color,
                AutoSize = false,
                Width = w / 2,
                Height = size + 10,
                Location = new Point(12, y),
                TextAlign = ContentAlignment.MiddleLeft
            });
            pnlReceipt.Controls.Add(new Label
            {
                Text = right,
                Font = font,
                ForeColor = color,
                AutoSize = false,
                Width = w / 2,
                Height = size + 10,
                Location = new Point(12 + w / 2, y),
                TextAlign = ContentAlignment.MiddleRight
            });
            y += size + 12;
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            printDoc.Print();
        }

        private void printDoc_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            var g = e.Graphics!;
            var bold = new Font("Courier New", 10, FontStyle.Bold);
            var norm = new Font("Courier New", 9);
            var small = new Font("Courier New", 8);
            var tiny = new Font("Courier New", 7);
            var brush = Brushes.Black;
            float x = 10, y = 10, lh = 16;

            g.DrawString("CAFÉ FILIPINO", bold, brush, x, y); y += lh;
            g.DrawString("123 Espresso St.", small, brush, x, y); y += lh;
            g.DrawString(
                $"Order #{SessionManager.OrderNumber:D3}  {DateTime.Now:MM/dd/yy hh:mm tt}",
                small, brush, x, y); y += lh;
            g.DrawString(
                $"Cashier: {SessionManager.CurrentUser.Username}",
                small, brush, x, y); y += lh;
            g.DrawString(new string('-', 32), small, brush, x, y); y += lh;

            foreach (var item in _cart)
            {
                string line =
                    $"{item.Item.ItemName} x{item.Quantity}".PadRight(22)
                    + $"P{item.Subtotal:N2}".PadLeft(10);
                g.DrawString(line, norm, brush, x, y); y += lh;

                string summary = item.Customization.Summary();
                if (!string.IsNullOrEmpty(summary))
                {
                    g.DrawString($"  {summary}", tiny, brush, x, y);
                    y += 14;
                }
            }

            g.DrawString(new string('-', 32), small, brush, x, y); y += lh;
            g.DrawString(
                $"{"TOTAL".PadRight(22)}{"P" + _total.ToString("N2"),10}",
                bold, brush, x, y); y += lh;
            g.DrawString(new string('-', 32), small, brush, x, y); y += lh;
            g.DrawString(
                $"{"Cash".PadRight(22)}{"P" + _cash.ToString("N2"),10}",
                norm, brush, x, y); y += lh;
            g.DrawString(
                $"{"Change".PadRight(22)}{"P" + _change.ToString("N2"),10}",
                norm, brush, x, y); y += lh;
            g.DrawString(new string('-', 32), small, brush, x, y); y += lh;
            g.DrawString("Thank you for visiting!", small, brush, x, y);
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ((HomePage)this.ParentForm!).LoadControl(new UC_Cashier());
        }

        private void pnlReceipt_Paint(object sender, PaintEventArgs e) { }
    }
}