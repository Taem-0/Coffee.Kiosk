using System.Collections.Generic;

namespace Coffee.Kiosk.Cashier.ModelClassHelper
{
    public static class CustomizerConfig
    {
        public static Dictionary<string, decimal> GetSizes(MenuItemModel item)
        {
            if (item.Category == "Drinks")
            {
                decimal b = item.Price;
                return new() { { "Small", b }, { "Medium", b + 10 }, { "Large", b + 20 } };
            }
            return new() { { "Regular", item.Price } };
        }

        public static Dictionary<string, decimal> GetDrinkAddOns() => new()
        {
            { "Espresso shot", 39 },
            { "Oat milk",      49 },
            { "Coffee jelly",  30 },
            { "Whipped cream", 49 },
            { "Cream cheese",  30 },
            { "Pearl",         10 },
            { "Nata",          15 },
            { "Sauce",         30 },
            { "Cinnamon",      39 },
        };

        public static Dictionary<string, decimal> GetFoodAddOns() => new()
        {
            { "Extra rice",  30 },
            { "Extra egg",   20 },
            { "Extra sauce", 30 },
        };

        public static Dictionary<string, decimal> GetBreakfastOptions(decimal basePrice) => new()
        {
            { "Rice",       basePrice      },
            { "Fried rice", basePrice + 5  },
            { "Pancake",    basePrice + 10 },
            { "Bread",      basePrice + 10 },
        };

        public static bool ShowServeAs(string cat) => cat == "Drinks";
        public static bool ShowBeans(string cat) => cat == "Drinks";
        public static bool ShowMilk(string cat) => cat == "Drinks";
        public static bool ShowIceLevel(string cat) => cat == "Drinks";
        public static bool ShowSugarLevel(string cat) => cat == "Drinks";
        public static bool ShowDrinkAddOns(string cat) => cat == "Drinks";
        public static bool ShowBreakfastOptions(string cat) => cat == "Foods";
        public static bool ShowFoodAddOns(string cat) => cat is "Foods" or "Snacks";
    }
}