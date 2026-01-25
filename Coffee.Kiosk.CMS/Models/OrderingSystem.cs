using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    internal class OrderingSystem
    {
        internal class CategoryData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string IconPath { get; set; }
            public bool IsDraft { get; set; }

            public CategoryData(int id, string name, string iconPath, bool isDraft = true)
            {
                Id = id;
                Name = name;
                IconPath = iconPath;
                IsDraft = isDraft;
            }
        }
        internal class ProductData
        {
            public int Id { get; set; }
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImagePath { get; set; } 

            public ProductData(int id, int categoryId, string name, decimal price, string imagePath)
            {
                Id = id;
                CategoryId = categoryId;
                Name = name;
                Price = price;
                ImagePath = imagePath;
            }
        }

    }
}
