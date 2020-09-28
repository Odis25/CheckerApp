using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestBlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("CheckerApp.WebApi", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CheckerApp.WebApi"));
            
            builder.Services.AddApiAuthorization();

            //builder.Services.AddOidcAuthentication(
            //    options =>
            //    {
            //        options.ProviderOptions.Authority = "https://localhost:5001";
            //        options.ProviderOptions.ClientId = "spa";

            //        options.ProviderOptions.DefaultScopes.Add("api");

            //        options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:5001/";
            //        options.ProviderOptions.RedirectUri = "https://localhost:5001/authentication/login-callback";

            //        options.ProviderOptions.ResponseType = "id_token token";
            //    });

            await builder.Build().RunAsync();
        }
    }
}
