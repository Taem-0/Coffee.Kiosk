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
                if (   other == null
                    || ProductId != other.ProductId
                    || SelectedModifierOptions.Count != other.SelectedModifierOptions.Count
                    ) return false;

                foreach (var GroupIdValue in SelectedModifierOptions)
                {
                    if (!other.SelectedModifierOptions.TryGetValue(GroupIdValue.Key, out var otherList))
                        return false;

                    var thisSorted =
                        from m in GroupIdValue.Value
                        orderby m
                        select m;
                    
                    var otherSorted =
                        from m in otherList
                        orderby m
                        select m;

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
            var existing = (
                from item in Items
                where item.IsSameAs(newItem)
                select item).FirstOrDefault();

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
            categoryData.Add(new(6, "Chainring", "C:/Images/Sugino-Big-Zen-Silver.png", true));
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

            productData.Add(new(5, 6, "Sugino Zen", 15000m, "C:/Images/Sugino-Big-Zen-Silver.png", true));

            int gId = 1;
            for (int i = 1; i < 4; i++)
            {
                modifierGroups.Add(new(gId, i, null, "Size", SelectionType.Single, true));
                gId++;
                modifierGroups.Add(new(gId, i, null, "Sugar Type", SelectionType.Single, true));
                gId++;
                modifierGroups.Add(new(gId, i, gId - 1, "Sugar Level", SelectionType.Single, true));
                gId++;
                modifierGroups.Add(new(gId, i, null, "Temperature", SelectionType.Single, true));
                gId++;
            }
            modifierGroups.Add(new(gId, 5, null, "Color", SelectionType.Single, false));
            modifierGroups.Add(new(gId+1, 5, null, "Teeth", SelectionType.Single, true));

            int pId = 1;
            gId = 1;
            for (int i = 1;  i < 4; i++)
            {
                modifierOption.Add(new ModifierOption(pId, gId, "Small", 0.00m, 250.00m, null, true, 1));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "Large", 30.00m, 450.00m, null, true, 2));
                pId++; gId++;

                modifierOption.Add(new ModifierOption(pId, gId, "No Sugar", 0.00m, 0.00m, null, false, 3));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "Cane", 5.00m, 0.00m, null, true, 4));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "Muscovado", 3.00m, 0.00m, null, true, 5));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "White", 2.00m, 0.00m, null, true, 6));
                pId++; gId++;

                modifierOption.Add(new ModifierOption(pId, gId, "25%", 2.00m, 2.00m, null, true, 7));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "50%", 5.00m, 4.00m, null, true, 8));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "75%", 10.00m, 6.00m, null, true, 9));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "100%", 15.00m, 8.00m, null, true, 10));
                pId++; gId++;

                modifierOption.Add(new ModifierOption(pId, gId, "Hot", 0.00m, 0.00m, null, true, 11));
                pId++;
                modifierOption.Add(new ModifierOption(pId, gId, "Iced", 0.00m, 0.00m, null, true, 12));
                pId++; gId++;
            }
            modifierOption.Add(new ModifierOption(pId, gId, "Silver", 167m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+1, gId, "Black", 67m, 0.00m, null, true, 14));
            modifierOption.Add(new ModifierOption(pId+2, gId+1, "47", 67m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+3, gId+1, "48", 70m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+4, gId+1, "49", 73m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+5, gId+1, "50", 76m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+6, gId+1, "51", 79m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+7, gId+1, "52", 82m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+8, gId+1, "53", 85m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+9, gId+1, "54", 88m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+10, gId+1, "55", 91m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+11, gId+1, "56", 94m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+12, gId+1, "57", 97m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+13, gId+1, "58", 100m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+14, gId+1, "59", 103m, 0.00m, null, true, 13));
            modifierOption.Add(new ModifierOption(pId+15, gId+1, "60", 106m, 0.00m, null, true, 13));
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
