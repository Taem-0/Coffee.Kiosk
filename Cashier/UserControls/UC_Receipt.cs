using Coffee.Kiosk.Cashier.ModelClassHelper;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DrawingColor = System.Drawing.Color;
using DrawingFont = System.Drawing.Font;
using DrawingPoint = System.Drawing.Point;

namespace Coffee.Kiosk.Cashier
{
    public class CashierReceiptDoc : IDocument
    {
        private readonly List<OrderItemModel> _cart;
        private readonly decimal _total;
        private readonly decimal _cash;
        private readonly decimal _change;
        private readonly string _cashierName;
        private readonly int _orderNumber;
        private readonly string _paymentMethod;

        public CashierReceiptDoc(
            List<OrderItemModel> cart,
            decimal total, decimal cash, decimal change,
            string cashierName, int orderNumber, string paymentMethod)
        {
            _cart = cart;
            _total = total;
            _cash = cash;
            _change = change;
            _cashierName = cashierName;
            _orderNumber = orderNumber;
            _paymentMethod = paymentMethod;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.ContinuousSize(76, Unit.Millimetre);
                page.Margin(5);
                page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Courier New"));

                page.Content().Column(col =>
                {
                    col.Item().PaddingVertical(3)
                        .Text(new string('=', 34)).AlignCenter();

                    col.Item()
                        .Text("CAFÉ FILIPINO")
                        .FontSize(14).Bold().AlignCenter();

                    col.Item()
                        .Text("123 Espresso St., Quezon City")
                        .FontSize(7).AlignCenter();

                    col.Item()
                        .Text("Tel: (02) 8123-4567")
                        .FontSize(7).AlignCenter();

                    col.Item().PaddingVertical(3)
                        .Text(new string('=', 34)).AlignCenter();

                    col.Item()
                        .Text($"ORDER #{_orderNumber:D3}")
                        .FontSize(11).Bold().AlignCenter();

                    col.Item().PaddingTop(2)
                        .Text(DateTime.Now.ToString("MM/dd/yyyy  hh:mm tt"))
                        .FontSize(8).AlignCenter();

                    col.Item()
                        .Text($"Cashier: {_cashierName}")
                        .FontSize(8).AlignCenter();

                    col.Item().PaddingVertical(3)
                        .Text(new string('-', 34)).AlignCenter();

                    foreach (var item in _cart)
                    {
                        col.Item().Column(itemCol =>
                        {
                            itemCol.Item().Row(row =>
                            {
                                row.RelativeItem()
                                    .Text($"{item.Item.ItemName}  x{item.Quantity}")
                                    .Bold();
                                row.ConstantItem(70).AlignRight()
                                    .Text($"₱{item.Subtotal:N2}").Bold();
                            });

                            string summary = item.Customization.Summary();
                            if (!string.IsNullOrEmpty(summary))
                            {
                                itemCol.Item().PaddingLeft(8)
                                    .Text(summary)
                                    .FontSize(7.5f).Italic();
                            }
                        });

                        col.Item().PaddingVertical(2);
                    }

                    col.Item().PaddingVertical(2)
                        .Text(new string('-', 34)).AlignCenter();

                    col.Item().Row(row =>
                    {
                        row.RelativeItem()
                            .Text("TOTAL").FontSize(11).Bold();
                        row.ConstantItem(70).AlignRight()
                            .Text($"₱{_total:N2}").FontSize(11).Bold();
                    });

                    col.Item().PaddingVertical(3)
                        .Text(new string('-', 34)).AlignCenter();

                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Payment").FontSize(8);
                        row.ConstantItem(70).AlignRight()
                            .Text(_paymentMethod).FontSize(8);
                    });

                    if (_paymentMethod == "Cash")
                    {
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text("Cash Tendered").FontSize(8);
                            row.ConstantItem(70).AlignRight()
                                .Text($"₱{_cash:N2}").FontSize(8);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text("Change").FontSize(8);
                            row.ConstantItem(70).AlignRight()
                                .Text($"₱{_change:N2}").FontSize(8);
                        });
                    }

                    col.Item().PaddingVertical(4)
                        .Text(new string('=', 34)).AlignCenter();

