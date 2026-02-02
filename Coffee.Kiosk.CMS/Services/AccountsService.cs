using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using Org.BouncyCastle.Asn1.Ocsp;

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
            var employee = new Employee
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                EmergencyNumber = request.EmergencyNumber,
                JobTitle = request.JobTitle,
                Department = request.Department,          // add
                EmploymentType = request.EmploymentType,  // add
                Role = request.Role,                      // add
                EmployeeID = request.EmployeeID,          // add
                Salary = decimal.TryParse(request.Salary, out var sal) ? sal : 0m,
                Status = AccountStatus.ACTIVE
            };

            _dBManager.PostEmployee(employee);
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
                    EmergencyNumber = account.EmergencyNumber,
                    JobTitle = account.JobTitle,
                    Salary = account.Salary.ToString("F2"),
                    Status = account.Status.ToString()

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
                EmergencyNumber = request.EmergencyNumber,
                JobTitle = request.JobTitle,
                Salary = decimal.Parse(request.Salary),
                Status = AccountStatus.ACTIVE
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
