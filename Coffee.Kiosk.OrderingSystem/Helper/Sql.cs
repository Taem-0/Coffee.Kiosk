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
            @"CREATE TABLE IF NOT EXISTS accounts (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                First_Name VARCHAR(100) NOT NULL,
                Middle_Name VARCHAR(100) NOT NULL,
                Last_Name VARCHAR(100) NOT NULL,
                Phone_Number VARCHAR(25) NOT NULL,
                Email_Address VARCHAR(255) NOT NULL,
                Emergency_First_Name VARCHAR(100) NOT NULL,
                Emergency_Last_Name VARCHAR(100) NOT NULL,
                Emergency_Number VARCHAR(20) NOT NULL,
                Job_Title VARCHAR(50) NOT NULL,
                Role ENUM('EMPLOYEE', 'MANAGER', 'OWNER') NOT NULL,
                Department ENUM('OPERATIONS', 'MANAGEMENT', 'ADMINISTRATION') 
                    NOT NULL DEFAULT 'OPERATIONS',
                EmploymentType ENUM('FULL_TIME', 'PART_TIME', 'CONTRACT') 
                    NOT NULL DEFAULT 'FULL_TIME',
                Status ENUM('ACTIVE','DEACTIVATED') 
                    NOT NULL DEFAULT 'ACTIVE',
                Profile_Picture_Path VARCHAR(255) NULL,
                Password_Hash VARCHAR(255) NOT NULL,
                Password_Salt VARCHAR(255) NOT NULL,
                Is_First_Login BOOLEAN NOT NULL DEFAULT 1,
                Password_Reset_Requested BOOLEAN NOT NULL DEFAULT 0
            );",

            @"CREATE TABLE IF NOT EXISTS shop (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                ShopName VARCHAR(100) NOT NULL,
                ThemeMode ENUM('default', 'custom') NOT NULL DEFAULT 'default',
                Primary_Color VARCHAR(10) NOT NULL,
                DarkPrimary_Color VARCHAR(10) NOT NULL,
                Secondary_Color VARCHAR(10) NOT NULL,
                Background_Color VARCHAR(10) NOT NULL,
                Accent_Color VARCHAR(10) NOT NULL,
                LogoPath VARCHAR(255) NULL
            );",

            @"INSERT INTO shop (
                ShopName, ThemeMode, Primary_Color, DarkPrimary_Color, Secondary_Color, Background_Color, Accent_Color
            )
            SELECT 'My Coffee Shop', 'default', '#6F4D38', '#3D211A', '#A07856', '#F5F5DC', '#CBB799'
            WHERE NOT EXISTS (SELECT 1 FROM shop);",


            // inventory
            @"CREATE TABLE IF NOT EXISTS inventory_item (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                Name VARCHAR(255) UNIQUE NOT NULL,
                Stock Decimal(10, 2) NOT NULL,
                Unit VARCHAR(255) NOT NULL,
                ImagePath VARCHAR(255)
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
                Status ENUM('Pending','Paid','Cancelled') NOT NULL DEFAULT 'Pending',
                TotalAmount DECIMAL(10,2) NOT NULL,

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
                );"
        };

        // OrderSummary Json format :
        //{
        //  "items": [
        //    {
        //      "productId": 1,
        //      "productName": "Americano",
        //      "basePrice": 120.00,
        //      "quantity": 2,
        //      "modifiers": [
        //        {
        //          "groupId": 1,
        //          "groupName": "Size",
        //          "optionId": 2,
        //          "optionName": "Large",
        //          "priceDelta": 30.00
        //        },
        //        {
        //          "groupId": 2,
        //          "groupName": "Sugar",
        //          "optionId": [5],
        //          "optionName": "[Muscovado]",
        //          "priceDelta": 3.00
        //        }
        //      ],
        //      "itemTotal": 306.00
        //    },
        //      "productId": 2,
        //      "productName": "Stuff",
        //      "basePrice": 120.00,
        //      "quantity": 1,
        //      "modifiers": [
        //        {
        //          "groupId": 1,
        //          "groupName": "Size",
        //          "optionId": [2, 3],
        //          "optionName": "[stuff1, stuff2]",
        //          "priceDelta": 30.00
        //        },
        //      ],
        //      "itemTotal": 306.00
        //  ],
        //  "subtotal": 306.00
        //}

                

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
                INSERT INTO customer_orders (OrderType, Status, TotalAmount)
                VALUES (@orderType, @status, @totalAmount);
            """;
            cmd.Parameters.AddWithValue("@orderType", order.Type.ToString());
            cmd.Parameters.AddWithValue("@status", "Pending");
            cmd.Parameters.AddWithValue("@totalAmount", subTotal);

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
    }
}
