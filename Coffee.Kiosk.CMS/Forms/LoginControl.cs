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

        public LoginControl()
        {
            InitializeComponent();

            // APPLY LOGIN THEME
            ApplyLoginTheme();

            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void ApplyLoginTheme()
        {
            // Apply to the UserControl itself
            this.BackColor = UIhelp.ThemeColors.Background; // #f5f5dc
            this.ForeColor = UIhelp.ThemeColors.TextColor;   // #3d211a

            // Apply to the left panel
            guna2Panel1.FillColor = UIhelp.ThemeColors.Background; // #f5f5dc
            guna2Panel1.BackColor = Color.Transparent;

            // Apply to labels
            label1.ForeColor = UIhelp.ThemeColors.TextColor; // #3d211a
            label1.BackColor = Color.Transparent;

            label2.ForeColor = UIhelp.ThemeColors.TextColor; // #3d211a
            label2.BackColor = Color.Transparent;

            label3.ForeColor = UIhelp.ThemeColors.TextColor; // #3d211a
            label3.BackColor = Color.Transparent;

            // Apply to text boxes
            emailTextBox.FillColor = UIhelp.ThemeColors.Background; // #f5f5dc
            emailTextBox.ForeColor = UIhelp.ThemeColors.TextColor;   // #3d211a
            emailTextBox.BorderColor = UIhelp.ThemeColors.BorderColor; // #6f4d38
            emailTextBox.FocusedState.BorderColor = UIhelp.ThemeColors.LightBrown; // #a07856
            emailTextBox.HoverState.BorderColor = UIhelp.ThemeColors.LightBrown; // #a07856

            passwordTextBox.FillColor = UIhelp.ThemeColors.Background; // #f5f5dc
            passwordTextBox.ForeColor = UIhelp.ThemeColors.TextColor;   // #3d211a
            passwordTextBox.BorderColor = UIhelp.ThemeColors.BorderColor; // #6f4d38
            passwordTextBox.FocusedState.BorderColor = UIhelp.ThemeColors.LightBrown; // #a07856
            passwordTextBox.HoverState.BorderColor = UIhelp.ThemeColors.LightBrown; // #a07856

            // Apply to login button
            loginButton.FillColor = UIhelp.ThemeColors.ButtonColor;     // #6f4d38
            loginButton.ForeColor = Color.White;
            loginButton.BorderColor = UIhelp.ThemeColors.BorderColor;   // #6f4d38
            loginButton.BorderRadius = 8;

            // Add hover effect to button
            loginButton.MouseEnter += (s, args) => loginButton.FillColor = UIhelp.ThemeColors.ButtonHover; // #a07856
            loginButton.MouseLeave += (s, args) => loginButton.FillColor = UIhelp.ThemeColors.ButtonColor; // #6f4d38

            // Apply to logo picture box (make it transparent)
            logoPictureBox.BackColor = Color.Transparent;
            logoPictureBox.FillColor = Color.Transparent;
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