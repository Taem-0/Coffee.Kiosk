using Coffee.Kiosk.CMS.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    public class DashboardDBManager
    {
        private readonly string _connectionString;

        public DashboardDBManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string missing.");
        }

        public DashboardData GetDashboardData(string filter)
        {
            var data = new DashboardData();

            using var connection = DBhelper.CreateConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            string dateFilter = filter switch
            {
                "month" => "MONTH(co.CreatedAt) = MONTH(NOW()) AND YEAR(co.CreatedAt) = YEAR(NOW())",
                "year" => "YEAR(co.CreatedAt) = YEAR(NOW())",
                _ => "DATE(co.CreatedAt) = CURDATE()" // day default
            };

            data.TodayRevenue = GetRevenue(connection, "DATE(co.CreatedAt) = CURDATE()");
            data.WeekRevenue = GetRevenue(connection, "YEARWEEK(co.CreatedAt) = YEARWEEK(NOW())");
            data.YearRevenue = GetRevenue(connection, "YEAR(co.CreatedAt) = YEAR(NOW())");

            data.TodayOrders = GetOrderCount(connection, "DATE(co.CreatedAt) = CURDATE()");
            data.WeekOrders = GetOrderCount(connection, "YEARWEEK(co.CreatedAt) = YEARWEEK(NOW())");
            data.YearOrders = GetOrderCount(connection, "YEAR(co.CreatedAt) = YEAR(NOW())");

            GetDineInVsTakeOut(connection, dateFilter, data);
            GetPeakHours(connection, dateFilter, data);

            data.TopProducts = GetTopSellingProducts(connection, dateFilter);
            data.DailyRevenuePoints = GetDailyRevenuePoints(connection, dateFilter);
            data.HourlyOrderPoints = GetHourlyOrderPoints(connection, dateFilter);

            return data;
        }

        private decimal GetRevenue(MySqlConnection connection, string dateFilter)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT COALESCE(SUM(TotalAmount), 0)
                FROM customer_orders co
                WHERE Status = 'Paid' AND {dateFilter}";
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private int GetOrderCount(MySqlConnection connection, string dateFilter)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT COUNT(*)
                FROM customer_orders co
                WHERE Status = 'Paid' AND {dateFilter}";
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void GetDineInVsTakeOut(MySqlConnection connection, string dateFilter, DashboardData data)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT OrderType, COUNT(*) as Count
                FROM customer_orders co
                WHERE Status = 'Paid' AND {dateFilter}
                GROUP BY OrderType";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var type = reader.GetString("OrderType");
                var count = reader.GetInt32("Count");
                if (type == "DineIn") data.DineInCount = count;
                if (type == "TakeOut") data.TakeOutCount = count;
            }
        }

        private void GetPeakHours(MySqlConnection connection, string dateFilter, DashboardData data)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT HOUR(co.CreatedAt) as Hour, COUNT(*) as OrderCount
                FROM customer_orders co
                WHERE Status = 'Paid' AND {dateFilter}
                GROUP BY HOUR(co.CreatedAt)
                ORDER BY OrderCount DESC";

            var hours = new List<HourlyOrders>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                hours.Add(new HourlyOrders
                {
                    Hour = reader.GetInt32("Hour"),
                    OrderCount = reader.GetInt32("OrderCount")
                });
            }

            if (hours.Count > 0)
            {
                data.BusiestHour = $"{hours[0].HourLabel} - {hours[0].OrderCount} orders";
                data.SlowestHour = $"{hours[^1].HourLabel} - {hours[^1].OrderCount} orders";
            }
            else
            {
                data.BusiestHour = "No data";
                data.SlowestHour = "No data";
            }
        }

        private List<TopSellingProduct> GetTopSellingProducts(MySqlConnection connection, string dateFilter)
        {
            var products = new List<TopSellingProduct>();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT coi.ProductName, SUM(coi.Quantity) as TotalQty
                FROM customer_order_item coi
                INNER JOIN customer_orders co ON coi.CustomerOrderId = co.ID
                WHERE co.Status = 'Paid' AND {dateFilter}
                GROUP BY coi.ProductName
                ORDER BY TotalQty DESC
                LIMIT 10";

            using var reader = cmd.ExecuteReader();
            int rank = 1;
            while (reader.Read())
            {
                products.Add(new TopSellingProduct
                {
                    Name = reader.GetString("ProductName"),
                    Quantity = Convert.ToInt32(reader.GetDecimal("TotalQty")),
                    Rank = rank++
                });
            }
            return products;
        }

        private List<DailyRevenue> GetDailyRevenuePoints(MySqlConnection connection, string dateFilter)
        {
            var points = new List<DailyRevenue>();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT DATE(co.CreatedAt) as Date, SUM(TotalAmount) as Revenue
                FROM customer_orders co
                WHERE Status = 'Paid' AND {dateFilter}
                GROUP BY DATE(co.CreatedAt)
                ORDER BY Date ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                points.Add(new DailyRevenue
                {
                    Date = reader.GetDateTime("Date"),
                    Revenue = reader.GetDecimal("Revenue")
                });
            }
            return points;
        }

        private List<HourlyOrders> GetHourlyOrderPoints(MySqlConnection connection, string dateFilter)
        {
            var points = new List<HourlyOrders>();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT HOUR(co.CreatedAt) as Hour, COUNT(*) as OrderCount
                FROM customer_orders co
                WHERE Status = 'Paid' AND {dateFilter}
                GROUP BY HOUR(co.CreatedAt)
                ORDER BY Hour ASC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                points.Add(new HourlyOrders
                {
                    Hour = reader.GetInt32("Hour"),
                    OrderCount = reader.GetInt32("OrderCount")
                });
            }
            return points;
        }
    }
}