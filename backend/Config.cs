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

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "client",
                    ClientName = "name",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("Secret".Sha256()) },
                    RedirectUris = { "http://localhost:4000/signin-oidc" },

                    PostLogoutRedirectUris = { "http://localhost:4000/signout-callback-oidc" },
                    RequireConsent = false,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }

                },
        };
  }
}