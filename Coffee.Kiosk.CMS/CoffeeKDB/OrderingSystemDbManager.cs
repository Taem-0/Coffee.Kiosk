using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class OrderingSystemDbManager
    {
        internal static List<Models.OrderingSystem.CategoryData> GetAllCategories()
        {
            var result = new List<Models.OrderingSystem.CategoryData>();
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM category;";

                using var row = cmd.ExecuteReader();
                while (row.Read())
                {
                    result.Add(new Models.OrderingSystem.CategoryData(
                        row.GetInt32(0),
                        row.GetString(1),
                        row.IsDBNull(2) ? string.Empty : row.GetString(2),
                        row.GetBoolean(3)
                        ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\033[1;31m{ex}\033[0m");
                //MessageBox.Show("failed to retrieve categories");
            }
            return result;
        }

        internal static void UpdateCategoryName(int categoryId, string newName)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE category
                                    SET Name = @newName
                                    WHERE ID = @categoryId;
                                   ";
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\033[1;31m{ex}\033[0m");
                MessageBox.Show("failed to update categoryname");
            }
        }

        internal static int AddCategory(string name, string iconPath)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO category (Name, IconPath, IsShown)
                                    VALUES (@name, @iconPath, false);";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@iconPath", iconPath);
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert into table category");
                Console.Write(ex);
                return 0;
            }
        }

        internal static void DeleteCategory(int categoryId)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"DELETE FROM category
                                    WHERE ID = @categoryId;";
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to delete category");
                Console.Write(ex);
            }
        }
        internal static void IsDraftCategory(int categoryId, bool isDraft)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE category
                                    SET IsShown = @isDraft
                                    WHERE ID = @categoryId;";
                cmd.Parameters.AddWithValue("@isDraft", isDraft);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to change IsDraft category");
                Console.Write(ex);
            }
        }

        internal static void UpdateCategoryIcon(int categoryId, string newIconPath)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE category
                                    SET IconPath = @newIconPath
                                    WHERE ID = @categoryId;";
                cmd.Parameters.AddWithValue("@newIconPath", newIconPath);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to change IconPath category");
                Console.Write(ex);
            }
        }


        internal static List<Models.OrderingSystem.ProductData> GetAllProductsCategory(int categoryId)
        {
            var result = new List<Models.OrderingSystem.ProductData>();

            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT * FROM product WHERE CategoryID = @categoryId";
                cmd.Parameters.AddWithValue("@categoryId", categoryId);

                using var row = cmd.ExecuteReader();
                while (row.Read())
                {
                    result.Add(new Models.OrderingSystem.ProductData(
                        row.GetInt32("ID"),
                        row.GetInt32("CategoryID"),
                        row.GetString("Name"),
                        row.GetDecimal("Price"),
                        row.GetString("ImagePath"),
                        row.GetBoolean("IsCustomizable")
                        ));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Couldn't GetAllProductsCategory for : ${categoryId}");
                MessageBox.Show($"${ex.Message}");
            }
            return result;
        }

        internal static int AddProduct(int categoryId, string name, decimal price, string imagePath)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO product (CategoryID, Name, Price, ImagePath, IsCustomizable)
                                    VALUES (@categoryId, @name, @price, @imagePath, false);";
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert into table product");
                Console.Write(ex.Message);
                return 0;
            }
        }

        internal static void DeleteProduct(int productId)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"DELETE FROM product
                                    WHERE ID = @productid;";
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to delete product");
                Console.Write(ex.Message);
            }
        }
        internal static List<Models.OrderingSystem.ModifierGroup> GetModifierGroups(int productId)
        {
            var result = new List<Models.OrderingSystem.ModifierGroup>();

            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT * FROM modifier_group WHERE ProductId = @productId";
                cmd.Parameters.AddWithValue("@productId", productId);

                using var row = cmd.ExecuteReader();
                while (row.Read())
                {
                    string selectionTypeString = row.GetString("SelectionType");

                    var selectionType = Enum.Parse<Models.OrderingSystem.SelectionType>(selectionTypeString);

                    result.Add(new Models.OrderingSystem.ModifierGroup(
                        row.GetInt32("ID"),
                        row.GetInt32("ProductID"),
                        row.IsDBNull("ParentGroupId")
                            ? null
                            : row.GetInt32("ParentGroupId"),
                        row.GetString("Name"),
                        selectionType,
                        row.GetBoolean("Required")
                    ));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Couldn't GetModifierGroup for : ${productId}");
                MessageBox.Show($"${ex.Message}");
            }
            return result;
        }

        internal static int AddModifierGroup(
            int productId,
            int? parentGroupId,
            string name,
            Models.OrderingSystem.SelectionType selectionType,
            bool required
            )
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO modifier_group(ProductId, ParentGroupId, Name, SelectionType, Required)
                                    VALUES (@productId, @parentGroupId, @name, @selectionType, @required);";
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@parentGroupId", parentGroupId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@selectionType", selectionType.ToString());
                cmd.Parameters.AddWithValue("@required", required);
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to insert into table modifier_group\n {ex.Message}");
                return 0;
            }
        }

        internal static void DeleteModifierGroup(int GroupId)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = $"DELETE FROM modifier_group WHERE ID = {GroupId}";
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to delete modifier_group\n{ex.Message}");
            }
        }


        internal static List<Models.OrderingSystem.ModifierOption> GetModifierOptions(int groupId)
        {
            var result = new List<Models.OrderingSystem.ModifierOption>();

            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT * FROM modifier_option WHERE GroupId = @groupId";
                cmd.Parameters.AddWithValue("@groupId", groupId);

                using var row = cmd.ExecuteReader();
                while (row.Read())
                {
                    int? inventoryItemId = row.IsDBNull(row.GetOrdinal("InventoryItemId"))
                        ? null
                        : row.GetInt32("InventoryItemId");

                    int? sortBy = row.IsDBNull(row.GetOrdinal("SortBy"))
                        ? null
                        : row.GetInt32("SortBy");

                    result.Add(new Models.OrderingSystem.ModifierOption
                    {
                        Id = row.GetInt32("ID"),
                        GroupId = row.GetInt32("GroupId"),
                        Name = row.GetString("Name"),
                        PriceDelta = row.GetDecimal("PriceDelta"),
                        InventorySubtraction = row.GetDecimal("InventorySubtraction"),
                        InventoryItemId = inventoryItemId,
                        TriggersChild = row.GetBoolean("TriggersChild"),
                        SortBy = sortBy
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Couldn't GetModifierOptions for : ${groupId}");
                MessageBox.Show($"${ex.Message}");
            }
            return result;
        }
        internal static int AddModifierOption(Models.OrderingSystem.ModifierOption model)
        {
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO modifier_option(
                    GroupId,
                    Name,
                    PriceDelta,
                    InventorySubtraction,
                    InventoryItemId,
                    TriggersChild
                    )
                    VALUES (
                    @groupId,
                    @name,
                    @priceDelta,
                    @inventorySubtraction,
                    @inventoryItemId,
                    @triggersChild
                    );";
                cmd.Parameters.AddWithValue("@groupId", model.GroupId);
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@priceDelta", model.PriceDelta);
                cmd.Parameters.AddWithValue("@inventorySubtraction", model.InventorySubtraction);
                cmd.Parameters.AddWithValue("@inventoryItemId", model.InventoryItemId);
                cmd.Parameters.AddWithValue("@triggersChild", model.TriggersChild);
                cmd.ExecuteNonQuery();

                int lastInsertedId = (int)cmd.LastInsertedId;

                using var cmd2 = conn.CreateCommand();
                cmd2.CommandText = $"""
                             UPDATE modifier_option 
                             SET SortBy = { lastInsertedId }
                             WHERE ID = { lastInsertedId };
                             """;
                cmd2.ExecuteNonQuery();

                return lastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to insert into table modifier_option\n {ex.Message}");
                return 0;
            }
        }
    }
}
