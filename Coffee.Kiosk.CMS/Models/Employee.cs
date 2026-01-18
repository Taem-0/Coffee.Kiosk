using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class Employee
    {

        public int Id { get; set; } 

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? EmergencyNumber { get; set; }

        public string? JobTitle { get; set; }

        public decimal Salary { get; set; }

        public AccountStatus Status { get; set; }

    }

    public enum AccountStatus
    {
        ACTIVE,
        DEACTIVATED
    }
}
