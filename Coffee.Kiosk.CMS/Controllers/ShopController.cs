using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Controllers
{
    public class ShopController
    {
        private readonly ShopService _service;

        public ShopController(ShopService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public Shop GetShopSettings()
        {
            return _service.GetShopSettings();
        }

        public void UpdateShopSettings(Shop updatedShop)
        {
            _service.UpdateShopSettings(updatedShop);
        }


    }
}
