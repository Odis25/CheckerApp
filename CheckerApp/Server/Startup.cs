using CheckerApp.Application;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Infrastructure;
using CheckerApp.Server.Common.JsonConverters;
using CheckerApp.Server.Common.Middleware;
using CheckerApp.Server.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Reflection;

namespace CheckerApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);

            services.AddApplication();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers().AddJsonOptions(options=> 
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.Converters.Add(new HardwareConverter());
                options.JsonSerializerOptions.Converters.Add(new SoftwareConverter());
            });
            services.AddRazorPages();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpClient();
            services.AddScoped<HttpClient>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
