using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class ShopDBManager
    {
        private readonly string _connectionString;

        public ShopDBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string 'Database' is missing in appsettings.json.");
        }

        public Shop GetShop()
        {
            Shop shop = new Shop();

            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"
                SELECT 
                    ID,
                    ShopName,
                    ThemeMode,
                    Primary_Color,
                    DarkPrimary_Color,
                    Secondary_Color,
                    Background_Color,
                    Accent_Color,
                    LogoPath
                FROM shop
                WHERE ID = 1"; 

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    shop = new Shop
                    {
                        Id = reader.GetInt32("ID"),
                        ShopName = reader.GetString("ShopName"),
                        ThemeMode = reader.GetString("ThemeMode"),
                        PrimaryColor = reader.GetString("Primary_Color"),
                        DarkPrimaryColor = reader.GetString("DarkPrimary_Color"),
                        SecondaryColor = reader.GetString("Secondary_Color"),
                        BackgroundColor = reader.GetString("Background_Color"),
                        AccentColor = reader.GetString("Accent_Color"),
                        LogoPath = reader.IsDBNull("LogoPath") ? null : reader.GetString("LogoPath")
                    };
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (GetShop): {ex.Message}");
            }

            return shop;
        }

        public void UpdateShop(Shop shop)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"
                UPDATE shop
                SET 
                    ShopName = @ShopName,
                    ThemeMode = @ThemeMode,
                    Primary_Color = @PrimaryColor,
                    DarkPrimary_Color = @DarkPrimaryColor,
                    Secondary_Color = @SecondaryColor,
                    Background_Color = @BackgroundColor,
                    Accent_Color = @AccentColor,
                    LogoPath = @LogoPath
                WHERE ID = 1";

                command.Parameters.AddWithValue("@ShopName", shop.ShopName);
                command.Parameters.AddWithValue("@ThemeMode", shop.ThemeMode);
                command.Parameters.AddWithValue("@PrimaryColor", shop.PrimaryColor);
                command.Parameters.AddWithValue("@DarkPrimaryColor", shop.DarkPrimaryColor);
                command.Parameters.AddWithValue("@SecondaryColor", shop.SecondaryColor);
                command.Parameters.AddWithValue("@BackgroundColor", shop.BackgroundColor);
                command.Parameters.AddWithValue("@AccentColor", shop.AccentColor);
                command.Parameters.AddWithValue("@LogoPath", shop.LogoPath ?? (object)DBNull.Value);

                command.ExecuteNonQuery();

                AuditLogsDb.AddLogs(
                AuditLogsDb.Tables.SHOP,
                shop.Id,
                AuditLogsDb.Action.UPDATE,
                $"Update shop with an ID: {shop.Id}"
                );
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (UpdateShop): {ex.Message}");
            }
        }
    }
}