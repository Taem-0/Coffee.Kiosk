using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Text;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class ThemeDBManager
    {

        private readonly string _connectionString;

        public ThemeDBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException(
                    "Connection string 'Database' is missing in appsettings.json.");
        }

        public ThemeSet GetThemeSet()
        {
            var themeSet = new ThemeSet();

            using var connection = DBhelper.CreateConnection(_connectionString);
            using var command = connection.CreateCommand();

            try
            {
                command.CommandText = @"
                SELECT 
                    ID,
                    Is_Default,
                    Primary_Color,
                    DarkPrimary_Color,
                    Secondary_Color,
                    Background_Color,
                    Accent_Color
                FROM theme";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var theme = new Theme
                    {
                        Id = reader.GetInt32("ID"),
                        IsDefault = reader.GetBoolean("Is_Default"),
                        PrimaryColor = reader.GetString("Primary_Color"),
                        DarkPrimaryColor = reader.GetString("DarkPrimary_Color"),
                        SecondaryColor = reader.GetString("Secondary_Color"),
                        Background = reader.GetString("Background_Color"),
                        Accent = reader.GetString("Accent_Color")
                    };

                    if (theme.IsDefault)
                        themeSet.DefaultTheme = theme;
                    else
                        themeSet.CustomTheme = theme;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR (GetThemeSet): {ex.Message}");
            }

            return themeSet;
        }
    }
}
