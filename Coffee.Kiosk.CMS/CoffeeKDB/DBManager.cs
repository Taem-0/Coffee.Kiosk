using Microsoft.Extensions.Configuration;


namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class DBManager
    {

        private readonly string _connectionString;

        public DBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("Connection string 'Default' is missing in appsettings.json.");
        }

        public void Connect()
        {
            Console.WriteLine($"Connecting with: {_connectionString}");
        }



    }
}
