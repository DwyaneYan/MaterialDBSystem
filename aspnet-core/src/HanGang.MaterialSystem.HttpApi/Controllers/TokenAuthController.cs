using System;
using System.Threading.Tasks;
using HanGang.MaterialSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.IdentityModel;

namespace HanGang.MaterialSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TokenAuthController : AbpController
    {
        private readonly IdentityModelAuthenticationService _authenticationService;

        public TokenAuthController(IdentityModelAuthenticationService authenticationService,
            IOptions<AbpIdentityClientOptions> options)
        {
            _authenticationService = authenticationService;
            ClientOptions = options.Value;
        }

        protected AbpIdentityClientOptions ClientOptions { get; }

        [HttpPost]
        public async Task<string> Authenticate([FromBody] AuthenticateModel login)
        {
            ValidateLoginInfo(login);
            var configuration = new IdentityClientConfiguration(
                ClientOptions.IdentityClients.Default.Authority,
                ClientOptions.IdentityClients.Default.Scope,
                ClientOptions.IdentityClients.Default.ClientId,
                ClientOptions.IdentityClients.Default.ClientSecret,
                ClientOptions.IdentityClients.Default.GrantType,
                login.UserName,
                login.Password,
                false);
            try
            {
                return await _authenticationService.GetAccessTokenAsync(configuration);
            }
            catch (AbpException e)
            {
                if (e.Message.Contains("invalid_username_or_password"))
                {
                    throw new UserFriendlyException("账号或密码错误");
                }

                throw;
            }
        }

        private void ValidateLoginInfo(AuthenticateModel login)
        {
            if (login == null)
            {
                throw new ArgumentException(nameof(login));
            }

            if (login.UserName.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(login.UserName));
            }

            if (login.Password.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(login.Password));
            }
        }
    }
}