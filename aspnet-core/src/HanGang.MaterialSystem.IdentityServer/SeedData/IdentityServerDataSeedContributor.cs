using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using ApiResource = Volo.Abp.IdentityServer.ApiResources.ApiResource;
using Client = Volo.Abp.IdentityServer.Clients.Client;

namespace HanGang.MaterialSystem.SeedData
{
    public class IdentityServerDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly IConfiguration _configuration;

        public IdentityServerDataSeedContributor(
            IClientRepository clientRepository,
            IApiResourceRepository apiResourceRepository,
            IIdentityResourceDataSeeder identityResourceDataSeeder,
            IGuidGenerator guidGenerator,
            IPermissionDataSeeder permissionDataSeeder,
            IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _apiResourceRepository = apiResourceRepository;
            _identityResourceDataSeeder = identityResourceDataSeeder;
            _guidGenerator = guidGenerator;
            _permissionDataSeeder = permissionDataSeeder;
            _configuration = configuration;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await _identityResourceDataSeeder.CreateStandardResourcesAsync();
            await CreateApiResourcesAsync();
            await CreateClientsAsync();
        }

        private async Task CreateApiResourcesAsync()
        {
            var commonApiUserClaims = new[]
            {
                "email",
                "email_verified",
                "name",
                "phone_number",
                "phone_number_verified",
                "role"
            };
            await CreateApiResourceAsync("hangang", commonApiUserClaims);
        }

        private async Task<ApiResource> CreateApiResourceAsync(string name, IEnumerable<string> claims)
        {
            var apiResource = await _apiResourceRepository.FindByNameAsync(name)
                              ?? await _apiResourceRepository.InsertAsync(
                                  new ApiResource(
                                      _guidGenerator.Create(),
                                      name,
                                      name + " API"), true);

            foreach (var claim in claims)
            {
                if (apiResource.FindClaim(claim) == null)
                {
                    apiResource.AddUserClaim(claim);
                }
            }

            return await _apiResourceRepository.UpdateAsync(apiResource);
        }

        private async Task CreateClientsAsync()
        {
            var commonScopes = new[]
            {
                "email",
                "openid",
                "profile",
                "role",
                "phone",
                "address",
                "hangang"
            };
            var configurationSection = _configuration.GetSection("IdentityServer:Clients");
            var customerClientId = configurationSection["HanGang_Web:ClientId"];
            if (!customerClientId.IsNullOrWhiteSpace())
            {
                await CreateClientAsync(
                    customerClientId,
                    commonScopes.Union(new[] { "openid", "hangang" }),
                    new[] { "password" },
                    (configurationSection["HanGang_Web:ClientSecret"] ?? "1q2w3E*").Sha256());
            }
            customerClientId = configurationSection["HanGang_App:ClientId"];
            if (!customerClientId.IsNullOrWhiteSpace())
            {
                await CreateClientAsync(
                    customerClientId,
                    commonScopes.Union(new[] { "openid", "hangang" }),
                    new[] { "password" },
                    (configurationSection["HanGang_App:ClientSecret"] ?? "1q2w3E*").Sha256());
            }
        }

        private async Task CreateClientAsync(
            string name,
            IEnumerable<string> scopes,
            IEnumerable<string> grantTypes,
            string secret,
            string redirectUri = null,
            string postLogoutRedirectUri = null,
            IEnumerable<string> permissions = null)
        {
            var client = await _clientRepository.FindByCliendIdAsync(name)
                         ?? await _clientRepository.InsertAsync(
                             new Client(
                                 _guidGenerator.Create(),
                                 name)
                             {
                                 ClientName = name,
                                 ProtocolType = "oidc",
                                 Description = name,
                                 AlwaysIncludeUserClaimsInIdToken = true,
                                 AllowOfflineAccess = true,
                                 AbsoluteRefreshTokenLifetime = 31536000, //365 days
                                 AccessTokenLifetime = 31536000, //365 days
                                 AuthorizationCodeLifetime = 300,
                                 IdentityTokenLifetime = 300,
                                 RequireConsent = false
                             },
                             autoSave: true);

            foreach (var scope in scopes)
            {
                if (client.FindScope(scope) is null)
                {
                    client.AddScope(scope);
                }
            }

            foreach (var grantType in grantTypes)
            {
                if (client.FindGrantType(grantType) is null)
                {
                    client.AddGrantType(grantType);
                }
            }

            if (client.FindSecret(secret) is null)
            {
                client.AddSecret(secret);
            }

            if (redirectUri != null)
            {
                if (client.FindRedirectUri(redirectUri) is null)
                {
                    client.AddRedirectUri(redirectUri);
                }
            }

            if (postLogoutRedirectUri != null)
            {
                if (client.FindPostLogoutRedirectUri(postLogoutRedirectUri) is null)
                {
                    client.AddPostLogoutRedirectUri(postLogoutRedirectUri);
                }
            }

            if (permissions != null)
            {
                await _permissionDataSeeder.SeedAsync(
                    ClientPermissionValueProvider.ProviderName,
                    name,
                    permissions);
            }

            await _clientRepository.UpdateAsync(client);
        }
    }
}
