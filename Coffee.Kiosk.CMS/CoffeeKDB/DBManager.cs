using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
