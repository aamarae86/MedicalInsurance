using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.MultiTenancy;
using Abp.Runtime;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using ERP.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.CustomSession
{
    public class ERPSession : ClaimsAbpSession, ITransientDependency
    {
        public ERPSession(
            IPrincipalAccessor principalAccessor, IMultiTenancyConfig multiTenancy, 
            ITenantResolver tenantResolver, IAmbientScopeProvider<SessionOverride> sessionOverrideScopeProvider)
            : base(principalAccessor, multiTenancy, tenantResolver, sessionOverrideScopeProvider)
        {
        }

        public override int? TenantId
        {
            get
            {
                if (!MultiTenancy.IsEnabled)
                {
                    return MultiTenancyConsts.DefaultTenantId;
                }

                if (OverridedValue != null)
                {
                    return OverridedValue.TenantId;
                }

                var tenantIdClaim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.TenantId);
                if (!string.IsNullOrEmpty(tenantIdClaim?.Value))
                {
                    return Convert.ToInt32(tenantIdClaim.Value);
                }

                if (UserId == null)
                {
                    //Resolve tenant id from request only if user has not logged in!
                    return TenantResolver.ResolveTenantId();
                }

                return null;
            }
        }

        public string TenantNameAr
        {
            get
            {
                var tenantNameAr = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.TenantNameAr");
                if (string.IsNullOrEmpty(tenantNameAr?.Value))
                {
                    return null;
                }

                return tenantNameAr.Value;
            }
        }
        
        public string TenantNameEn
        {
            get
            {
                var tenantNameEn = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.TenantNameEn");
                if (string.IsNullOrEmpty(tenantNameEn?.Value))
                {
                    return null;
                }

                return tenantNameEn.Value;
            }
        }

        public string BoxNo
        {
            get
            {
                var boxNo = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.BoxNo");
                if (string.IsNullOrEmpty(boxNo?.Value))
                {
                    return null;
                }

                return boxNo.Value;
            }
        }
        
        public string Email
        {
            get
            {
                var email = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.Email");
                if (string.IsNullOrEmpty(email?.Value))
                {
                    return null;
                }

                return email.Value;
            }
        }
        public string Fax
        {
            get
            {
                var fax = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.Fax");
                if (string.IsNullOrEmpty(fax?.Value))
                {
                    return null;
                }

                return fax.Value;
            }
        }
        
        public string LogoPath
        {
            get
            {
                var logoPath = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.LogoPath");
                if (string.IsNullOrEmpty(logoPath?.Value))
                {
                    return null;
                }

                return logoPath.Value;
            }
        }

        public string Tel
        {
            get
            {
                var tel = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.Tel");
                if (string.IsNullOrEmpty(tel?.Value))
                {
                    return null;
                }

                return tel.Value;
            }
        }
        
        public string WebSite
        {
            get
            {
                var website = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "TenantDetails.WebSite");
                if (string.IsNullOrEmpty(website?.Value))
                {
                    return null;
                }

                return website.Value;
            }
        }
    }
}
