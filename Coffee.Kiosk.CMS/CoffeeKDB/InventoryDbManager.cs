using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class InventoryDbManager
    {
        internal static List<Models.InventorySystem.Inventory> GetInventory(string search = "")
        {
            var result = new List<Models.InventorySystem.Inventory>();
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT *
                    FROM inventory_item
                    WHERE 
                        CAST(ID AS CHAR) LIKE @search
                        OR Name LIKE @search
                        OR CAST(Stock AS CHAR) LIKE @search
                        OR Unit LIKE @search;
                    ";

                cmd.Parameters.AddWithValue("@search", search);

                using var row = cmd.ExecuteReader();
                while (row.Read())
                {
                    result.Add(new Models.InventorySystem.Inventory(
                        row.GetInt32("ID"),
                        row.GetString("Name"),
                        row.GetDecimal("Stock"),
                        row.GetString("Unit"),
                        row.IsDBNull(4) ? "" : row.GetString("ImagePath")
                        ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"failed to retrieve inventory\n{ex.Message}");
            }
            return result;
        }
    }
}
