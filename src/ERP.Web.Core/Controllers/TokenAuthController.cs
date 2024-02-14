using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using Abp.UI;
using ERP.Authentication.External;
using ERP.Authentication.JwtBearer;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Models.TokenAuth;
using ERP.MultiTenancy;
using ERP.MultiTenancy.Dto;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ERP.Core.Helpers.Extensions;
using Microsoft.AspNetCore.Http;
using Abp.Runtime.Session;

namespace ERP.Controllers
{

    public class UserSubscribtionValidationModel
    {
        public bool IsUserValid { get; set; }
        public bool IsTenantValid { get; set; }
        public bool IsTenantAdminValid { get; set; }
        public string Message { get; set; }
    }
    [Route("api/[controller]/[action]")]
    public class TokenAuthController : ERPControllerBase
    {
        private readonly LogInManager _logInManager;
        private readonly ITenantCache _tenantCache;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly TokenAuthConfiguration _configuration;
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        private readonly IExternalAuthManager _externalAuthManager;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly TenantManager _tenantManager;
        private readonly UserManager _userManager;
        private readonly IConfiguration _config;

        //private readonly UserManager _userManager;

        public TokenAuthController(
            LogInManager logInManager,
            ITenantCache tenantCache,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            TokenAuthConfiguration configuration,
            IExternalAuthConfiguration externalAuthConfiguration,
            IExternalAuthManager externalAuthManager,
            UserRegistrationManager userRegistrationManager,
            TenantManager tenantManager,
             UserManager userManager,
            IConfiguration config
            )
        {
            _config = config;
            _logInManager = logInManager;
            _tenantCache = tenantCache;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _configuration = configuration;
            _externalAuthConfiguration = externalAuthConfiguration;
            _externalAuthManager = externalAuthManager;
            _userRegistrationManager = userRegistrationManager;
            _tenantManager = tenantManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<AuthenticateResultModel> Authenticate([FromBody] AuthenticateModel model)
        {
            model.TenantId = GetTenantFromAppSetting();
            
            
            
            string tenantName = model.HostManager || model.TenantId == 0 ? GetTenancyNameOrNull() : GetTenantById(model.TenantId);


            if (model.TenantId > 0)
            {
                var User = await _userManager
                  .FindByNameOrEmailAsync(model.TenantId, model.UserNameOrEmailAddress);
                await _userManager.ResetAllPermissionsAsync(User);
            }

            var loginResult = await GetLoginResultAsync(
                model.UserNameOrEmailAddress,
                model.Password,
                tenantName
            );

            if (model.HostManager)
            {
                loginResult.Identity.AddClaim(new Claim(AbpClaimTypes.TenantId, $"{model.TenantId}"));
            }

            TenantDetailDto tenantDetailDto = new TenantDetailDto();

            if (loginResult != null && loginResult.Tenant != null)
            {
                var tenant = await _tenantManager.GetDetails(loginResult.Tenant.Id);
                loginResult.Identity.AddClaim(new Claim("IsTenentAdmin", loginResult.User.Name == "admin" ? "YES" : "NO"));
                //var res = await CheckIfUserSubscribtionValid(tenant, loginResult.User);
                var res = await CheckTenantAndUesrSubscribtionValid(tenant, loginResult.User);

                if (res.Item1)
                {
                    loginResult.Identity.AddClaim(new Claim("TenentSubscriptionValid", "YES"));
                    loginResult.Identity.AddClaim(new Claim("UserSubscriptionValid", "YES"));
                }
                else
                {
                    if (res.Item3 == "AdminInvalid")
                    {
                        loginResult.Identity.AddClaim(new Claim("TenentSubscriptionValid", "NO"));
                        loginResult.Identity.AddClaim(new Claim("UserSubscriptionValid", "NO"));

                    }
                    else if (res.Item3 == "UserInvalid")
                    {
                        loginResult.Identity.AddClaim(new Claim("UserSubscriptionValid", "NO"));
                        loginResult.Identity.AddClaim(new Claim("TenentSubscriptionValid", "YES"));

                    }
                    Logger.Info($"{loginResult.User.Name} - {res.Item2}");
                }

                ObjectMapper.Map(tenant, tenantDetailDto);
                tenantDetailDto.LogoPath = tenant.Filepath;
            }
            var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));

            var t = AbpSession.MultiTenancySide == MultiTenancySides.Host ? true : false;
            return new AuthenticateResultModel
            {
                AccessToken = accessToken,
                EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                UserId = loginResult.User.Id,
                UserName = loginResult.User.Name,
                TenantDetail = tenantDetailDto,
                IsHost = loginResult.Tenant != null ? false : true ,
                //IsHost = AbpSession.MultiTenancySide == MultiTenancySides.Host ? true : false,
                IsTenentAdmin = loginResult.User.Name == "admin" ? true : false
            };
        }

        [HttpGet]
        public List<ExternalLoginProviderInfoModel> GetExternalAuthenticationProviders()
        {
            return ObjectMapper.Map<List<ExternalLoginProviderInfoModel>>(_externalAuthConfiguration.Providers);
        }

