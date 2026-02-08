using Coffee.Kiosk.CMS;
using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Forms.AccountsTab;
using Coffee.Kiosk.CMS.Forms.DashBoardTab;
using Coffee.Kiosk.CMS.Forms.SettingsTab;
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
        private LoginValidation loginValidation;
        private AccountsService service;
        private AccountController controller;
        private DashBoardControl dashBoardControl;
        private SettingsView settingsView;

        private readonly Stack<UserControl> _navigationStack = new();
        private Employee _currentEmployee;
        private readonly MaterialSkinManager materialSkinManager = null!;

        public AdminControlForm(Employee employee)
        {
            InitializeComponent();


            _currentEmployee = employee;

            this.Text = $"Logged in as: {employee.FirstName} {employee.LastName}";


            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                primary: UIhelp.ThemeColors.MediumBrown,      // #6f4d38
                darkPrimary: UIhelp.ThemeColors.DarkBrown,    // #3d211a
                lightPrimary: UIhelp.ThemeColors.LightBrown,  // #a07856
                accent: UIhelp.ThemeColors.Beige,             // #cbb799
                textShade: TextShade.WHITE
            );

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var dbManager = new AccountDBManager(configuration);

            validator = new RegistrationValidation();
            updateValidation = new UpdateValidation();
            loginValidation = new LoginValidation();
            service = new AccountsService(dbManager);
            controller = new AccountController(validator, updateValidation, service, loginValidation); 

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

            settingsView = new SettingsView(controller, _currentEmployee);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            AdminFormHamburger.BackColor = UIhelp.ThemeColors.Background;
            AdminFormHamburger.ForeColor = UIhelp.ThemeColors.TextColor;

            foreach (TabPage tabPage in AdminFormHamburger.TabPages)
            {
                tabPage.BackColor = UIhelp.ThemeColors.Background;
                tabPage.ForeColor = UIhelp.ThemeColors.TextColor;
            }

            AdminContentPanel.BackColor = UIhelp.ThemeColors.Background;
            AccountsContentPanel.BackColor = UIhelp.ThemeColors.Background;
            settingsContentPanel.BackColor = UIhelp.ThemeColors.Background;

            this.BackColor = UIhelp.ThemeColors.Background;

            ShowInPanel(dashBoardControl, AdminContentPanel);
            ShowInPanel(newEmployeeView, AccountsContentPanel);
            ShowInPanel(settingsView, settingsContentPanel);
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