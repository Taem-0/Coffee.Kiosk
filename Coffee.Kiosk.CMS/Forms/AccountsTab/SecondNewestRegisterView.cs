using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class SecondNewestRegisterView : Form
    {
        private readonly AccountController _controller;
        private readonly DisplayDTO _draft;

        public SecondNewestRegisterView(AccountController controller, DisplayDTO draft)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _draft = draft ?? throw new ArgumentNullException(nameof(draft));

            LoadDraftValues();
        }

        private void LoadDraftValues()
        {
            JobTitleTextBox.Text = _draft.JobTitle;
            EmployeeIDTextBox.Text = _draft.EmployeeID;
            SalaryTextBox1.Text = _draft.Salary;

            // Preselect Department in ComboBox
            if (!string.IsNullOrEmpty(_draft.Department))
                DepartmentComboBox.SelectedItem = _draft.Department;

            // Preselect EmploymentType in ComboBox
            if (!string.IsNullOrEmpty(_draft.EmploymentType))
                EmployeeTypecomboBox.SelectedItem = _draft.EmploymentType;

            // Preselect Role radio button
            switch (_draft.Role?.ToUpper())
            {
                case "EMPLOYEE":
                    employeeRadioButton.Checked = true;
                    break;
                case "MANAGER":
                    ManagerRadioButton.Checked = true;
                    break;
                case "OWNER":
                    AdminRadioButton.Checked = true;
                    break;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Collect values from controls
            _draft.Department = DepartmentComboBox.SelectedItem?.ToString() ?? "";
            _draft.JobTitle = JobTitleTextBox.Text.Trim();
            _draft.EmployeeID = EmployeeIDTextBox.Text.Trim();
            _draft.Salary = SalaryTextBox1.Text.Trim();
            _draft.EmploymentType = EmployeeTypecomboBox.SelectedItem?.ToString() ?? "";

            // Role from radio buttons
            if (employeeRadioButton.Checked)
                _draft.Role = "EMPLOYEE";
            else if (ManagerRadioButton.Checked)
                _draft.Role = "MANAGER";
            else if (AdminRadioButton.Checked)
                _draft.Role = "OWNER";

            // Convert strings to enums safely
            if (!Enum.TryParse<Department>(_draft.Department, true, out var department))
                department = Department.OPERATIONS;

            if (!Enum.TryParse<EmploymentType>(_draft.EmploymentType.Replace(" ", "_"), true, out var employmentType))
                employmentType = EmploymentType.FULL_TIME;

            if (!Enum.TryParse<AccountRole>(_draft.Role, true, out var role))
                role = AccountRole.EMPLOYEE;

            if (!decimal.TryParse(_draft.Salary, out var salaryDecimal))
                salaryDecimal = 0m;

            // Build the registration DTO
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
                Salary = salaryDecimal.ToString(), // keep string if DTO expects string
                EmploymentType = employmentType,
                Role = role,
                EmployeeID = _draft.EmployeeID
            };

            // Submit via controller
            var result = _controller.Register(registrationDto);

            if (!result.IsValid)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result.Errors.Values),
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void employeeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Optional: handle UI changes based on role
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: handle Department selection changes
        }
    }
}
