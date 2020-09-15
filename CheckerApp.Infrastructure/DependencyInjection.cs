using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Infrastructure.Data;
using CheckerApp.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CheckerApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
            options.UseLazyLoadingProxies()
                   .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

            services.AddIdentityServer()
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddDeveloperSigningCredential();
                    //.AddAspNetIdentity<ApplicationUser>()
                    //.AddApiAuthorization<ApplicationUser, AppDbContext>();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config => 
                {
                    config.Authority = "https://localhost:44373";
                    config.Audience = "CheckerAppApi";
                });

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            return services;
        }
    }
}
