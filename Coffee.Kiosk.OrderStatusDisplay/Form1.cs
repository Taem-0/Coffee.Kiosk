using System;
using System.Drawing;
using System.Windows.Forms;

// ── uncomment when connecting to MySQL database ───────────
// using MySql.Data.MySqlClient;
// using Coffee.Kiosk.CMS.CoffeeKDB;

namespace Coffee.Kiosk.OrderStatusDisplay
{
    public partial class Form1 : Form
    {
        // ══════════════════════════════════════════════════════
        //  DATABASE CONNECTION STRING
        //  uncomment when ready to connect
        // ══════════════════════════════════════════════════════
        // private readonly string _connString =
        //     DBhelper.connectionStringDatabase;

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
            // left=8 top=10 right=8 bottom=10 — inner breathing room
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

            // fill full column width minus flp left+right padding (8+8=16) + small gap
            card.Width = flp.ClientSize.Width - flp.Padding.Left
                                               - flp.Padding.Right
                                               - 4;
            card.Height = 75;

            flp.Controls.Add(card);
        }

        // ══════════════════════════════════════════════════════
        //  FUNCTION 1 — PLEASE PAY
        //  Status = 'CashPayment' or 'GCashPayment'
        // ══════════════════════════════════════════════════════
        private void LoadPaymentOrders()
        {
            flpPay.Controls.Clear();

            // ── HARDCODED TEST DATA ───────────────────────────
            var orders = new[]
            {
                new { OrderId = 41, ItemName = "Caramel Latte · Lg",  Status = "CashPayment"  },
                new { OrderId = 42, ItemName = "Iced Mocha · Med",    Status = "GCashPayment" },
                new { OrderId = 45, ItemName = "Americano · Sm",      Status = "CashPayment"  },
            };

            foreach (var order in orders)
            {
                string badge;
                Color bgColor, fgColor;

                if (order.Status == "GCashPayment")
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
                    $"#{order.OrderId:D3}",
                    order.ItemName,
                    badge,
                    BlueAccent,
                    bgColor, fgColor);
            }

            // ══════════════════════════════════════════════════
            //  DATABASE VERSION — uncomment when ready
            //  comment out hardcoded block above first
            // ══════════════════════════════════════════════════
            // flpPay.Controls.Clear();
            // string sql = @"
            //     SELECT OrderId, ItemName, Status
            //     FROM   Orders
            //     WHERE  Status IN ('CashPayment','GCashPayment')
            //     ORDER  BY OrderId";
            // try
            // {
            //     using (var conn = DBhelper.CreateConnection(_connString))
            //     using (var cmd  = new MySqlCommand(sql, conn))
            //     using (var r    = cmd.ExecuteReader())
            //     {
            //         while (r.Read())
            //         {
            //             int    orderId = Convert.ToInt32(r["OrderId"]);
            //             string item    = r["ItemName"].ToString();
            //             string status  = r["Status"].ToString();
            //             string badge;
            //             Color  bgColor, fgColor;
            //             if (status == "GCashPayment")
            //             { badge = "GCash"; bgColor = GCashBg; fgColor = GCashFg; }
            //             else
            //             { badge = "Cash";  bgColor = CashBg;  fgColor = CashFg;  }
            //             AddCard(flpPay,
            //                 $"#{orderId:D3}", item, badge,
            //                 BlueAccent, bgColor, fgColor);
            //         }
            //     }
            // }
            // catch (Exception ex)
            // { MessageBox.Show("Pay error: " + ex.Message); }
        }

        // ══════════════════════════════════════════════════════
        //  FUNCTION 2 — BEING PREPARED
        //  Status = 'Preparing'
        // ══════════════════════════════════════════════════════
        private void LoadPreparingOrders()
        {
            flpPrep.Controls.Clear();

            // ── HARDCODED TEST DATA ───────────────────────────
            var orders = new[]
            {
                new { OrderId = 38, ItemName = "Flat White · Sm"   },
                new { OrderId = 39, ItemName = "Matcha Latte · Lg" },
                new { OrderId = 40, ItemName = "Cold Brew · Med"   },
            };

            foreach (var order in orders)
            {
                AddCard(flpPrep,
                    $"#{order.OrderId:D3}",
                    order.ItemName,
                    "Brewing",
                    AmberAccent,
                    PrepBg, PrepFg);
            }

            // ══════════════════════════════════════════════════
            //  DATABASE VERSION — uncomment when ready
            //  comment out hardcoded block above first
            // ══════════════════════════════════════════════════
            // flpPrep.Controls.Clear();
            // string sql = @"
            //     SELECT OrderId, ItemName
            //     FROM   Orders
            //     WHERE  Status = 'Preparing'
            //     ORDER  BY OrderId";
            // try
            // {
            //     using (var conn = DBhelper.CreateConnection(_connString))
            //     using (var cmd  = new MySqlCommand(sql, conn))
            //     using (var r    = cmd.ExecuteReader())
            //     {
            //         while (r.Read())
            //         {
            //             int    orderId = Convert.ToInt32(r["OrderId"]);
            //             string item    = r["ItemName"].ToString();
            //             AddCard(flpPrep,
            //                 $"#{orderId:D3}", item, "Brewing",
            //                 AmberAccent, PrepBg, PrepFg);
            //         }
            //     }
            // }
            // catch (Exception ex)
            // { MessageBox.Show("Prep error: " + ex.Message); }
        }

        // ══════════════════════════════════════════════════════
        //  FUNCTION 3 — READY FOR PICK-UP
        //  Status = 'ReadyForPickup'
        // ══════════════════════════════════════════════════════
        private void LoadPickupOrders()
        {
            flpPickup.Controls.Clear();

            // ── HARDCODED TEST DATA ───────────────────────────
            var orders = new[]
            {
                new { OrderId = 35, ItemName = "Cappuccino · Reg" },
                new { OrderId = 36, ItemName = "Espresso · Dbl"   },
            };

            foreach (var order in orders)
            {
                AddCard(flpPickup,
                    $"#{order.OrderId:D3}",
                    order.ItemName,
                    "Pick up",
                    GreenAccent,
                    PickupBg, PickupFg,
                    isPickup: true);
            }

            // ══════════════════════════════════════════════════
            //  DATABASE VERSION — uncomment when ready
            //  comment out hardcoded block above first
            // ══════════════════════════════════════════════════
            // flpPickup.Controls.Clear();
            // string sql = @"
            //     SELECT OrderId, ItemName
            //     FROM   Orders
            //     WHERE  Status = 'ReadyForPickup'
            //     ORDER  BY OrderId";
            // try
            // {
            //     using (var conn = DBhelper.CreateConnection(_connString))
            //     using (var cmd  = new MySqlCommand(sql, conn))
            //     using (var r    = cmd.ExecuteReader())
            //     {
            //         while (r.Read())
            //         {
            //             int    orderId = Convert.ToInt32(r["OrderId"]);
            //             string item    = r["ItemName"].ToString();
            //             AddCard(flpPickup,
            //                 $"#{orderId:D3}", item, "Pick up",
            //                 GreenAccent, PickupBg, PickupFg,
            //                 isPickup: true);
            //         }
            //     }
            // }
            // catch (Exception ex)
            // { MessageBox.Show("Pickup error: " + ex.Message); }
        }
    }
}