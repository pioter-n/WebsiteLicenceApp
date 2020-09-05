
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteLicenceApp
{
    public class CustomClientStore : IClientStore
    {
        private static IEnumerable<Client> AllClients { get; } = new[]
        {
            new Client
            {
                ClientId = "Authentication.Agent",
                AccessTokenLifetime = 60 * 60 * 24,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireClientSecret = false,
                AllowedScopes =
                {
                    "api",
                    "Authentication.WebAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(AllClients.FirstOrDefault(c => c.ClientId == clientId));
        }
    }
}
