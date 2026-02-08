using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
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
                     Password_Hash,
                     Password_Salt,
                     Is_First_Login,
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
                     @passwordHash,
                     @passwordSalt,
                     @isFirstLogin,
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
                command.Parameters.AddWithValue("@passwordHash", employee.PasswordHash);
                command.Parameters.AddWithValue("@passwordSalt", employee.PasswordSalt);
                command.Parameters.AddWithValue("@isFirstLogin", employee.IsFirstLogin);
                command.Parameters.AddWithValue("@status", employee.Status.ToString());

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (PostEmployee): {ex.Message}");
                throw;
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
                        Profile_Picture_Path = @profilePicturePath,
                        Is_First_Login = @isFirstLogin
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
                command.Parameters.AddWithValue("@isFirstLogin", employee.IsFirstLogin);

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (UpdateEmployee): {ex.Message}");
                throw;
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

        public Employee ValidateLogin(string email, string password)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"SELECT * FROM accounts 
                              WHERE Email_Address = @email 
                              AND Status = 'ACTIVE'";

                command.Parameters.AddWithValue("@email", email);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var storedHash = reader.GetString("Password_Hash");
                    var storedSalt = reader.GetString("Password_Salt");

                    if (LogicHelpers.VerifyPassword(password, storedHash, storedSalt))
                    {
                        return new Employee
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
                            PasswordHash = storedHash,
                            PasswordSalt = storedSalt,
                            IsFirstLogin = reader.GetBoolean("Is_First_Login"),
                            Status = Enum.Parse<AccountStatus>(reader.GetString("Status"))
                        };
                    }
                }

                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (ValidateLogin): {ex.Message}");
                return null;
            }
        }

        public void UpdatePassword(int employeeId, string newPasswordHash, string newPasswordSalt, bool resetFirstLogin = false)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"UPDATE accounts
                    SET Password_Hash = @passwordHash,
                        Password_Salt = @passwordSalt,
                        Is_First_Login = @isFirstLogin
                    WHERE ID = @id";

                command.Parameters.AddWithValue("@id", employeeId);
                command.Parameters.AddWithValue("@passwordHash", newPasswordHash);
                command.Parameters.AddWithValue("@passwordSalt", newPasswordSalt);
                command.Parameters.AddWithValue("@isFirstLogin", resetFirstLogin);

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (UpdatePassword): {ex.Message}");
                throw;
            }
        }


        public void SubmitPasswordResetRequest(int employeeId)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"UPDATE accounts 
                               SET Password_Reset_Requested = 1
                               WHERE ID = @id";

                command.Parameters.AddWithValue("@id", employeeId);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (SubmitPasswordResetRequest): {ex.Message}");
                throw;
            }
        }

        public bool HasPendingResetRequest(int employeeId)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"SELECT Password_Reset_Requested 
                               FROM accounts WHERE ID = @id";

                command.Parameters.AddWithValue("@id", employeeId);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // CCOOCOCOCLUMN
                    int columnIndex = reader.GetOrdinal("Password_Reset_Requested");
                    if (!reader.IsDBNull(columnIndex))
                    {
                        return reader.GetBoolean("Password_Reset_Requested");
                    }
                }

                return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (HasPendingResetRequest): {ex.Message}");
                return false;
            }
        }

        public List<DisplayDTO> GetEmployeesWithResetRequests()
        {
            var employees = new List<DisplayDTO>();

            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"SELECT * FROM accounts 
                               WHERE Password_Reset_Requested = 1 
                               AND Status = 'ACTIVE'
                               AND Role != 'OWNER'";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var display = new DisplayDTO
                    {
                        PrimaryID = reader.GetInt32("ID").ToString(),
                        FirstName = reader.GetString("First_Name"),
                        MiddleName = reader.GetString("Middle_Name"),
                        LastName = reader.GetString("Last_Name"),
                        PhoneNumber = reader.GetString("Phone_Number"),
                        Email = reader.GetString("Email_Address"),
                        EmergencyFirstName = reader.GetString("Emergency_First_Name"),
                        EmergencyLastName = reader.GetString("Emergency_Last_Name"),
                        EmergencyNumber = reader.GetString("Emergency_Number"),
                        JobTitle = reader.GetString("Job_Title"),
                        Salary = reader.GetDecimal("Salary").ToString("F2"),
                        Role = reader.GetString("Role"),
                        Department = reader.GetString("Department"),
                        EmploymentType = reader.GetString("EmploymentType"),
                        Status = reader.GetString("Status"),
                        ProfilePicturePath = reader.IsDBNull(
                            reader.GetOrdinal("Profile_Picture_Path"))
                            ? null
                            : reader.GetString("Profile_Picture_Path")
                    };

                    employees.Add(display);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (GetEmployeesWithResetRequests): {ex.Message}");
            }

            return employees;
        }

        public void ApproveResetRequest(int employeeId, int approvedByAdminId)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                var defaultPasswordResult = LogicHelpers.GenerateDefaultPassword();
                string defaultHash = defaultPasswordResult.hash;
                string defaultSalt = defaultPasswordResult.salt;

                command.CommandText = @"UPDATE accounts 
                               SET Password_Hash = @passwordHash,
                                   Password_Salt = @passwordSalt,
                                   Is_First_Login = 1,
                                   Password_Reset_Requested = 0
                               WHERE ID = @id";

                command.Parameters.AddWithValue("@id", employeeId);
                command.Parameters.AddWithValue("@passwordHash", defaultHash);
                command.Parameters.AddWithValue("@passwordSalt", defaultSalt);

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (ApproveResetRequest): {ex.Message}");
                throw;
            }
        }

        public void RejectResetRequest(int employeeId, int rejectedByAdminId, string reason = "")
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"UPDATE accounts 
                               SET Password_Reset_Requested = 0
                               WHERE ID = @id";

                command.Parameters.AddWithValue("@id", employeeId);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (RejectResetRequest): {ex.Message}");
                throw;
            }
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
                    PasswordHash = reader.GetString("Password_Hash"),
                    PasswordSalt = reader.GetString("Password_Salt"),
                    IsFirstLogin = reader.GetBoolean("Is_First_Login"),
                    Status = Enum.Parse<AccountStatus>(reader.GetString("Status"))
                });
            }
        }
    }
}
