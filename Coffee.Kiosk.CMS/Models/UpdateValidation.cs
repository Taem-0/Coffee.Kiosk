using Coffee.Kiosk.CMS.DTOs;
using MySqlX.XDevAPI.Common;


namespace Coffee.Kiosk.CMS.Models
{
    public class UpdateValidation : AccountBaseValidations
    {

        public ValidationResults Validate(DisplayDTO request)
        {
            var result = new ValidationResults();

            ValidateName(request.FirstName, "First Name", result, false);
            ValidateName(request.MiddleName, "Middle Name", result, false);
            ValidateName(request.LastName, "Last Name", result, false);
            ValidatePhoneNumber(request.PhoneNumber, result, false);
            ValidateEmail(request.Email, result, false);
            ValidateEmergencyNumber(request.EmergencyNumber, result, false);
            ValidateJobTitle(request.JobTitle, result, false);
            ValidateSalary(request.Salary, result, false);

            return result;

        }

    }
}
