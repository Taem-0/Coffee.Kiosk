using System.Text.RegularExpressions;

namespace Coffee.Kiosk.CMS.Models
{
    public abstract class AccountBaseValidations
    {

        public void ValidateName(string? name, string fieldDisplayName, ValidationResults result, bool required)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (required)
                    result.AddError(fieldDisplayName, $"{fieldDisplayName} is required.");
                return;
            }

            if (name.Length < 2 || name.Length > 100)
                result.AddError(fieldDisplayName, $"{fieldDisplayName} must be 2–100 characters long.");
        }


        public void ValidatePhoneNumber(string? phoneNumber, ValidationResults result, bool required, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                if (required)
                    result.AddError(fieldName, $"{fieldName} is required.");
                return;
            }

            if (!Regex.IsMatch(phoneNumber, @"^(09|\+639)\d{9}$"))
                result.AddError(fieldName, $"{fieldName} is invalid.");
        }


        public void ValidateEmail(string? email, ValidationResults result, bool required)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                if (required)
                    result.AddError("Email", "Email is required.");
                return;
            }

            if (!Regex.IsMatch(email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase))
            {
                result.AddError("Email", "Email is invalid.");
            }
        }


        public void ValidateEmergencyContact(
            string? firstName,
            string? lastName,
            string? phoneNumber,
            ValidationResults result,
            bool required)
        {
            ValidateName(firstName, "Emergency First Name", result, required);
            ValidateName(lastName, "Emergency Last Name", result, required);
            ValidatePhoneNumber(phoneNumber, result, required, "Emergency Phone Number");
        }


        public void ValidateJobTitle(string? jobTitle, ValidationResults result, bool required)
        {
            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                if (required)
                    result.AddError("JobTitle", "Job title is required.");
                return;
            }

            if (jobTitle.Length > 50)
                result.AddError("JobTitle", "Job title cannot exceed 50 characters.");
        }

        public void ValidateSalary(string? salaryString, ValidationResults result, bool required)
        {
            if (string.IsNullOrWhiteSpace(salaryString))
            {
                if (required)
                    result.AddError("Salary", "Salary is required.");
                return;
            }

            if (!decimal.TryParse(salaryString, out decimal salary))
            {
                result.AddError("Salary", "Salary must be a valid number.");
                return;
            }

            if (salary < 0)
                result.AddError("Salary", "Salary cannot be negative.");
        }



        public void ValidateEnum<T>(T value, string fieldName, ValidationResults result)
            where T : struct, Enum
        {
            if (!Enum.IsDefined(typeof(T), value))
                result.AddError(fieldName, $"{fieldName} selection is invalid.");
        }
    }
}
