using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    internal class InventorySystem
    {

        internal record Inventory(
            int? Id,
            string Name,
            decimal Stock,
            string Unit,
            string ImagePath
            );

    }
}
