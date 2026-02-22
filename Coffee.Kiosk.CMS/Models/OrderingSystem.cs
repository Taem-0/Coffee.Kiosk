using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class OrderingSystem
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
    }

}
