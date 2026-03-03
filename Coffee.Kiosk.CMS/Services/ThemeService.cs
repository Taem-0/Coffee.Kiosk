using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Services
{
    public class ThemeService
    {

        private readonly ThemeDBManager _dbManager;

        public ThemeService(ThemeDBManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        public Theme GetActiveTheme(bool useCustomTheme)
        {
            var themeSet = _dbManager.GetThemeSet();

            return useCustomTheme
                ? themeSet.CustomTheme
                : themeSet.DefaultTheme;
        }

    }
}
