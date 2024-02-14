using System;
using System.Linq;
using System.Web;
using Abp.Dependency;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Text;
using Abp.Web.MultiTenancy;
using Microsoft.AspNetCore.Http;

namespace ERP.Web.Host.MultiTenancy
{
    //public class MyDomainTenantResolveContributor : ITenantResolveContributor, ITransientDependency
    //{
    //    private readonly IWebMultiTenancyConfiguration _multiTenancyConfiguration;
    //    private readonly ITenantStore _tenantStore;

    //    public MyDomainTenantResolveContributor(
    //        IWebMultiTenancyConfiguration multiTenancyConfiguration,
    //        ITenantStore tenantStore)
    //    {
    //        _multiTenancyConfiguration = multiTenancyConfiguration;
    //        _tenantStore = tenantStore;
    //    }

    //    public int? ResolveTenantId()
    //    {
    //        if (_multiTenancyConfiguration.DomainFormat.IsNullOrEmpty())
    //        {
    //            return null;
    //        }

    //        var httpContext = HttpContext.Current;
    //        if (httpContext == null)
    //        {
    //            return null;
    //        }

    //        var hostName = httpContext.Request.Url.Host.RemovePreFix("http://", "https://").RemovePostFix("/");
    //        var domainFormat = _multiTenancyConfiguration.DomainFormat.RemovePreFix("http://", "https://").Split(':')[0].RemovePostFix("/");
    //        var result = new FormattedStringValueExtracter().Extract(hostName, domainFormat, true, '/');

    //        if (!result.IsMatch || !result.Matches.Any())
    //        {
    //            return null;
    //        }

    //        var tenancyName = result.Matches[0].Value;
    //        if (tenancyName.IsNullOrEmpty())
    //        {
    //            return null;
    //        }

    //        if (string.Equals(tenancyName, "www", StringComparison.OrdinalIgnoreCase))
    //        {
    //            return null;
    //        }

    //        var tenantInfo = _tenantStore.Find(tenancyName);
    //        if (tenantInfo == null)
    //        {
    //            return null;
    //        }

    //        return tenantInfo.Id;
    //    }
    //}
}
