using Coffee.Kiosk.CMS.DTOs;


namespace Coffee.Kiosk.CMS.Models
{
    public class UpdateValidation : AccountBaseValidations
    {

        public ValidationResults Validate(DisplayDTO request)
        {
            var result = new ValidationResults();

            ValidateFullName(request.FullName, result, false);
            ValidatePhoneNumber(request.PhoneNumber, result, false);
            ValidateEmail(request.Email, result, false);
            ValidateEmergencyNumber(request.EmergencyNumber, result, false);
            ValidateJobTitle(request.JobTitle, result, false);
            ValidateSalary(request.Salary, result, false);

            return result;

        }

    }
}
