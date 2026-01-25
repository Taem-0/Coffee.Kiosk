using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class DBhelper
    {

        internal static string? connectionStringDatabase;

        internal static MySqlConnection CreateConnection(string connectionString)
        {

            var connection = new MySqlConnection(connectionString);

            connection.Open();

            return connection;

        }


    }
}
