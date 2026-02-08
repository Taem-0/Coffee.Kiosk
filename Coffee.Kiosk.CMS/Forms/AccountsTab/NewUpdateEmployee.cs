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
        private string _selectedImagePath;
        private bool _hasChanges;

        public NewUpdateEmployee(DisplayDTO employee, AccountController controller)
        {
            InitializeComponent();

            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _selectedImagePath = employee.ProfilePicturePath;
            _hasChanges = false;

            InitializeForm();
            LoadEmployeeIntoForm();
            SetupScrollbar();
            SetupFormControls();
            SetupPasswordResetButton();
            WireUpTextChangedEvents();
        }

        private void InitializeForm()
        {
            // Initialize combo boxes
            DepartmentComboBox.DataSource = Enum.GetNames(typeof(Department))
                .Select(EnumDisplayHelper.FormatEnum)
                .ToList();

            EmployeeTypecomboBox.DataSource = Enum.GetNames(typeof(EmploymentType))
                .Select(EnumDisplayHelper.FormatEnum)
                .ToList();
        }

        private void SetupScrollbar()
        {
            guna2vScrollBar1.Scroll += (s, e) =>
            {
                mainPanel.AutoScrollPosition = new Point(0, guna2vScrollBar1.Value);
            };

            mainPanel.Scroll += (s, e) =>
            {
                int scrollY = -mainPanel.AutoScrollPosition.Y;
                guna2vScrollBar1.Value = Math.Min(guna2vScrollBar1.Maximum, scrollY);
            };
        }

        private void SetupFormControls()
        {
            // Set deactivation button state
            bool isOwner = _employee.Role == "Owner";
            bool isDeactivated = _employee.Status == "DEACTIVATED";

            DeactivateButton.Enabled = !isOwner && !isDeactivated;
            DeactivateButton.Text = isDeactivated ? "Deactivated" : "Deactivate";

            if (isOwner)
            {
                DeactivateButton.Enabled = false;
                DeactivateButton.Text = "Cannot Deactivate Owner";
                AdminRadioButton.Enabled = false;
                ManagerRadioButton.Enabled = false;
                employeeRadioButton.Enabled = false;
            }
        }

        private void WireUpTextChangedEvents()
        {
            // Wire up all textboxes to clear errors when user types
            FirstNameTextBox.TextChanged += (s, e) => ClearError(FirstNameTextBox);
            MiddleNameTextBox.TextChanged += (s, e) => ClearError(MiddleNameTextBox);
            LastNameTextBox.TextChanged += (s, e) => ClearError(LastNameTextBox);
            EmailTextBox.TextChanged += (s, e) => ClearError(EmailTextBox);
            PhoneTextBox.TextChanged += (s, e) => ClearError(PhoneTextBox);
            EmergencyFirstNameTextBox.TextChanged += (s, e) => ClearError(EmergencyFirstNameTextBox);
            EmergencyLastNameTextBox.TextChanged += (s, e) => ClearError(EmergencyLastNameTextBox);
            EmergencyPhoneTextBox.TextChanged += (s, e) => ClearError(EmergencyPhoneTextBox);
            JobTitleTextBox.TextChanged += (s, e) => ClearError(JobTitleTextBox);
            SalaryTextBox1.TextChanged += (s, e) => ClearError(SalaryTextBox1);
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
                try
                {
                    using var img = Image.FromFile(_selectedImagePath);
                    PictureBox.Image = new Bitmap(img);
                }
                catch (Exception)
                {
                    SetDefaultProfileImage();
                }
            }
            else
            {
                SetDefaultProfileImage();
            }

            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetDefaultProfileImage()
        {
            PictureBox.Image = CreateDefaultProfileImage();
        }

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
            SalaryTextBox1.Text = _employee.Salary;

            DepartmentComboBox.SelectedItem = _employee.Department;
            EmployeeTypecomboBox.SelectedItem = _employee.EmploymentType;
        }

        private void LoadRole()
        {
            switch (_employee.Role)
            {
                case "Owner":
                    AdminRadioButton.Checked = true;
                    break;
                case "Manager":
                    ManagerRadioButton.Checked = true;
                    break;
                default:
                    employeeRadioButton.Checked = true;
                    break;
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
            ClearError(FirstNameTextBox);
            ClearError(MiddleNameTextBox);
            ClearError(LastNameTextBox);
            ClearError(EmailTextBox);
            ClearError(PhoneTextBox);
            ClearError(EmergencyFirstNameTextBox);
            ClearError(EmergencyLastNameTextBox);
            ClearError(EmergencyPhoneTextBox);
            ClearError(JobTitleTextBox);
            ClearError(SalaryTextBox1);
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
                        ShowError(FirstNameTextBox, error.Value, true);
                        break;
                    case "middle name":
                    case "middlename":
                        ShowError(MiddleNameTextBox, error.Value, true);
                        break;
                    case "last name":
                    case "lastname":
                        ShowError(LastNameTextBox, error.Value, true);
                        break;
                    case "email":
                        ShowError(EmailTextBox, error.Value, true);
                        break;
                    case "phone number":
                    case "phonenumber":
                        ShowError(PhoneTextBox, error.Value, true);
                        break;
                    case "emergency first name":
                    case "emergencyfirstname":
                        ShowError(EmergencyFirstNameTextBox, error.Value, true);
                        break;
                    case "emergency last name":
                    case "emergencylastname":
                        ShowError(EmergencyLastNameTextBox, error.Value, true);
                        break;
                    case "emergency number":
                    case "emergencynumber":
                        ShowError(EmergencyPhoneTextBox, error.Value, true);
                        break;
                    case "job title":
                    case "jobtitle":
                        ShowError(JobTitleTextBox, error.Value, true);
                        break;
                    case "salary":
                        ShowError(SalaryTextBox1, error.Value, true);
                        break;
                    case "department":
                        MessageBox.Show(error.Value, "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "employment type":
                        MessageBox.Show(error.Value, "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    default:
                        MessageBox.Show(error.Value, "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        private bool ValidateAllFields()
        {
            ClearAllErrors();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                ShowError(FirstNameTextBox, "First name is required", true);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                ShowError(LastNameTextBox, "Last name is required", true);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                ShowError(EmailTextBox, "Email is required", true);
                isValid = false;
            }
            else if (!IsValidEmail(EmailTextBox.Text))
            {
                ShowError(EmailTextBox, "Please enter a valid email address", true);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                ShowError(PhoneTextBox, "Phone number is required", true);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(JobTitleTextBox.Text))
            {
                ShowError(JobTitleTextBox, "Job title is required", true);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(SalaryTextBox1.Text))
            {
                ShowError(SalaryTextBox1, "Salary is required", true);
                isValid = false;
            }
            else if (!decimal.TryParse(SalaryTextBox1.Text, out _))
            {
                ShowError(SalaryTextBox1, "Please enter a valid salary amount", true);
                isValid = false;
            }

            if (DepartmentComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a department", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            if (EmployeeTypecomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an employment type", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
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

        private void InputCollection()
        {
            if (!ValidateAllFields())
                return;

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

            if (decimal.TryParse(SalaryTextBox1.Text, out var salary))
            {
                _employee.Salary = salary.ToString();
            }

            _employee.ProfilePicturePath = _selectedImagePath;

            if (_employee.Role != "Owner")
            {
                if (AdminRadioButton.Checked)
                    _employee.Role = "Owner";
                else if (ManagerRadioButton.Checked)
                    _employee.Role = "Manager";
                else
                    _employee.Role = "Employee";
            }

            var result = _controller.Update(_employee);

            if (!result.IsValid)
            {
                ShowValidationErrors(result);
                return;
            }

            MessageBox.Show(
                "Employee updated successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void SubmitButton_Click_1(object sender, EventArgs e)
        {
            InputCollection();
        }

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            if (_employee.Role == "Owner")
            {
                MessageBox.Show(
                    "Owner accounts cannot be deactivated.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to deactivate {_employee.FirstName} {_employee.LastName}?",
                "Confirm Deactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                _controller.DeactivateAccount(_employee);
                _employee.Status = "DEACTIVATED";

                MessageBox.Show(
                    "Employee deactivated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error deactivating employee: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AddPfpButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Profile Picture";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _selectedImagePath = openFileDialog.FileName;

                        using (var img = Image.FromFile(_selectedImagePath))
                        {
                            PictureBox.Image = new Bitmap(img);
                            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _selectedImagePath = _employee.ProfilePicturePath; // Revert to original
                    }
                }
            }
        }

        private Image CreateDefaultProfileImage()
        {
            var bmp = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(240, 240, 240));
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2))
                {
                    g.DrawEllipse(pen, 10, 10, 180, 180);
                }

                string initials = GetInitials(_employee.FirstName, _employee.LastName);
                using (Font font = new Font("Arial", 48, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.FromArgb(150, 150, 150)))
                {
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    g.DrawString(initials, font, brush,
                        new RectangleF(0, 0, bmp.Width, bmp.Height), format);
                }
            }
            return bmp;
        }

        private string GetInitials(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return "??";

            return $"{firstName[0]}{lastName[0]}".ToUpper();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenuStrip();
                var removeItem = new ToolStripMenuItem("Remove Profile Picture");
                removeItem.Click += (s, args) =>
                {
                    var result = MessageBox.Show(
                        "Remove profile picture?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        _selectedImagePath = null;
                        SetDefaultProfileImage();
                    }
                };
                contextMenu.Items.Add(removeItem);
                contextMenu.Show(PictureBox, e.Location);
            }
        }

        private void acceptRequest_Click(object sender, EventArgs e)
        {
            bool hasPendingRequest = _controller.HasPendingResetRequest(int.Parse(_employee.PrimaryID));

            if (!hasPendingRequest)
            {
                MessageBox.Show(
                    "This employee does not have a pending password reset request.",
                    "No Request Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                acceptRequest.Visible = false;
                return;
            }

            var result = MessageBox.Show(
                $"Approve password reset for {_employee.FirstName} {_employee.LastName}?\n\n" +
                "This will reset their password to the default temporary password.\n" +
                "They will need to change it on their next login.",
                "Approve Password Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                bool success = _controller.ApprovePasswordReset(
                    int.Parse(_employee.PrimaryID),
                    0
                );

                if (success)
                {
                    string tempPassword = Coffee.Kiosk.CMS.Helpers.LogicHelpers.GetTemporaryPasswordDisplay();

                    MessageBox.Show(
                        $"Password reset approved!\n\n" +
                        $"Employee: {_employee.FirstName} {_employee.LastName}\n" +
                        $"Temporary Password: {tempPassword}\n\n" +
                        "The employee will need to use this password on their next login.",
                        "Reset Approved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    acceptRequest.Enabled = false;
                    acceptRequest.Text = "Reset Approved";
                    acceptRequest.FillColor = Color.Gray;
                }
                else
                {
                    MessageBox.Show(
                        "Failed to approve password reset. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error approving password reset: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetupPasswordResetButton()
        {
            acceptRequest.Visible = false;

            if (_employee.Role == "Owner")
            {
                return;
            }

            if (_employee.Status != "ACTIVE")
            {
                return;
            }

            bool hasPendingRequest = _controller.HasPendingResetRequest(int.Parse(_employee.PrimaryID));

            if (hasPendingRequest)
            {
                acceptRequest.Visible = true;
                acceptRequest.Enabled = true;
                acceptRequest.Text = "Approve Password Reset";
                acceptRequest.FillColor = Color.Salmon;
            }
        }
    }
}