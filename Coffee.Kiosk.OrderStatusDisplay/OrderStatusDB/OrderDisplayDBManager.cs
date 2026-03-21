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
        //  Called by: Form1 display
        // ─────────────────────────────────────────────────────

        public List<PaymentQueueItem> GetPaymentQueue()
        {
            var list = new List<PaymentQueueItem>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT OrderNumber, ItemName, PaymentMethod
                FROM   display_payment_queue
                ORDER  BY ID ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PaymentQueueItem
                {
                    OrderNumber = reader["OrderNumber"].ToString(),
                    ItemName = reader["ItemName"].ToString(),
                    PaymentMethod = reader["PaymentMethod"].ToString()
                });
            }

            return list;
        }

        // ─────────────────────────────────────────────────────
        //  GET — BEING PREPARED column
        //  Called by: Form1 display
        // ─────────────────────────────────────────────────────

        public List<PreparingQueueItem> GetPreparingQueue()
        {
            var list = new List<PreparingQueueItem>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT OrderNumber, ItemName
                FROM   display_preparing_queue
                ORDER  BY ID ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PreparingQueueItem
                {
                    OrderNumber = reader["OrderNumber"].ToString(),
                    ItemName = reader["ItemName"].ToString()
                });
            }

            return list;
        }

        // ─────────────────────────────────────────────────────
        //  GET — READY FOR PICK-UP column
        //  Called by: Form1 display
        // ─────────────────────────────────────────────────────

        public List<PickupQueueItem> GetPickupQueue()
        {
            var list = new List<PickupQueueItem>();

            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT OrderNumber, ItemName
                FROM   display_pickup_queue
                WHERE  CompletedAt IS NULL
                ORDER  BY ID ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PickupQueueItem
                {
                    OrderNumber = reader["OrderNumber"].ToString(),
                    ItemName = reader["ItemName"].ToString()
                });
            }

            return list;
        }

        // ─────────────────────────────────────────────────────
        //  ADD — new order appears in Please Pay
        //  Called by: Cashier subsystem
        // ─────────────────────────────────────────────────────

        public void AddToPaymentQueue(string orderNumber, string itemName, string paymentMethod)
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO display_payment_queue (OrderNumber, ItemName, PaymentMethod)
                VALUES (@OrderNumber, @ItemName, @PaymentMethod)";

            cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
            cmd.Parameters.AddWithValue("@ItemName", itemName);
            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────
        //  MOVE — payment confirmed → Being Prepared
        //  Called by: Cashier subsystem
        // ─────────────────────────────────────────────────────

        public void MoveToPreparingQueue(string orderNumber, string itemName)
        {
            using var conn = CreateConnection();
            using var tran = conn.BeginTransaction();

            try
            {
                using (var del = conn.CreateCommand())
                {
                    del.Transaction = tran;
                    del.CommandText = @"
                        DELETE FROM display_payment_queue
                        WHERE  OrderNumber = @OrderNumber";
                    del.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    del.ExecuteNonQuery();
                }

                using (var ins = conn.CreateCommand())
                {
                    ins.Transaction = tran;
                    ins.CommandText = @"
                        INSERT INTO display_preparing_queue (OrderNumber, ItemName)
                        VALUES (@OrderNumber, @ItemName)";
                    ins.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    ins.Parameters.AddWithValue("@ItemName", itemName);
                    ins.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        //  MOVE — barista marks done → Ready for Pick-up
        //  Called by: Kitchen subsystem
        // ─────────────────────────────────────────────────────

        public void MoveToPickupQueue(string orderNumber, string itemName)
        {
            using var conn = CreateConnection();
            using var tran = conn.BeginTransaction();

            try
            {
                using (var del = conn.CreateCommand())
                {
                    del.Transaction = tran;
                    del.CommandText = @"
                        DELETE FROM display_preparing_queue
                        WHERE  OrderNumber = @OrderNumber";
                    del.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    del.ExecuteNonQuery();
                }

                using (var ins = conn.CreateCommand())
                {
                    ins.Transaction = tran;
                    ins.CommandText = @"
                        INSERT INTO display_pickup_queue (OrderNumber, ItemName, ReadyAt)
                        VALUES (@OrderNumber, @ItemName, NOW())";
                    ins.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    ins.Parameters.AddWithValue("@ItemName", itemName);
                    ins.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        //  AUTO-COMPLETE — removes card after 5 mins
        //  Called by: Form1 timer every 30 seconds
        // ─────────────────────────────────────────────────────

        public void AutoCompleteExpiredPickups()
        {
            using var conn = CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE display_pickup_queue
                SET    CompletedAt = NOW()
                WHERE  CompletedAt IS NULL
                AND    TIMESTAMPDIFF(MINUTE, ReadyAt, NOW()) >= 5";

            cmd.ExecuteNonQuery();
        }
    }
}