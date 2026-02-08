using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
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
    }
}