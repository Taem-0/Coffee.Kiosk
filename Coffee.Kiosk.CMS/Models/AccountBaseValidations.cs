using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

            if (name.Length < 3 || name.Length > 100)
            {
                result.AddError(fieldDisplayName, $"{fieldDisplayName} must be 3–100 characters long.");
            }
        }

        public void ValidatePhoneNumber(string? phoneNumber, ValidationResults result, bool required)
        {

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                if (required)
                    result.AddError("PhoneNumber", "Phone Number is required.");
                return;
            }

            if (!Regex.IsMatch(phoneNumber, @"^(09|\+639)\d{9}$"))
            {
                result.AddError("PhoneNumber", "Phone Number is Invalid.");
            }

        }

        public void ValidateEmail(string? email, ValidationResults result, bool required)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                if (required)
                    result.AddError("Email", "Email is required");
                return;
            }

            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                result.AddError("Email", "Email is Invalid");
            }

        }

        public void ValidateEmergencyNumber(string? emergencyNumber, ValidationResults result, bool required)
        {
            if (string.IsNullOrWhiteSpace(emergencyNumber))
            {
                if (required)
                    result.AddError("EmergencyNumber", "Emergency Number is required");
                return;
            }

            if (!Regex.IsMatch(emergencyNumber, @"^(09|\+639)\d{9}$"))
            {
                result.AddError("EmergencyNumber", "Emergency Number is Invalid");
            }
        }

        public void ValidateJobTitle(string? jobTitle, ValidationResults result, bool required)
        {

            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                if (required)
                    result.AddError("JobTitle", "Job Title is required");
                return;
            }

            if (jobTitle.Length > 50)
            {
                result.AddError("JobTitle", "Job Title cannot exceed 50 characters");
            }

        }

        public void ValidateSalary(string salaryString, ValidationResults result, bool required)
        {

            if (string.IsNullOrWhiteSpace(salaryString))
            {
                if (required)
                    result.AddError("Salary", "Salary is required");
            }

            if (!decimal.TryParse(salaryString, out decimal salary))
            {
                result.AddError("Salary", "Salary must be a valid number");
                return;
            }

            if (salary < 0)
            {
                result.AddError("Salary", "Salary cannot be a negative number");
            }
        }

    }
}
