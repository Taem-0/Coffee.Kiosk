using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Coffee.Kiosk.CMS.Services
{
    public class AccountsService(AccountDBManager dBManager)
    {

        public readonly AccountDBManager _dBManager = dBManager ?? throw new ArgumentNullException(nameof(dBManager));

        public void RegisterUser(RegistrationDTO request)
        {

            var (passwordHash, passwordSalt) = LogicHelpers.GenerateDefaultPassword();

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
                IsFirstLogin = true
            };

            _dBManager.PostEmployee(employee);

            var tempPassword = LogicHelpers.GetTemporaryPasswordDisplay();
            System.Diagnostics.Debug.WriteLine($"New employee created. Temporary password: {tempPassword}");
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
