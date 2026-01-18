using Coffee.Kiosk.CMS;
using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
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
        private RegistrationValidation validator;
        private RegistrationService service;
        private RegistrationController controller;



        private void ShowEmployees() => UIhelp.CallControl(employeesControl, AccountsContentPanel);


        public AdminControlForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var dbManager = new DBManager(configuration);

            //Dependency Injection: Initialize injections HERE.
            validator = new RegistrationValidation();
            service = new RegistrationService(dbManager);
            controller = new RegistrationController(validator, service);

            registerControl = new RegisterControl(controller);
            registerControl.ParentFormReference = this;

            employeesControl = new EmployeesControl(controller); 
            employeesControl.ParentFormReference = this;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ShowEmployees();

        }

        public void ShowInAccountsPanel(UserControl control)
        {
            UIhelp.CallControl(control, AccountsContentPanel);
        }

    }
}
