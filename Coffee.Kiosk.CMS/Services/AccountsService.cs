using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                EmergencyNumber = request.EmergencyNumber,
                JobTitle = request.JobTitle,
                Salary = decimal.Parse(request.Salary),
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
                    FullName = account.FullName,
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


    }
}
