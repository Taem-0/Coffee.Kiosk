using Coffee.Kiosk.CMS.DTOs;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;


namespace Coffee.Kiosk.CMS.Models
{
    public class RegistrationValidation : AccountBaseValidations
    {

        public ValidationResults Validate (RegistrationDTO request)
        {
            var resullt = new ValidationResults();

            ValidateName(request.FirstName, "First Name", resullt, true);
            ValidateName(request.MiddleName, "Middle Name", resullt, true);
            ValidateName(request.LastName, "Last Name", resullt, true);
            ValidatePhoneNumber(request.PhoneNumber, resullt, true);
            ValidateEmail(request.Email, resullt, true);
            ValidateEmergencyNumber(request.EmergencyNumber, resullt, true);
            ValidateJobTitle(request.JobTitle, resullt, true);
            ValidateSalary(request.Salary, resullt, true);

            return resullt;

        }
        

    }
}
