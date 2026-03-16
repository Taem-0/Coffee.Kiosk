using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.Cashier
{
    public static class SessionManager
    {
        public static UserModel CurrentUser { get; set; } = new();
        public static int OrderNumber { get; set; } = 1;
    }
}