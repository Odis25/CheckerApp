using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CheckerApp.Server.Areas.Identity.IdentityHostingStartup))]
namespace CheckerApp.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}