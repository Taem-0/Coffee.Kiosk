using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class Shop
    {

        public int Id { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string ThemeMode { get; set; } = "default"; 
        public string PrimaryColor { get; set; } = string.Empty;
        public string DarkPrimaryColor { get; set; } = string.Empty;
        public string SecondaryColor { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = string.Empty;
        public string AccentColor { get; set; } = string.Empty;
        public string? LogoPath { get; set; }

    }
}
