using Coffee.Kiosk.CMS;
using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Forms.AccountsTab;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.Configuration;
namespace Coffee.Kiosk
{
    public partial class AdminControlForm : MaterialForm
    {

        private RegisterControl registerControl;
        private EmployeesControl employeesControl;
        private UpdateAccount updateControl;
        private RegistrationValidation validator;
        private UpdateValidation updateValidation;
        private AccountsService service;
        private AccountController controller;

        private readonly Stack<UserControl> _navigationStack = new();


        private readonly MaterialSkinManager materialSkinManager = null!;

        public AdminControlForm()
        {
            InitializeComponent();

            // change later
            this.Text = $"Logged in as: ";

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                ColorTranslator.FromHtml("#6F4D38"),
                ColorTranslator.FromHtml("#3D211A"),
                ColorTranslator.FromHtml("#3D211A"),
                ColorTranslator.FromHtml("#3D211A"),
                TextShade.WHITE
            );


            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var dbManager = new AccountDBManager(configuration);

            //Dependency Injection: Initialize injections HERE.
            validator = new RegistrationValidation();
            updateValidation = new UpdateValidation();
            service = new AccountsService(dbManager);
            controller = new AccountController(validator, updateValidation, service);

            registerControl = new RegisterControl(controller);
            registerControl.ParentFormReference = this;

            employeesControl = new EmployeesControl(controller);
            employeesControl.ParentFormReference = this;

            updateControl = new UpdateAccount(controller);
            updateControl.ParentFormReference = this;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowInAccountsPanel(employeesControl);
        }

        public void ShowInAccountsPanel(UserControl control)
        {
            if (AccountsContentPanel.Controls.Count > 0)
            {
                var current = AccountsContentPanel.Controls[0] as UserControl;
                if (current != null)
                    _navigationStack.Push(current);
            }

            UIhelp.CallControl(control, AccountsContentPanel);
        }

        public void ShowRegister()
        {
            ShowInAccountsPanel(registerControl);
        }

        public void ShowUpdate(DisplayDTO dto)
        {
            updateControl.DisplayAccount(dto);
            ShowInAccountsPanel(updateControl);
        }



        public void GoBack()
        {
            if (_navigationStack.Count == 0)
                return;

            var previous = _navigationStack.Pop();
            UIhelp.CallControl(previous, AccountsContentPanel);
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            materialSkinManager.Theme =
                materialSwitch1.Checked
                ? MaterialSkinManager.Themes.DARK
                : MaterialSkinManager.Themes.LIGHT;
        }
    }
}
