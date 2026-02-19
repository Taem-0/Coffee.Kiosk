using Coffee.Kiosk.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.DTOs
{
    public class RegistrationDTO
    {

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName {  get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string EmergencyFirstName { get; set; } = string.Empty;

        public string EmergencyLastName { get; set; } = string.Empty;

        public string EmergencyNumber { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public string? ProfilePicturePath { get; set; }

        public AccountRole Role { get; set; } 
        public Department Department { get; set; } 
        public EmploymentType EmploymentType { get; set; }

        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public bool IsFirstLogin { get; set; } = true;

    }
}
