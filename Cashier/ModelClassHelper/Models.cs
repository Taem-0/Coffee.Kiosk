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
        public string Notes { get; set; } = "";
        public List<(string GroupName, string OptionName, decimal Price)> SelectedModifiers { get; set; } = new();
        public decimal AddOnsTotal => SelectedModifiers.Sum(m => m.Price);

        public List<string> AddOns
        {
            get => SelectedModifiers.Select(m => m.OptionName).ToList();
        }

        public string Summary()
        {
            var parts = new List<string>();
            foreach (var m in SelectedModifiers)
                parts.Add($"{m.GroupName}: {m.OptionName}");
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