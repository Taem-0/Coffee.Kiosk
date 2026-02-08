using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.WizardFormSequence
{
    public partial class OwnerRegistration : Form
    {
        public IServiceProvider ServiceProvider { get; set; }
        private AccountController _accountController;
        private bool _isValidating = false;

        public OwnerRegistration()
        {
            InitializeComponent();

            ApplyMyThemeSimple();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ServiceProvider != null)
            {
                _accountController = ServiceProvider.GetRequiredService<AccountController>();
            }
        }

        private void ApplyMyThemeSimple()
        {
            //Manual stuff
            this.BackColor = UIhelp.ThemeColors.Background;
            this.ForeColor = UIhelp.ThemeColors.TextColor;

            guna2Panel1.FillColor = UIhelp.ThemeColors.MediumBrown;

            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;

            label2.ForeColor = UIhelp.ThemeColors.TextColor;
            label2.BackColor = Color.Transparent;

            label3.ForeColor = UIhelp.ThemeColors.TextColor;
            label3.BackColor = Color.Transparent;

            label4.ForeColor = UIhelp.ThemeColors.TextColor;
            label4.BackColor = Color.Transparent;

            label5.ForeColor = UIhelp.ThemeColors.TextColor;
            label5.BackColor = Color.Transparent;

            label6.ForeColor = UIhelp.ThemeColors.TextColor;
            label6.BackColor = Color.Transparent;

            label7.ForeColor = UIhelp.ThemeColors.TextColor;
            label7.BackColor = Color.Transparent;

            label8.ForeColor = UIhelp.ThemeColors.TextColor;
            label8.BackColor = Color.Transparent;

            // Apply theme to textboxes with a helper method
            ApplyThemeToTextBox(shopNameTextBox);
            ApplyThemeToTextBox(firstNameTextBox);
            ApplyThemeToTextBox(lastNameTextBox);
            ApplyThemeToTextBox(phoneNumberTextBox);
            ApplyThemeToTextBox(emailAddTextBox);
            ApplyThemeToTextBox(passwordTextBox);
            ApplyThemeToTextBox(confirmPasswordTextBox);

            nextButton.FillColor = UIhelp.ThemeColors.ButtonColor;
            nextButton.ForeColor = Color.White;
            nextButton.BorderColor = UIhelp.ThemeColors.BorderColor;

            cancelButton.FillColor = UIhelp.ThemeColors.ButtonColor;
            cancelButton.ForeColor = Color.White;
            cancelButton.BorderColor = UIhelp.ThemeColors.BorderColor;

            nextButton.MouseEnter += (s, args) => nextButton.FillColor = UIhelp.ThemeColors.ButtonHover;
            nextButton.MouseLeave += (s, args) => nextButton.FillColor = UIhelp.ThemeColors.ButtonColor;

            cancelButton.MouseEnter += (s, args) => cancelButton.FillColor = UIhelp.ThemeColors.ButtonHover;
            cancelButton.MouseLeave += (s, args) => cancelButton.FillColor = UIhelp.ThemeColors.ButtonColor;
        }

        private void ApplyThemeToTextBox(Guna2TextBox textBox)
        {
            textBox.FillColor = UIhelp.ThemeColors.Background;
            textBox.ForeColor = UIhelp.ThemeColors.TextColor;
            textBox.BorderColor = UIhelp.ThemeColors.BorderColor;
            textBox.FocusedState.BorderColor = UIhelp.ThemeColors.LightBrown;
            textBox.HoverState.BorderColor = UIhelp.ThemeColors.LightBrown;

            // Set error colors
            textBox.DisabledState.BorderColor = UIhelp.ThemeColors.DisabledColor;
            textBox.DisabledState.FillColor = UIhelp.ThemeColors.DisabledColor;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            // DON'T clear all errors first - we need to show them!
            // Validate all fields - this will show errors AND clear invalid input
            if (!ValidateAllFields())
                return;

            var password = passwordTextBox.Text;
            var salt = LogicHelpers.GenerateSalt();
            var passwordHash = LogicHelpers.HashPassword(password, salt);

            var ownerDto = new RegistrationDTO
            {
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                MiddleName = "",
                Email = emailAddTextBox.Text.Trim(),
                PhoneNumber = phoneNumberTextBox.Text.Trim(),
                JobTitle = "Owner",
                Salary = "0",
                Department = Department.ADMINISTRATION,
                EmploymentType = EmploymentType.FULL_TIME,
                Role = AccountRole.OWNER,
                ProfilePicturePath = null,
                PasswordHash = passwordHash,
                PasswordSalt = salt,
                IsFirstLogin = false
            };

            var validationResult = _accountController.Register(ownerDto);

            if (!validationResult.IsValid)
            {
                ShowValidationErrors(validationResult);
                return;
            }

            MessageBox.Show("Owner account created successfully!",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateAllFields()
        {
            bool isValid = true;
            bool firstErrorFocused = false;

            if (string.IsNullOrWhiteSpace(shopNameTextBox.Text))
            {
                ShowError(shopNameTextBox, "Shop name is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    shopNameTextBox.Focus();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                ShowError(firstNameTextBox, "First name is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    firstNameTextBox.Focus();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                ShowError(lastNameTextBox, "Last name is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    lastNameTextBox.Focus();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(emailAddTextBox.Text))
            {
                ShowError(emailAddTextBox, "Email is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    emailAddTextBox.Focus();
                    firstErrorFocused = true;
                }
            }
            else if (!IsValidEmail(emailAddTextBox.Text))
            {
                ShowError(emailAddTextBox, "Please enter a valid email address", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    emailAddTextBox.Focus();
                    emailAddTextBox.SelectAll();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(phoneNumberTextBox.Text))
            {
                ShowError(phoneNumberTextBox, "Phone number is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    phoneNumberTextBox.Focus();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                ShowError(passwordTextBox, "Password is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    passwordTextBox.Focus();
                    firstErrorFocused = true;
                }
            }
            else if (passwordTextBox.Text.Length < 8)
            {
                ShowError(passwordTextBox, "Password must be at least 8 characters", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    passwordTextBox.Focus();
                    passwordTextBox.SelectAll();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text))
            {
                ShowError(confirmPasswordTextBox, "Please confirm your password", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    confirmPasswordTextBox.Focus();
                    firstErrorFocused = true;
                }
            }
            else if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                ShowError(confirmPasswordTextBox, "Passwords do not match", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    confirmPasswordTextBox.Focus();
                    confirmPasswordTextBox.SelectAll();
                    firstErrorFocused = true;
                }
            }

            return isValid;
        }

        private void ShowError(Guna2TextBox textBox, string errorMessage, bool clearInput = false)
        {
            // Set error text and style
            textBox.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.FocusedState.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.HoverState.BorderColor = UIhelp.ThemeColors.ErrorColor;

            // Set the error message (this will show as placeholder when focused)
            textBox.PlaceholderText = errorMessage;
            textBox.PlaceholderForeColor = UIhelp.ThemeColors.ErrorColor;

            // Clear the input if requested
            if (clearInput)
            {
                textBox.Text = "";
            }
        }

        private void ClearAllErrors()
        {
            ClearError(shopNameTextBox);
            ClearError(firstNameTextBox);
            ClearError(lastNameTextBox);
            ClearError(emailAddTextBox);
            ClearError(phoneNumberTextBox);
            ClearError(passwordTextBox);
            ClearError(confirmPasswordTextBox);
        }

        private void ClearError(Guna2TextBox textBox)
        {
            // Reset to normal theme colors
            textBox.BorderColor = UIhelp.ThemeColors.BorderColor;
            textBox.FocusedState.BorderColor = UIhelp.ThemeColors.LightBrown;
            textBox.HoverState.BorderColor = UIhelp.ThemeColors.LightBrown;

            // Clear placeholder but keep the text
            textBox.PlaceholderText = "";
            textBox.PlaceholderForeColor = Color.Gray; // Default placeholder color
        }

        private void ShowValidationErrors(ValidationResults result)
        {
            foreach (var error in result.Errors)
            {
                switch (error.Key.ToLower())
                {
                    case "first name":
                    case "firstname":
                        ShowError(firstNameTextBox, error.Value, true); // Clear invalid first name
                        break;
                    case "last name":
                    case "lastname":
                        ShowError(lastNameTextBox, error.Value, true); // Clear invalid last name
                        break;
                    case "email":
                        ShowError(emailAddTextBox, error.Value, true); // Clear invalid email
                        break;
                    case "phone number":
                    case "phonenumber":
                        ShowError(phoneNumberTextBox, error.Value, true); // Clear invalid phone
                        break;
                    case "password":
                        ShowError(passwordTextBox, error.Value, true); // Clear invalid password
                        break;
                    default:
                        MessageBox.Show(error.Value, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ValidateFields()
        {
            // Clear real-time formatting errors first
            ClearAllErrors();

            bool isValid = !string.IsNullOrWhiteSpace(shopNameTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(firstNameTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(lastNameTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(emailAddTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(phoneNumberTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(passwordTextBox.Text) &&
                          passwordTextBox.Text == confirmPasswordTextBox.Text;

            nextButton.Enabled = isValid;

            // Show real-time format validation WITHOUT clearing
            if (!string.IsNullOrWhiteSpace(emailAddTextBox.Text) && !IsValidEmail(emailAddTextBox.Text))
            {
                emailAddTextBox.BorderColor = UIhelp.ThemeColors.ErrorColor;
                emailAddTextBox.PlaceholderText = "Invalid email format";
                emailAddTextBox.PlaceholderForeColor = UIhelp.ThemeColors.ErrorColor;
                nextButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(passwordTextBox.Text) && passwordTextBox.Text.Length < 8)
            {
                passwordTextBox.BorderColor = UIhelp.ThemeColors.ErrorColor;
                passwordTextBox.PlaceholderText = "Password too short (min 8 chars)";
                passwordTextBox.PlaceholderForeColor = UIhelp.ThemeColors.ErrorColor;
                nextButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(passwordTextBox.Text) &&
                !string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text) &&
                passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                confirmPasswordTextBox.BorderColor = UIhelp.ThemeColors.ErrorColor;
                confirmPasswordTextBox.PlaceholderText = "Passwords don't match";
                confirmPasswordTextBox.PlaceholderForeColor = UIhelp.ThemeColors.ErrorColor;
                nextButton.Enabled = false;
            }
        }

        private void shopNameTextBox_TextChanged(object sender, EventArgs e) => ValidateFields();
        private void firstNameTextBox_TextChanged(object sender, EventArgs e) => ValidateFields();
        private void lastNameTextBox_TextChanged(object sender, EventArgs e) => ValidateFields();
        private void emailAddTextBox_TextChanged(object sender, EventArgs e) => ValidateFields();
        private void phoneNumberTextBox_TextChanged(object sender, EventArgs e) => ValidateFields();
        private void passwordTextBox_TextChanged(object sender, EventArgs e) => ValidateFields();
        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e) => ValidateFields();
    }
}