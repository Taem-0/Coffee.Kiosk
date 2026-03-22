using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;

namespace Coffee.Kiosk.CMS.Controllers
{
    public class DashboardController
    {
        private readonly DashboardService _service;

        public DashboardController(DashboardService service)
        {
            _service = service;
        }

        public DashboardData GetDashboardData(string filter) => _service.GetDashboardData(filter);
    }
}