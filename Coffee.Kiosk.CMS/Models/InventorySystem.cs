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
            );

    }
}
