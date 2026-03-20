using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class KioskBanner
    {
        public int ID { get; set; }
        public string Placement { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 1;
        public string FilePath { get; set; } = string.Empty;


    }
}
