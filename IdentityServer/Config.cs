// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("planthorwebapi", "Planthor Web Api")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "frontendclientTestByPass",
                    ClientName = "Any web client with Fast Test Authentication, but no IdentityResources",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("planthorHardCodeSecret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "planthorwebapi" }
                },
                new Client
                {
                    ClientId = "reactjs",
                    ClientName = "React Javascript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { "https://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "https://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "https://localhost:5003" },

                    AllowOfflineAccess = true,
                    
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "planthorwebapi"
                    }
                }
            };
    }
}