using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class InventorySystem
    {

        public record Inventory(
            int? Id,
            string Name,
            decimal Stocks,
            string Unit,
            string? ImagePath
            )
            {
                public string Name { get; set; } = Name;
                public decimal Stocks { get; set; } = Stocks;
                public string Unit { get; set; } = Unit;
                public string? ImagePath { get; set; } = ImagePath;
            }

    }
}
