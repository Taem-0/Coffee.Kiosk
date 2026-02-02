using Coffee.Kiosk.CMS;
using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Forms.AccountsTab;
using Coffee.Kiosk.CMS.Forms.DashBoardTab;
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
        private NewestRegisterView registerView;
        private SecondNewestRegisterView secondNewestRegisterView;
        private NewEmployeeView newEmployeeView;
        private UpdateAccount updateControl;
        private RegistrationValidation validator;
        private UpdateValidation updateValidation;
        private AccountsService service;
        private AccountController controller;
        private DashBoardControl dashBoardControl;

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

            var draft = new DisplayDTO();
            registerView = new NewestRegisterView(controller, draft);
            secondNewestRegisterView = new SecondNewestRegisterView(controller, draft);

            newEmployeeView = new NewEmployeeView(controller);
            newEmployeeView.ParentFormReference = this;

            updateControl = new UpdateAccount(controller);
            updateControl.ParentFormReference = this;

            dashBoardControl = new DashBoardControl(controller);
            dashBoardControl.ParentFormReference = this;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowInPanel(dashBoardControl, AdminContentPanel);
            //ShowInPanel(employeesControl, AccountsContentPanel);
            ShowInPanel(newEmployeeView, AccountsContentPanel);
        }



        public void ShowInPanel(UserControl control, Panel panel)
        {
            if (panel.Controls.Count > 0)
            {
                var current = panel.Controls[0] as UserControl;

                if (current != null && current != control)
                {
                    _navigationStack.Push(current);
                }
            }

            panel.Controls.Clear();
            control.Dock = DockStyle.Fill; 
            panel.Controls.Add(control);

            panel.ResumeLayout(true);
            panel.PerformLayout();
        }

        public void ShowRegister()
        {
            ShowInPanel(registerControl, AccountsContentPanel);
        }

        public void ShowUpdate(DisplayDTO dto)
        {
            updateControl.DisplayAccount(dto);
            ShowInPanel(updateControl, AccountsContentPanel);
        }

        public void GoBack()
        {
            if (_navigationStack.Count == 0)
                return;

            var previous = _navigationStack.Pop();
            UIhelp.CallControl(previous, AccountsContentPanel);
        }

        
    }
}
