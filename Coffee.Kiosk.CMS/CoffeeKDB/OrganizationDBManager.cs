using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class OrganizationDBManager
    {
        private readonly string _connectionString;

        public OrganizationDBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string missing.");
        }

        public List<OrganizationItem> GetJobTitles()
        {
            return GetItems("SELECT ID, Title AS Name, IsDefault FROM job_titles ORDER BY IsDefault DESC, Title ASC");
        }

        public List<OrganizationItem> GetDepartments()
        {
            return GetItems("SELECT ID, Name, IsDefault FROM departments ORDER BY IsDefault DESC, Name ASC");
        }

        public void AddJobTitle(string title)
        {
            Execute("INSERT INTO job_titles (Title, IsDefault) VALUES (@name, 0)", title);
        }

        public void AddDepartment(string name)
        {
            Execute("INSERT INTO departments (Name, IsDefault) VALUES (@name, 0)", name);
        }

        public void DeleteJobTitle(int id)
        {
            ExecuteDelete("DELETE FROM job_titles WHERE ID = @id AND IsDefault = 0", id);
        }

        public void DeleteDepartment(int id)
        {
            ExecuteDelete("DELETE FROM departments WHERE ID = @id AND IsDefault = 0", id);
        }

        private List<OrganizationItem> GetItems(string query)
        {
            var items = new List<OrganizationItem>();
            using var connection = DBhelper.CreateConnection(_connectionString);
            if (connection.State != ConnectionState.Open) connection.Open();
            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = query;
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new OrganizationItem
                    {
                        ID = reader.GetInt32("ID"),
                        Name = reader.GetString("Name"),
                        IsDefault = reader.GetBoolean("IsDefault")
                    });
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Database Error: {ex.Message}");
            }
            return items;
        }

        private void Execute(string query, string name)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            if (connection.State != ConnectionState.Open) connection.Open();
            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Database Error: {ex.Message}");
            }
        }

        private void ExecuteDelete(string query, int id)
        {
            using var connection = DBhelper.CreateConnection(_connectionString);
            if (connection.State != ConnectionState.Open) connection.Open();
            using var command = connection.CreateCommand();
            try
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Database Error: {ex.Message}");
            }
        }
    }
}