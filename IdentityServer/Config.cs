using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityServerHost;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources
        {
            get
            {
                return new List<ApiResource>()
                        {
                            new ("resource_api1")
                            {
                                Scopes = {"api1.read", "api1.write", "api1.update"},
                                ApiSecrets={ new Secret("şifre".Sha256()) } },
                            new ("resource_api2")
                            {
                                Scopes = {"api2.read", "api2.write", "api2.update"},
                                     ApiSecrets={ new Secret("şifre".Sha256()) }
                            },
                        };
            }
        }

        public static IEnumerable<ApiScope> GetApiScopes
        {
            get
            {
                return new List<ApiScope>()
                        {
                            new ("api1.read","API1 için okuma"),
                            new ("api1.write","API1 için yazma"),
                            new ("api1.update","API1 için güncelleme"),
                            new ("api2.read","API2 için okuma"),
                            new ("api2.write","API2 için yazma"),
                            new ("api2.update","API2 için güncelleme"),
                        };
            }
        }


        public static IEnumerable<Client> GetClients
        {
            get
            {
                return new List<Client>()
                        {
                            new (){
                                ClientId="Client1",
                                ClientSecrets=new[]{new Secret("şifre".Sha256())},ClientName="Client1",
                                AllowedGrantTypes = GrantTypes.ClientCredentials,
                                AllowedScopes={ "api1.read", "api1.write", "api1.update", "api2.read", }
                            },
                            new (){
                                ClientId="Client2",
                                ClientSecrets=new[]{new Secret("şifre".Sha256())},ClientName="Client2",
                                AllowedGrantTypes = GrantTypes.ClientCredentials,
                                AllowedScopes={ "api2.read", "api2.write", "api2.update",  }
                            },
                            new (){
                                ClientId="Client1MVC",
                                ClientSecrets=new[]{new Secret("şifre".Sha256())},
                                ClientName="Client1MVC",
                                AllowedGrantTypes = GrantTypes.Hybrid,
                                RedirectUris = new List<string>()
                                {
                                    "https://localhost:7234/signin-oidc"
                                },
                                AllowedScopes={ IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                                RequirePkce=false,
                            },


                        };
            }
        }


        public static IEnumerable<IdentityResource> GetIdentityResources
        {
            get
            {
                return new List<IdentityResource>()
                {
                    new IdentityResources.OpenId(), // subid claime denk gelir
                    new IdentityResources.Profile(),
                    //new IdentityResources.Address(),
                    //new IdentityResources.Email(),
                };
            }
        }


        public static IEnumerable<TestUser> Users
        {
            get
            {
                var data = new List<TestUser>()
                {
                    new()
                    {
                        SubjectId=Guid.NewGuid().ToString(),
                        Username="hasan",
                        Password="q",
                        Claims =new List<Claim>()
                        {
                                new Claim("given_name","Hasan"),
                                new Claim("family_name","Avcı"),
                        }

                    },
                      new()
                    {
                        SubjectId=Guid.NewGuid().ToString(),
                        Username="hasan1",
                        Password="q",
                        Claims =new List<Claim>()
                        {
                                new Claim("given_name","Hasan"),
                                new Claim("family_name","Avcı"),
                        }
                    },
                        new()
                    {
                        SubjectId=Guid.NewGuid().ToString(),
                        Username="hasan2",
                        Password="q",
                        Claims =new List<Claim>()
                        {
                                new Claim("given_name","Hasan"),
                                new Claim("family_name","Avcı"),
                        }
                    },
                };

                data.AddRange(TestUsers.Users);
                return data;
            }
        }
    }
}
