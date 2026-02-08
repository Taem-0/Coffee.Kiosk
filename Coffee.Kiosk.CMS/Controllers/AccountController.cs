using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
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

        // Add to AccountController class

        public bool ChangePassword(int employeeId, string newPassword, bool isFirstLogin = false)
        {
            try
            {
                return _service.ChangePassword(employeeId, newPassword, isFirstLogin);
            }
            catch
            {
                return false;
            }
        }

        public bool RequestPasswordReset(int employeeId)
        {
            try
            {
                // Check if there's already a pending request
                bool hasPendingRequest = _service.HasPendingResetRequest(employeeId);

                if (hasPendingRequest)
                {
                    return false; // Already has a pending request
                }

                // Submit new request
                _service.SubmitPasswordResetRequest(employeeId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DisplayDTO> GetPasswordResetRequests()
        {
            return _service.GetEmployeesWithResetRequests();
        }

        public bool ApprovePasswordReset(int employeeId, int approvedByAdminId)
        {
            try
            {
                _service.ApproveResetRequest(employeeId, approvedByAdminId);

                var tempPassword = LogicHelpers.GetTemporaryPasswordDisplay();
                System.Diagnostics.Debug.WriteLine($"Password reset approved for employee {employeeId}. Temporary password: {tempPassword}");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RejectPasswordReset(int employeeId, int rejectedByAdminId, string reason = "")
        {
            try
            {
                _service.RejectResetRequest(employeeId, rejectedByAdminId, reason);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool HasPendingResetRequest(int employeeId)
        {
            try
            {
                return _service.HasPendingResetRequest(employeeId);
            }
            catch
            {
                return false;
            }
        }
    }
}
