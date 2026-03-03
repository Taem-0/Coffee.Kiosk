using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class ThemeSet
    {

        public Theme DefaultTheme { get; set; } = new();
        public Theme CustomTheme { get; set; } = new();

    }
}
