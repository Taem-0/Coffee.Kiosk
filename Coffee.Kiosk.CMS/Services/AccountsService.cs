using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;

namespace Coffee.Kiosk.CMS.Services
{
    public class AccountsService
    {
        public readonly AccountDBManager _dBManager;

        public AccountsService(AccountDBManager dBManager)
        {
            _dBManager = dBManager ?? throw new ArgumentNullException(nameof(dBManager));
        }

        public void RegisterUser(RegistrationDTO request)
        {
            string passwordHash;
            string passwordSalt;
            bool isFirstLogin;

            if (!string.IsNullOrEmpty(request.PasswordHash) && !string.IsNullOrEmpty(request.PasswordSalt))
            {
                passwordHash = request.PasswordHash;
                passwordSalt = request.PasswordSalt;
                isFirstLogin = request.IsFirstLogin;
            }
            else
            {
                var (hash, salt) = LogicHelpers.GenerateDefaultPassword();
                passwordHash = hash;
                passwordSalt = salt;
                isFirstLogin = true;
            }

            var employee = new Employee
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                EmergencyFirstName = request.EmergencyFirstName,
                EmergencyLastName = request.EmergencyLastName,
                EmergencyNumber = request.EmergencyNumber,
                JobTitle = request.JobTitle,
                Department = request.Department,
                EmploymentType = request.EmploymentType,
                Role = request.Role,
                Salary = decimal.TryParse(request.Salary, out var sal) ? sal : 0m,
                Status = AccountStatus.ACTIVE,
                ProfilePicturePath = request.ProfilePicturePath,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsFirstLogin = isFirstLogin
            };

            _dBManager.PostEmployee(employee);

            if (isFirstLogin)
            {
                var tempPassword = LogicHelpers.GetTemporaryPasswordDisplay();
                System.Diagnostics.Debug.WriteLine($"New employee created. Temporary password: {tempPassword}");
            }
        }

        public Employee ValidateLogin(string email, string password)
        {
            return _dBManager.ValidateLogin(email, password);
        }

        public List<DisplayDTO> DisplayAccounts()
        {
            List<DisplayDTO> tableDisplay = [];

            var employees = _dBManager.GetEmployees();

            foreach (var account in employees)
            {
                DisplayDTO display = new()
                {
                    PrimaryID = account.Id.ToString(),

                    FirstName = account.FirstName,
                    MiddleName = account.MiddleName,
                    LastName = account.LastName,

                    PhoneNumber = account.PhoneNumber,
                    Email = account.Email,

                    EmergencyFirstName = account.EmergencyFirstName,
                    EmergencyLastName = account.EmergencyLastName,
                    EmergencyNumber = account.EmergencyNumber,

                    JobTitle = account.JobTitle,
                    Salary = account.Salary.ToString("F2"),

                    Role = Helpers.UIhelp.EnumDisplayHelper.FormatEnum(account.Role.ToString()),
                    Department = Helpers.UIhelp.EnumDisplayHelper.FormatEnum(account.Department.ToString()),
                    EmploymentType = Helpers.UIhelp.EnumDisplayHelper.FormatEnum(account.EmploymentType.ToString()),

                    Status = account.Status.ToString(),

                    ProfilePicturePath = account.ProfilePicturePath
                };

                tableDisplay.Add(display);
            }

            return tableDisplay;
        }

        public void UpdateUser(DisplayDTO request)
        {
            var employee = new Employee
            {
                Id = int.Parse(request.PrimaryID),

                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,

                PhoneNumber = request.PhoneNumber,
                Email = request.Email,

                EmergencyFirstName = request.EmergencyFirstName,
                EmergencyLastName = request.EmergencyLastName,
                EmergencyNumber = request.EmergencyNumber,

                JobTitle = request.JobTitle,
                Salary = decimal.Parse(request.Salary),

                Role = Enum.Parse<AccountRole>(request.Role.Replace(" ", "_").ToUpper()),
                Department = Enum.Parse<Department>(request.Department.Replace(" ", "_").ToUpper()),
                EmploymentType = Enum.Parse<EmploymentType>(request.EmploymentType.Replace(" ", "_").ToUpper()),

                Status = Enum.Parse<AccountStatus>(request.Status),

                ProfilePicturePath = request.ProfilePicturePath
            };

            _dBManager.UpdateEmployee(employee);
        }

        public void Deactivate(DisplayDTO request)
        {
            var employee = new Employee
            {
                Id = int.Parse(request.PrimaryID),
                Status = AccountStatus.DEACTIVATED
            };

            _dBManager.DeactivateEmployee(employee);
        }
    }
}