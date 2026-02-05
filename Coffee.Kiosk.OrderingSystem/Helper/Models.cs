using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.OrderingSystem.Models
{
    public class Orders
    {
        public class OrderItem
        {
            public int ProductId;
            public string ProductName = String.Empty;
            public decimal ProductPrice;
            public int Quantity;
            public String ImagePath = String.Empty;


            public Dictionary<int, List<int>> SelectedModifierOptions = new();
            public Dictionary<string, List<string>> SelectedModifiersName = new();

            public bool IsSameAs(OrderItem other)
            {
                if (other == null) return false;

                if (ProductId != other.ProductId)
                    return false;

                if (SelectedModifierOptions.Count != other.SelectedModifierOptions.Count)
                    return false;

                foreach (var GroupIdValue in SelectedModifierOptions)
                {
                    if (!other.SelectedModifierOptions.TryGetValue(GroupIdValue.Key, out var otherList))
                        return false;

                    var thisSorted = GroupIdValue.Value.OrderBy(x => x).ToList();
                    var otherSorted = otherList.OrderBy(x => x).ToList();

                    if (!thisSorted.SequenceEqual(otherSorted))
                        return false;
                }

                return true;
            }

        }
        public enum TypeOfOrder 
        {
            DineIn,
            TakeOut
        }
        public TypeOfOrder Type;
        public List<OrderItem> Items = new();

        public void AddOrMergeItem(OrderItem newItem)
        {
            var existing = Items.FirstOrDefault(i => i.IsSameAs(newItem));

            if (existing != null)
            {
                existing.Quantity += newItem.Quantity;
            }
            else
            {
                Items.Add(newItem);
            }
        }

    }

    internal class Category
    {
        internal record CategoryData(
            int Id,
            string Name,
            string IconPath,
            bool IsShown = true
            );

        internal static List<CategoryData> categoryData = new();

        internal static void LoadDummyData()
        {
            categoryData.Add(new(1, "Coffee", "C:/Images/Kiosk/Main Menu/COFFEE.png", true));
            categoryData.Add(new(2, "Milktea", "C:/Images/Kiosk/Main Menu/MILKTEA.png", true));
            categoryData.Add(new(3, "Pastry", "C:/Images/Kiosk/Main Menu/PASTRY.png", true));
            categoryData.Add(new(4, "Snacks", "C:/Images/Kiosk/Main Menu/SNACKS.png", true));
            categoryData.Add(new(5, "Meals", "C:/Images/Kiosk/Main Menu/MEALS.png", true));
        }
        internal static void LoadFromDataBase()
        {
            categoryData.Clear();
            categoryData = Sql.Queries.GetAllCategories();
        }
    }

    public class Product
    {
        public enum SelectionType
        {
            Single,
            Multiple
        }

        internal record ProductData(
            int Id,
            int CategoryId,
            string Name,
            decimal Price,
            string ImagePath,
            bool IsCustomizable
        );

        public record ModifierGroup(
            int Id,
            int ProductId,
            int? ParentGroupId,
            string Name,
            SelectionType SelectionType,
            bool Required
            );

        public record ModifierOption(
            int Id,
            int GroupId,
            string Name,
            decimal PriceDelta,
            decimal InventorySubtraction,
            int? InventoryItemId,
            bool TriggersChild,
            int SortBy
            );

        internal static List<ProductData> productData = new();
        internal static List<ModifierGroup> modifierGroups = new();
        internal static List<ModifierOption> modifierOption = new();
        internal static void LoadDummyData()
        {
            productData.Add(new(1, 1, "Americano", 120m, "C:/Images/Kiosk/Coffee Product/Americano.png", true));
            productData.Add(new(2, 1, "Mocha Latte", 120m, "C:/Images/Kiosk/Coffee Product/Mocha Latte.png", true));
            productData.Add(new(3, 1, "Cafe Latte", 120m, "C:/Images/Kiosk/Coffee Product/Cafe Latte.png", true));
            productData.Add(new(4, 1, "Matcha Latte", 120m, "C:/Images/Kiosk/Coffee Product/Matcha Latte.png", true));

            modifierGroups.Add(new(1, 1, null, "Size", SelectionType.Single, true));
            modifierGroups.Add(new(2, 1, null, "Sugar Type", SelectionType.Single, true));
            modifierGroups.Add(new(3, 1, 2, "Sugar Level", SelectionType.Single, true));
            modifierGroups.Add(new(4, 1, null, "Temperature", SelectionType.Single, true));

            modifierOption.Add(new ModifierOption(1, 1, "Small", 0.00m, 250.00m, 4, true, 1));
            modifierOption.Add(new ModifierOption(2, 1, "Large", 30.00m, 450.00m, 4, true, 2));

            modifierOption.Add(new ModifierOption(3, 2, "No Sugar", 0.00m, 0.00m, null, false, 3));
            modifierOption.Add(new ModifierOption(4, 2, "Cane", 0.00m, 0.00m, 10, true, 4));
            modifierOption.Add(new ModifierOption(5, 2, "Muscovado", 0.00m, 0.00m, null, true, 5));
            modifierOption.Add(new ModifierOption(6, 2, "White", 0.00m, 0.00m, 8, true, 6));

            modifierOption.Add(new ModifierOption(7, 3, "25%", 0.00m, 2.00m, null, true, 7));
            modifierOption.Add(new ModifierOption(8, 3, "50%", 5.00m, 4.00m, null, true, 8));
            modifierOption.Add(new ModifierOption(9, 3, "75%", 10.00m, 6.00m, null, true, 9));
            modifierOption.Add(new ModifierOption(10, 3, "100%", 15.00m, 8.00m, null, true, 10));

            modifierOption.Add(new ModifierOption(11, 4, "Hot", 0.00m, 0.00m, null, true, 11));
            modifierOption.Add(new ModifierOption(12, 4, "Iced", 0.00m, 0.00m, null, true, 12));
        }
        internal static void LoadFromDataBase()
        {
            productData.Clear();
            modifierGroups.Clear();
            modifierOption.Clear();

            productData = Sql.Queries.GetAllProduct();
            modifierGroups = Sql.Queries.GetAllModifierGroups();
            modifierOption = Sql.Queries.GetAllModifierOptions();
        }
    }
}
