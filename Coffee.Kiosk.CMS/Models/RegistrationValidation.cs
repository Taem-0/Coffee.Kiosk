using Coffee.Kiosk.CMS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class RegistrationValidation
    {

        public ValidationResults Validate (RegistrationDTO request)
        {
            var resullt = new ValidationResults();

            ValidateFullName(request.FullName, resullt);
            ValidatePhoneNumber(request.PhoneNumber, resullt);
            ValidateEmail(request.Email, resullt);
            ValidateEmergencyNumber(request.EmergencyNumber, resullt);
            ValidateJobTitle(request.JobTitle, resullt);
            ValidateSalary(request.Salary, resullt);

            return resullt;

        }


        private void ValidateFullName(string? fullName, ValidationResults result)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                result.AddError("FullName", "Full Name is required.");
                return;
            }

            if (fullName.Length < 3 || fullName.Length > 100)
            {
                result.AddError("FullName", "Full Name must be 3–100 characters long.");
            }
        }

        private void ValidatePhoneNumber(string? phoneNumber, ValidationResults result)
        {

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                result.AddError("PhoneNumber", "Phone Number is required.");
                return;
            }

            if (!Regex.IsMatch(phoneNumber, @"^(09|\+639)\d{9}$"))
            {
                result.AddError("PhoneNumber", "Phone Number is Invalid.");
            }

        }

        private void ValidateEmail(string? email, ValidationResults result)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                result.AddError("Email", "Email is required");
                return;
            }

            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                result.AddError("Email", "Email is Invalid");
            }

        }

        private void ValidateEmergencyNumber(string? emergencyNumber, ValidationResults result)
        {
            if (string.IsNullOrWhiteSpace(emergencyNumber))
            {
                result.AddError("EmergencyNumber", "Emergency Number is required");
                return;
            }

            if (!Regex.IsMatch(emergencyNumber, @"^(09|\+639)\d{9}$"))
            {
                result.AddError("EmergencyNumber", "Emergency Number is Invalid");
            }
        }

        private void ValidateJobTitle(string? jobTitle, ValidationResults result)
        {

            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                result.AddError("JobTitle", "Job Title is required");
                return;
            }

            if (jobTitle.Length > 50)
            {
                result.AddError("JobTitle", "Job Title cannot exceed 50 characters");
            }

        }

        private void ValidateSalary(string salaryString, ValidationResults result)
        {

            if (string.IsNullOrWhiteSpace(salaryString))
            {
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
