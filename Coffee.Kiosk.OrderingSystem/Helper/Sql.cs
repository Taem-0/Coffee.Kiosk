using Coffee.Kiosk.OrderingSystem.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Coffee.Kiosk.OrderingSystem.Sql
{
    internal static class DBInitializer
    {
        private static string? _connectionString;
        internal static string? connectionStringDatabase;

        private static string[] tableCommands =
        {
            // inventory
            @"CREATE TABLE IF NOT EXISTS inventory_item (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                Name VARCHAR(255) UNIQUE NOT NULL,
                Stock Decimal(10, 2) NOT NULL,
                Unit VARCHAR(255) NOT NULL,
                ImagePath VARCHAR(255)
            );",

            // logs
            @"CREATE TABLE IF NOT EXISTS logs (
                ID INT AUTO_INCREMENT PRIMARY KEY,

                Table_Affected VARCHAR(50) NOT NULL,
                Record_ID INT NOT NULL,

                Action ENUM('INSERT','UPDATE','DELETE') NOT NULL,

                Changed_By INT NOT NULL,
                Changed_By_Name VARCHAR(67) NOT NULL,

                Summary VARCHAR(255) NOT NULL,

                Created_At DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
            );",

            // Ordering System
            @"CREATE TABLE IF NOT EXISTS category (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                Name VARCHAR(255) NOT NULL,
                IconPath VARCHAR(255),
                IsShown BOOLEAN NOT NULL DEFAULT 1
            );",

            @"CREATE TABLE IF NOT EXISTS product (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                CategoryID INT NOT NULL,
                Name VARCHAR(255) NOT NULL,
                Price DECIMAL(10,2) NOT NULL,
                ImagePath VARCHAR(255),
                IsCustomizable BOOLEAN NOT NULL DEFAULT 0,
                FOREIGN KEY (CategoryID) REFERENCES category(ID) ON DELETE CASCADE
            );",

            @"CREATE TABLE IF NOT EXISTS product_recipe (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                ProductId INT NOT NULL,
                InventoryItemId INT NOT NULL,
                InventorySubtraction DECIMAL(10,2) NOT NULL,
                FOREIGN KEY (ProductId) REFERENCES product(ID) ON DELETE CASCADE
            );",

            @"CREATE TABLE IF NOT EXISTS modifier_group (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                ProductId INT NOT NULL,
                ParentGroupId INT NULL,
                Name VARCHAR(100),
                SelectionType ENUM('Single','Multiple') NOT NULL,
                Required BOOLEAN NOT NULL DEFAULT 0,
                FOREIGN KEY (ProductId) REFERENCES product(ID) ON DELETE CASCADE,
                FOREIGN KEY (ParentGroupId) REFERENCES modifier_group(ID) ON DELETE CASCADE
                );",

            @"CREATE TABLE IF NOT EXISTS modifier_option (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                GroupId INT NOT NULL,
                Name VARCHAR(100),
                PriceDelta DECIMAL (10, 2) NOT NULL,
                InventorySubtraction Decimal(10, 2) DEFAULT 0,
                InventoryItemId INT,
                TriggersChild BOOLEAN NOT NULL DEFAULT TRUE,
                SubtractFromParent BOOLEAN NOT NULL DEFAULT TRUE,
                SortBy INT,
                FOREIGN KEY (GroupId) REFERENCES modifier_group(ID) ON DELETE CASCADE,
                FOREIGN KEY (InventoryItemId) REFERENCES inventory_item(ID)
                );",


            // customer orders
            @"CREATE TABLE IF NOT EXISTS customer_orders (
                ID INT AUTO_INCREMENT PRIMARY KEY,

                OrderType ENUM('DineIn','TakeOut') NOT NULL,
                Status ENUM('Pending','Paid','Cancelled', 'Completed') NOT NULL DEFAULT 'Pending',
                TotalAmount DECIMAL(10,2) NOT NULL,
                Payment ENUM('Cash','Gcash') NOT NULL DEFAULT 'Cash',

                CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                );",

            @"CREATE TABLE IF NOT EXISTS customer_order_item (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                CustomerOrderId INT NOT NULL,

                ProductId INT,
                ProductName VARCHAR(255) NOT NULL,

                BasePrice DECIMAL(10,2) NOT NULL,
                UnitPrice DECIMAL(10,2) NOT NULL,
                Quantity INT NOT NULL,

                FOREIGN KEY (CustomerOrderId) REFERENCES customer_orders(ID) ON DELETE CASCADE
                );",

            @"CREATE TABLE IF NOT EXISTS customer_order_item_modifier (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                CustomerOrderItemId INT NOT NULL,

                ModifierGroupId INT,
                ModifierOptionId INT,
                ModifierGroupName VARCHAR(100) NOT NULL,
                ModifierOptionName VARCHAR(100) NOT NULL,

                PriceDelta DECIMAL(10,2) NOT NULL,

                FOREIGN KEY (CustomerOrderItemId) REFERENCES customer_order_item(ID) ON DELETE CASCADE
                );",

        };

        internal static void Init(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("Connection string 'Default' is missing in appsettings.json.");

            connectionStringDatabase = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string 'Database' is missing in appsettings.json.");

            CreateDatabase();
        }

        private static void CreateDatabase()
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                using var createDbCmd = connection.CreateCommand();
                createDbCmd.CommandText = "CREATE DATABASE IF NOT EXISTS CoffeeKioskDB;";
                createDbCmd.ExecuteNonQuery();

                using var dbConnection = new MySqlConnection(connectionStringDatabase);
                dbConnection.Open();

                for (int i = 0; i < tableCommands.Length; i++)
                {
                    using var createTableCmd = dbConnection.CreateCommand();
                    createTableCmd.CommandText = tableCommands[i];
                    createTableCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database or tables: {ex.Message}");
                MessageBox.Show("Failed to initialize database\n" + ex.Message);
                throw;
            }
        }
    }

    internal class Queries 
    {
        internal static List<Models.Category.CategoryData> GetAllCategories()
        {
            var result = new List<Models.Category.CategoryData>();

            try
            {
                using var conn = new MySqlConnection(Sql.DBInitializer.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM category;";

                using var row = cmd.ExecuteReader();
                while (row.Read())
                {
                    result.Add(new Models.Category.CategoryData(
                        row.GetInt32("ID"),
                        row.GetString(1),
                        row.IsDBNull(2) ? string.Empty : row.GetString(2),
                        row.GetBoolean(3)
                        ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\033[1;31m{ex}\033[0m");
            }
            return result;
        }

        internal static List<Models.Product.ProductData> GetAllProduct()
        {
            var result = new List<Models.Product.ProductData>();

            try
            {
                using var conn = new MySqlConnection(Sql.DBInitializer.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM product;";

                using var row = cmd.ExecuteReader();
                while (row.Read())
                {
                    result.Add(new Models.Product.ProductData(
                        row.GetInt32(0),
                        row.GetInt32(1),
                        row.GetString(2),
                        row.GetDecimal(3),
                        row.IsDBNull(4) ? string.Empty : row.GetString(4),
                        row.GetBoolean(5)
                        ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\033[1;31m{ex}\033[0m");
            }
            return result;
        }

        internal static List<Models.Product.ModifierGroup> GetAllModifierGroups()
        {
            var result = new List<Models.Product.ModifierGroup>();

            using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = """
                SELECT ID, ProductId, ParentGroupId, Name, SelectionType, Required
                 FROM modifier_group;
            """;

            using var row = cmd.ExecuteReader();
            while (row.Read())
            {
                result.Add(new Models.Product.ModifierGroup(
                    row.GetInt32("ID"),
                    row.GetInt32("ProductId"),
                    row.IsDBNull(2) ? null : row.GetInt32("ParentGroupId"),
                    row.GetString("Name"),
                    Enum.Parse<Models.Product.SelectionType>(row.GetString("SelectionType")),
                    row.GetBoolean("Required")
                ));
            }

            return result;
        }

        internal static List<Models.Product.ModifierOption> GetAllModifierOptions()
        {
            var result = new List<Models.Product.ModifierOption>();

            using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = """
                SELECT ID, GroupId, Name, PriceDelta, InventorySubtraction,
                InventoryItemId, TriggersChild, SortBy
                FROM modifier_option;
            """;

            using var row = cmd.ExecuteReader();
            while (row.Read())
            {
                result.Add(new Models.Product.ModifierOption(
                    row.GetInt32("ID"),
                    row.GetInt32("GroupId"),
                    row.GetString("Name"),
                    row.GetDecimal("PriceDelta"),
                    row.GetDecimal("InventorySubtraction"),
                    row.IsDBNull(5) ? null : row.GetInt32("InventoryItemId"),
                    row.GetBoolean("TriggersChild"),
                    row.GetInt32("SortBy")
                ));
            }

            return result;
        }


        //internal static Models.Product.ProductData? GetProductData(int productId)
        //{
        //    Models.Product.ProductData? result = null;
        //    try
        //    {
        //        using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
        //        conn.Open();

        //        using var cmd = conn.CreateCommand();
        //        cmd.CommandText = @"SELECT * FROM product WHERE ID = @productId";
        //        cmd.Parameters.AddWithValue("@productId", productId);
        //        using var row = cmd.ExecuteReader();
        //        row.Read();
        //        result = new Models.Product.ProductData(
        //            row.GetInt32(0),
        //            row.GetInt32(1),
        //            row.GetString(2),
        //            row.GetDecimal(3),
        //            row.IsDBNull(4) ? string.Empty : row.GetString(4),
        //            row.GetBoolean(5)
        //            );
        //    }
        //    catch(Exception Ex)
        //    {
        //        MessageBox.Show($"Failed to GetProductData for productId: {productId}\n" + Ex);
        //    }
        //    return result;
        //}




        internal static int AddCustomerOrder(Models.Orders order)
        {
            decimal subTotal = order.Items.Sum(i => i.ProductPrice * i.Quantity);

            using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = """
                INSERT INTO customer_orders (OrderType, Status, TotalAmount, Payment)
                VALUES (@orderType, @status, @totalAmount, @payment);
            """;
            cmd.Parameters.AddWithValue("@orderType", order.Type.ToString());
            cmd.Parameters.AddWithValue("@status", "Pending");
            cmd.Parameters.AddWithValue("@totalAmount", subTotal);
            cmd.Parameters.AddWithValue("@payment", order.paymentType.ToString());

            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId;
        }

        internal static bool AddCustomerOrderItem(Models.Orders order, int customerOrderId)
        {
            try
            {
                using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
                conn.Open();

                foreach (var item in order.Items)
                {
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = """
                        INSERT INTO customer_order_item 
                            (CustomerOrderId, ProductId, ProductName, BasePrice, UnitPrice, Quantity)
                        VALUES 
                            (@orderId, @productId, @productName, @basePrice, @unitPrice, @quantity);
                    """;

                    cmd.Parameters.AddWithValue("@orderId", customerOrderId);
                    cmd.Parameters.AddWithValue("@productId", item.ProductId);
                    cmd.Parameters.AddWithValue("@productName", item.ProductName);
                    cmd.Parameters.AddWithValue("@basePrice", item.BasePrice);
                    cmd.Parameters.AddWithValue("@unitPrice", item.ProductPrice);
                    cmd.Parameters.AddWithValue("@quantity", item.Quantity);

                    cmd.ExecuteNonQuery();

                    int itemId = (int)cmd.LastInsertedId;
                    bool modSuccess = AddCustomerOrderItemModifier(item, itemId, conn);
                    if (!modSuccess) return false;
                }
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool AddCustomerOrderItemModifier(
            Models.Orders.OrderItem item,
            int customerOrderItemId,
            MySqlConnection conn)
        {
            try
            {
                foreach (var groupEntry in item.SelectedModifierOptions)
                {
                    int groupId = groupEntry.Key;

                    var group = (
                        from g in Models.Product.modifierGroups
                        where g.Id == groupId
                        select g
                    ).First();

                    foreach (var optionId in groupEntry.Value)
                    {
                        var option = (
                            from o in Models.Product.modifierOption
                            where o.Id == optionId
                            select o
                        ).First();

                        using var cmd = conn.CreateCommand();
                        cmd.CommandText = """
                    INSERT INTO customer_order_item_modifier
                        (CustomerOrderItemId, ModifierGroupId, ModifierOptionId,
                         ModifierGroupName, ModifierOptionName, PriceDelta)
                    VALUES
                        (@itemId, @groupId, @optionId,
                         @groupName, @optionName, @priceDelta);
                """;

                        cmd.Parameters.AddWithValue("@itemId", customerOrderItemId);
                        cmd.Parameters.AddWithValue("@groupId", group.Id);
                        cmd.Parameters.AddWithValue("@optionId", option.Id);
                        cmd.Parameters.AddWithValue("@groupName", group.Name);
                        cmd.Parameters.AddWithValue("@optionName", option.Name);
                        cmd.Parameters.AddWithValue("@priceDelta", option.PriceDelta);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        //internal static bool IsProductAvailable(int productId)
        //{
        //    try
        //    {
        //        using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
        //        conn.Open();

        //        var cmd = conn.CreateCommand();
        //        cmd.CommandText = @"
        //            SELECT 1
        //            FROM product_recipe pr
        //            JOIN inventory_item i 
        //                ON pr.InventoryItemId = i.ID
        //            WHERE pr.ProductId = @productId
        //              AND i.Stock < pr.InventorySubtraction
        //            LIMIT 1;
        //        ";

        //        cmd.Parameters.AddWithValue("@productId", productId);

        //        var result = cmd.ExecuteScalar();

        //        return result == null;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        internal static bool IsProductAvailable(int productId)
        {
            try
            {
                using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
                conn.Open();
                var cmd = conn.CreateCommand();
                // crazy mofo what is this
                cmd.CommandText = @"
                    SELECT 1
                    FROM product p

                    LEFT JOIN (
                        SELECT pr.ProductId
                        FROM product_recipe pr
                        JOIN inventory_item i ON pr.InventoryItemId = i.ID
                        WHERE pr.ProductId = @productId
                          AND i.Stock < pr.InventorySubtraction
                        LIMIT 1
                    ) recipe_fail ON recipe_fail.ProductId = p.ID

                    LEFT JOIN (
                        SELECT mg.ProductId
                        FROM modifier_option mo
                        JOIN modifier_group mg ON mo.GroupId = mg.ID
                        JOIN inventory_item i ON mo.InventoryItemId = i.ID
                        WHERE mg.ProductId = @productId
                          AND mo.InventoryItemId IS NOT NULL
                          AND i.Stock < mo.InventorySubtraction
                        LIMIT 1
                    ) modifier_fail ON modifier_fail.ProductId = p.ID

                    WHERE p.ID = @productId
                      AND (recipe_fail.ProductId IS NOT NULL 
                        OR modifier_fail.ProductId IS NOT NULL);
                "; 
                cmd.Parameters.AddWithValue("@productId", productId);
                var result = cmd.ExecuteScalar();

                return result == null;
            }
            catch
            {
                return false;
            }
        }


        internal static bool CheckIfDatabaseChanged()
        {
            try
            {
                using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT 1
                    FROM logs
                    WHERE Table_Affected != 'ACCOUNTS'
                      AND Created_At > @lastCheck
                    LIMIT 1;
                ";

                cmd.Parameters.AddWithValue("@lastCheck", AuditLogs.currentDateTime);

                var result = cmd.ExecuteScalar();

                return result != null;
            }
            catch 
            {
                return false;
            }
        }
        internal static Models.UiAssets.Shop? GetAssets()
        {
            try
            {
                using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = """
                SELECT * FROM shop;
                """;

                using var row = cmd.ExecuteReader();
                if (row.Read())
                {
                    return new Models.UiAssets.Shop(
                        row.GetString("ShopName"),
                        row.GetString("ThemeMode"),
                        row.GetString("Primary_Color"),
                        row.GetString("DarkPrimary_Color"),
                        row.GetString("Secondary_Color"),
                        row.GetString("Background_Color"),
                        row.GetString("Accent_Color"),
                        row.IsDBNull(8) ? "" : row.GetString(8)
                        );
                }
                return null;

            }catch (Exception ex)
            {
                MessageBox.Show($"Error\n{ex.Message}");
                return null;
            }
        }

        internal static List<Models.Ads.Banners> GetAds()
        {
            var result = new List<Models.Ads.Banners>();
            try
            {
                using var conn = new MySqlConnection(DBInitializer.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = """
                SELECT * FROM kiosk_banners;
                """;

                using var row = cmd.ExecuteReader();
                while(row.Read())
                {
                    var placement = row.GetString("Placement") switch
                    {
                        "Starting Screen" => Models.Ads.AdPlacement.STARTING_SCREEN,
                        "Top Banner" => Models.Ads.AdPlacement.TOP_BANNER,
                        "Home Page Banner 1" => Models.Ads.AdPlacement.HOME_PAGE_BANNER_1,
                        "Home Page Banner 2" => Models.Ads.AdPlacement.HOME_PAGE_BANNER_2,
                        _ => Models.Ads.AdPlacement.HOME_PAGE_BANNER_1
                    };

                    result.Add(new Models.Ads.Banners(
                        row.GetInt32("ID"),
                        row.GetString("FilePath"),
                        placement,
                        row.GetInt32("ID")
                        ));
                }

            }catch (Exception ex)
            {
                MessageBox.Show($"Error\n{ex.Message}");
            }
            return result;
        }

    }
}
