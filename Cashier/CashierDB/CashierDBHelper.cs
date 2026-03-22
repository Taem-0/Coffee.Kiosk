using MySql.Data.MySqlClient;
using System;
using System.Drawing;

namespace Coffee.Kiosk.Cashier.CashierDBHelper
{
    public class ShopTheme
    {
        public string ShopName { get; set; } = "Coffee Kiosk";
        public string? LogoPath { get; set; }
        public Color PrimaryColor { get; set; } = Color.FromArgb(107, 79, 58);
        public Color DarkPrimaryColor { get; set; } = Color.FromArgb(61, 33, 26);
        public Color SecondaryColor { get; set; } = Color.FromArgb(160, 120, 86);
        public Color BackgroundColor { get; set; } = Color.FromArgb(245, 245, 220);
        public Color AccentColor { get; set; } = Color.FromArgb(203, 183, 153);
    }

    public static class CashierDBHelper
    {
        private const string ConnectionString =
            "Server=localhost;Database=CoffeeKioskDB;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static int OpenShift(int employeeId, string employeeName)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = @"INSERT INTO EmployeeSales 
                               (EmployeeId, EmployeeName, TotalSales, ShiftDate, ShiftStart)
                           VALUES (@empId, @empName, 0, @shiftDate, @shiftStart);
                           SELECT LAST_INSERT_ID();";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@empId", employeeId);
            cmd.Parameters.AddWithValue("@empName", employeeName);
            cmd.Parameters.AddWithValue("@shiftDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@shiftStart", DateTime.Now);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void AddToSales(int salesId, decimal amount)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "UPDATE EmployeeSales SET TotalSales = TotalSales + @amount WHERE SalesId = @id;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@id", salesId);
            cmd.ExecuteNonQuery();
        }

        public static void CloseShift(int salesId)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "UPDATE EmployeeSales SET ShiftEnd = @shiftEnd WHERE SalesId = @id;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@shiftEnd", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", salesId);
            cmd.ExecuteNonQuery();
        }

        public static int GetNextCashierOrderNumber()
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = @"SELECT IFNULL(MAX(ID), 0) + 1 FROM customer_orders;";
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void DeductInventoryForOrder(int orderId, MySqlConnection conn, MySqlTransaction tx)
        {
            string sql = @"
                UPDATE inventory_item ii
                INNER JOIN product_recipe pr ON pr.InventoryItemId = ii.ID
                INNER JOIN customer_order_item coi ON coi.ProductId = pr.ProductId
                SET ii.Stock = ii.Stock - (pr.InventorySubtraction * coi.Quantity)
                WHERE coi.CustomerOrderId = @orderId;";
            using var cmd = new MySqlCommand(sql, conn, tx);
            cmd.Parameters.AddWithValue("@orderId", orderId);
            cmd.ExecuteNonQuery();
        }

        public static void DeductInventoryForOrder(int orderId)
        {
            using var conn = GetConnection();
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                DeductInventoryForOrder(orderId, conn, tx);
                tx.Commit();
            }
            catch { tx.Rollback(); throw; }
        }

        // Auto-cancels kiosk orders that have been Pending for too long.
        // Only touches Status = 'Pending' so Paid/Completed/Cancelled are never affected.
        public static void CancelExpiredKioskOrders(int minutesOld = 10)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = @"UPDATE customer_orders 
                           SET Status = 'Cancelled'
                           WHERE Status = 'Pending'
                           AND TIMESTAMPDIFF(MINUTE, CreatedAt, NOW()) >= @minutes;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@minutes", minutesOld);
            cmd.ExecuteNonQuery();
        }

        public static ShopTheme GetShopTheme()
        {
            var theme = new ShopTheme();
            try
            {
                using var conn = GetConnection();
                conn.Open();
                string sql = @"SELECT ShopName, LogoPath, Primary_Color, DarkPrimary_Color,
                                      Secondary_Color, Background_Color, Accent_Color
                               FROM shop LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    theme.ShopName = reader.IsDBNull(0) ? "Coffee Kiosk" : reader.GetString(0);
                    theme.LogoPath = reader.IsDBNull(1) ? null : reader.GetString(1);
                    theme.PrimaryColor = ParseColor(reader.IsDBNull(2) ? "#6B4F3A" : reader.GetString(2), Color.FromArgb(107, 79, 58));
                    theme.DarkPrimaryColor = ParseColor(reader.IsDBNull(3) ? "#3D211A" : reader.GetString(3), Color.FromArgb(61, 33, 26));
                    theme.SecondaryColor = ParseColor(reader.IsDBNull(4) ? "#A07856" : reader.GetString(4), Color.FromArgb(160, 120, 86));
                    theme.BackgroundColor = ParseColor(reader.IsDBNull(5) ? "#F5F5DC" : reader.GetString(5), Color.FromArgb(245, 245, 220));
                    theme.AccentColor = ParseColor(reader.IsDBNull(6) ? "#CBB799" : reader.GetString(6), Color.FromArgb(203, 183, 153));
                }
            }
            catch { }
            return theme;
        }

        private static Color ParseColor(string hex, Color fallback)
        {
            try { return ColorTranslator.FromHtml(hex); }
            catch { return fallback; }
        }

        public static (string ShopName, string? LogoPath) GetShopInfo()
        {
            var theme = GetShopTheme();
            return (theme.ShopName, theme.LogoPath);
        }
    }
}