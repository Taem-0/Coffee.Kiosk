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
        private static string? _connectionStringDatabase;

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
                IconPath VARCHAR(255)
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

            _connectionStringDatabase = configuration.GetConnectionString("Database")
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

                using var dbConnection = new MySqlConnection(_connectionStringDatabase);
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
    }
}

