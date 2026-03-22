using Microsoft.Extensions.Hosting;
using QuestPDF;

namespace Coffee.Kiosk.OrderingSystem
{
    internal static class Program
    {

        const string APIPORT = "6767";
        public static IHost? ApiHost;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            ApiHost = Starter.Starter.Start(APIPORT);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            Application.Run(new CoffeeKioskMainForm());

        }
    }
}