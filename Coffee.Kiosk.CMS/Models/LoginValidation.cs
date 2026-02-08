using Coffee.Kiosk.CMS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class LoginValidation
    {
        public ValidationResults Validate(LoginDTO request)
        {
            var result = new ValidationResults();

            if (string.IsNullOrWhiteSpace(request.Email))
                result.AddError("Email", "Email is required.");

            if (string.IsNullOrWhiteSpace(request.Password))
                result.AddError("Password", "Password is required.");

            return result;
        }
    }
}
