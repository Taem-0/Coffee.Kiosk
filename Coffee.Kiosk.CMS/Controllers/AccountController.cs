using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Controllers
{
    public class AccountController(RegistrationValidation validation, UpdateValidation updateValidation, AccountsService service, LoginValidation loginValidation)
    {

        private readonly RegistrationValidation _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        private readonly UpdateValidation _updateValidation = updateValidation ?? throw new ArgumentNullException(nameof(updateValidation));
        private readonly LoginValidation _loginValidation = loginValidation ?? throw new ArgumentException(nameof(loginValidation));
        private readonly AccountsService _service = service ?? throw new ArgumentNullException(nameof(service));

        public ValidationResults Register(RegistrationDTO request)
        {

            ValidationResults result = _validation.Validate(request);

            if (!result.IsValid)
                return result;
            

            _service.RegisterUser(request);

            return result;

        }

        public ValidationResults Update(DisplayDTO request)
        {

            ValidationResults result = _updateValidation.Validate(request);

            if (!result.IsValid)
                return result;


            _service.UpdateUser(request);

            return result;

        }

        public LoginResult Login(LoginDTO request)
        {
            var result = _loginValidation.Validate(request);

            if (!result.IsValid)
                return new LoginResult { ValidationResults = result, Employee = null };

            var employee = _service.ValidateLogin(request.Email, request.Password);

            if (employee == null)
                result.AddError("Login", "Invalid email or password.");

            return new LoginResult { ValidationResults = result, Employee = employee };
        }

        public List<DisplayDTO> GetDisplayDTOs()
        {

            return _service.DisplayAccounts();

        }

        public void DeactivateAccount(DisplayDTO currentAccount)
        {

            _service.Deactivate(currentAccount);

        }

        public class LoginResult
        {
            public ValidationResults ValidationResults { get; set; }
            public Employee Employee { get; set; }
        }
    }
}
