using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class Theme
    {

        public int Id { get; set; }
    
        public Boolean IsDefault { get; set; }

        public string PrimaryColor { get; set; } = string.Empty;

        public string DarkPrimaryColor { get; set; } = string.Empty;

        public string SecondaryColor { get; set; } = string.Empty;

        public string Background { get; set; } = string.Empty;

        public string Accent { get; set; } = string.Empty;


    }
}
