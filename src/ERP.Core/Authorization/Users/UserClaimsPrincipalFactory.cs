using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using ERP.Authorization.Roles;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using ERP.MultiTenancy;

namespace ERP.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        private readonly TenantManager _tenantManger;

        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            TenantManager tenantManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor)
        {
            _tenantManger = tenantManager;
        }
        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var claim = await base.CreateAsync(user);
            if (user.TenantId != null)
            {
              
                Tenant tenantDetail = await _tenantManger.GetDetails(user.TenantId.Value);
             
                claim.Identities.First().AddClaim(new Claim("TenantDetails.TenantNameAr", tenantDetail?.TenantNameAr ?? ""));
                claim.Identities.First().AddClaim(new Claim("TenantDetails.TenantNameEn", tenantDetail?.TenantNameEn ?? ""));
                claim.Identities.First().AddClaim(new Claim("TenantDetails.BoxNo", tenantDetail?.BoxNo ?? ""));
                claim.Identities.First().AddClaim(new Claim("TenantDetails.Email", tenantDetail?.Email ?? ""));
                claim.Identities.First().AddClaim(new Claim("TenantDetails.Fax", tenantDetail?.Fax ?? ""));
                claim.Identities.First().AddClaim(new Claim("TenantDetails.LogoPath", tenantDetail?.LogoPath ?? ""));
                claim.Identities.First().AddClaim(new Claim("TenantDetails.Tel", tenantDetail?.Tel ?? ""));
                claim.Identities.First().AddClaim(new Claim("TenantDetails.WebSite", tenantDetail?.WebSite ?? ""));
            }

            return claim;
        }
    }
}