                    col.Item().PaddingTop(4)
                        .Text("Thank you for visiting!").Bold().AlignCenter();
                    col.Item()
                        .Text("Please come again ☕").FontSize(8).AlignCenter();

                    col.Item().PaddingVertical(4)
                        .Text(new string('=', 34)).AlignCenter();
                });
            });
        }

        public static string Save(
            List<OrderItemModel> cart,
            decimal total, decimal cash, decimal change,
            string cashierName, int orderNumber, string paymentMethod)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            string dir = @"C:\Images\Receipts";
            Directory.CreateDirectory(dir);

            int counter = 1;
            string path;
            do
            {
                path = Path.Combine(dir, $"CashierReceipt{counter}.pdf");
                counter++;
            } while (File.Exists(path));

            new CashierReceiptDoc(cart, total, cash, change,
                cashierName, orderNumber, paymentMethod)
                .GeneratePdf(path);

            return path;
        }
    }

    public partial class UC_Receipt : UserControl
    {
        private List<OrderItemModel> _cart = new();
        private decimal _total = 0;
        private decimal _cash = 0;
        private decimal _change = 0;
        private string _paymentMethod = "Cash";
        private string? _pdfPath = null;

        private static readonly DrawingColor Brown = DrawingColor.FromArgb(107, 79, 58);
        private static readonly DrawingColor DarkBrown = DrawingColor.FromArgb(59, 35, 20);
        private static readonly DrawingColor MutedBrown = DrawingColor.FromArgb(160, 130, 100);

        public UC_Receipt() { InitializeComponent(); }

        public UC_Receipt(
            List<OrderItemModel> cart,
            decimal total, decimal cash, decimal change,
            string paymentMethod = "Cash") : this()
        {
            _cart = cart;
            _total = total;
            _cash = cash;
            _change = change;
            _paymentMethod = paymentMethod;

            try
            {
                _pdfPath = CashierReceiptDoc.Save(
                    cart, total, cash, change,
                    SessionManager.CurrentUser.Username,
                    SessionManager.OrderNumber,
                    paymentMethod);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save PDF:\n{ex.Message}",
                    "PDF Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            BuildPreview();
        }

        private void BuildPreview()
        {
            pnlReceipt.Controls.Clear();
            pnlReceipt.BackColor = DrawingColor.White;
            pnlReceipt.AutoScroll = true;

            int w = pnlReceipt.Width - 40;
            int x = 20;
            int y = 20;

            C("─────────────────────────────────────", new DrawingFont("Courier New", 7f), MutedBrown, w, x, ref y);
            C("CAFÉ FILIPINO", new DrawingFont("Segoe UI", 15f, FontStyle.Bold), Brown, w, x, ref y);
            C("2J ELJ AND SON COMMERCIAL BLDG RV5 PH1 CONGRESSIONAL RD BAGUMBONG CALOOCAN CITY", new DrawingFont("Segoe UI", 7.5f), MutedBrown, w, x, ref y);
            C("Tel: (02) 8123-4567", new DrawingFont("Segoe UI", 7.5f), MutedBrown, w, x, ref y);
            y += 4;
            C("─────────────────────────────────────", new DrawingFont("Courier New", 7f), MutedBrown, w, x, ref y);
            y += 4;

            C($"ORDER #{SessionManager.OrderNumber:D3}", new DrawingFont("Segoe UI", 11f, FontStyle.Bold), DarkBrown, w, x, ref y);
            C(DateTime.Now.ToString("MMMM dd, yyyy   hh:mm tt"), new DrawingFont("Segoe UI", 8f), MutedBrown, w, x, ref y);
            C($"Cashier: {SessionManager.CurrentUser.Username}", new DrawingFont("Segoe UI", 8f), MutedBrown, w, x, ref y);
            y += 4;
            D(x, w, ref y);
            y += 4;

            foreach (var item in _cart)
            {
                R($"{item.Item.ItemName}  x{item.Quantity}", $"₱{item.Subtotal:N2}",
                    new DrawingFont("Segoe UI", 9f, FontStyle.Bold), DarkBrown, x, w, ref y);

                string s = item.Customization.Summary();
                if (!string.IsNullOrEmpty(s))
                    L($"  {s}", new DrawingFont("Segoe UI", 7.5f, FontStyle.Italic), MutedBrown, x + 8, w - 8, ref y);
                y += 2;
            }

            y += 4; D(x, w, ref y); y += 4;

            R("TOTAL", $"₱{_total:N2}", new DrawingFont("Segoe UI", 12f, FontStyle.Bold), Brown, x, w, ref y);
            y += 4; D(x, w, ref y); y += 4;

            R("Payment", _paymentMethod, new DrawingFont("Segoe UI", 8.5f), MutedBrown, x, w, ref y);
            if (_paymentMethod == "Cash")
            {
                R("Cash Tendered", $"₱{_cash:N2}", new DrawingFont("Segoe UI", 8.5f), MutedBrown, x, w, ref y);
                R("Change", $"₱{_change:N2}", new DrawingFont("Segoe UI", 8.5f), MutedBrown, x, w, ref y);
            }

            y += 8;
            C("─────────────────────────────────────", new DrawingFont("Courier New", 7f), MutedBrown, w, x, ref y);
            y += 4;
            C("Thank you for visiting!", new DrawingFont("Segoe UI", 9f, FontStyle.Bold), Brown, w, x, ref y);
            C("Please come again ☕", new DrawingFont("Segoe UI", 8f, FontStyle.Italic), MutedBrown, w, x, ref y);
            y += 4;
            C("─────────────────────────────────────", new DrawingFont("Courier New", 7f), MutedBrown, w, x, ref y);

            if (_pdfPath != null)
            {
                y += 10;
                C("PDF saved to C:\\Images\\Receipts", new DrawingFont("Segoe UI", 7f), MutedBrown, w, x, ref y);
            }

            pnlReceipt.Height = y + 20;
        }

        void C(string t, DrawingFont f, DrawingColor c, int w, int x, ref int y)
        {
            var l = new Label { Text = t, Font = f, ForeColor = c, AutoSize = false, Width = w, Height = (int)f.GetHeight() + 8, Location = new DrawingPoint(x, y), TextAlign = ContentAlignment.MiddleCenter, BackColor = DrawingColor.Transparent };
            pnlReceipt.Controls.Add(l); y += l.Height + 1;
        }
        void L(string t, DrawingFont f, DrawingColor c, int x, int w, ref int y)
        {
            var l = new Label { Text = t, Font = f, ForeColor = c, AutoSize = false, Width = w, Height = (int)f.GetHeight() + 6, Location = new DrawingPoint(x, y), TextAlign = ContentAlignment.MiddleLeft, BackColor = DrawingColor.Transparent };
            pnlReceipt.Controls.Add(l); y += l.Height;
        }
        void R(string left, string right, DrawingFont f, DrawingColor c, int x, int w, ref int y)
        {
            int h = (int)f.GetHeight() + 8;
            pnlReceipt.Controls.Add(new Label { Text = left, Font = f, ForeColor = c, AutoSize = false, Width = w * 2 / 3, Height = h, Location = new DrawingPoint(x, y), TextAlign = ContentAlignment.MiddleLeft, BackColor = DrawingColor.Transparent });
            pnlReceipt.Controls.Add(new Label { Text = right, Font = f, ForeColor = c, AutoSize = false, Width = w / 3, Height = h, Location = new DrawingPoint(x + w * 2 / 3, y), TextAlign = ContentAlignment.MiddleRight, BackColor = DrawingColor.Transparent });
            y += h + 2;
        }
        void D(int x, int w, ref int y)
        {
            var l = new Label { Text = new string('-', 52), Font = new DrawingFont("Courier New", 7f), ForeColor = DrawingColor.FromArgb(200, 185, 165), AutoSize = false, Width = w, Height = 14, Location = new DrawingPoint(x, y), TextAlign = ContentAlignment.MiddleCenter, BackColor = DrawingColor.Transparent };
            pnlReceipt.Controls.Add(l); y += 14;
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (_pdfPath != null && File.Exists(_pdfPath))
                Process.Start(new ProcessStartInfo(_pdfPath) { UseShellExecute = true });
            else
                MessageBox.Show("PDF not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ((HomePage)this.ParentForm!).LoadControl(new UC_Cashier());
        }

        private void pnlReceipt_Paint(object sender, PaintEventArgs e) { }
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) { }
    }
}