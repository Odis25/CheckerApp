using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Services;
using CheckerApp.Mobile.ViewModels;
using CheckerApp.Mobile.Views.Pages;
using System;
using Xamarin.Forms;

namespace CheckerApp.Mobile
{
    public static class Startup
    {
        public static Uri BackendUri { get; set; } = new Uri("https://192.168.0.103:5001");  
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            DependencyService.Register<IContractService, MockContractService>();
            DependencyService.Register<ContractsVm>();

            RegisterRoutes();
        }

        public static void RegisterRoutes()
        {
            Routing.RegisterRoute("contract", typeof(ContractDetail));
        }
    }
}
