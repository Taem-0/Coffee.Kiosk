using System;
using System.Drawing;
using System.Windows.Forms;
using Coffee.Kiosk.OrderStatusDisplay.OrderStatusDB;
using MySql.Data.MySqlClient;

namespace Coffee.Kiosk.OrderStatusDisplay
{
    public partial class Form1 : Form
    {
        private readonly OrderDisplayDBManager _db = new OrderDisplayDBManager();

        static readonly Color BlueAccent = Color.FromArgb(59, 79, 212);
        static readonly Color AmberAccent = Color.FromArgb(122, 74, 0);
        static readonly Color GreenAccent = Color.FromArgb(26, 92, 42);

        static readonly Color CashBg = Color.FromArgb(59, 79, 212);
        static readonly Color CashFg = Color.FromArgb(220, 226, 255);
        static readonly Color GCashBg = Color.FromArgb(91, 45, 158);
        static readonly Color GCashFg = Color.FromArgb(220, 185, 255);
        static readonly Color PrepBg = Color.FromArgb(122, 74, 0);
        static readonly Color PrepFg = Color.FromArgb(255, 208, 128);
        static readonly Color PickupBg = Color.FromArgb(26, 92, 42);
        static readonly Color PickupFg = Color.FromArgb(134, 239, 172);

        private string _lastPrimaryColor = "";
        private string _lastLogoPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

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

            var autoCompleteTimer = new System.Windows.Forms.Timer();
            autoCompleteTimer.Interval = 30000;
            autoCompleteTimer.Tick += (s, ev) =>
            {
                _db.AutoCompleteExpiredPickups();
                LoadPickupOrders();
            };
            autoCompleteTimer.Start();

            var themeTimer = new System.Windows.Forms.Timer();
            themeTimer.Interval = 2000;
            themeTimer.Tick += (s, ev) => ApplyTheme();
            themeTimer.Start();

            ApplyTheme();

            LoadPaymentOrders();
            LoadPreparingOrders();
            LoadPickupOrders();

            this.Resize += (s, ev) =>
            {
                LoadPaymentOrders();
                LoadPreparingOrders();
                LoadPickupOrders();
            };
        }

        private void ApplyTheme()
        {
            try
            {
                using var conn = new MySqlConnection("Server=localhost;Database=CoffeeKioskDB;Uid=root;Pwd=;");
                conn.Open();

                using var cmd = new MySqlCommand("SELECT Primary_Color, LogoPath FROM shop LIMIT 1", conn);
                using var reader = cmd.ExecuteReader();

                if (!reader.Read()) return;

                var primary = reader["Primary_Color"]?.ToString() ?? "";
                var logo = reader["LogoPath"]?.ToString() ?? "";

                if (primary == _lastPrimaryColor && logo == _lastLogoPath)
                    return;

                _lastPrimaryColor = primary;
                _lastLogoPath = logo;

                if (!string.IsNullOrEmpty(primary))
                {
                    var color = ColorTranslator.FromHtml(primary);

                    this.BackColor = color;

                    pnlHeader.BackColor = color;
                    pnlPay.BackColor = color;
                    pnlPrep.BackColor = color;
                    pnlPickup.BackColor = color;
                    tableLayoutPanel1.BackColor = color;
                }

                if (!string.IsNullOrEmpty(logo) && System.IO.File.Exists(logo))
                {
                    using var img = Image.FromFile(logo);
                    pictureBox1.Image = new Bitmap(img);
                }
            }
            catch { }
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
        }

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

            card.Width = flp.ClientSize.Width - flp.Padding.Left
                                               - flp.Padding.Right - 4;
            card.Height = 75;

            flp.Controls.Add(card);
        }

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

                    if (order.PaymentMethod == "Gcash")
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