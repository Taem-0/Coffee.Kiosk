using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
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

        public AdminControlForm ParentFormReference {  get; set; }

        private readonly AccountController _controller;


        public UpdateAccount(AccountController accountController)
        {
            InitializeComponent();
            _controller = accountController ?? throw new ArgumentNullException(nameof(accountController));

        }

        public void DisplayAccount(DisplayDTO account)
        {

            fullNameTextBox.Text = account.FullName;
            phoneNumTextBox.Text = account.PhoneNumber;
            emailAddressTextBox.Text = account.Email;
            emergencyContactTextBox.Text = account.EmergencyNumber;
            jobTitleTextBox.Text = account.JobTitle;
            salaryTextBox.Text = account.Salary;

        }



    }
}
