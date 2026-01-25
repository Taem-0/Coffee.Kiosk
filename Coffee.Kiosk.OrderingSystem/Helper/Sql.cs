using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Full_Name VARCHAR(255) NOT NULL,
                Phone_Number VARCHAR(255) NOT NULL,
                Email_Address VARCHAR(255) NOT NULL,
                Emergency_Contact VARCHAR(255) NOT NULL,
                Job_Title VARCHAR(255) NOT NULL,
                Salary DECIMAL(10,2) NOT NULL,
                Status ENUM('ACTIVE','DEACTIVATED') NOT NULL
            );",

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
                FOREIGN KEY (CategoryID) REFERENCES category(ID) ON DELETE CASCADE
            );"
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
                MessageBox.Show("Failed to initialize database");
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
                        row.GetInt32(0),
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
    }
}

