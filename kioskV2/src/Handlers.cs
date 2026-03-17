using Microsoft.AspNetCore.Http;

namespace kioskV2
{
    public static class Handlers
    {
        public static object GetStatus()
        {
            return new { status = "ok" };
        }

        public static IResult GetCategory(HttpContext ctx)
        {
            var type = ctx.Request.Query["type"].ToString();

            Console.WriteLine($"Requested category type: {type}");

            var categories = new[]
            {
                new { Id = 1, Name = "Beverages" },
                new { Id = 2, Name = "Snacks" }
            };

            var filtered = string.IsNullOrEmpty(type)
                ? categories
                : categories.Where(c => c.Name.Contains(type, StringComparison.OrdinalIgnoreCase));

            return Results.Ok(filtered);
        }
    }
}