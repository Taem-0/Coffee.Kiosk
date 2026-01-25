using Microsoft.Extensions.Configuration;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class DBInitializer
    {

        private static string[] tableCommands =
        {
            @"CREATE TABLE IF NOT EXISTS accounts (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                First_Name VARCHAR(255) NOT NULL,
                Middle_Name VARCHAR(255) NOT NULL,
                Last_Name VARCHAR(255) NOT NULL,
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
