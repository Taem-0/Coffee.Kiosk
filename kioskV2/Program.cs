using Microsoft.Extensions.Hosting;

namespace kioskV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        const string APIPORT = "6767";
        const bool RUNFORM = true;

        public static IHost? ApiHost;

        [STAThread]
        static void Main()
        {

            ApiHost = src.ApiServer.Start(APIPORT);

            if (RUNFORM)
            {
                Application.Run(new Form1(APIPORT));
            }
            else
            {
                Console.WriteLine($"API running on http://localhost:{APIPORT}");
                ApiHost.WaitForShutdown();
            }
        }
    }
}