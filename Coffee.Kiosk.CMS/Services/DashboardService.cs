using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Models;

namespace Coffee.Kiosk.CMS.Services
{
    public class DashboardService
    {
        private readonly DashboardDBManager _dbManager;

        public DashboardService(DashboardDBManager dbManager)
        {
            _dbManager = dbManager;
        }

        public DashboardData GetDashboardData(string filter) => _dbManager.GetDashboardData(filter);
    }
}