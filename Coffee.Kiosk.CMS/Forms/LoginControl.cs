using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms
{
    public partial class LoginControl : UserControl
    {
        private AccountController _controller;
        private bool _passwordVisible = false;

        public LoginControl()
        {
            InitializeComponent();

            ApplyLoginTheme();

            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.PasswordChar = '*';
            hideButton.Text = "Show";
        }

        private void ApplyLoginTheme()
        {
            // ... existing theme code ...
        }

        public void SetController(AccountController controller)
        {
            _controller = controller;
        }

        public event Action<Employee> OnLoginSuccess;

        private void ShowValidationErrors(ValidationResults result)
        {
            // Clear previous errors
            ClearError(emailTextBox);
            ClearError(passwordTextBox);

            foreach (var error in result.Errors)
            {
                switch (error.Key.ToLower())
                {
                    case "email":
                        ShowError(emailTextBox, error.Value, true);
                        break;
                    case "password":
                        ShowError(passwordTextBox, error.Value, true);
                        break;
                    case "login":
                        // For general login errors, show in both fields
                        ShowError(emailTextBox, error.Value, false);
                        ShowError(passwordTextBox, error.Value, false);
                        break;
                    default:
                        // For any other errors, show message box
                        MessageBox.Show(error.Value, "Login Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        private void ShowError(Guna.UI2.WinForms.Guna2TextBox textBox, string errorMessage, bool clearInput = false)
        {
            textBox.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.FocusedState.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.HoverState.BorderColor = UIhelp.ThemeColors.ErrorColor;

            textBox.PlaceholderText = errorMessage;
            textBox.PlaceholderForeColor = UIhelp.ThemeColors.ErrorColor;

            if (clearInput)
            {
                textBox.Text = "";
            }
        }

        private void ClearError(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            textBox.BorderColor = UIhelp.ThemeColors.BorderColor;
            textBox.FocusedState.BorderColor = UIhelp.ThemeColors.LightBrown;
            textBox.HoverState.BorderColor = UIhelp.ThemeColors.LightBrown;

            textBox.PlaceholderText = "";
            textBox.PlaceholderForeColor = Color.Gray;
        }

        private void ClearAllErrors()
        {
            ClearError(emailTextBox);
            ClearError(passwordTextBox);
        }

        public void ClearFields()
        {
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
            ClearAllErrors();
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            ClearAllErrors();

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
                ShowError(emailTextBox, "Invalid email or password", false);
                ShowError(passwordTextBox, "Invalid email or password", true);
                return;
            }

            OnLoginSuccess?.Invoke(loginResult.Employee);
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;

            if (_passwordVisible)
            {
                passwordTextBox.UseSystemPasswordChar = false;
                passwordTextBox.PasswordChar = '\0';
                hideButton.Text = "Hide";
            }
            else
            {
                passwordTextBox.UseSystemPasswordChar = true;
                passwordTextBox.PasswordChar = '*';
                hideButton.Text = "Show";
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearError(emailTextBox);
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearError(passwordTextBox);
        }
    }
}