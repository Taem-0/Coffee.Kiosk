using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
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
    public partial class UpdateAccount : UserControl
    {


        public AdminControlForm? ParentFormReference { get; set; }

        private readonly AccountController _controller;

        private DisplayDTO _currentAccount;


        public UpdateAccount(AccountController accountController)
        {
            InitializeComponent();
            _controller = accountController ?? throw new ArgumentNullException(nameof(accountController));

        }

        public void DisplayAccount(DisplayDTO account)
        {

            _currentAccount = account;

            FirstNameTextBox.Text = account.FirstName;
            MiddleNameTextBox.Text = account.MiddleName;
            LastNameTextBox.Text = account.LastName;
            phoneNumTextBox.Text = account.PhoneNumber;
            emailAddressTextBox.Text = account.Email;
            emergencyContactTextBox.Text = account.EmergencyNumber;
            jobTitleTextBox.Text = account.JobTitle;
            salaryTextBox.Text = account.Salary;

        }

        private void InputCollection()
        {
            _currentAccount.FirstName = FirstNameTextBox.Text;
            _currentAccount.MiddleName = MiddleNameTextBox.Text;
            _currentAccount.LastName = LastNameTextBox.Text;
            _currentAccount.PhoneNumber = phoneNumTextBox.Text;
            _currentAccount.Email = emailAddressTextBox.Text;
            _currentAccount.EmergencyNumber = emergencyContactTextBox.Text;
            _currentAccount.JobTitle = jobTitleTextBox.Text;
            _currentAccount.Salary = salaryTextBox.Text;

            var result = _controller.Update(_currentAccount);


            if (!result.IsValid)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result.Errors.Values), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (result.IsValid)
            {

                MessageBox.Show("Update successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentFormReference?.GoBack();

            }
        }

        private void Deactivate()
        {

            var confirmation = MessageBox.Show($"Are you sure you want to deactivate {_currentAccount.Email}?", "Confirm Deactivation",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning
    );

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            _controller.DeactivateAccount(_currentAccount);

            MessageBox.Show("Account has been deactivated successfully.!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ParentFormReference?.GoBack();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            InputCollection();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ParentFormReference?.GoBack();
        }

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            Deactivate();
        }




    }
}
