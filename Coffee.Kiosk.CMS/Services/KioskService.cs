using Coffee.Kiosk.CMS.Models;
using System.Collections.Generic;

namespace Coffee.Kiosk.CMS.Services
{
    public class KioskService
    {
        private readonly CoffeeKDB.KioskDBManager _dbManager;
        public KioskService(CoffeeKDB.KioskDBManager dbManager) => _dbManager = dbManager;

        public List<KioskBanner> GetAllBanners() => _dbManager.GetAllBanners();

        public void AddBanner(KioskBanner banner) => _dbManager.AddBanner(banner);

        public void UpdateBannerFilePath(int id, string path) => _dbManager.UpdateBannerFilePath(id, path);

        public void UpdateBanner(KioskBanner banner) => _dbManager.UpdateBanner(banner);

        public void DeleteBanner(int id) => _dbManager.DeleteBanner(id);
    }
}