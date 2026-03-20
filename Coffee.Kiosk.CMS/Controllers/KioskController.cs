using Coffee.Kiosk.CMS.Models;
using System.Collections.Generic;

namespace Coffee.Kiosk.CMS.Controllers
{
    public class KioskController
    {
        private readonly Services.KioskService _service;
        public KioskController(Services.KioskService service) => _service = service;

        public List<KioskBanner> GetAllBanners() => _service.GetAllBanners();
        public void AddBanner(KioskBanner banner) => _service.AddBanner(banner);
        public void UpdateBannerFilePath(int id, string path) => _service.UpdateBannerFilePath(id, path);
        public void DeleteBanner(int id) => _service.DeleteBanner(id);
    }
}