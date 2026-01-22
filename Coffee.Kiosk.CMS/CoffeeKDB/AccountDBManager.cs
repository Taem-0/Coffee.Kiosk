using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class AccountDBManager
    {

        private readonly string _connectionString;

        public AccountDBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string 'Default' is missing in appsettings.json.");
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

        public void UpdateEmployee(Employee employee)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = @"UPDATE accounts
                                              SET Full_Name = @fullName,
                                                  Phone_Number = @phoneNumber,
                                                  Email_Address = @emailAddress,
                                                  Emergency_Contact = @emergencyContact,
                                                  Job_Title = @jobTitle,
                                                  Salary = @salary
                                              WHERE 
                                                  ID = @id";
           
                command.Parameters.AddWithValue("@fullName", employee.FullName);
                command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@emailAddress", employee.Email);
                command.Parameters.AddWithValue("@emergencyContact", employee.EmergencyNumber);
                command.Parameters.AddWithValue("@jobTitle", employee.JobTitle);
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@id", employee.Id);

                int rowsAffected = command.ExecuteNonQuery();


            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");

            }
        }

        public void DeactivateEmployee(Employee employee)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();
            try
            {

                command.CommandText = @"UPDATE accounts
                                              SET Status = @status
                                              WHERE 
                                                  ID = @id";

                command.Parameters.AddWithValue("@status", employee.Status.ToString());
                command.Parameters.AddWithValue("@id", employee.Id);

                int rowsAffected = command.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public List<Employee> GetEmployees()
        {

            List<Employee> tableData = [];

            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = @"SELECT * FROM accounts WHERE Status = 'ACTIVE'";

                using var reader = command.ExecuteReader();

                if (!reader.HasRows)
                    return tableData;

                ReadData(reader, tableData);


            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            return tableData;

        }

        private void ReadData(MySqlDataReader reader, List<Employee> tableData)
        {
            while (reader.Read())
            {
                tableData.Add(new Employee
                {
                    
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    PhoneNumber = reader.GetString(2),
                    Email = reader.GetString(3),
                    EmergencyNumber = reader.GetString(4),
                    JobTitle = reader.GetString(5),
                    Salary = reader.GetDecimal(6),
                    Status = Enum.Parse<AccountStatus>(reader.GetString("Status"))

                });
            }
        }


    }
}
