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
                ?? throw new InvalidOperationException(
                    "Connection string 'Database' is missing in appsettings.json.");
        }

        public void PostEmployee(Employee employee)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"INSERT INTO accounts
                    (First_Name,
                     Middle_Name,
                     Last_Name,
                     Phone_Number,
                     Email_Address,
                     Emergency_First_Name,
                     Emergency_Last_Name,
                     Emergency_Number,
                     Job_Title,
                     Salary,
                     Role,
                     Department,
                     EmploymentType,
                     Profile_Picture_Path,
                     Status)
                VALUES
                    (@firstName,
                     @middleName,
                     @lastName,
                     @phoneNumber,
                     @emailAddress,
                     @emergencyFirstName,
                     @emergencyLastName,
                     @emergencyNumber,
                     @jobTitle,
                     @salary,
                     @role,
                     @department,
                     @employmentType,
                     @profilePicturePath,
                     @status)";

                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@middleName", employee.MiddleName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@emailAddress", employee.Email);
                command.Parameters.AddWithValue("@emergencyFirstName", employee.EmergencyFirstName);
                command.Parameters.AddWithValue("@emergencyLastName", employee.EmergencyLastName);
                command.Parameters.AddWithValue("@emergencyNumber", employee.EmergencyNumber);
                command.Parameters.AddWithValue("@jobTitle", employee.JobTitle);
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@role", employee.Role.ToString());
                command.Parameters.AddWithValue("@department", employee.Department.ToString());
                command.Parameters.AddWithValue("@employmentType", employee.EmploymentType.ToString());
                command.Parameters.AddWithValue(
                    "@profilePicturePath",
                    (object?)employee.ProfilePicturePath ?? DBNull.Value);
                command.Parameters.AddWithValue("@status", employee.Status.ToString());

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (PostEmployee): {ex.Message}");
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"UPDATE accounts
                    SET First_Name = @firstName,
                        Middle_Name = @middleName,
                        Last_Name = @lastName,
                        Phone_Number = @phoneNumber,
                        Email_Address = @emailAddress,
                        Emergency_First_Name = @emergencyFirstName,
                        Emergency_Last_Name = @emergencyLastName,
                        Emergency_Number = @emergencyNumber,
                        Job_Title = @jobTitle,
                        Salary = @salary,
                        Role = @role,
                        Department = @department,
                        EmploymentType = @employmentType,
                        Profile_Picture_Path = @profilePicturePath
                    WHERE ID = @id";

                command.Parameters.AddWithValue("@id", employee.Id);
                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@middleName", employee.MiddleName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@emailAddress", employee.Email);
                command.Parameters.AddWithValue("@emergencyFirstName", employee.EmergencyFirstName);
                command.Parameters.AddWithValue("@emergencyLastName", employee.EmergencyLastName);
                command.Parameters.AddWithValue("@emergencyNumber", employee.EmergencyNumber);
                command.Parameters.AddWithValue("@jobTitle", employee.JobTitle);
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@role", employee.Role.ToString());
                command.Parameters.AddWithValue("@department", employee.Department.ToString());
                command.Parameters.AddWithValue("@employmentType", employee.EmploymentType.ToString());
                command.Parameters.AddWithValue(
                    "@profilePicturePath",
                    (object?)employee.ProfilePicturePath ?? DBNull.Value);

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (UpdateEmployee): {ex.Message}");
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
                                        WHERE ID = @id";

                command.Parameters.AddWithValue("@status", employee.Status.ToString());
                command.Parameters.AddWithValue("@id", employee.Id);

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (DeactivateEmployee): {ex.Message}");
            }
        }

        public List<Employee> GetEmployees()
        {
            var tableData = new List<Employee>();

            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText =
                    @"SELECT * FROM accounts WHERE Status = 'ACTIVE'";

                using var reader = command.ExecuteReader();

                if (!reader.HasRows)
                    return tableData;

                ReadData(reader, tableData);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (GetEmployees): {ex.Message}");
            }

            return tableData;
        }

        private void ReadData(MySqlDataReader reader, List<Employee> tableData)
        {
            while (reader.Read())
            {
                tableData.Add(new Employee
                {
                    Id = reader.GetInt32("ID"),
                    FirstName = reader.GetString("First_Name"),
                    MiddleName = reader.GetString("Middle_Name"),
                    LastName = reader.GetString("Last_Name"),
                    PhoneNumber = reader.GetString("Phone_Number"),
                    Email = reader.GetString("Email_Address"),
                    EmergencyFirstName = reader.GetString("Emergency_First_Name"),
                    EmergencyLastName = reader.GetString("Emergency_Last_Name"),
                    EmergencyNumber = reader.GetString("Emergency_Number"),
                    JobTitle = reader.GetString("Job_Title"),
                    Salary = reader.GetDecimal("Salary"),
                    Role = Enum.Parse<AccountRole>(reader.GetString("Role")),
                    Department = Enum.Parse<Department>(reader.GetString("Department")),
                    EmploymentType = Enum.Parse<EmploymentType>(reader.GetString("EmploymentType")),
                    ProfilePicturePath = reader.IsDBNull(
                        reader.GetOrdinal("Profile_Picture_Path"))
                        ? null
                        : reader.GetString("Profile_Picture_Path"),
                    Status = Enum.Parse<AccountStatus>(reader.GetString("Status"))
                });
            }
        }
    }
}
