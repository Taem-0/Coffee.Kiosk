using Microsoft.Extensions.Configuration;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class DBInitializer
    {

        private readonly string _connectionString;

        public DBInitializer(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString("Default")


                    ?? throw new InvalidOperationException("Connection string 'Default' is missing in appsettings.json.");

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

                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS accounts (
                                            Employee_ID INT AUTO_INCREMENT PRIMARY KEY,
                                            Full_Name VARCHAR(255) NOT NULL,
                                            Phone_Number VARCHAR(255) NOT NULL,
                                            Email_Address VARCHAR(255) NOT NULL,
                                            Emergency_Contact VARCHAR(255) NOT NULL,    
                                            Job_Title VARCHAR(255) NOT NULL,
                                            Salary INT NOT NULL,
                                            Status ENUM ('ACTIVE', 'DEACTIVATED') NOT NULL,
                                            );";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
                throw;
            }
        }













    }
}
