using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.Identity;
using CheckerApp.Infrastructure.Data;
using CheckerApp.Infrastructure.Services;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CheckerApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseLazyLoadingProxies()
                   .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery)));

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddClaimsPrincipalFactory<ApplicationUserClaimsFactory>();

            services.AddIdentityServer(config =>
            {  
                config.UserInteraction = new UserInteractionOptions
                {
                    LoginUrl = "/login"
                };
            })
               .AddApiAuthorization<ApplicationUser, AppDbContext>(options =>
               {
                   options.IdentityResources["openid"].UserClaims.Add("role");
                   options.IdentityResources["openid"].UserClaims.Add("full_name");
                   options.ApiResources.Single().UserClaims.Add("role");
                   options.ApiResources.Single().UserClaims.Add("full_name");
               });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
