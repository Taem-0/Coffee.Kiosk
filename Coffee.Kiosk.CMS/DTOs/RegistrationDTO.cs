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
        
        public string EmergencyNumber { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public string Salary { get; set; } = string.Empty;

    }
}
