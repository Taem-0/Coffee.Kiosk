using System.Collections.Generic;

namespace Coffee.Kiosk.Cashier.ModelClassHelper
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
    }

    public class MenuItemModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
    }

    public class OrderCustomization
    {
        public string ServeAs { get; set; } = "";
        public string Size { get; set; } = "";
        public string Beans { get; set; } = "";
        public string Milk { get; set; } = "";
        public string IceLevel { get; set; } = "";
        public string SugarLevel { get; set; } = "";
        public string ServedWith { get; set; } = "";
        public string Notes { get; set; } = "";
        public List<string> AddOns { get; set; } = new();
        public decimal AddOnsTotal { get; set; } = 0;

        public string Summary()
        {
            var parts = new List<string>();
            if (!string.IsNullOrEmpty(ServeAs)) parts.Add(ServeAs);
            if (!string.IsNullOrEmpty(Size)) parts.Add(Size);
            if (!string.IsNullOrEmpty(ServedWith)) parts.Add(ServedWith);
            if (!string.IsNullOrEmpty(Beans)) parts.Add(Beans);
            if (!string.IsNullOrEmpty(Milk)) parts.Add(Milk);
            if (!string.IsNullOrEmpty(IceLevel)) parts.Add(IceLevel);
            if (!string.IsNullOrEmpty(SugarLevel)) parts.Add(SugarLevel);
            foreach (var a in AddOns) parts.Add($"+{a}");
            if (!string.IsNullOrEmpty(Notes)) parts.Add($"\"{Notes}\"");
            return string.Join(" · ", parts);
        }
    }

    public class OrderItemModel
    {
        public MenuItemModel Item { get; set; } = new();
        public int Quantity { get; set; }
        public OrderCustomization Customization { get; set; } = new();
        public decimal Subtotal => (Item.Price + Customization.AddOnsTotal) * Quantity;
    }
}