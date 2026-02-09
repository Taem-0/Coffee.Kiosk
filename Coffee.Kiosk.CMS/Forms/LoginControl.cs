using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms
{
    public partial class LoginControl : UserControl
    {
        private AccountController _controller;
        private bool _passwordVisible = false;

        private readonly Color _darkBrown = ColorTranslator.FromHtml("#3d211a");
        private readonly Color _mediumBrown = ColorTranslator.FromHtml("#6f4d38");
        private readonly Color _lightBrown = ColorTranslator.FromHtml("#a07856");
        private readonly Color _beige = ColorTranslator.FromHtml("#cbb799");
        private readonly Color _background = ColorTranslator.FromHtml("#f5f5dc");

        public LoginControl()
        {
            InitializeComponent();
            ApplyLoginTheme();

            logoPictureBox.Parent = this;
            logoPictureBox.BackColor = Color.Transparent;
            logoPictureBox.FillColor = Color.Transparent;
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;



            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.PasswordChar = '*';
            hideButton.Text = "Show";
        }

        private void ApplyLoginTheme()
        {
            BackColor = _background;
            ForeColor = _darkBrown;

            ApplyTextBoxTheme(emailTextBox);
            ApplyTextBoxTheme(passwordTextBox);

            loginButton.FillColor = _mediumBrown;
            loginButton.ForeColor = Color.White;
            loginButton.BorderColor = _darkBrown;
            loginButton.BorderThickness = 1;
            loginButton.HoverState.FillColor = _lightBrown;

            hideButton.ForeColor = _darkBrown;
        }

        private void ApplyTextBoxTheme(Guna.UI2.WinForms.Guna2TextBox tb)
        {
            tb.FillColor = Color.White;
            tb.ForeColor = _darkBrown;
            tb.BorderColor = _mediumBrown;
            tb.FocusedState.BorderColor = _lightBrown;
            tb.HoverState.BorderColor = _lightBrown;
            tb.PlaceholderForeColor = Color.Gray;
        }

        public void SetController(AccountController controller)
        {
            _controller = controller;
        }

        public event Action<Employee> OnLoginSuccess;

        private void ShowValidationErrors(ValidationResults result)
        {
            ClearAllErrors();

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
                        ShowError(emailTextBox, error.Value, false);
                        ShowError(passwordTextBox, error.Value, false);
                        break;
                    default:
                        MessageBox.Show(error.Value, "Login Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        private void ShowError(Guna.UI2.WinForms.Guna2TextBox tb, string msg, bool clear)
        {
            tb.BorderColor = Color.Firebrick;
            tb.FocusedState.BorderColor = Color.Firebrick;
            tb.HoverState.BorderColor = Color.Firebrick;
            tb.PlaceholderText = msg;
            tb.PlaceholderForeColor = Color.Firebrick;

            if (clear)
                tb.Text = "";
        }

        private void ClearError(Guna.UI2.WinForms.Guna2TextBox tb)
        {
            tb.BorderColor = _mediumBrown;
            tb.FocusedState.BorderColor = _lightBrown;
            tb.HoverState.BorderColor = _lightBrown;
            tb.PlaceholderText = "";
            tb.PlaceholderForeColor = Color.Gray;
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

            var dto = new LoginDTO
            {
                Email = emailTextBox.Text.Trim(),
                Password = passwordTextBox.Text
            };

            var result = _controller.Login(dto);

            if (!result.ValidationResults.IsValid)
            {
                ShowValidationErrors(result.ValidationResults);
                return;
            }

            if (result.Employee == null)
            {
                ShowError(emailTextBox, "Invalid email or password", false);
                ShowError(passwordTextBox, "Invalid email or password", true);
                return;
            }

            OnLoginSuccess?.Invoke(result.Employee);
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;

            passwordTextBox.UseSystemPasswordChar = !_passwordVisible;
            passwordTextBox.PasswordChar = _passwordVisible ? '\0' : '*';
            hideButton.Text = _passwordVisible ? "Hide" : "Show";
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
