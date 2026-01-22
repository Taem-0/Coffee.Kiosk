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

    internal class Category
    {
        internal record CategoryData(
            int Id,
            string Name,
            string IconPath
            );

        internal static List<CategoryData> categoryData = new();

        internal static void LoadDummyData()
        {
            categoryData.Add(new(1, "Coffee", "C:/Images/Kiosk/Main Menu/COFFEE.png"));
            categoryData.Add(new(2, "Milktea", "C:/Images/Kiosk/Main Menu/MILKTEA.png"));
            categoryData.Add(new(3, "Pastry", "C:/Images/Kiosk/Main Menu/PASTRY.png"));
            categoryData.Add(new(4, "Snacks", "C:/Images/Kiosk/Main Menu/SNACKS.png"));
            categoryData.Add(new(5, "Meals", "C:/Images/Kiosk/Main Menu/MEALS.png"));
        }
        internal static void LoadFromDataBase()
        {
            categoryData.Clear();
            categoryData = Sql.Queries.GetAllCategories();
        }
    }

    internal class Product
    {
        internal record ProductData(
            int Id,
            int CategoryId,
            string Name,
            decimal Price,
            string ImagePath
        );

        internal static List<ProductData> productData = new();
        internal static void LoadDummyData()
        {
            productData.Add(new(1, 1, "Americano", 120m, "C:/Images/Kiosk/Coffee Product/Americano.png"));
            productData.Add(new(2, 1, "Mocha Latte", 120m, "C:/Images/Kiosk/Coffee Product/Mocha Latte.png"));
            productData.Add(new(3, 1, "Cafe Latte", 120m, "C:/Images/Kiosk/Coffee Product/Cafe Latte.png"));
            productData.Add(new(4, 1, "Matcha Latte", 120m, "C:/Images/Kiosk/Coffee Product/Matcha Latte.png"));
        }
    }
}
