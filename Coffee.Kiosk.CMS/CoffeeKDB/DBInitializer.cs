using Microsoft.Extensions.Configuration;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class DBInitializer
    {

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



        private readonly string _connectionString;
        private readonly string _connectionStringDatabase;


        public DBInitializer(IConfiguration configuration)
        {
            // wtf?? json should only be read once unless json file changes at runtime

            _connectionString = configuration.GetConnectionString("Default")
                    ?? throw new InvalidOperationException("Connection string 'Default' is missing in appsettings.json.");

            _connectionStringDatabase = configuration.GetConnectionString("Database")
                    ?? throw new InvalidOperationException("Connection string 'Database' is missing in appsettings.json.");

            // 
            DBhelper.connectionStringDatabase = _connectionStringDatabase;
        }

        public void CreateDataBase()
        {
            try
            {
                using (var connection = DBhelper.CreateConnection(_connectionString))
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "CREATE DATABASE IF NOT EXISTS CoffeeKioskDB";
                        cmd.ExecuteNonQuery();
                    }
                }

                using (var connection = DBhelper.CreateConnection(_connectionStringDatabase))
                {

                    for (int i = 0; i < tableCommands.Length; i++)
                    {
                        using var createTableCmd = connection.CreateCommand();
                        createTableCmd.CommandText = tableCommands[i];
                        createTableCmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
                MessageBox.Show("Failed to initialize database");
                throw;
            }
        }

    }
}
