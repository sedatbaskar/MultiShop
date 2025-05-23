﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes = { "CatalogFullPermission", "CatalogReadPermission" }},
            new ApiResource("ResourceDiscount"){Scopes = { "DiscountFullPermission" }},
            new ApiResource("ResourceOrder"){Scopes = { "OrderFullPermission" }}
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Read authority for catalog operations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
            new ApiScope("OrderFullPermission", "Full authority for order operations")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor

            new Client
            {

                ClientId = "MultiShopVisitor",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets= {new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission" },
            },

            //Manager

            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets= {new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogFullPermission"}
            }

            //Admin
            ,new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets= {new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 600
            }
        };
    }
}
