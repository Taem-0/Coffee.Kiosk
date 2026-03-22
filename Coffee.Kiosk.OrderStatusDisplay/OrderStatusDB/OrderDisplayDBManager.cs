using System;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
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
        //  Status: Pending (case-insensitive)
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
                    COALESCE(co.PaymentMethod, 'cash')  AS PaymentMethod
                FROM customer_orders co
                JOIN customer_order_item coi ON coi.CustomerOrderId = co.ID
                WHERE LOWER(co.Status) = 'pending'
                GROUP BY co.ID, co.PaymentMethod
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
        //  Status: Paid (case-insensitive)
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
                WHERE LOWER(co.Status) = 'paid'
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
        //  Status: Completed (case-insensitive)
        //  Shows order immediately when completed
        //  Hides after 5 minutes automatically
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
                WHERE LOWER(co.Status) = 'completed'
                AND  (
                        co.UpdatedAt IS NULL
                        OR TIMESTAMPDIFF(MINUTE, co.UpdatedAt, NOW()) < 5
                     )
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
                WHERE  LOWER(co.Status) = 'completed'
                AND    co.UpdatedAt IS NOT NULL
                AND    TIMESTAMPDIFF(MINUTE, co.UpdatedAt, NOW()) >= 5";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                expiredOrders.Add($"#{reader["OrderNumber"]}");
            }

            return expiredOrders;
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-COMPLETE — archives cards after 5 min fade
        //  Called by: Form1 timer every 30 seconds
        // ─────────────────────────────────────────────────────
        public void AutoCompleteExpiredPickups()
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE customer_orders
                SET    Status    = 'archived'
                WHERE  LOWER(Status) = 'completed'
                AND    UpdatedAt IS NOT NULL
                AND    TIMESTAMPDIFF(MINUTE, UpdatedAt, NOW()) >= 5";

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-ADD — cashier confirms payment
        //  Moves: pending → paid
        //  Called by: Cashier subsystem
        // ─────────────────────────────────────────────────────
        public void ConfirmPayment(string orderNumber)
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE customer_orders
                SET    Status    = 'paid',
                       UpdatedAt = NOW()
                WHERE  ID        = @OrderNumber
                AND    LOWER(Status) = 'pending'";

            cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-ADD — barista marks order done
        //  Moves: paid → completed
        //  Called by: Kitchen subsystem
        // ─────────────────────────────────────────────────────
        public void MarkAsReady(string orderNumber)
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE customer_orders
                SET    Status    = 'completed',
                       UpdatedAt = NOW()
                WHERE  ID        = @OrderNumber
                AND    LOWER(Status) = 'paid'";

            cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
            cmd.ExecuteNonQuery();
        }
    }
}