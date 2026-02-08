using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.Small_Dialogues
{
    public partial class passwordChangeDialogue : Form
    {
        private readonly AccountController _controller;
        private readonly Employee _currentEmployee;
        private readonly bool _isFirstLogin;

        private bool _oldPasswordVisible = false;
        private bool _newPasswordVisible = false;
        private bool _confirmPasswordVisible = false;

        public event EventHandler PasswordChanged;

        public passwordChangeDialogue(AccountController controller, Employee currentEmployee, bool isFirstLogin = false)
        {
            InitializeComponent();
            _controller = controller;
            _currentEmployee = currentEmployee;
            _isFirstLogin = isFirstLogin;

            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = _isFirstLogin ? "Change Password (First Login)" : "Change Password";

            oldPassTextBox.Visible = !_isFirstLogin;
            label2.Visible = !_isFirstLogin;
            hideButton.Visible = !_isFirstLogin;

            oldPassTextBox.UseSystemPasswordChar = true;
            oldPassTextBox.PasswordChar = '●';
            newPassTextBox.UseSystemPasswordChar = true;
            newPassTextBox.PasswordChar = '●';
            confirmPassTextBox.UseSystemPasswordChar = true;
            confirmPassTextBox.PasswordChar = '●';

            hideButton.Text = "Show";
            hideButton2.Text = "Show";
            hideButton3.Text = "Show";

            ConfirmButton.Click += ConfirmButton_Click;
            cancelButton.Click += (s, e) => this.Close();
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
            if (!_isFirstLogin)
            {
                ClearError(oldPassTextBox);
            }
            ClearError(newPassTextBox);
            ClearError(confirmPassTextBox);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            ClearAllErrors();

            string currentPassword = _isFirstLogin ? "" : oldPassTextBox.Text;
            string newPassword = newPassTextBox.Text;
            string confirmPassword = confirmPassTextBox.Text;

            bool hasError = false;

            // Validate passwords
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                ShowError(newPassTextBox, "New password cannot be empty", true);
                hasError = true;
            }
            else if (newPassword.Length < 6)
            {
                ShowError(newPassTextBox, "Password must be at least 6 characters", true);
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowError(confirmPassTextBox, "Please confirm your password", true);
                hasError = true;
            }
            else if (newPassword != confirmPassword)
            {
                ShowError(confirmPassTextBox, "Passwords do not match", true);
                hasError = true;
            }

            if (!_isFirstLogin)
            {
                if (string.IsNullOrWhiteSpace(currentPassword))
                {
                    ShowError(oldPassTextBox, "Current password is required", true);
                    hasError = true;
                }
                else
                {
                    var loginResult = _controller.Login(new LoginDTO
                    {
                        Email = _currentEmployee.Email,
                        Password = currentPassword
                    });

                    if (loginResult.Employee == null)
                    {
                        ShowError(oldPassTextBox, "Current password is incorrect", true);
                        hasError = true;
                    }
                }
            }

            if (hasError)
                return;

            bool success = _controller.ChangePassword(
                _currentEmployee.Id,
                newPassword,
                _isFirstLogin
            );

            if (success)
            {
                MessageBox.Show("Password changed successfully!" +
                    (_isFirstLogin ? " You can now log in with your new password." : ""),
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PasswordChanged?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                ShowError(newPassTextBox, "Failed to change password. Please try again.", true);
                ShowError(confirmPassTextBox, "", true);
            }
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            _oldPasswordVisible = !_oldPasswordVisible;

            if (_oldPasswordVisible)
            {
                oldPassTextBox.UseSystemPasswordChar = false;
                oldPassTextBox.PasswordChar = '\0';
                hideButton.Text = "Hide";
            }
            else
            {
                oldPassTextBox.UseSystemPasswordChar = true;
                oldPassTextBox.PasswordChar = '●';
                hideButton.Text = "Show";
            }
        }

        private void hideButton2_Click(object sender, EventArgs e)
        {
            _newPasswordVisible = !_newPasswordVisible;

            if (_newPasswordVisible)
            {
                newPassTextBox.UseSystemPasswordChar = false;
                newPassTextBox.PasswordChar = '\0';
                hideButton2.Text = "Hide";
            }
            else
            {
                newPassTextBox.UseSystemPasswordChar = true;
                newPassTextBox.PasswordChar = '●';
                hideButton2.Text = "Show";
            }
        }

        private void hideButton3_Click(object sender, EventArgs e)
        {
            _confirmPasswordVisible = !_confirmPasswordVisible;

            if (_confirmPasswordVisible)
            {
                confirmPassTextBox.UseSystemPasswordChar = false;
                confirmPassTextBox.PasswordChar = '\0';
                hideButton3.Text = "Hide";
            }
            else
            {
                confirmPassTextBox.UseSystemPasswordChar = true;
                confirmPassTextBox.PasswordChar = '●';
                hideButton3.Text = "Show";
            }
        }

        private void oldPassTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearError(oldPassTextBox);
        }

        private void newPassTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearError(newPassTextBox);
        }

        private void confirmPassTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearError(confirmPassTextBox);
        }
    }
}