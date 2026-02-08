using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewestRegisterView : Form
    {

        private readonly AccountController _controller;
        private readonly DisplayDTO _draft;

        public NewestRegisterView(AccountController controller, DisplayDTO draft)
        {
            InitializeComponent();



            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _draft = draft ?? throw new ArgumentNullException(nameof(draft));

            LoadDraftValues();
        }

        private void LoadDraftValues()
        {
            FirstNameTextBox.Text = _draft.FirstName;
            MiddleNameTextBox.Text = _draft.MiddleName;
            LastNameTextBox.Text = _draft.LastName;
            PhoneTextBox.Text = _draft.PhoneNumber;
            EmailTextBox.Text = _draft.Email;
            EmergencyFirstNameTextBox.Text = _draft.EmergencyFirstName;
            EmergencyLastNameTextBox.Text = _draft.EmergencyLastName;
            EmergencyPhoneTextBox.Text = _draft.EmergencyNumber;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
                return;

            _draft.FirstName = FirstNameTextBox.Text.Trim();
            _draft.MiddleName = MiddleNameTextBox.Text.Trim();
            _draft.LastName = LastNameTextBox.Text.Trim();
            _draft.PhoneNumber = PhoneTextBox.Text.Trim();
            _draft.Email = EmailTextBox.Text.Trim();
            _draft.EmergencyFirstName = EmergencyFirstNameTextBox.Text.Trim();
            _draft.EmergencyLastName = EmergencyLastNameTextBox.Text.Trim();
            _draft.EmergencyNumber = EmergencyPhoneTextBox.Text.Trim();

            using (var step2 = new SecondNewestRegisterView(_controller, _draft))
            {
                var result = step2.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
                else if (result == DialogResult.OK)
                {
                    this.Close();
                }
                else if (result == DialogResult.Retry)
                {
                }
            }
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void AddPfpButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Profile Picture";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _draft.ProfilePicturePath = ofd.FileName;

                    PictureBox.Image = Image.FromFile(ofd.FileName);
                }
            }

            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {

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
            ClearError(FirstNameTextBox);
            ClearError(MiddleNameTextBox);
            ClearError(LastNameTextBox);
            ClearError(PhoneTextBox);
            ClearError(EmailTextBox);
            ClearError(EmergencyFirstNameTextBox);
            ClearError(EmergencyLastNameTextBox);
            ClearError(EmergencyPhoneTextBox);
        }

        private bool ValidateAllFields()
        {
            ClearAllErrors();
            bool isValid = true;
            bool firstErrorFocused = false;

            // Add validation logic similar to OwnerRegistration
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                ShowError(FirstNameTextBox, "First name is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    FirstNameTextBox.Focus();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                ShowError(LastNameTextBox, "Last name is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    LastNameTextBox.Focus();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                ShowError(EmailTextBox, "Email is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    EmailTextBox.Focus();
                    firstErrorFocused = true;
                }
            }
            else if (!IsValidEmail(EmailTextBox.Text))
            {
                ShowError(EmailTextBox, "Please enter a valid email address", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    EmailTextBox.Focus();
                    EmailTextBox.SelectAll();
                    firstErrorFocused = true;
                }
            }

            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                ShowError(PhoneTextBox, "Phone number is required", true);
                isValid = false;
                if (!firstErrorFocused)
                {
                    PhoneTextBox.Focus();
                    firstErrorFocused = true;
                }
            }

            return isValid;
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

    }
}
