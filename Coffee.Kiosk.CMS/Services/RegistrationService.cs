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
    public class RegistrationService
    {

        public readonly DBManager _dBManager;

        public RegistrationService(DBManager dBManager)
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



    }
}
