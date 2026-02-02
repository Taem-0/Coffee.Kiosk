using Coffee.Kiosk.CMS.CoffeeKDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coffee.Kiosk
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            Console.WriteLine("Starting application...");
            ApplicationConfiguration.Initialize();


            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();


            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration); 
            services.AddTransient<DBInitializer>();

            var serviceProvider = services.BuildServiceProvider();

            
            var dbInitializer = serviceProvider.GetRequiredService<DBInitializer>();

            
            dbInitializer.CreateDataBase();

            ApplicationConfiguration.Initialize();
            Application.Run(new AdminControlForm());

        }
    }
}