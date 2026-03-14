using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class InventoryDbManager
    {
        public static List<Models.InventorySystem.Inventory> GetInventory(string search = "")
        {
            var result = new List<Models.InventorySystem.Inventory>();
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT * FROM inventory_item
                    WHERE
                        Name LIKE @search
                        OR Unit LIKE @search
                    ;
                    ";

                cmd.Parameters.AddWithValue("@search", $"%{search}%");

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

        internal static int AddInventory(Models.InventorySystem.Inventory model)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO inventory_item (Name, Stock, Unit, ImagePath)
                                    VALUES (@name, @stock, @unit, @imagePath);";
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@stock", model.Stocks);
                cmd.Parameters.AddWithValue("@unit", model.Unit);
                cmd.Parameters.AddWithValue("@imagePath", model.ImagePath);

                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to insert into table inventory_item\n{ex.Message}");
                return 0;
            }
        }

        internal static bool EditInventory(
            Models.InventorySystem.Inventory model,
            bool updateName = true,
            bool updateStock = true,
            bool updateUnit = true,
            bool updateImagePath = true)
        {
            var updates = new List<string>();

            if (updateName) updates.Add("Name = @name");
            if (updateStock) updates.Add("Stock = @stock");
            if (updateUnit) updates.Add("Unit = @unit");
            if (updateImagePath) updates.Add("ImagePath = @imagePath");

            if (updates.Count == 0) return false;

            string query = $"UPDATE inventory_item SET {string.Join(", ", updates)} WHERE ID = @id;";

            string defaultImagePath = "../../../Resources/default_icon.png";

            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query;

                if (updateName) cmd.Parameters.AddWithValue("@name", model.Name);
                if (updateStock) cmd.Parameters.AddWithValue("@stock", model.Stocks);
                if (updateUnit) cmd.Parameters.AddWithValue("@unit", model.Unit);
                if (updateImagePath)
                {
                    cmd.Parameters.AddWithValue("@imagePath",
                        string.IsNullOrEmpty(model.ImagePath)
                        ? defaultImagePath
                        : model.ImagePath);
                }

                cmd.Parameters.AddWithValue("@id", model.Id);
                
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update table inventory_item\n{ex.Message}");
                return false;
            }
        }
        internal static bool DeleteInventory(int invetoryId)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"DELETE FROM inventory_item
                                    WHERE ID = @id;";
                cmd.Parameters.AddWithValue("@id", invetoryId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show($"""
                        Cannot delete this inventory item because one or more modifier options are using it.
                        List of products with modifier options using this item:

                        """);
                        
                    return false;
                }
                else
                {
                    MessageBox.Show($"Failed to delete inventory item: {ex.Message}");
                    return false;
                }
            }
        }

        internal static List<Models.OrderingSystem.ProductData> GetProductsUsingInventoryItem(int inventoryId)
        {
            List<Models.OrderingSystem.ProductData> result = new();

            List<Models.OrderingSystem.ModifierOption> modifierOptions = new();
            List<Models.OrderingSystem.ModifierGroup> modifierGroup = new();

            return result;
        }
    }
}
