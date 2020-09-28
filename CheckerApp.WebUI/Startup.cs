using CheckerApp.WebUI.Handlers;
using CheckerApp.WebUI.Interfaces;
using CheckerApp.WebUI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace CheckerApp.WebUI
{
    public class Startup
    {
        // Host API
        private readonly Uri _host;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _host = new Uri("https://localhost:5001");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddServerSideBlazor();

            services.AddScoped<HttpClient>();

            services.AddTransient<RequestHandler>();

            services.AddHttpClient<IContractService, ContractService>(client =>
            {
                client.BaseAddress = _host;
            })
                .AddHttpMessageHandler<RequestHandler>();

            services.AddHttpClient<IHardwareService, HardwareService>(client =>
            {
                client.BaseAddress = _host;
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();

            services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<AuthenticationStateProvider, AuthService>(provider =>
            //    provider.GetRequiredService<AuthService>());

            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://demo.identityserver.io/";
                    options.ClientId = "interactive.confidential"; // 75 seconds
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Events = new OpenIdConnectEvents
                    {
                        OnAccessDenied = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/");
                            return Task.CompletedTask;
                        }
                    };
                });

            //services.AddSingleton<BlazorServerAuthStateCache>();
            //services.AddScoped<AuthenticationStateProvider, BlazorServerAuthState>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
