using Coffee.Kiosk.CMS.DTOs;


namespace Coffee.Kiosk.CMS.Models
{
    public class RegistrationValidation : AccountBaseValidations
    {

        public ValidationResults Validate (RegistrationDTO request)
        {
            var resullt = new ValidationResults();

            ValidateFullName(request.FullName, resullt, true);
            ValidatePhoneNumber(request.PhoneNumber, resullt, true);
            ValidateEmail(request.Email, resullt, true);
            ValidateEmergencyNumber(request.EmergencyNumber, resullt, true);
            ValidateJobTitle(request.JobTitle, resullt, true);
            ValidateSalary(request.Salary, resullt, true);

            return resullt;

        }
        

    }
}
