using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Services;
using CheckerApp.Mobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CheckerApp.Mobile
{
    public static class Startup
    {
        public static Uri BackendUri { get; set; } = new Uri("https://192.168.0.103:5001");  
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureServices()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<ContractsVm>();

            services.AddHttpClient("ServerAPI", client => 
            {
                client.BaseAddress = new Uri("https://192.168.0.103:5001");
            });

            return services;
        }
    }
}
