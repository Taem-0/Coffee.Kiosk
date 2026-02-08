using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.Small_Dialogues
{
    public partial class passwordChangeDialogue : Form
    {
        private readonly AccountController _controller;
        private readonly Employee _currentEmployee;
        private readonly bool _isFirstLogin;

        // Event to notify when password is changed successfully
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
            // Set form title
            this.Text = _isFirstLogin ? "Change Password (First Login)" : "Change Password";

            // Hide old password field if it's first login
            oldPassTextBox.Visible = !_isFirstLogin;
            label2.Visible = !_isFirstLogin;

            // Set password char
            oldPassTextBox.PasswordChar = '●';
            newPassTextBox.PasswordChar = '●';
            confirmPassTextBox.PasswordChar = '●';

            // Wire up button events
            ConfirmButton.Click += ConfirmButton_Click;
            cancelButton.Click += (s, e) => this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string currentPassword = _isFirstLogin ? "" : oldPassTextBox.Text;
            string newPassword = newPassTextBox.Text;
            string confirmPassword = confirmPassTextBox.Text;

            // Validate passwords
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("New password cannot be empty.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_isFirstLogin)
            {
                // Validate current password
                var loginResult = _controller.Login(new LoginDTO
                {
                    Email = _currentEmployee.Email,
                    Password = currentPassword
                });

                if (loginResult.Employee == null)
                {
                    MessageBox.Show("Current password is incorrect.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Change the password
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

                // Notify that password was changed
                PasswordChanged?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to change password. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}