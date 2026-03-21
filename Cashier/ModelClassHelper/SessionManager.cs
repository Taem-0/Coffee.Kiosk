namespace Coffee.Kiosk.Cashier.ModelClassHelper
{
    public static class SessionManager
    {
        public static UserModel CurrentUser { get; set; } = new();
        public static int OrderNumber { get; set; } = 1;
        public static int ActiveSalesId { get; set; }
    }
}