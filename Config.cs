using Duende.IdentityServer.Models;

namespace Diplomka.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource("role", new[] {"role"})
        };

        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("dpapi", "Diplomka Api", new[] {"role"})
            {
                Scopes = {"dpapi"}
            }
        };

        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("dpapi"),
        };

        //Configuration for blazor WASM from visual studio
        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        new Client
        //        {
        //            ClientId = "BlazorWasm",
        //            ClientName = "Blazor standalone app",
        //            AllowedGrantTypes = GrantTypes.Code,
        //            RequireClientSecret = false,
        //            RequirePkce = true,
        //            RedirectUris = { "https://localhost:44001/authentication/login-callback" },
        //            PostLogoutRedirectUris = { "https://localhost:44001/authentication/logout-callback" },
        //            AllowedScopes = { "openid", "profile", "email", "dpapi", "role"},
        //            AllowedCorsOrigins = { "https://localhost:44001" }
        //        }
        //    };


        //Configuration for blazor WASM from react project
        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "BlazorWasm",
                ClientName = "Blazor standalone app",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris = {"http://localhost:3000/authentication/login-callback"},
                PostLogoutRedirectUris = {"http://localhost:3000/authentication/logout-callback"},
                AllowedScopes = {"openid", "profile", "email", "dpapi", "role"},
                AllowedCorsOrigins = {"http://localhost:3000"}
            }
        };
    }
}
