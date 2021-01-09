using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CheckerApp.Infrastructure
{
    public static class Config
    {
        public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "CheckerApp.Client",

                RequireClientSecret = false, // for auth code flow there is no secret required as it couldn't be securely stored in the front-end anyway
                
                RequireConsent = false,

                AllowedGrantTypes = GrantTypes.Implicit,

                RedirectUris = { "https://localhost:5001/authentication/login-callback" },

                PostLogoutRedirectUris = { "https://localhost:5001/" },

                // CORS
                AllowedCorsOrigins = { "https://localhost:5001" },

                ClientSecrets = {new Secret("longsupersecretkeyword".ToSha256()) },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "CheckerApp.ServerAPI"
                },

                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,
                RefreshTokenUsage = TokenUsage.ReUse
            }
        };

        public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource("CheckerApp.ServerAPI")
        };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }
}
