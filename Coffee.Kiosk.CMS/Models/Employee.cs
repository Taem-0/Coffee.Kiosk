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

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string EmergencyNumber { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public decimal Salary { get; set; } = decimal.Zero;

        public AccountStatus Status { get; set; } = AccountStatus.ACTIVE;

    }

    public enum AccountStatus
    {
        ACTIVE,
        DEACTIVATED
    }
}
