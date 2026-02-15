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
                Salary DECIMAL(10,2) NOT NULL,
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


            // inventory
            @"CREATE TABLE IF NOT EXISTS inventory_item (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                Name VARCHAR(255) UNIQUE NOT NULL,
                Stock Decimal(10, 2) NOT NULL,
                Unit VARCHAR(255) NOT NULL
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
                GroupId INT,
                Name VARCHAR(100),
                PriceDelta DECIMAL (10, 2),
                InventorySubtraction Decimal(10, 2) DEFAULT 0,
                InventoryItemId INT,
                TriggersChild BOOLEAN NOT NULL DEFAULT TRUE,
                SortBy INT NOT NULL,
                FOREIGN KEY (GroupId) REFERENCES modifier_group(ID) ON DELETE CASCADE,
                FOREIGN KEY (InventoryItemId) REFERENCES inventory_item(ID)
                );",


            // customer orders
            @"CREATE TABLE customer_orders (
                ID INT AUTO_INCREMENT PRIMARY KEY,

                OrderType ENUM('DineIn','TakeOut') NOT NULL,
                Status ENUM('Pending','Paid','Cancelled') NOT NULL DEFAULT 'Pending',
                TotalAmount DECIMAL(10,2) NOT NULL,

                CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                );",

            @"CREATE TABLE customer_order_item (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                CustomerOrderId INT NOT NULL,

                ProductId INT,
                ProductName VARCHAR(255) NOT NULL,

                BasePrice DECIMAL(10,2) NOT NULL,
                UnitPrice DECIMAL(10,2) NOT NULL,
                Quantity INT NOT NULL,

                FOREIGN KEY (CustomerOrderId) REFERENCES customer_orders(ID) ON DELETE CASCADE
                );",

            @"CREATE TABLE customer_order_item_modifier (
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

    }
}
