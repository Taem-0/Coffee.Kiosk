using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Forms;
using Coffee.Kiosk.CMS.Forms.WizardWoopWoop;
using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace Coffee.Kiosk
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<DBInitializer>();
            services.AddTransient<AccountDBManager>();
            services.AddTransient<AccountsService>();
            services.AddTransient<RegistrationValidation>();
            services.AddTransient<UpdateValidation>();
            services.AddTransient<LoginValidation>(); // Add this line
            services.AddTransient<AccountController>();

            var serviceProvider = services.BuildServiceProvider();
            var dbInitializer = serviceProvider.GetRequiredService<DBInitializer>();
            dbInitializer.CreateDataBase();

            bool adminExists = CheckIfAdminExists(serviceProvider);

            if (!adminExists)
            {
                ShowStartupWizard(serviceProvider);
            }
            else
            {
                var loginForm = new LoginForm();
                Application.Run(loginForm);
            }
        }

        private static bool CheckIfAdminExists(IServiceProvider serviceProvider)
        {
            try
            {
                var accountController = serviceProvider.GetRequiredService<AccountController>();
                var accounts = accountController.GetDisplayDTOs();
                return accounts.Any(account =>
                    account.Role.Equals("Owner", StringComparison.OrdinalIgnoreCase) &&
                    account.Status.Equals("Active", StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }

        private static void ShowStartupWizard(IServiceProvider serviceProvider)
        {
            var startupWizard = new StartUpWizard();
            startupWizard.ServiceProvider = serviceProvider;

            if (startupWizard.ShowDialog() == DialogResult.OK)
            {
                var loginForm = new LoginForm();
                Application.Run(loginForm);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}