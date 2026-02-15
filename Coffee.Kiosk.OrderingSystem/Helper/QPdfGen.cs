using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Coffee.Kiosk.OrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.OrderingSystem.Helper
{
    public class QPdfGen : IDocument
    {
        private readonly Orders _order;

        public QPdfGen(Orders order)
        {
            _order = order;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.ContinuousSize(76, Unit.Millimetre);
                page.Margin(5); 
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Courier New"));

                page.Content().Column(col =>
                {
                    //col.Item().Text("=========================================================").AlignCenter();
                    col.Item().PaddingVertical(7).Background(Colors.Black).Text($"67").FontSize(48).Bold().FontColor(Colors.White).AlignCenter();

                    col.Item().PaddingVertical(5).Text(new String('=', 34)).AlignCenter();
                    col.Item().Text("Cafe Filipino").AlignCenter();
                    col.Item().PaddingVertical(5).Text(new String('=', 34)).AlignCenter();

                    col.Item().Text(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    col.Item().Text($"Order ID: 1");
                    col.Item().Text($"{(_order.Type == Models.Orders.TypeOfOrder.DineIn ? "Dine In" : "Take Out")}");
                    col.Item().PaddingVertical(5).Text(new String('=', 34)).AlignCenter();


                    foreach (var item in _order.Items)
                    {
                        col.Item().Column(itemCol =>
                        {
                            itemCol.Item().Row(row =>
                            {
                                row.RelativeItem().Text($"{item.Quantity}x {item.ProductName}");
                                row.ConstantItem(80).AlignRight().Text($"₱{item.BasePrice * item.Quantity:0.00}");
                            });
                            if (item.SelectedModifiersName.Count > 0)
                            {
                                foreach (var groupEntry in item.SelectedModifierOptions)
                                {
                                    //var group = Models.Product.modifierGroups.First(g => g.Id == groupEntry.Key);
                                    var group = (
                                        from g in Models.Product.modifierGroups
                                        where g.Id == groupEntry.Key
                                        select g
                                    ).First();

                                    itemCol.Item().Row(row =>
                                    {
                                        foreach (var optionId in groupEntry.Value)
                                        {
                                            var option = Models.Product.modifierOption.First(o => o.Id == optionId);

                                            row.RelativeItem().Text($"    {group.Name}: {option.Name}").FontSize(8);
                                            row.ConstantItem(80).AlignRight().Text($"+₱{option.PriceDelta:0.00}").FontSize(8);
                                        }
                                    });
                                }
                                col.Item().Text($"₱{item.ProductPrice * item.Quantity:0.00}").AlignRight().Bold().FontSize(8);
                            }
                        });
                    }

                    //col.Item().PaddingVertical(5).LineHorizontal(1);
                    col.Item().PaddingVertical(5).Text(new String('=', 34)).AlignCenter();

                    var subtotal = _order.Items.Sum(i => i.ProductPrice * i.Quantity);
                    col.Item().Text($"TOTAL: ₱{subtotal:0.00}");
                    col.Item().Text($"Payment: {_order.paymentType}");

                    col.Item().PaddingVertical(5).Text(new String('=', 34)).AlignCenter();
                    col.Item().PaddingTop(10).Text("Thank you! Come again!").AlignCenter();
                    col.Item().PaddingVertical(5).Text(new String('=', 34)).AlignCenter();
                });
            });
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;


        public static void GenerateReceiptPdf(Orders order, string basePath)
        {
            if (order == null) return;

            string directory = "C:/Images/Receipts";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(basePath);
            string extension = Path.GetExtension(basePath);

            int counter = 1;
            string fullPath = Path.Combine(directory, $"{fileNameWithoutExt}{extension}");

            while (File.Exists(fullPath))
            {
                fullPath = Path.Combine(directory, $"{fileNameWithoutExt}_{counter}{extension}");
                counter++;
            }

            var pdf = new QPdfGen(order);
            pdf.GeneratePdf(fullPath);
        }

    }
}