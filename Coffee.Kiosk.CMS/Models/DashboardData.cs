using System.Collections.Generic;

namespace Coffee.Kiosk.CMS.Models
{
    public class DashboardData
    {
        public decimal TodayRevenue { get; set; }
        public decimal WeekRevenue { get; set; }
        public decimal YearRevenue { get; set; }

        public int TodayOrders { get; set; }
        public int WeekOrders { get; set; }
        public int YearOrders { get; set; }

        public int DineInCount { get; set; }
        public int TakeOutCount { get; set; }

        public string BusiestHour { get; set; } = string.Empty;
        public string SlowestHour { get; set; } = string.Empty;

        public List<TopSellingProduct> TopProducts { get; set; } = new();

        // Chart-ready: daily revenue points for line chart
        public List<DailyRevenue> DailyRevenuePoints { get; set; } = new();

        // Chart-ready: hourly order counts for bar chart
        public List<HourlyOrders> HourlyOrderPoints { get; set; } = new();
    }

    public class TopSellingProduct
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Rank { get; set; }
        public string? ImagePath { get; set; }
    }

    public class DailyRevenue
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
    }

    public class HourlyOrders
    {
        public int Hour { get; set; }
        public int OrderCount { get; set; }
        public string HourLabel => $"{(Hour == 0 ? 12 : Hour > 12 ? Hour - 12 : Hour)}{(Hour < 12 ? "AM" : "PM")}";
    }
}