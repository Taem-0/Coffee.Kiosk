using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class SecondNewestRegisterView : Form
    {
        private readonly AccountController _controller;
        private readonly DisplayDTO _draft;
        private readonly ShopController _themeController;
        private Color _darkBrown;
        private Color _mediumBrown;
        private Color _lightBrown;
        private Color _beige;
        private Color _background;

        public SecondNewestRegisterView(AccountController controller, DisplayDTO draft, ShopController themeController)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _draft = draft ?? throw new ArgumentNullException(nameof(draft));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            _darkBrown = uiTheme.DarkPrimary;
            _mediumBrown = uiTheme.Primary;
            _lightBrown = uiTheme.Secondary;
            _beige = uiTheme.Accent;
            _background = uiTheme.Background;

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

            ApplyLabelTheme(label1);
            ApplyLabelTheme(label2);
            ApplyLabelTheme(label3);
            ApplyLabelTheme(label6);

            label17.ForeColor = Color.White;
            label17.BackColor = Color.Transparent;

            ConfigureButton(SubmitButton);
            ConfigureButton(BackButton);
            ConfigureCircleButton(AddPictureButton);

            ApplyTextBoxTheme(JobTitleTextBox);

            ApplyComboBoxTheme(DepartmentComboBox);
            ApplyComboBoxTheme(EmployeeTypecomboBox);

            ApplyRadioButtonTheme(AdminRadioButton);
            ApplyRadioButtonTheme(ManagerRadioButton);
            ApplyRadioButtonTheme(employeeRadioButton);

            PictureBox2.FillColor = Color.White;
            tableLayoutPanel2.BackColor = Color.Transparent;
        }

        private void ApplyLabelTheme(Label label)
        {
            label.ForeColor = _darkBrown;
            label.BackColor = Color.Transparent;
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

        private void ApplyComboBoxTheme(ComboBox comboBox)
        {
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = _darkBrown;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 11F);
        }

        private void ApplyRadioButtonTheme(RadioButton radioButton)
        {
            radioButton.ForeColor = _darkBrown;
            radioButton.BackColor = Color.Transparent;
        }

        private void WireUpEvents()
        {
            JobTitleTextBox.TextChanged += (s, e) => ClearError(JobTitleTextBox);
            PictureBox2.MouseClick += PictureBox2_MouseClick;
        }

        private void LoadDraftValues()
        {
            JobTitleTextBox.Text = _draft.JobTitle;

            if (!string.IsNullOrEmpty(_draft.Department))
                DepartmentComboBox.SelectedItem = _draft.Department;

            if (!string.IsNullOrEmpty(_draft.EmploymentType))
                EmployeeTypecomboBox.SelectedItem = _draft.EmploymentType;

            switch (_draft.Role?.ToUpper())
            {
                case "EMPLOYEE": employeeRadioButton.Checked = true; break;
                case "MANAGER": ManagerRadioButton.Checked = true; break;
                case "OWNER": AdminRadioButton.Checked = true; break;
            }

            if (!string.IsNullOrEmpty(_draft.ProfilePicturePath) && File.Exists(_draft.ProfilePicturePath))
            {
                try
                {
                    PictureBox2.Image = Image.FromFile(_draft.ProfilePicturePath);
                    PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch { PictureBox2.Image = null; }
            }
        }

        private void AddPictureButton_Click(object sender, EventArgs e)
        {
            using var openFile = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" };
            if (openFile.ShowDialog() != DialogResult.OK) return;
            try
            {
                _draft.ProfilePicturePath = openFile.FileName;
                PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                PictureBox2.Image = Image.FromFile(openFile.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || PictureBox2.Image == null) return;
            if (MessageBox.Show("Remove profile picture?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _draft.ProfilePicturePath = null;
                PictureBox2.Image = null;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ClearAllErrors();
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(JobTitleTextBox.Text))
            {
                ShowError(JobTitleTextBox, "Job title is required", true);
                hasError = true;
            }

            if (DepartmentComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a department", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasError = true;
            }

            if (EmployeeTypecomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an employment type", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasError = true;
            }

            if (hasError) return;

            _draft.Department = DepartmentComboBox.SelectedItem?.ToString() ?? "";
            _draft.JobTitle = JobTitleTextBox.Text.Trim();
            _draft.EmploymentType = EmployeeTypecomboBox.SelectedItem?.ToString() ?? "";

            if (employeeRadioButton.Checked) _draft.Role = "EMPLOYEE";
            else if (ManagerRadioButton.Checked) _draft.Role = "MANAGER";
            else if (AdminRadioButton.Checked) _draft.Role = "OWNER";

            if (!Enum.TryParse<Department>(_draft.Department, true, out var department))
                department = Department.OPERATIONS;

            if (!Enum.TryParse<EmploymentType>(_draft.EmploymentType.Replace(" ", "_"), true, out var employmentType))
                employmentType = EmploymentType.FULL_TIME;

            if (!Enum.TryParse<AccountRole>(_draft.Role, true, out var role))
                role = AccountRole.EMPLOYEE;

            var registrationDto = new RegistrationDTO
            {
                FirstName = _draft.FirstName,
                MiddleName = _draft.MiddleName,
                LastName = _draft.LastName,
                PhoneNumber = _draft.PhoneNumber,
                Email = _draft.Email,
                EmergencyFirstName = _draft.EmergencyFirstName,
                EmergencyLastName = _draft.EmergencyLastName,
                EmergencyNumber = _draft.EmergencyNumber,
                JobTitle = _draft.JobTitle,
                Department = department,
                EmploymentType = employmentType,
                Role = role,
                ProfilePicturePath = _draft.ProfilePicturePath
            };

            var result = _controller.Register(registrationDto);
            if (!result.IsValid) { ShowValidationErrors(result); return; }

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
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
            textBox.BorderColor = _mediumBrown;
            textBox.FocusedState.BorderColor = _lightBrown;
            textBox.HoverState.BorderColor = _lightBrown;
            textBox.PlaceholderText = "";
            textBox.PlaceholderForeColor = Color.Gray;
        }

        private void ClearAllErrors() => ClearError(JobTitleTextBox);

        private void ShowValidationErrors(ValidationResults result)
        {
            ClearAllErrors();
            foreach (var error in result.Errors)
            {
                if (error.Key.ToLower() is "job title" or "jobtitle")
                    ShowError(JobTitleTextBox, error.Value, true);
                else
                    MessageBox.Show(error.Value, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}