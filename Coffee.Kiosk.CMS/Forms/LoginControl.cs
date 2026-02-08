using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms
{
    public partial class LoginControl : UserControl
    {
        private AccountController _controller;

        public LoginControl()
        {
            InitializeComponent();
            passwordTextBox.UseSystemPasswordChar = true;
        }

        public void SetController(AccountController controller)
        {
            _controller = controller;
        }


        public event Action<Employee> OnLoginSuccess;

        private void ShowValidationErrors(ValidationResults result)
        {
            string errorMessage = "";
            foreach (var error in result.Errors)
            {
                errorMessage += $"• {error.Value}\n";
            }
            MessageBox.Show(errorMessage, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ClearFields()
        {
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            var loginDto = new LoginDTO
            {
                Email = emailTextBox.Text.Trim(),
                Password = passwordTextBox.Text
            };

            var loginResult = _controller.Login(loginDto);

            if (!loginResult.ValidationResults.IsValid)
            {
                ShowValidationErrors(loginResult.ValidationResults);
                return;
            }

            if (loginResult.Employee == null)
            {
                MessageBox.Show("Invalid email or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OnLoginSuccess?.Invoke(loginResult.Employee);
        }
    }
}