using Coffee.Kiosk.CMS.DTOs;

namespace Coffee.Kiosk.CMS.Models
{
    public class RegistrationValidation : AccountBaseValidations
    {
        public ValidationResults Validate(RegistrationDTO request)
        {
            var result = new ValidationResults();

            ValidateName(request.FirstName, "First Name", result, true);
            ValidateName(request.MiddleName, "Middle Name", result, false);
            ValidateName(request.LastName, "Last Name", result, true);

            ValidatePhoneNumber(request.PhoneNumber, result, false, "Phone Number");
            ValidateEmail(request.Email, result, true);

            ValidateEmergencyContact(
                request.EmergencyFirstName,
                request.EmergencyLastName,
                request.EmergencyNumber,
                result,
                false
            );

            ValidateJobTitle(request.JobTitle, result, true);

            ValidateEnum(request.Role, "Role", result);
            ValidateEnum(request.Department, "Department", result);
            ValidateEnum(request.EmploymentType, "Employment Type", result);

            return result;
        }
    }
}