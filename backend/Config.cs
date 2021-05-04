// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace backend
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1"),
            };

        public static IEnumerable<ApiResource> Apis =>
           new ApiResource[]
           {
                new ApiResource("api1")
           };

        public static IEnumerable<Client> Clients(string clientUrl, string backendUrl) =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "client",
                    ClientName = "name",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("Secret".Sha256()) },
                    RedirectUris = { $"{clientUrl}/signin-oidc" },

                    PostLogoutRedirectUris = { $"{clientUrl}/signout-callback-oidc" },
                    RequireConsent = false,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                },
                 new Client
                {
                    // unique ID for this client
                    ClientId = "spa", 
                    // human-friendly name displayed in IS
                    ClientName = "React app", 
                    // URL of client
                    ClientUri = backendUrl, 
                    // how client will interact with our identity server (Implicit is basic flow for web apps)
                    AllowedGrantTypes = GrantTypes.Implicit, 
                    // don't require client to send secret to token endpoint
                    RequireClientSecret = false,
                    RedirectUris =
                    {             
                        // can redirect here after login                     
                        $"{backendUrl}/signin-oidc",
                    },
                    // can redirect here after logout
                    PostLogoutRedirectUris = { $"{backendUrl}/signout-oidc" }, 
                    // builds CORS policy for javascript clients
                    AllowedCorsOrigins = { backendUrl }, 
                    // what resources this client can access
                    AllowedScopes = { "openid", "profile", "api1" }, 
                    // client is allowed to receive tokens via browser
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                }
            };
    }
}