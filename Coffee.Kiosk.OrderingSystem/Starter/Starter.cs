using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;


namespace Coffee.Kiosk.OrderingSystem.Starter
{
    internal class Starter
    {
        public static string Port = "6767"; 
        public static IHost Start(string port)
        {
            string distPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"starter", "dist");
            Port = port;

            var host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://localhost:{port}");

                    webBuilder.Configure(app =>
                    {
                        var fileProvider = new PhysicalFileProvider(distPath);

                        app.UseDefaultFiles(new DefaultFilesOptions
                        {
                            FileProvider = fileProvider
                        });

                        app.UseStaticFiles(new StaticFileOptions
                        {
                            FileProvider = fileProvider
                        });

                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            EndPoints.MapEndpoints(endpoints);
                        });
                    });
                })
                .Build();

            host.Start();

            return host;
        }
    }
}
