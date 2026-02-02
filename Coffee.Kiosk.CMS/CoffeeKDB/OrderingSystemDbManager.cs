using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    }
}
