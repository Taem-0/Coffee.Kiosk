using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Coffee.Kiosk.CMS.Helpers.UIhelp;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewUpdateEmployee : Form
    {
        private readonly DisplayDTO _employee;
        private readonly AccountController _controller;
        private readonly ShopController _themeController;
        private string _selectedImagePath;
        private bool _hasChanges;
        private Color _darkBrown;
        private Color _mediumBrown;
        private Color _lightBrown;
        private Color _beige;
        private Color _background;

        public NewUpdateEmployee(DisplayDTO employee, AccountController controller, ShopController themeController)
        {
            InitializeComponent();

            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));
            _selectedImagePath = employee.ProfilePicturePath;
            _hasChanges = false;

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            _darkBrown = uiTheme.DarkPrimary;
            _mediumBrown = uiTheme.Primary;
            _lightBrown = uiTheme.Secondary;
            _beige = uiTheme.Accent;
            _background = uiTheme.Background;

            ApplyTheme();
            InitializeForm();
            LoadEmployeeIntoForm();
            SetupScrollbar();
            SetupFormControls();
            SetupPasswordResetButton();
            WireUpTextChangedEvents();
        }

        private void ApplyTheme()
        {
            this.BackColor = _background;
            this.ForeColor = _darkBrown;

            guna2Panel1.FillColor = _mediumBrown;
            guna2Panel1.BackColor = _mediumBrown;
            guna2Panel1.BorderColor = _darkBrown;
            guna2Panel1.BorderThickness = 1;

            mainPanel.FillColor = _background;
            mainPanel.BackColor = _background;
            guna2Panel2.FillColor = _background;
            guna2Panel2.BackColor = _background;
            guna2Panel3.FillColor = _background;
            guna2Panel3.BackColor = _background;

            tableLayoutPanel1.BackColor = _beige;
            tableLayoutPanel3.BackColor = _beige;
            tableLayoutPanel2.BackColor = Color.Transparent;

            foreach (Control c in tableLayoutPanel1.Controls)
                if (c is Label l) { l.ForeColor = _darkBrown; l.BackColor = Color.Transparent; }

            foreach (Control c in tableLayoutPanel3.Controls)
                if (c is Label l) { l.ForeColor = _darkBrown; l.BackColor = Color.Transparent; }

            ConfigureButton(SubmitButton);

            ApplyTextBoxTheme(FirstNameTextBox);
            ApplyTextBoxTheme(MiddleNameTextBox);
            ApplyTextBoxTheme(LastNameTextBox);
            ApplyTextBoxTheme(EmailTextBox);
            ApplyTextBoxTheme(PhoneTextBox);
            ApplyTextBoxTheme(EmergencyFirstNameTextBox);
            ApplyTextBoxTheme(EmergencyLastNameTextBox);
            ApplyTextBoxTheme(EmergencyPhoneTextBox);
            ApplyTextBoxTheme(JobTitleTextBox);

            ApplyRadioButtonTheme(AdminRadioButton);
            ApplyRadioButtonTheme(ManagerRadioButton);
            ApplyRadioButtonTheme(employeeRadioButton);

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

        private void ApplyRadioButtonTheme(RadioButton radioButton)
        {
            radioButton.ForeColor = _darkBrown;
            radioButton.BackColor = Color.Transparent;
        }

        private void InitializeForm()
        {
            DepartmentComboBox.DataSource = Enum.GetNames(typeof(Department))
                .Select(EnumDisplayHelper.FormatEnum).ToList();
            EmployeeTypecomboBox.DataSource = Enum.GetNames(typeof(EmploymentType))
                .Select(EnumDisplayHelper.FormatEnum).ToList();
        }

        private void SetupScrollbar()
        {
            guna2vScrollBar1.Scroll += (s, e) =>
                mainPanel.AutoScrollPosition = new Point(0, guna2vScrollBar1.Value);

            mainPanel.Scroll += (s, e) =>
            {
                int scrollY = -mainPanel.AutoScrollPosition.Y;
                guna2vScrollBar1.Value = Math.Min(guna2vScrollBar1.Maximum, scrollY);
            };
        }

        private void SetupFormControls()
        {
            bool isOwner = _employee.Role == "Owner";
            bool isDeactivated = _employee.Status == "DEACTIVATED";

            if (isOwner)
            {
                DeactivateButton.Enabled = false;
                DeactivateButton.Text = "Cannot Deactivate Owner";
                AdminRadioButton.Enabled = false;
                ManagerRadioButton.Enabled = false;
                employeeRadioButton.Enabled = false;
                return;
            }

            if (isDeactivated)
            {
                DeactivateButton.Enabled = true;
                DeactivateButton.Text = "Reactivate";
                DeactivateButton.FillColor = Color.SeaGreen;
                DeactivateButton.HoverState.FillColor = Color.DarkGreen;
            }
            else
            {
                DeactivateButton.Enabled = true;
                DeactivateButton.Text = "Deactivate";
                DeactivateButton.FillColor = Color.Red;
                DeactivateButton.HoverState.FillColor = Color.DarkRed;
            }
        }

        private void WireUpTextChangedEvents()
        {
            FirstNameTextBox.TextChanged += (s, e) => ClearError(FirstNameTextBox);
            MiddleNameTextBox.TextChanged += (s, e) => ClearError(MiddleNameTextBox);
            LastNameTextBox.TextChanged += (s, e) => ClearError(LastNameTextBox);
            EmailTextBox.TextChanged += (s, e) => ClearError(EmailTextBox);
            PhoneTextBox.TextChanged += (s, e) => ClearError(PhoneTextBox);
            EmergencyFirstNameTextBox.TextChanged += (s, e) => ClearError(EmergencyFirstNameTextBox);
            EmergencyLastNameTextBox.TextChanged += (s, e) => ClearError(EmergencyLastNameTextBox);
            EmergencyPhoneTextBox.TextChanged += (s, e) => ClearError(EmergencyPhoneTextBox);
            JobTitleTextBox.TextChanged += (s, e) => ClearError(JobTitleTextBox);
        }

        private void LoadEmployeeIntoForm()
        {
            LoadProfilePicture();
            LoadPersonalInformation();
            LoadContactInformation();
            LoadEmergencyContact();
            LoadEmploymentDetails();
            LoadRole();
        }

        private void LoadProfilePicture()
        {
            if (!string.IsNullOrWhiteSpace(_selectedImagePath) && File.Exists(_selectedImagePath))
            {
                try { using var img = Image.FromFile(_selectedImagePath); PictureBox.Image = new Bitmap(img); }
                catch { SetDefaultProfileImage(); }
            }
            else SetDefaultProfileImage();
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetDefaultProfileImage() => PictureBox.Image = CreateDefaultProfileImage();

        private void LoadPersonalInformation()
        {
            FirstNameTextBox.Text = _employee.FirstName;
            MiddleNameTextBox.Text = _employee.MiddleName;
            LastNameTextBox.Text = _employee.LastName;
        }

        private void LoadContactInformation()
        {
            EmailTextBox.Text = _employee.Email;
            PhoneTextBox.Text = _employee.PhoneNumber;
        }

        private void LoadEmergencyContact()
        {
            EmergencyFirstNameTextBox.Text = _employee.EmergencyFirstName;
            EmergencyLastNameTextBox.Text = _employee.EmergencyLastName;
            EmergencyPhoneTextBox.Text = _employee.EmergencyNumber;
        }

        private void LoadEmploymentDetails()
        {
            JobTitleTextBox.Text = _employee.JobTitle;
            DepartmentComboBox.SelectedItem = _employee.Department;
            EmployeeTypecomboBox.SelectedItem = _employee.EmploymentType;
        }

        private void LoadRole()
        {
            switch (_employee.Role)
            {
                case "Owner": AdminRadioButton.Checked = true; break;
                case "Manager": ManagerRadioButton.Checked = true; break;
                default: employeeRadioButton.Checked = true; break;
            }
        }

        private void ShowError(Guna.UI2.WinForms.Guna2TextBox textBox, string errorMessage, bool clearInput = false)
        {
            textBox.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.FocusedState.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.HoverState.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.PlaceholderText = errorMessage;
            textBox.PlaceholderForeColor = UIhelp.ThemeColors.ErrorColor;
            if (clearInput) textBox.Text = "";
        }

        private void ClearError(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            textBox.BorderColor = Color.Empty;
            textBox.FocusedState.BorderColor = Color.Empty;
            textBox.HoverState.BorderColor = Color.Empty;
            textBox.PlaceholderText = "";
            textBox.PlaceholderForeColor = Color.Gray;
        }

        private void ClearAllErrors()
        {
            ClearError(FirstNameTextBox); ClearError(MiddleNameTextBox);
            ClearError(LastNameTextBox); ClearError(EmailTextBox);
            ClearError(PhoneTextBox); ClearError(EmergencyFirstNameTextBox);
            ClearError(EmergencyLastNameTextBox); ClearError(EmergencyPhoneTextBox);
            ClearError(JobTitleTextBox);
        }

        private void ShowValidationErrors(ValidationResults result)
        {
            ClearAllErrors();
            foreach (var error in result.Errors)
            {
                switch (error.Key.ToLower())
                {
                    case "first name":
                    case "firstname":
                        ShowError(FirstNameTextBox, error.Value, true); break;
                    case "middle name":
                    case "middlename":
                        ShowError(MiddleNameTextBox, error.Value, true); break;
                    case "last name":
                    case "lastname":
                        ShowError(LastNameTextBox, error.Value, true); break;
                    case "email":
                        ShowError(EmailTextBox, error.Value, true); break;
                    case "phone number":
                    case "phonenumber":
                        ShowError(PhoneTextBox, error.Value, true); break;
                    case "emergency first name":
                    case "emergencyfirstname":
                        ShowError(EmergencyFirstNameTextBox, error.Value, true); break;
                    case "emergency last name":
                    case "emergencylastname":
                        ShowError(EmergencyLastNameTextBox, error.Value, true); break;
                    case "emergency number":
                    case "emergencynumber":
                        ShowError(EmergencyPhoneTextBox, error.Value, true); break;
                    case "job title":
                    case "jobtitle":
                        ShowError(JobTitleTextBox, error.Value, true); break;
                    default:
                        MessageBox.Show(error.Value, "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning); break;
                }
            }
        }

        private bool ValidateAllFields()
        {
            ClearAllErrors();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            { ShowError(FirstNameTextBox, "First name is required", true); isValid = false; }
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            { ShowError(LastNameTextBox, "Last name is required", true); isValid = false; }
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            { ShowError(EmailTextBox, "Email is required", true); isValid = false; }
            else if (!IsValidEmail(EmailTextBox.Text))
            { ShowError(EmailTextBox, "Please enter a valid email address", true); isValid = false; }
            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            { ShowError(PhoneTextBox, "Phone number is required", true); isValid = false; }
            if (string.IsNullOrWhiteSpace(JobTitleTextBox.Text))
            { ShowError(JobTitleTextBox, "Job title is required", true); isValid = false; }
            if (DepartmentComboBox.SelectedItem == null)
            { MessageBox.Show("Please select a department", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); isValid = false; }
            if (EmployeeTypecomboBox.SelectedItem == null)
            { MessageBox.Show("Please select an employment type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); isValid = false; }

            return isValid;
        }

        private bool IsValidEmail(string email)
        {
            try { var a = new System.Net.Mail.MailAddress(email); return a.Address == email; }
            catch { return false; }
        }

        private void InputCollection()
        {
            if (!ValidateAllFields()) return;

            _employee.FirstName = FirstNameTextBox.Text.Trim();
            _employee.MiddleName = MiddleNameTextBox.Text.Trim();
            _employee.LastName = LastNameTextBox.Text.Trim();
            _employee.Email = EmailTextBox.Text.Trim();
            _employee.PhoneNumber = PhoneTextBox.Text.Trim();
            _employee.EmergencyFirstName = EmergencyFirstNameTextBox.Text.Trim();
            _employee.EmergencyLastName = EmergencyLastNameTextBox.Text.Trim();
            _employee.EmergencyNumber = EmergencyPhoneTextBox.Text.Trim();
            _employee.Department = DepartmentComboBox.SelectedItem?.ToString() ?? "";
            _employee.EmploymentType = EmployeeTypecomboBox.SelectedItem?.ToString() ?? "";
            _employee.JobTitle = JobTitleTextBox.Text.Trim();
            _employee.ProfilePicturePath = _selectedImagePath;

            if (_employee.Role != "Owner")
            {
                if (AdminRadioButton.Checked) _employee.Role = "Owner";
                else if (ManagerRadioButton.Checked) _employee.Role = "Manager";
                else _employee.Role = "Employee";
            }

            var result = _controller.Update(_employee);
            if (!result.IsValid) { ShowValidationErrors(result); return; }

            MessageBox.Show("Employee updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void SubmitButton_Click_1(object sender, EventArgs e) => InputCollection();

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            if (_employee.Role == "Owner")
            {
                MessageBox.Show("Owner accounts cannot be deactivated.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var dialogue = new Coffee.Kiosk.CMS.Forms.QuickDialogues.DeactivateDialogue();
            dialogue.StartPosition = FormStartPosition.CenterParent;
            dialogue.ShowDialog(this);

            if (!dialogue.Confirmed) return;

            try
            {
                bool isDeactivated = _employee.Status == "DEACTIVATED";
                if (isDeactivated)
                {
                    _controller.ReactivateAccount(_employee);
                    _employee.Status = "ACTIVE";
                    MessageBox.Show("Employee reactivated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _controller.DeactivateAccount(_employee);
                    _employee.Status = "DEACTIVATED";
                    MessageBox.Show("Employee deactivated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPfpButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Profile Picture",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                _selectedImagePath = openFileDialog.FileName;
                using var img = Image.FromFile(_selectedImagePath);
                PictureBox.Image = new Bitmap(img);
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _selectedImagePath = _employee.ProfilePicturePath;
            }
        }

        private Image CreateDefaultProfileImage()
        {
            var bmp = new Bitmap(200, 200);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(240, 240, 240));
            using var pen = new Pen(Color.FromArgb(200, 200, 200), 2);
            g.DrawEllipse(pen, 10, 10, 180, 180);
            string initials = GetInitials(_employee.FirstName, _employee.LastName);
            using var font = new Font("Arial", 48, FontStyle.Bold);
            using var brush = new SolidBrush(Color.FromArgb(150, 150, 150));
            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(initials, font, brush, new RectangleF(0, 0, bmp.Width, bmp.Height), format);
            return bmp;
        }

        private string GetInitials(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) return "??";
            return $"{firstName[0]}{lastName[0]}".ToUpper();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenuStrip();
            var removeItem = new ToolStripMenuItem("Remove Profile Picture");
            removeItem.Click += (s, args) =>
            {
                if (MessageBox.Show("Remove profile picture?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _selectedImagePath = null;
                    SetDefaultProfileImage();
                }
            };
            contextMenu.Items.Add(removeItem);
            contextMenu.Show(PictureBox, e.Location);
        }

        private void acceptRequest_Click(object sender, EventArgs e)
        {
            using var dialogue = new Coffee.Kiosk.CMS.Forms.QuickDialogues.ResetPassDialogue();
            dialogue.StartPosition = FormStartPosition.CenterParent;
            dialogue.ShowDialog(this);

            if (!dialogue.Confirmed) return;

            try
            {
                bool success = _controller.ResetPasswordToDefault(int.Parse(_employee.PrimaryID));
                if (success)
                {
                    string tempPassword = Coffee.Kiosk.CMS.Helpers.LogicHelpers.GetTemporaryPasswordDisplay();
                    MessageBox.Show(
                        $"Password reset successfully!\n\nEmployee: {_employee.FirstName} {_employee.LastName}\n" +
                        $"Temporary Password: {tempPassword}\n\nThey must change it on next login.",
                        "Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    acceptRequest.Enabled = false;
                    acceptRequest.Text = "Password Reset";
                    acceptRequest.FillColor = Color.Gray;
                }
                else
                    MessageBox.Show("Failed to reset password. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting password: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupPasswordResetButton()
        {
            bool isOwnerOrManager = _employee.Role == "Owner" || _employee.Role == "Manager";
            if (!isOwnerOrManager) { acceptRequest.Visible = false; return; }
            acceptRequest.Visible = true;
            acceptRequest.Enabled = true;
            acceptRequest.Text = "Reset Password";
            acceptRequest.FillColor = Color.Salmon;
            acceptRequest.HoverState.FillColor = Color.Coral;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
    }
}