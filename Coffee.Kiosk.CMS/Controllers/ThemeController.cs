using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Controllers
{
    public class ThemeController
    {

        private readonly ThemeService _service;

        public ThemeController(ThemeService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public Theme GetTheme(bool useCustomTheme)
        {
            return _service.GetActiveTheme(useCustomTheme);
        }

    }
}