        [HttpPost]
        public async Task<ExternalAuthenticateResultModel> ExternalAuthenticate([FromBody] ExternalAuthenticateModel model)
        {
            var externalUser = await GetExternalUserInfo(model);

            var loginResult = await _logInManager.LoginAsync(new UserLoginInfo(model.AuthProvider, model.ProviderKey, model.AuthProvider), GetTenancyNameOrNull());

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    {
                        var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));
                        return new ExternalAuthenticateResultModel
                        {
                            AccessToken = accessToken,
                            EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                        };
                    }
                case AbpLoginResultType.UnknownExternalLogin:
                    {
                        var newUser = await RegisterExternalUserAsync(externalUser);
                        if (!newUser.IsActive)
                        {
                            return new ExternalAuthenticateResultModel
                            {
                                WaitingForActivation = true
                            };
                        }

                        // Try to login again with newly registered user!
                        loginResult = await _logInManager.LoginAsync(new UserLoginInfo(model.AuthProvider, model.ProviderKey, model.AuthProvider), GetTenancyNameOrNull());
                        if (loginResult.Result != AbpLoginResultType.Success)
                        {
                            throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                                loginResult.Result,
                                model.ProviderKey,
                                GetTenancyNameOrNull()
                            );
                        }

                        return new ExternalAuthenticateResultModel
                        {
                            AccessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity)),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                        };
                    }
                default:
                    {
                        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                            loginResult.Result,
                            model.ProviderKey,
                            GetTenancyNameOrNull()
                        );
                    }
            }
        }


        private int GetTenantFromAppSetting()
        {
            string tenantId = _config.GetValue<string>("TenantId");

            return string.IsNullOrEmpty(tenantId) ? 0 : (Convert.ToInt32(tenantId) == -1 ? 0 : Convert.ToInt32(tenantId));
        }

        private async Task<User> RegisterExternalUserAsync(ExternalAuthUserInfo externalUser)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                externalUser.Name,
                externalUser.Surname,
                externalUser.EmailAddress,
                externalUser.EmailAddress,
                Authorization.Users.User.CreateRandomPassword(),
                true
            );

            user.Logins = new List<UserLogin>
            {
                new UserLogin
                {
                    LoginProvider = externalUser.Provider,
                    ProviderKey = externalUser.ProviderKey,
                    TenantId = user.TenantId
                }
            };

            await CurrentUnitOfWork.SaveChangesAsync();

            return user;
        }

        private async Task<ExternalAuthUserInfo> GetExternalUserInfo(ExternalAuthenticateModel model)
        {
            var userInfo = await _externalAuthManager.GetUserInfo(model.AuthProvider, model.ProviderAccessCode);
            if (userInfo.ProviderKey != model.ProviderKey)
            {
                throw new UserFriendlyException(L("CouldNotValidateExternalUser"));
            }

            return userInfo;
        }

        private string GetTenancyNameOrNull()
        {
            if (AbpSession.TenantId.HasValue)
            {
                return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
            }
            return null;
        }

        private string GetTenantById(int Id)
        {
            return _tenantCache.GetOrNull(Id)?.TenancyName;
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private async Task<(bool, string, string)> CheckTenantAndUesrSubscribtionValid(Tenant tenant, User user)
        {
            var tenentAdmin = await _userManager.FindByNameOrEmailAsync(tenant.Id, "admin");

            if ( tenentAdmin?.SubEndDate == null)
                return (false, "Not Valid Tenent Admin", "AdminInvalid");


            if ( tenentAdmin.SubEndDate.Value.ClculateRemainingDays() > 0)
            {
                if (user.SubEndDate != null && user.SubEndDate.Value.ClculateRemainingDays() > 0)
                {
                    return (true, "User Subscription valid", "");
                }
                return (false, "Please Renew Subscription", "UserInvalid");
            }
            return (false, "Please Renew Subscription For Tenent Admin ", "AdminInvalid");
        }

        private async Task<(bool, string, string)> CheckIfUserSubscribtionValid(Tenant tenant, User user)
        {
            //var tenent=await _tenantManager.GetDetails(AbpSession.GetTenantId());
            var tenentAdmin = await _userManager.FindByNameOrEmailAsync(tenant.Id, "admin");


            if (tenentAdmin?.SubEndDate == null)
                return (false, "Not Valid Tenent Admin", "AdminInvalid"); 
 

            if (tenentAdmin.SubEndDate.Value.ClculateRemainingDays() > 0)
            {
                if (user.SubEndDate != null && user.SubEndDate.Value.ClculateRemainingDays() > 0)
                {
                    return (true, "User Subscription valid", "");
                }
                return (false, "Please Renew Subscription", "UserInvalid");
            }
            return (false, "Please Renew Subscription For Tenent Admin ", "AdminInvalid");
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _configuration.Expiration),
                signingCredentials: _configuration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }

        private string GetEncryptedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken, AppConsts.DefaultPassPhrase);
        }
    }
}
