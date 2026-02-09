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
        private Color _darkBrown = ColorTranslator.FromHtml("#3d211a");
        private Color _mediumBrown = ColorTranslator.FromHtml("#6f4d38");
        private Color _lightBrown = ColorTranslator.FromHtml("#a07856");
        private Color _beige = ColorTranslator.FromHtml("#cbb799");
        private Color _background = ColorTranslator.FromHtml("#f5f5dc");

        public NewestRegisterView(AccountController controller, DisplayDTO draft)
        {

            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _draft = draft ?? throw new ArgumentNullException(nameof(draft));

            ApplyTheme();
            WireUpEvents();
            LoadDraftValues();

        }

        private void ApplyTheme()
        {

            this.BackColor = _background;
            this.ForeColor = _darkBrown;
            this.Padding = new Padding(20);

            guna2Panel1.FillColor = _mediumBrown;
            guna2Panel1.BackColor = _mediumBrown;
            guna2Panel1.BorderColor = _darkBrown;
            guna2Panel1.BorderThickness = 1;

            tableLayoutPanel1.BackColor = _beige;

            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;

            label2.ForeColor = _darkBrown;
            label2.BackColor = Color.Transparent;
            
            label3.ForeColor = _darkBrown;
            label3.BackColor = Color.Transparent;

            label4.ForeColor = _darkBrown;
            label4.BackColor = Color.Transparent;

            label5.ForeColor = _darkBrown;
            label5.BackColor = Color.Transparent;

            label6.ForeColor = _darkBrown;
            label6.BackColor = Color.Transparent;

            label7.ForeColor = _darkBrown;
            label7.BackColor = Color.Transparent;

            label8.ForeColor = _darkBrown;
            label8.BackColor = Color.Transparent;

            label9.ForeColor = _darkBrown;
            label9.BackColor = Color.Transparent;

            label10.ForeColor = _darkBrown;
            label10.BackColor = Color.Transparent;

            label17.ForeColor = Color.White;
            label17.BackColor = Color.Transparent;

            ConfigureButton(NextButton);
            ConfigureButton(CancelButton);
            ConfigureCircleButton(AddPfpButton);

            ApplyTextBoxTheme(FirstNameTextBox);
            ApplyTextBoxTheme(MiddleNameTextBox);
            ApplyTextBoxTheme(LastNameTextBox);
            ApplyTextBoxTheme(PhoneTextBox);
            ApplyTextBoxTheme(EmailTextBox);
            ApplyTextBoxTheme(EmergencyFirstNameTextBox);
            ApplyTextBoxTheme(EmergencyLastNameTextBox);
            ApplyTextBoxTheme(EmergencyPhoneTextBox);

            PictureBox.FillColor = Color.White;

        }

        private void ConfigureButton(Guna.UI2.WinForms.Guna2Button button)
        {
            button.FillColor = _mediumBrown;
            button.ForeColor = Color.White;
            button.BorderColor = _darkBrown;
            button.BorderThickness = 1;
            button.HoverState.FillColor = _lightBrown;
            button.HoverState.BorderColor = _darkBrown;
            button.PressedColor = _darkBrown;
            button.BorderRadius = 15;
        }

        private void ConfigureCircleButton(Guna.UI2.WinForms.Guna2CircleButton button)
        {
            button.FillColor = _mediumBrown;
            button.ForeColor = Color.White;
            button.BorderColor = _darkBrown;
            button.BorderThickness = 1;
            button.HoverState.FillColor = _lightBrown;
            button.HoverState.BorderColor = _darkBrown;
            button.PressedColor = _darkBrown;
        }

        private void ApplyTextBoxTheme(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            textBox.BorderColor = _mediumBrown;
            textBox.FocusedState.BorderColor = _lightBrown;
            textBox.HoverState.BorderColor = _lightBrown;
            textBox.FillColor = Color.White;
            textBox.ForeColor = _darkBrown;
            textBox.PlaceholderForeColor = Color.Gray;
            textBox.BorderRadius = 8;
        }

        private void WireUpEvents()
        {
            FirstNameTextBox.TextChanged += (s, e) => ClearError(FirstNameTextBox);
            MiddleNameTextBox.TextChanged += (s, e) => ClearError(MiddleNameTextBox);
            LastNameTextBox.TextChanged += (s, e) => ClearError(LastNameTextBox);
            PhoneTextBox.TextChanged += (s, e) => ClearError(PhoneTextBox);
            EmailTextBox.TextChanged += (s, e) => ClearError(EmailTextBox);
            EmergencyFirstNameTextBox.TextChanged += (s, e) => ClearError(EmergencyFirstNameTextBox);
            EmergencyLastNameTextBox.TextChanged += (s, e) => ClearError(EmergencyLastNameTextBox);
            EmergencyPhoneTextBox.TextChanged += (s, e) => ClearError(EmergencyPhoneTextBox);

            PictureBox.MouseClick += PictureBox_MouseClick;
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

            if (!string.IsNullOrEmpty(_draft.ProfilePicturePath) && System.IO.File.Exists(_draft.ProfilePicturePath))
            {
                try
                {
                    PictureBox.Image = Image.FromFile(_draft.ProfilePicturePath);
                }
                catch
                {
                    PictureBox.Image = null;
                }
            }
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

                    //UHMMMM

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

                    try
                    {
                        PictureBox.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            textBox.BorderColor = _mediumBrown;
            textBox.FocusedState.BorderColor = _lightBrown;
            textBox.HoverState.BorderColor = _lightBrown;

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

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && PictureBox.Image != null)
            {
                var result = MessageBox.Show("Remove profile picture?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _draft.ProfilePicturePath = null;
                    PictureBox.Image = null;
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}