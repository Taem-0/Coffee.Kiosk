using MySql.Data.MySqlClient;

namespace Coffee.Kiosk.Cashier.CashierDBHelper
{
    // One row in the pending orders list
    public class KioskOrderSummary
    {
        public int OrderId { get; set; }
        public string OrderType { get; set; } = "";
        public decimal TotalAmount { get; set; }
    }

    // One item inside a kiosk order
    public class KioskOrderItem
    {
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public List<string> Modifiers { get; set; } = new();
    }

    // Modifier group (e.g. "Size", "Milk")
    public class ModifierGroupModel
    {
        public int GroupId { get; set; }
        public string Name { get; set; } = "";
        public string SelectionType { get; set; } = "Single";
        public bool Required { get; set; }
        public List<ModifierOptionModel> Options { get; set; } = new();
    }

    // One option inside a modifier group (e.g. "Small", "Oat milk")
    public class ModifierOptionModel
    {
        public int OptionId { get; set; }
        public string Name { get; set; } = "";
        public decimal PriceDelta { get; set; }
    }

    public static class KioskOrderDbManager
    {
        // Returns all Pending orders from the kiosk
        public static List<KioskOrderSummary> GetPendingOrders()
        {
            var list = new List<KioskOrderSummary>();
            using var conn = CashierDBHelper.GetConnection();
            conn.Open();

            var cmd = new MySqlCommand(
                "SELECT ID, OrderType, TotalAmount " +
                "FROM customer_orders " +
                "WHERE Status = 'Pending' " +
                "ORDER BY ID ASC", conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new KioskOrderSummary
                {
                    OrderId = reader.GetInt32("ID"),
                    OrderType = reader.GetString("OrderType"),
                    TotalAmount = reader.GetDecimal("TotalAmount")
                });
            }
            return list;
        }

        // Returns count of pending orders (for the bell badge)
        public static int GetPendingCount()
        {
            using var conn = CashierDBHelper.GetConnection();
            conn.Open();
            var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM customer_orders WHERE Status = 'Pending'", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Returns all items + modifiers for a given order ID
        public static List<KioskOrderItem> GetOrderItems(int orderId)
        {
            var items = new List<KioskOrderItem>();
            using var conn = CashierDBHelper.GetConnection();
            conn.Open();

            // Get line items
            var cmdItems = new MySqlCommand(
                "SELECT ID, ProductName, Quantity, UnitPrice " +
                "FROM customer_order_item " +
                "WHERE CustomerOrderId = @oid", conn);
            cmdItems.Parameters.AddWithValue("@oid", orderId);

            var itemIds = new List<(int Id, KioskOrderItem Item)>();
            using (var r = cmdItems.ExecuteReader())
            {
                while (r.Read())
                {
                    var item = new KioskOrderItem
                    {
                        ProductName = r.GetString("ProductName"),
                        Quantity = r.GetInt32("Quantity"),
                        UnitPrice = r.GetDecimal("UnitPrice")
                    };
                    itemIds.Add((r.GetInt32("ID"), item));
                    items.Add(item);
                }
            }

            // Get modifiers for each item
            foreach (var (id, item) in itemIds)
            {
                var cmdMod = new MySqlCommand(
                    "SELECT ModifierGroupName, ModifierOptionName " +
                    "FROM customer_order_item_modifier " +
                    "WHERE CustomerOrderItemId = @itemId", conn);
                cmdMod.Parameters.AddWithValue("@itemId", id);

                using var r2 = cmdMod.ExecuteReader();
                while (r2.Read())
                {
                    item.Modifiers.Add(
                        $"{r2.GetString("ModifierGroupName")}: {r2.GetString("ModifierOptionName")}");
                }
            }

            return items;
        }

        // Returns all products from the DB for the cashier menu
        public static List<Coffee.Kiosk.Cashier.ModelClassHelper.MenuItemModel> GetMenuItems()
        {
            var list = new List<Coffee.Kiosk.Cashier.ModelClassHelper.MenuItemModel>();
            using var conn = CashierDBHelper.GetConnection();
            conn.Open();

            var cmd = new MySqlCommand(
                @"SELECT p.ID, p.Name, p.Price, c.Name AS CategoryName
                  FROM product p
                  JOIN category c ON p.CategoryID = c.ID
                  ORDER BY c.Name, p.Name", conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Coffee.Kiosk.Cashier.ModelClassHelper.MenuItemModel
                {
                    ItemID = reader.GetInt32("ID"),
                    ItemName = reader.GetString("Name"),
                    Price = reader.GetDecimal("Price"),
                    Category = reader.GetString("CategoryName")
                });
            }
            return list;
        }

        // Returns modifier groups + options for a product from the DB
        public static List<ModifierGroupModel> GetProductModifiers(int productId)
        {
            var groups = new List<ModifierGroupModel>();
            using var conn = CashierDBHelper.GetConnection();
            conn.Open();

            var cmdGroups = new MySqlCommand(
                "SELECT ID, Name, SelectionType, Required " +
                "FROM modifier_group " +
                "WHERE ProductId = @pid AND ParentGroupId IS NULL " +
                "ORDER BY ID", conn);
            cmdGroups.Parameters.AddWithValue("@pid", productId);

            var groupIds = new List<(int Id, ModifierGroupModel Group)>();
            using (var r = cmdGroups.ExecuteReader())
            {
                while (r.Read())
                {
                    var g = new ModifierGroupModel
                    {
                        GroupId = r.GetInt32("ID"),
                        Name = r.GetString("Name"),
                        SelectionType = r.GetString("SelectionType"),
                        Required = r.GetBoolean("Required")
                    };
                    groupIds.Add((g.GroupId, g));
                    groups.Add(g);
                }
            }

            foreach (var (gid, group) in groupIds)
            {
                var cmdOpts = new MySqlCommand(
                    "SELECT ID, Name, PriceDelta " +
                    "FROM modifier_option " +
                    "WHERE GroupId = @gid " +
                    "ORDER BY COALESCE(SortBy, ID)", conn);
                cmdOpts.Parameters.AddWithValue("@gid", gid);

                using var r2 = cmdOpts.ExecuteReader();
                while (r2.Read())
                {
                    group.Options.Add(new ModifierOptionModel
                    {
                        OptionId = r2.GetInt32("ID"),
                        Name = r2.GetString("Name"),
                        PriceDelta = r2.GetDecimal("PriceDelta")
                    });
                }
            }

            return groups;
        }

        // Marks an order as Paid after cashier confirms
        public static void MarkOrderPaid(int orderId)
        {
            using var conn = CashierDBHelper.GetConnection();
            conn.Open();
            var cmd = new MySqlCommand(
                "UPDATE customer_orders SET Status = 'Paid' WHERE ID = @oid", conn);
            cmd.Parameters.AddWithValue("@oid", orderId);
            cmd.ExecuteNonQuery();
        }
    }
}