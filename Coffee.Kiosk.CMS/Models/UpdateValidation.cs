using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;

public class UpdateValidation : AccountBaseValidations
{
    public ValidationResults Validate(DisplayDTO request)
    {
        var result = new ValidationResults();

        ValidateName(request.FirstName, "First Name", result, false);
        ValidateName(request.MiddleName, "Middle Name", result, false);
        ValidateName(request.LastName, "Last Name", result, false);

        ValidatePhoneNumber(request.PhoneNumber, result, false, "Phone Number");
        ValidateEmail(request.Email, result, false);

        ValidateEmergencyContact(
            request.EmergencyFirstName,
            request.EmergencyLastName,
            request.EmergencyNumber,
            result,
            false
        );

        ValidateJobTitle(request.JobTitle, result, false);
        ValidateSalary(request.Salary, result, false);

        // Wooopss
        // ValidateEnum(request.Role, "Role", result);
        // ValidateEnum(request.Department, "Department", result);
        // ValidateEnum(request.EmploymentType, "Employment Type", result);

        return result;
    }
}
