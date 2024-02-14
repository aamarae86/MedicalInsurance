using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ERP.Configuration;
using Abp.AspNetCore.MultiTenancy;

namespace ERP.Web.Host.Startup
{
    [DependsOn(
       typeof(ERPWebCoreModule))]
    public class ERPWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ERPWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            //Configuration.MultiTenancy.Resolvers.Add<DomainTenantResolveContributor>();
            //Configuration.MultiTenancy.Resolvers.Add<HttpHeaderTenantResolveContributor>();
            //Configuration.MultiTenancy.Resolvers.Add<HttpCookieTenantResolveContributor>();

            base.PreInitialize();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ERPWebHostModule).GetAssembly());
        }
    }
}
