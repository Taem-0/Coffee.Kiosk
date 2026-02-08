using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.WizardFormSequence
{
    public partial class OwnerRegistration : Form
    {
        public IServiceProvider ServiceProvider { get; set; }
        private AccountController _accountController;

        public OwnerRegistration()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ServiceProvider != null)
            {
                _accountController = ServiceProvider.GetRequiredService<AccountController>();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!ValidatePassword())
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

        private bool ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Password is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordTextBox.Focus();
                return false;
            }

            if (passwordTextBox.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordTextBox.Focus();
                passwordTextBox.SelectAll();
                return false;
            }

            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords do not match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                confirmPasswordTextBox.Focus();
                confirmPasswordTextBox.SelectAll();
                return false;
            }

            return true;
        }

        private void ShowValidationErrors(ValidationResults result)
        {
            string errorMessage = "Please fix the following errors:\n\n";
            foreach (var error in result.Errors)
            {
                errorMessage += $"• {error.Value}\n";
            }
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ValidateFields()
        {
            bool isValid = !string.IsNullOrWhiteSpace(shopNameTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(firstNameTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(lastNameTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(emailAddTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(phoneNumberTextBox.Text) &&
                          !string.IsNullOrWhiteSpace(passwordTextBox.Text) &&
                          passwordTextBox.Text == confirmPasswordTextBox.Text;

            nextButton.Enabled = isValid;
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