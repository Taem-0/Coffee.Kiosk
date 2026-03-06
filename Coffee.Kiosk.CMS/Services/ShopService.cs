using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Models;

namespace Coffee.Kiosk.CMS.Services
{
    public class ShopService
    {
        private readonly ShopDBManager _dbManager;

        public ShopService(ShopDBManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        public Shop GetShopSettings()
        {
            return _dbManager.GetShop();
        }

        public void UpdateShopSettings(Shop updatedShop)
        {
            _dbManager.UpdateShop(updatedShop);
        }
    }
}