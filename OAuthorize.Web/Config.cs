using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityModel.OidcConstants;

namespace OAuthorize.Web
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityScopes()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource {
                    Name = "role",
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiScopes()
        {
            return new List<ApiResource>
            {
                new ApiResource {
                    Name = "vendorManagementAPI",
                     DisplayName = "Vendor API",
                         Description = "Vendor API scope",
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientName ="MVC Client",
                    AllowedGrantTypes= IdentityServer4.Models.GrantTypes.Implicit,
                    RedirectUris = {
                      "http://localhost:5002/signin-oidc" },
                      PostLogoutRedirectUris= {"http://localhost:5002"},
                      Enabled=true,
                      AccessTokenType=  AccessTokenType.Jwt,
                      AllowedScopes =new List<string>
                      {
                          StandardScopes.OpenId,
                          StandardScopes.Profile,
                          StandardScopes.Email,
                          StandardScopes.OfflineAccess,
                          "role"
                      },
                  }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "scott",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("name", "scott"),
                        new Claim("given_name","scott edward"),
                        new Claim("family_name", "edward"),
                        new Claim("website", "www.scottdeveloper.com"),
                        new Claim("email", "scott@mailxyz.com"),
                        new Claim("role","admin"),

                    },
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "richard",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim("role","user")
                    }

                }
            };
        }
    }
}
