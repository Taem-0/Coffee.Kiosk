using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class KioskDBManager
    {
        private readonly string _connectionString;

        public KioskDBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string missing.");
        }

        public List<KioskBanner> GetAllBanners()
        {
            var banners = new List<KioskBanner>();
            using var connection = DBhelper.CreateConnection(_connectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = "SELECT * FROM kiosk_banners ORDER BY Placement, DisplayOrder";
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    banners.Add(new KioskBanner
                    {
                        ID = reader.GetInt32("ID"),
                        FilePath = reader.GetString("FilePath"),
                        Placement = reader.GetString("Placement"),
                        DisplayOrder = reader.GetInt32("DisplayOrder")
                    });
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Database Error: {ex.Message}");
            }
            return banners;
        }

        public void AddBanner(KioskBanner banner)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = @"
                INSERT INTO kiosk_banners (FilePath, Placement, DisplayOrder)
                VALUES (@FilePath, @Placement, @DisplayOrder)";
                command.Parameters.AddWithValue("@FilePath", banner.FilePath ?? "");
                command.Parameters.AddWithValue("@Placement", banner.Placement ?? "");
                command.Parameters.AddWithValue("@DisplayOrder", banner.DisplayOrder);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Database Error: {ex.Message}");
            }
        }

        public void UpdateBannerFilePath(int id, string filePath)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            using var command = connection.CreateCommand();


            try
            {
                command.CommandText = "UPDATE kiosk_banners SET FilePath = @FilePath WHERE ID = @ID";
                command.Parameters.AddWithValue("@FilePath", filePath ?? "");
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Database Error: {ex.Message}");
            }
        }

        public void DeleteBanner(int id)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            
            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = "DELETE FROM kiosk_banners WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Database Error: {ex.Message}");
            }
        }
    }
}