using Coffee.Kiosk.OrderingSystem.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Coffee.Kiosk.OrderingSystem.Starter
{
    internal class EndPoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/getstarterads", () =>
            {
                var ads = Models.Ads.AdsBanners
                    .Where(b => b.AdPlacement == Models.Ads.AdPlacement.STARTING_SCREEN)
                    .OrderBy(b => b.DisplayOrder)
                    .Select(b => new
                    {
                        id = b.Id,
                        displayOrder = b.DisplayOrder
                    })
                    .ToList();
                return Results.Json(ads);
            });

            endpoints.MapGet("/api/image/{id:int}", (int id) =>
            {
                var banner = Models.Ads.AdsBanners.FirstOrDefault(b => b.Id == id);
                if (banner is null || !File.Exists(banner.FilePath))
                    return Results.NotFound();

                var ext = Path.GetExtension(banner.FilePath).ToLower();
                var mimeType = ext switch
                {
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".png" => "image/png",
                    ".gif" => "image/gif",
                    ".webp" => "image/webp",
                    _ => "application/octet-stream"
                };

                var bytes = File.ReadAllBytes(banner.FilePath);
                return Results.File(bytes, mimeType);
            });

            endpoints.MapGet("/api/logo", () =>
            {
                var logo = UI_Images.logoImage;
                if (logo is null) return Results.NotFound();

                using var ms = new MemoryStream();
                logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Results.File(ms.ToArray(), "image/png");
            });
        }
    }
}
