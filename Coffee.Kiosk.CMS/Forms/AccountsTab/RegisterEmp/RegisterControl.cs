using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS
{
    public partial class RegisterControl : UserControl
    {


        public AdminControlForm? ParentFormReference { get; set; }

        //From here.
        private readonly RegistrationController _controller;

        public RegisterControl(RegistrationController registrationController)
        {
            InitializeComponent();
            _controller = registrationController ?? throw new ArgumentNullException(nameof(registrationController));
        }
        //To here, This is the basic structure of initializing your Dependency injections on each class.
        //Dependency Injections are just another way of calling a class in another class but like... they're blind you know likeee
        //"aaa theres data I need and uhm It just appears on the mail box... Like boom" then they continue working, not worrying where that
        //mysterious data comes from. Head hurts.

        private void RegisterControl_Load(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {

            InputCollection();

        }

        private void InputCollection()
        {
            var newRequest = new RegistrationDTO
            {

                FullName = fullNameTextBox.Text,
                PhoneNumber = phoneNumTextBox.Text,
                Email = emailAddressTextBox.Text,
                EmergencyNumber = emergencyContactTextBox.Text,
                JobTitle = jobTitleTextBox.Text,
                Salary = salaryTextBox.Text
            };

            var result = _controller.Register(newRequest);

            if (!result.IsValid)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result.Errors.Values), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (result.IsValid)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

            ParentFormReference?.GoBack();

        }
    }
}
