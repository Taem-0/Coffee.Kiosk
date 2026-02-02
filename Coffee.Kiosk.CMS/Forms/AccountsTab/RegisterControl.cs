using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS
{
    public partial class RegisterControl : UserControl
    {
        public AdminControlForm? ParentFormReference { get; set; }

        private readonly AccountController _controller;

        public RegisterControl(AccountController accountController)
        {
            InitializeComponent();
            _controller = accountController ?? throw new ArgumentNullException(nameof(accountController));

        }

        private void RegisterControl_Load(object sender, EventArgs e)
        {
            departmentComboBox.Items.AddRange(Enum.GetNames(typeof(Department)));
            employeeTypeComboBox.Items.AddRange(Enum.GetNames(typeof(EmploymentType)));
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {

            CollectAndRegisterInput();

        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            ParentFormReference?.GoBack();
        }


        private void CollectAndRegisterInput()
        {
            AccountRole role = employeeRadioButton.Checked ? AccountRole.EMPLOYEE :
                               managerRadioButton.Checked ? AccountRole.MANAGER :
                               adminRadioButton.Checked ? AccountRole.OWNER :
                               AccountRole.EMPLOYEE;

            Enum.TryParse(departmentComboBox.Text.Trim(), out Department department);

            Enum.TryParse(employeeTypeComboBox.Text.Trim(), out EmploymentType employmentType);

            //BuildABear
            var newRequest = new RegistrationDTO
            {
                FirstName = firstNameTextBox.Text.Trim(),
                MiddleName = middleNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                PhoneNumber = phoneTextBox.Text.Trim(),
                Email = emailTextBox.Text.Trim(),
                EmergencyFirstName = emergencyNameTextBox.Text.Trim(),
                EmergencyLastName = emergencyMiddleNameTextBox.Text.Trim(),
                EmergencyNumber = emergencyPhoneTextBox.Text.Trim(),
                JobTitle = jobTitleComboBox.Text.Trim(),
                Department = department,
                Salary = salaryTextBox.Text.Trim(),
                EmploymentType = employmentType,
                Role = role,
                EmployeeID = employeeIDTextBox.Text.Trim()
            };

            var result = _controller.Register(newRequest);

            if (!result.IsValid)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result.Errors.Values),
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        
    }
}
