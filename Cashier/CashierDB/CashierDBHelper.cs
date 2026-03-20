using MySql.Data.MySqlClient;

namespace Coffee.Kiosk.Cashier.CashierDBHelper
{
    public static class CashierDBHelper
    {
        private const string ConnectionString =
            "Server=localhost;Database=CoffeeKioskDB;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
