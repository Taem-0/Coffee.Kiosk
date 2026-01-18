using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class DBManager
    {

        private readonly string _connectionString;

        public DBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string 'Default' is missing in appsettings.json.");
        }

        public void Connect()
        {
            Console.WriteLine($"Connecting with: {_connectionString}");
        }

        public void PostEmployee(Employee employee)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = @"INSERT INTO accounts
                                              (Full_Name, 
                                               Phone_Number, 
                                               Email_Address, 
                                               Emergency_Contact, 
                                               Job_Title, 
                                               Salary, 
                                               Status)
                                        VALUES(@fullName, 
                                               @phoneNumber, 
                                               @emailAddress, 
                                               @emergencyContact, 
                                               @jobTitle, 
                                               @salary, 
                                               @status)";

                command.Parameters.AddWithValue("@fullName", employee.FullName);
                command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@emailAddress", employee.Email);
                command.Parameters.AddWithValue("@emergencyContact", employee.EmergencyNumber);
                command.Parameters.AddWithValue("@jobTitle", employee.JobTitle);
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@status", employee.Status.ToString());

                int rowsAffected = command.ExecuteNonQuery();



            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
                
            


        }


    }
}
