using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.OrderingSystem.Models
{
    internal class Orders
    {
        internal enum TypeOfOrder 
        {
            DineIn,
            TakeOut
        }

        internal TypeOfOrder Type { get; set; }

    }
}
