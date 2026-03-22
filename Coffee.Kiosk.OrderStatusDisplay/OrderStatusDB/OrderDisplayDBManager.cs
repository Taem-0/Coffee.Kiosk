using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Coffee.Kiosk.OrderStatusDisplay.OrderStatusDB
{
    internal class OrderDisplayDBManager
    {
        private readonly string _connectionString =
            "Server=localhost;Database=CoffeeKioskDB;Uid=root;Pwd=;";

        private MySqlConnection CreateConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        // ─────────────────────────────────────────────────────
        //  MODELS
        // ─────────────────────────────────────────────────────
        public class PaymentQueueItem
        {
            public string? OrderNumber { get; set; }
            public string? ItemName { get; set; }
            public string? PaymentMethod { get; set; }
        }

        public class PreparingQueueItem
        {
            public string? OrderNumber { get; set; }
            public string? ItemName { get; set; }
        }

        public class PickupQueueItem
        {
            public string? OrderNumber { get; set; }
            public string? ItemName { get; set; }
        }

        // ─────────────────────────────────────────────────────
        //  GET — PLEASE PAY column
        //  Status: Pending
        //  Hides after 10 minutes
        //  Called by: Form1 display
        // ─────────────────────────────────────────────────────
        public List<PaymentQueueItem> GetPaymentQueue()
        {
            var list = new List<PaymentQueueItem>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT
                    co.ID                               AS OrderNumber,
                    GROUP_CONCAT(coi.ProductName
                        ORDER BY coi.ID
                        SEPARATOR ', ')                 AS ItemName,
                    COALESCE(co.Payment, 'Cash')        AS PaymentMethod
                FROM customer_orders co
                JOIN customer_order_item coi ON coi.CustomerOrderId = co.ID
                WHERE co.Status = 'Pending'
                AND   co.CreatedAt IS NOT NULL
                AND   TIMESTAMPDIFF(MINUTE, co.CreatedAt, NOW()) < 10
                GROUP BY co.ID, co.Payment
                ORDER BY co.ID ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PaymentQueueItem
                {
                    OrderNumber = $"#{reader["OrderNumber"]}",
                    ItemName = reader["ItemName"].ToString(),
                    PaymentMethod = reader["PaymentMethod"].ToString()
                });
            }

            return list;
        }

        // ─────────────────────────────────────────────────────
        //  GET — BEING PREPARED column
        //  Status: Paid
        //  Called by: Form1 display
        // ─────────────────────────────────────────────────────
        public List<PreparingQueueItem> GetPreparingQueue()
        {
            var list = new List<PreparingQueueItem>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT
                    co.ID                           AS OrderNumber,
                    GROUP_CONCAT(coi.ProductName
                        ORDER BY coi.ID
                        SEPARATOR ', ')             AS ItemName
                FROM customer_orders co
                JOIN customer_order_item coi ON coi.CustomerOrderId = co.ID
                WHERE co.Status = 'Paid'
                GROUP BY co.ID
                ORDER BY co.ID ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PreparingQueueItem
                {
                    OrderNumber = $"#{reader["OrderNumber"]}",
                    ItemName = reader["ItemName"].ToString()
                });
            }

            return list;
        }

        // ─────────────────────────────────────────────────────
        //  GET — READY FOR PICK-UP column
        //  Status: Completed
        //  Hides after 5 minutes using CreatedAt
        //  Called by: Form1 display
        // ─────────────────────────────────────────────────────
        public List<PickupQueueItem> GetPickupQueue()
        {
            var list = new List<PickupQueueItem>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT
                    co.ID                           AS OrderNumber,
                    GROUP_CONCAT(coi.ProductName
                        ORDER BY coi.ID
                        SEPARATOR ', ')             AS ItemName
                FROM customer_orders co
                JOIN customer_order_item coi ON coi.CustomerOrderId = co.ID
                WHERE co.Status = 'Completed'
                AND   co.CreatedAt IS NOT NULL
                AND   TIMESTAMPDIFF(MINUTE, co.CreatedAt, NOW()) < 5
                GROUP BY co.ID
                ORDER BY co.ID ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PickupQueueItem
                {
                    OrderNumber = $"#{reader["OrderNumber"]}",
                    ItemName = reader["ItemName"].ToString()
                });
            }

            return list;
        }

        // ─────────────────────────────────────────────────────
        //  GET — expired pickup orders (5 mins reached)
        //  Used by Form1 timer to trigger fade animation
        //  Called by: Form1 timer every 30 seconds
        // ─────────────────────────────────────────────────────
        public List<string> GetExpiredPickupOrderNumbers()
        {
            var expiredOrders = new List<string>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT co.ID AS OrderNumber
                FROM   customer_orders co
                WHERE  co.Status = 'Completed'
                AND    co.CreatedAt IS NOT NULL
                AND    TIMESTAMPDIFF(MINUTE, co.CreatedAt, NOW()) >= 5";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                expiredOrders.Add($"#{reader["OrderNumber"]}");

            return expiredOrders;
        }

        // ─────────────────────────────────────────────────────
        //  GET — expired payment orders (10 mins reached)
        //  Used by Form1 timer to trigger fade animation
        //  Called by: Form1 timer every 30 seconds
        // ─────────────────────────────────────────────────────
        public List<string> GetExpiredPaymentOrderNumbers()
        {
            var expiredOrders = new List<string>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT co.ID AS OrderNumber
                FROM   customer_orders co
                WHERE  co.Status = 'Pending'
                AND    co.CreatedAt IS NOT NULL
                AND    TIMESTAMPDIFF(MINUTE, co.CreatedAt, NOW()) >= 10";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                expiredOrders.Add($"#{reader["OrderNumber"]}");

            return expiredOrders;
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-CANCEL — completed orders after 5 mins
        //  Called by: Form1 timer every 30 seconds
        // ─────────────────────────────────────────────────────
        public void AutoCancelExpiredPickups()
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE customer_orders
                SET    Status = 'Cancelled'
                WHERE  Status = 'Completed'
                AND    CreatedAt IS NOT NULL
                AND    TIMESTAMPDIFF(MINUTE, CreatedAt, NOW()) >= 5";

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-CANCEL — pending orders after 10 mins
        //  Called by: Form1 timer every 30 seconds
        // ─────────────────────────────────────────────────────
        public void AutoCancelExpiredPayments()
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE customer_orders
                SET    Status = 'Cancelled'
                WHERE  Status = 'Pending'
                AND    CreatedAt IS NOT NULL
                AND    TIMESTAMPDIFF(MINUTE, CreatedAt, NOW()) >= 10";

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-ADD — cashier confirms payment
        //  Moves: Pending → Paid
        //  Called by: Cashier subsystem
        // ─────────────────────────────────────────────────────
        public void ConfirmPayment(string orderNumber)
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE customer_orders
                SET    Status    = 'Paid',
                       UpdatedAt = NOW()
                WHERE  ID        = @OrderNumber
                AND    Status    = 'Pending'";

            cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-ADD — barista marks order done
        //  Moves: Paid → Completed
        //  Called by: Kitchen subsystem
        // ─────────────────────────────────────────────────────
        public void MarkAsReady(string orderNumber)
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE customer_orders
                SET    Status    = 'Completed',
                       UpdatedAt = NOW()
                WHERE  ID        = @OrderNumber
                AND    Status    = 'Paid'";

            cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
            cmd.ExecuteNonQuery();
        }
    }
}