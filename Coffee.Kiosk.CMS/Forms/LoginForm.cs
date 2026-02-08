using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms
{
    public partial class LoginForm : Form
    {
        private LoginControl loginControl;
        private AccountController _controller;

        public LoginForm()
        {
            InitializeComponent();

            // APPLY THEME TO THE FORM
            this.BackColor = UIhelp.ThemeColors.Background; // #f5f5dc

            // Theme the container
            guna2ContainerControl1.FillColor = UIhelp.ThemeColors.MediumBrown; // #6f4d38
            guna2ContainerControl1.BorderColor = UIhelp.ThemeColors.DarkBrown; // #3d211a

            // Theme the panel
            loginPanel.FillColor = UIhelp.ThemeColors.Background; // #f5f5dc
            loginPanel.BackColor = Color.Transparent;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<AccountDBManager>();
            services.AddTransient<AccountsService>();
            services.AddTransient<RegistrationValidation>();
            services.AddTransient<UpdateValidation>();
            services.AddTransient<LoginValidation>();
            services.AddTransient<AccountController>();

            var serviceProvider = services.BuildServiceProvider();
            _controller = serviceProvider.GetRequiredService<AccountController>();

            loginControl = new LoginControl();
            loginControl.SetController(_controller);
            loginControl.OnLoginSuccess += OnLoginSuccess;

            UIhelp.CallControl(loginControl, loginPanel);
        }

        private void OnLoginSuccess(Employee employee)
        {
            var adminForm = new AdminControlForm(employee);
            this.Hide();
            adminForm.ShowDialog();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // No changes needed here
        }
    }
}