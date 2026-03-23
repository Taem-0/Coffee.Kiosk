using Coffee.Kiosk.CMS.Models;
using Google.Protobuf.Collections;
using MaterialSkin;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using MySqlX.XDevAPI.Relational;
using System;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            @"CREATE TABLE IF NOT EXISTS kiosk_banners (
                ID           INT AUTO_INCREMENT PRIMARY KEY,
                FilePath     VARCHAR(255) NOT NULL DEFAULT '',
                Placement    VARCHAR(100) NOT NULL,
                DisplayOrder INT NOT NULL DEFAULT 0
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


            @"CREATE TABLE IF NOT EXISTS job_titles (
                ID        INT AUTO_INCREMENT PRIMARY KEY,
                Title     VARCHAR(100) NOT NULL,
                IsDefault TINYINT(1) NOT NULL DEFAULT 0
            );",


            @"CREATE TABLE IF NOT EXISTS departments (
                ID        INT AUTO_INCREMENT PRIMARY KEY,
                Name      VARCHAR(100) NOT NULL,
                IsDefault TINYINT(1) NOT NULL DEFAULT 0
            );",

            @"INSERT INTO job_titles (Title, IsDefault)
            SELECT * FROM (
                SELECT 'Barista', 1 UNION ALL
                SELECT 'Cook', 1 UNION ALL
                SELECT 'Waiter', 1 UNION ALL
                SELECT 'Cashier', 1 UNION ALL
                SELECT 'Manager', 1
            ) AS tmp
            WHERE NOT EXISTS (SELECT 1 FROM job_titles WHERE IsDefault = 1);",

            @"INSERT INTO departments (Name, IsDefault)
            SELECT * FROM (
                SELECT 'Operations', 1 UNION ALL
                SELECT 'Management', 1 UNION ALL
                SELECT 'Administration', 1
            ) AS tmp
            WHERE NOT EXISTS (SELECT 1 FROM departments WHERE IsDefault = 1);",

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

           //Employee's Sale

                @"CREATE TABLE IF NOT EXISTS EmployeeSales (
                SalesId       INT AUTO_INCREMENT PRIMARY KEY,
                EmployeeId    INT          NOT NULL,
                EmployeeName  VARCHAR(100) NOT NULL,
                TotalSales    DECIMAL(10,2) NOT NULL DEFAULT 0,
                ShiftDate     DATE          NOT NULL,
                ShiftStart    DATETIME      NOT NULL,
                ShiftEnd      DATETIME      NULL,
                CreatedAt     DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP
                );"


    };

        private static string[] insertPresets =
        {
            // ─── SHOP ────────────────────────────────────────────────────────────────
            @"INSERT INTO shop (ShopName, ThemeMode, Primary_Color, DarkPrimary_Color, Secondary_Color, Background_Color, Accent_Color)
              SELECT 'Brew & Sip', 'default', '#6F4D38', '#3D211A', '#A07856', '#F5F5DC', '#CBB799'
              WHERE NOT EXISTS (SELECT 1 FROM shop);",

            // ─── INVENTORY ITEMS ─────────────────────────────────────────────────────
            // IDs 1–21
            @"INSERT INTO inventory_item (Name, Stock, Unit, ImagePath) VALUES
              ('Small Cup',         500.00, 'PIECES', '../../../Resources/default_icon.png'),
              ('Medium Cup',        500.00, 'PIECES', '../../../Resources/default_icon.png'),
              ('Large Cup',         500.00, 'PIECES', '../../../Resources/default_icon.png'),
              ('Espresso Beans',   2000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Milk',             5000.00, 'ML',      '../../../Resources/default_icon.png'),
              ('Brown Sugar',      2000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Matcha Powder',    1000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Caramel Syrup',    1000.00, 'ML',      '../../../Resources/default_icon.png'),
              ('Tea Bags',          200.00, 'PIECES', '../../../Resources/default_icon.png'),
              ('Taro Powder',      1000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Wintermelon Syrup',1000.00, 'ML',      '../../../Resources/default_icon.png'),
              ('Lychee Syrup',     1000.00, 'ML',      '../../../Resources/default_icon.png'),
              ('Strawberry Syrup', 1000.00, 'ML',      '../../../Resources/default_icon.png'),
              ('Passion Fruit Syrup',1000.00,'ML',     '../../../Resources/default_icon.png'),
              ('Tapioca Pearls',   2000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Jelly',            2000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Coconut Jelly',    2000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Pudding',          1000.00, 'GRAMS',  '../../../Resources/default_icon.png'),
              ('Cake Slice',         30.00, 'PIECES', '../../../Resources/default_icon.png'),
              ('Muffin',             30.00, 'PIECES', '../../../Resources/default_icon.png'),
              ('Croissant',          30.00, 'PIECES', '../../../Resources/default_icon.png');",

            // ─── CATEGORIES ──────────────────────────────────────────────────────────
            // IDs 1–4
            @"INSERT INTO category (Name, IconPath, IsShown) VALUES
              ('Coffee',        'C:\\Images\\Kiosk\\Main menu\\COFFEE.png',   1),
              ('Milk Tea',      'C:\\Images\\Kiosk\\Main menu\\MILKTEA.png',  1),
              ('Fruit Tea',     'C:\\Images\\Kiosk\\Main menu\\FruitTea.jpg', 1),
              ('Pastry/Snacks', 'C:\\Images\\Kiosk\\Main menu\\PASTRY.png',   1);",

            // ─── PRODUCTS ────────────────────────────────────────────────────────────
            // Coffee:       IDs 1–4   (CategoryID = 1, IsCustomizable = 1)
            // Milk Tea:     IDs 5–8   (CategoryID = 2, IsCustomizable = 1)
            // Fruit Tea:    IDs 9–11  (CategoryID = 3, IsCustomizable = 1)
            // Pastry:       IDs 12–14 (CategoryID = 4, IsCustomizable = 0)
            @"INSERT INTO product (CategoryID, Name, Price, ImagePath, IsCustomizable) VALUES
              (1, 'Americano',             100.00, 'C:\\Images\\Kiosk\\Coffee Product\\Americano.png',         1),
              (1, 'Cappuccino',            120.00, 'C:\\Images\\Kiosk\\Coffee Product\\Cappuccino.png',        1),
              (1, 'Caramel Latte',         130.00, 'C:\\Images\\Kiosk\\Coffee Product\\Cafe Latte.png',        1),
              (1, 'Matcha Latte',          130.00, 'C:\\Images\\Kiosk\\Coffee Product\\Matcha Latte.png',      1),
              (2, 'Classic Milk Tea',      110.00, 'C:\\Images\\Kiosk\\MilkTea Product\\Classic.png',          1),
              (2, 'Taro Milk Tea',         120.00, 'C:\\Images\\Kiosk\\MilkTea Product\\Taro.jpg',             1),
              (2, 'Brown Sugar Milk Tea',  125.00, 'C:\\Images\\Kiosk\\MilkTea Product\\BrownSugar.jpg',       1),
              (2, 'Wintermelon Milk Tea',  115.00, 'C:\\Images\\Kiosk\\MilkTea Product\\WinterMelon.png',      1),
              (3, 'Lychee Fruit Tea',      110.00, 'C:\\Images\\Kiosk\\FruitTea Product\\Lychee.jpg',          1),
              (3, 'Strawberry Fruit Tea',  115.00, 'C:\\Images\\Kiosk\\FruitTea Product\\Strawberry.jpg',      1),
              (3, 'Passion Fruit Tea',     115.00, 'C:\\Images\\Kiosk\\FruitTea Product\\Passion.jpg',         1),
              (4, 'Chocolate Cake Slice',  100.00, 'C:\\Images\\Kiosk\\Pastry product\\Chocolate.jpg',         0),
              (4, 'Blueberry Muffin',       75.00, 'C:\\Images\\Kiosk\\Pastry product\\BlueBerry muffin.jpg',  0),
              (4, 'Cheese Croissant',       85.00, 'C:\\Images\\Kiosk\\Pastry product\\CheeseCrossaint.png',   0);",
            // ─── PRODUCT RECIPES ─────────────────────────────────────────────────────
            @"INSERT INTO product_recipe (ProductId, InventoryItemId, InventorySubtraction) VALUES
              -- Americano (1): espresso beans(4) + cup subtracted via modifier
              (1,  4, 18.00),
              -- Cappuccino (2): espresso beans(4) + milk(5)
              (2,  4, 18.00),
              (2,  5, 120.00),
              -- Caramel Latte (3): espresso beans(4) + milk(5) + caramel syrup(8)
              (3,  4, 18.00),
              (3,  5, 150.00),
              (3,  8, 20.00),
              -- Matcha Latte (4): matcha powder(7) + milk(5)
              (4,  7, 15.00),
              (4,  5, 150.00),
              -- Classic Milk Tea (5): tea bags(9) + milk(5)
              (5,  9,  1.00),
              (5,  5, 100.00),
              -- Taro Milk Tea (6): taro powder(10) + milk(5)
              (6, 10, 20.00),
              (6,  5, 100.00),
              -- Brown Sugar Milk Tea (7): brown sugar(6) + milk(5) + tea bags(9)
              (7,  6, 25.00),
              (7,  5, 100.00),
              (7,  9,  1.00),
              -- Wintermelon Milk Tea (8): wintermelon syrup(11) + milk(5) + tea bags(9)
              (8, 11, 20.00),
              (8,  5, 100.00),
              (8,  9,  1.00),
              -- Lychee Fruit Tea (9): lychee syrup(12) + tea bags(9)
              (9, 12, 20.00),
              (9,  9,  1.00),
              -- Strawberry Fruit Tea (10): strawberry syrup(13) + tea bags(9)
              (10, 13, 20.00),
              (10,  9,  1.00),
              -- Passion Fruit Tea (11): passion fruit syrup(14) + tea bags(9)
              (11, 14, 20.00),
              (11,  9,  1.00),
              -- Chocolate Cake Slice (12): cake slice(19)
              (12, 19,  1.00),
              -- Blueberry Muffin (13): muffin(20)
              (13, 20,  1.00),
              -- Cheese Croissant (14): croissant(21)
              (14, 21,  1.00);",

            // ─── MODIFIER GROUPS ─────────────────────────────────────────────────────
            //
            // Coffee products (1–4): each gets Size, Temperature, Sugar Level
            //   Product 1 (Americano):      Size=1,  Temp=2,  Sugar=3
            //   Product 2 (Cappuccino):     Size=4,  Temp=5,  Sugar=6
            //   Product 3 (Caramel Latte):  Size=7,  Temp=8,  Sugar=9
            //   Product 4 (Matcha Latte):   Size=10, Temp=11, Sugar=12
            //
            // Milk Tea products (5–8): each gets Size, Sugar Level, Add-ons
            //   Product 5 (Classic MT):     Size=13, Sugar=14, Addons=15
            //   Product 6 (Taro MT):        Size=16, Sugar=17, Addons=18
            //   Product 7 (Brown Sugar MT): Size=19, Sugar=20, Addons=21
            //   Product 8 (Wintermelon MT): Size=22, Sugar=23, Addons=24
            //
            // Fruit Tea products (9–11): each gets Size, Sugar Level, Add-ons
            //   Product 9  (Lychee FT):     Size=25, Sugar=26, Addons=27
            //   Product 10 (Strawberry FT): Size=28, Sugar=29, Addons=30
            //   Product 11 (Passion FT):    Size=31, Sugar=32, Addons=33
            //
            // Pastry (12–14): no modifier groups
            //
            @"INSERT INTO modifier_group (ProductId, ParentGroupId, Name, SelectionType, Required) VALUES
              -- Americano (1)
              (1,  NULL, 'Size',        'Single',   1),
              (1,  NULL, 'Temperature', 'Single',   1),
              (1,  NULL, 'Sugar Level', 'Single',   1),
              -- Cappuccino (2)
              (2,  NULL, 'Size',        'Single',   1),
              (2,  NULL, 'Temperature', 'Single',   1),
              (2,  NULL, 'Sugar Level', 'Single',   1),
              -- Caramel Latte (3)
              (3,  NULL, 'Size',        'Single',   1),
              (3,  NULL, 'Temperature', 'Single',   1),
              (3,  NULL, 'Sugar Level', 'Single',   1),
              -- Matcha Latte (4)
              (4,  NULL, 'Size',        'Single',   1),
              (4,  NULL, 'Temperature', 'Single',   1),
              (4,  NULL, 'Sugar Level', 'Single',   1),
              -- Classic Milk Tea (5)
              (5,  NULL, 'Size',        'Single',   1),
              (5,  NULL, 'Sugar Level', 'Single',   1),
              (5,  NULL, 'Add-ons',     'Multiple', 0),
              -- Taro Milk Tea (6)
              (6,  NULL, 'Size',        'Single',   1),
              (6,  NULL, 'Sugar Level', 'Single',   1),
              (6,  NULL, 'Add-ons',     'Multiple', 0),
              -- Brown Sugar Milk Tea (7)
              (7,  NULL, 'Size',        'Single',   1),
              (7,  NULL, 'Sugar Level', 'Single',   1),
              (7,  NULL, 'Add-ons',     'Multiple', 0),
              -- Wintermelon Milk Tea (8)
              (8,  NULL, 'Size',        'Single',   1),
              (8,  NULL, 'Sugar Level', 'Single',   1),
              (8,  NULL, 'Add-ons',     'Multiple', 0),
              -- Lychee Fruit Tea (9)
              (9,  NULL, 'Size',        'Single',   1),
              (9,  NULL, 'Sugar Level', 'Single',   1),
              (9,  NULL, 'Add-ons',     'Multiple', 0),
              -- Strawberry Fruit Tea (10)
              (10, NULL, 'Size',        'Single',   1),
              (10, NULL, 'Sugar Level', 'Single',   1),
              (10, NULL, 'Add-ons',     'Multiple', 0),
              -- Passion Fruit Tea (11)
              (11, NULL, 'Size',        'Single',   1),
              (11, NULL, 'Sugar Level', 'Single',   1),
              (11, NULL, 'Add-ons',     'Multiple', 0);",

            // ─── MODIFIER OPTIONS ────────────────────────────────────────────────────
            //
            // Size options: Small(+0, cup-1), Medium(+15, cup-1), Large(+25, cup-1)
            //   Cup inventory item IDs: Small=1, Medium=2, Large=3
            //
            // Temperature options: Hot(+0), Iced(+0)  — no inventory item
            //
            // Sugar Level options: 0%(+0), 25%(+0), 50%(+0), 75%(+5), 100%(+10)
            //   Brown Sugar inventory ID = 6; subtraction only for 75% and 100%
            //
            // Add-ons options: None(+0), Pearls(+15,inv=15), Jelly(+15,inv=16),
            //                  Coconut Jelly(+15,inv=17), Pudding(+20,inv=18)
            //
            // TriggersChild / SubtractFromParent:
            //   Size options trigger child (cup deducted from inventory) → TriggersChild=1
            //   Temperature / Sugar / Add-ons → TriggersChild=0 (leaf options)
            //   SubtractFromParent=1 for all options that consume inventory
            //
            // GROUP ID REFERENCE (33 groups total, 3 per drink × 11 drinks):
            //   Size groups:        1,4,7,10,13,16,19,22,25,28,31
            //   Temperature groups: 2,5,8,11
            //   Sugar groups:       3,6,9,12,14,17,20,23,26,29,32
            //   Add-on groups:      15,18,21,24,27,30,33
            //
            @"INSERT INTO modifier_option (GroupId, Name, PriceDelta, InventorySubtraction, InventoryItemId, TriggersChild, SubtractFromParent, SortBy) VALUES

              -- ── Size: Americano (GroupId=1) ──────────────────────────────────────
              (1,  'Small',  0.00, 1.00, 1, 1, 1, 1),
              (1,  'Medium',15.00, 1.00, 2, 1, 1, 2),
              (1,  'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Temperature: Americano (GroupId=2) ───────────────────────────────
              (2,  'Hot',   0.00, 0.00, NULL, 0, 0, 1),
              (2,  'Iced',  0.00, 0.00, NULL, 0, 0, 2),
              -- ── Sugar Level: Americano (GroupId=3) ───────────────────────────────
              (3,  '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (3,  '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (3,  '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (3,  '75%',   5.00, 5.00,    6, 0, 1, 4),
              (3,  '100%', 10.00,10.00,    6, 0, 1, 5),

              -- ── Size: Cappuccino (GroupId=4) ─────────────────────────────────────
              (4,  'Small',  0.00, 1.00, 1, 1, 1, 1),
              (4,  'Medium',15.00, 1.00, 2, 1, 1, 2),
              (4,  'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Temperature: Cappuccino (GroupId=5) ──────────────────────────────
              (5,  'Hot',   0.00, 0.00, NULL, 0, 0, 1),
              (5,  'Iced',  0.00, 0.00, NULL, 0, 0, 2),
              -- ── Sugar Level: Cappuccino (GroupId=6) ──────────────────────────────
              (6,  '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (6,  '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (6,  '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (6,  '75%',   5.00, 5.00,    6, 0, 1, 4),
              (6,  '100%', 10.00,10.00,    6, 0, 1, 5),

              -- ── Size: Caramel Latte (GroupId=7) ──────────────────────────────────
              (7,  'Small',  0.00, 1.00, 1, 1, 1, 1),
              (7,  'Medium',15.00, 1.00, 2, 1, 1, 2),
              (7,  'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Temperature: Caramel Latte (GroupId=8) ───────────────────────────
              (8,  'Hot',   0.00, 0.00, NULL, 0, 0, 1),
              (8,  'Iced',  0.00, 0.00, NULL, 0, 0, 2),
              -- ── Sugar Level: Caramel Latte (GroupId=9) ───────────────────────────
              (9,  '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (9,  '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (9,  '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (9,  '75%',   5.00, 5.00,    6, 0, 1, 4),
              (9,  '100%', 10.00,10.00,    6, 0, 1, 5),

              -- ── Size: Matcha Latte (GroupId=10) ──────────────────────────────────
              (10, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (10, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (10, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Temperature: Matcha Latte (GroupId=11) ───────────────────────────
              (11, 'Hot',   0.00, 0.00, NULL, 0, 0, 1),
              (11, 'Iced',  0.00, 0.00, NULL, 0, 0, 2),
              -- ── Sugar Level: Matcha Latte (GroupId=12) ───────────────────────────
              (12, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (12, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (12, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (12, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (12, '100%', 10.00,10.00,    6, 0, 1, 5),

              -- ── Size: Classic Milk Tea (GroupId=13) ──────────────────────────────
              (13, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (13, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (13, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Sugar Level: Classic Milk Tea (GroupId=14) ───────────────────────
              (14, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (14, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (14, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (14, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (14, '100%', 10.00,10.00,    6, 0, 1, 5),
              -- ── Add-ons: Classic Milk Tea (GroupId=15) ───────────────────────────
              (15, 'None',         0.00, 0.00, NULL, 0, 0, 1),
              (15, 'Pearls',      15.00,15.00,   15, 0, 1, 2),
              (15, 'Jelly',       15.00,15.00,   16, 0, 1, 3),
              (15, 'Coconut Jelly',15.00,15.00,  17, 0, 1, 4),
              (15, 'Pudding',     20.00,20.00,   18, 0, 1, 5),

              -- ── Size: Taro Milk Tea (GroupId=16) ─────────────────────────────────
              (16, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (16, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (16, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Sugar Level: Taro Milk Tea (GroupId=17) ──────────────────────────
              (17, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (17, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (17, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (17, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (17, '100%', 10.00,10.00,    6, 0, 1, 5),
              -- ── Add-ons: Taro Milk Tea (GroupId=18) ──────────────────────────────
              (18, 'None',         0.00, 0.00, NULL, 0, 0, 1),
              (18, 'Pearls',      15.00,15.00,   15, 0, 1, 2),
              (18, 'Jelly',       15.00,15.00,   16, 0, 1, 3),
              (18, 'Coconut Jelly',15.00,15.00,  17, 0, 1, 4),
              (18, 'Pudding',     20.00,20.00,   18, 0, 1, 5),

              -- ── Size: Brown Sugar Milk Tea (GroupId=19) ───────────────────────────
              (19, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (19, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (19, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Sugar Level: Brown Sugar Milk Tea (GroupId=20) ────────────────────
              (20, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (20, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (20, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (20, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (20, '100%', 10.00,10.00,    6, 0, 1, 5),
              -- ── Add-ons: Brown Sugar Milk Tea (GroupId=21) ────────────────────────
              (21, 'None',         0.00, 0.00, NULL, 0, 0, 1),
              (21, 'Pearls',      15.00,15.00,   15, 0, 1, 2),
              (21, 'Jelly',       15.00,15.00,   16, 0, 1, 3),
              (21, 'Coconut Jelly',15.00,15.00,  17, 0, 1, 4),
              (21, 'Pudding',     20.00,20.00,   18, 0, 1, 5),

              -- ── Size: Wintermelon Milk Tea (GroupId=22) ───────────────────────────
              (22, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (22, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (22, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Sugar Level: Wintermelon Milk Tea (GroupId=23) ────────────────────
              (23, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (23, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (23, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (23, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (23, '100%', 10.00,10.00,    6, 0, 1, 5),
              -- ── Add-ons: Wintermelon Milk Tea (GroupId=24) ────────────────────────
              (24, 'None',         0.00, 0.00, NULL, 0, 0, 1),
              (24, 'Pearls',      15.00,15.00,   15, 0, 1, 2),
              (24, 'Jelly',       15.00,15.00,   16, 0, 1, 3),
              (24, 'Coconut Jelly',15.00,15.00,  17, 0, 1, 4),
              (24, 'Pudding',     20.00,20.00,   18, 0, 1, 5),

              -- ── Size: Lychee Fruit Tea (GroupId=25) ──────────────────────────────
              (25, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (25, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (25, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Sugar Level: Lychee Fruit Tea (GroupId=26) ───────────────────────
              (26, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (26, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (26, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (26, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (26, '100%', 10.00,10.00,    6, 0, 1, 5),
              -- ── Add-ons: Lychee Fruit Tea (GroupId=27) ───────────────────────────
              (27, 'None',         0.00, 0.00, NULL, 0, 0, 1),
              (27, 'Pearls',      15.00,15.00,   15, 0, 1, 2),
              (27, 'Jelly',       15.00,15.00,   16, 0, 1, 3),
              (27, 'Coconut Jelly',15.00,15.00,  17, 0, 1, 4),
              (27, 'Pudding',     20.00,20.00,   18, 0, 1, 5),

              -- ── Size: Strawberry Fruit Tea (GroupId=28) ──────────────────────────
              (28, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (28, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (28, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Sugar Level: Strawberry Fruit Tea (GroupId=29) ───────────────────
              (29, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (29, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (29, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (29, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (29, '100%', 10.00,10.00,    6, 0, 1, 5),
              -- ── Add-ons: Strawberry Fruit Tea (GroupId=30) ───────────────────────
              (30, 'None',         0.00, 0.00, NULL, 0, 0, 1),
              (30, 'Pearls',      15.00,15.00,   15, 0, 1, 2),
              (30, 'Jelly',       15.00,15.00,   16, 0, 1, 3),
              (30, 'Coconut Jelly',15.00,15.00,  17, 0, 1, 4),
              (30, 'Pudding',     20.00,20.00,   18, 0, 1, 5),

              -- ── Size: Passion Fruit Tea (GroupId=31) ─────────────────────────────
              (31, 'Small',  0.00, 1.00, 1, 1, 1, 1),
              (31, 'Medium',15.00, 1.00, 2, 1, 1, 2),
              (31, 'Large', 25.00, 1.00, 3, 1, 1, 3),
              -- ── Sugar Level: Passion Fruit Tea (GroupId=32) ──────────────────────
              (32, '0%',    0.00, 0.00, NULL, 0, 0, 1),
              (32, '25%',   0.00, 0.00, NULL, 0, 0, 2),
              (32, '50%',   0.00, 0.00, NULL, 0, 0, 3),
              (32, '75%',   5.00, 5.00,    6, 0, 1, 4),
              (32, '100%', 10.00,10.00,    6, 0, 1, 5),
              -- ── Add-ons: Passion Fruit Tea (GroupId=33) ──────────────────────────
              (33, 'None',         0.00, 0.00, NULL, 0, 0, 1),
              (33, 'Pearls',      15.00,15.00,   15, 0, 1, 2),
              (33, 'Jelly',       15.00,15.00,   16, 0, 1, 3),
              (33, 'Coconut Jelly',15.00,15.00,  17, 0, 1, 4),
              (33, 'Pudding',     20.00,20.00,   18, 0, 1, 5);"
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

        private void InsertPresets()
        {
            try
            {
                using var connection = DBhelper.CreateConnection(_connectionStringDatabase);

                using var checkCmd = connection.CreateCommand();
                checkCmd.CommandText = "SELECT COUNT(*) FROM shop";
                var shopCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (shopCount > 0)
                {
                    Console.WriteLine("Shop table already has data. Skipping preset inserts.");
                    return;
                }

                foreach (var sql in insertPresets)
                {
                    using var cmd = connection.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Preset data inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting presets: {ex.Message}");
                MessageBox.Show($"Failed to insert preset data: {ex.Message}");
                throw;
            }
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
                    InsertPresets();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
                MessageBox.Show($"Failed to initialize database ${ex.Message}");
                throw;
            }
        }

    }
}
