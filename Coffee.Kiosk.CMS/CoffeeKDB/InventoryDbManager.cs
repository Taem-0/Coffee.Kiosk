using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Coffee.Kiosk.CMS.Models.InventorySystem;

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

        public static Models.InventorySystem.Inventory? GetInventoryById(int inventoryId)
        {
            Models.InventorySystem.Inventory? result = null;
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT * FROM inventory_item
                    WHERE ID = @inventoryId
                    ;
                    ";

                cmd.Parameters.AddWithValue("@inventoryId", inventoryId);

                using var row = cmd.ExecuteReader();
                if (row.Read())
                {
                    result = new Models.InventorySystem.Inventory(
                        row.GetInt32("ID"),
                        row.GetString("Name"),
                        row.GetDecimal("Stock"),
                        row.GetString("Unit"),
                        row.IsDBNull(4) ? "" : row.GetString("ImagePath")
                        );
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
        internal static bool DeleteInventory(int inventoryId)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"DELETE FROM inventory_item
                                    WHERE ID = @id;";
                cmd.Parameters.AddWithValue("@id", inventoryId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451) // foreign key constraint fails
                {
                    var usageList = GetProductsUsingInventoryItem(inventoryId);
                    if (usageList.Count == 0)
                    {
                        MessageBox.Show("Cannot perform this operation: the inventory item is referenced by other records.");
                    }
                    else
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("This inventory item is currently used by the following modifier options:");
                        sb.AppendLine();

                        foreach (var usage in usageList)
                        {
                            sb.AppendLine($"Product: {usage.ProductName}");
                            sb.AppendLine($"  Group: {usage.ModifierGroupName}");
                            sb.AppendLine($"    Option: {usage.ModifierOptionName}");
                            sb.AppendLine();
                        }

                        MessageBox.Show(sb.ToString(), "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    return false;
                }
                else
                {
                    MessageBox.Show($"Failed to perform the operation: {ex.Message}");
                    return false;
                }
            }
        }

        public record InventoryUsageInfo(
            int ProductId,
            string ProductName,
            int ModifierGroupId,
            string ModifierGroupName,
            int ModifierOptionId,
            string ModifierOptionName,
            int? InventoryItemId
        );

        private static List<InventoryUsageInfo> GetProductsUsingInventoryItem(int inventoryId)
        {
            var result = new List<InventoryUsageInfo>();

            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT 
                        p.Id AS ProductId,
                        p.Name AS ProductName,
                        mg.Id AS ModifierGroupId,
                        mg.Name AS ModifierGroupName,
                        mo.Id AS ModifierOptionId,
                        mo.Name AS ModifierOptionName,
                        mo.InventoryItemId
                    FROM modifier_option mo
                    INNER JOIN modifier_group mg ON mo.GroupId = mg.Id
                    INNER JOIN product p ON mg.ProductId = p.Id
                    WHERE mo.InventoryItemId = @inventoryId;
                ";
                cmd.Parameters.AddWithValue("@inventoryId", inventoryId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new InventoryUsageInfo(
                        reader.GetInt32("ProductId"),
                        reader.GetString("ProductName"),
                        reader.GetInt32("ModifierGroupId"),
                        reader.GetString("ModifierGroupName"),
                        reader.GetInt32("ModifierOptionId"),
                        reader.GetString("ModifierOptionName"),
                        reader.IsDBNull(reader.GetOrdinal("InventoryItemId"))
                            ? null
                            : reader.GetInt32("InventoryItemId")
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve products using this inventory item:\n{ex.Message}");
            }

            return result;
        }
    }
}
