using MySql.Data.MySqlClient;
using System;

namespace Coffee.Kiosk.Cashier.CashierDBHelper
{
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
            string sql = @"SELECT IFNULL(MAX(CAST(SUBSTRING(OrderNumber, 2) AS UNSIGNED)), 0) + 1
                           FROM display_preparing_queue
                           WHERE OrderNumber LIKE 'C%'";
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void MoveToDisplayPreparingQueue(string orderNumber, string itemName)
        {
            using var conn = GetConnection();
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                var del = new MySqlCommand(
                    "DELETE FROM display_payment_queue WHERE OrderNumber = @num",
                    conn, tx);
                del.Parameters.AddWithValue("@num", orderNumber);
                del.ExecuteNonQuery();

                var ins = new MySqlCommand(
                    "INSERT INTO display_preparing_queue (OrderNumber, ItemName) VALUES (@num, @item)",
                    conn, tx);
                ins.Parameters.AddWithValue("@num", orderNumber);
                ins.Parameters.AddWithValue("@item", itemName);
                ins.ExecuteNonQuery();

                tx.Commit();
            }
            catch { tx.Rollback(); throw; }
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

        public static (string ShopName, string? LogoPath) GetShopInfo()
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT ShopName, LogoPath FROM Shop LIMIT 1;";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string name = reader.IsDBNull(0) ? "Coffee Kiosk" : reader.GetString(0);
                string? path = reader.IsDBNull(1) ? null : reader.GetString(1);
                return (name, path);
            }
            return ("Coffee Kiosk", null);
        }
    }
}