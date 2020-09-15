using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckerApp.Infrastructure
{
    public static class Config
    {
        public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "blazor_client_app",
                ClientSecrets = {new Secret("client_super_secret".ToSha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "CheckerAppApi"
                }
            }
        };

        public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource("CheckerAppApi")
        };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId()
        };
    }
}
