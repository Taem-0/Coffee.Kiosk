using MySql.Data.MySqlClient;
using System;

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

        public static int OpenShift(int employeeId, string employeeName)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = @"INSERT INTO EmployeeSales 
                               (EmployeeId, EmployeeName, TotalSales, ShiftDate, ShiftStart)
                           VALUES (@empId, @empName, 0, @shiftDate, @shiftStart);
                           SELECT LAST_INSERT_ID();";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@empId", employeeId);
            cmd.Parameters.AddWithValue("@empName", employeeName);
            cmd.Parameters.AddWithValue("@shiftDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@shiftStart", DateTime.Now);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void AddToSales(int salesId, decimal amount)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "UPDATE EmployeeSales SET TotalSales = TotalSales + @amount WHERE SalesId = @id;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@id", salesId);
            cmd.ExecuteNonQuery();
        }

        public static void CloseShift(int salesId)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "UPDATE EmployeeSales SET ShiftEnd = @shiftEnd WHERE SalesId = @id;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@shiftEnd", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", salesId);
            cmd.ExecuteNonQuery();
        }

        public static int GetNextOrderNumber()
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT IFNULL(MAX(ID), 0) + 1 FROM customer_orders;";
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static (string ShopName, string? LogoPath) GetShopInfo()
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT ShopName, LogoPath FROM Shop LIMIT 1;";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string name = reader.IsDBNull(0) ? "Coffee Kiosk" : reader.GetString(0);
                string? path = reader.IsDBNull(1) ? null : reader.GetString(1);
                return (name, path);
            }
            return ("Coffee Kiosk", null);
        }
    }
}