using Abp.AutoMapper;
using Abp.MailKit;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ERP._System.__PmPropertiesModule._PmTenants.Dto;
using ERP._System._ArCustomers.Dto;
using ERP.Authorization;
using ERP.CustomMailKit;
//using Abp.Web.Common;
using Abp.Configuration.Startup;
using Abp.Web;
using Abp.Web.MultiTenancy;
using Abp.MultiTenancy;
using ERP.MultiTenancy;

namespace ERP
{
    [DependsOn(
        typeof(ERPCoreModule), 
        typeof(AbpAutoMapperModule),
        typeof(AbpWebCommonModule),
        typeof(AbpMailKitModule))]
    public class ERPApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ERPAuthorizationProvider>();
            //Configuration.MultiTenancy.Resolvers.Add(typeof(ITenantResolveContributor));
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = "{0}.tenxerp.com";


            Configuration.MultiTenancy.Resolvers.Add<MyDomainTenantResolveContributor>();
            //Configuration.MultiTenancy.Resolvers.Add<HttpHeaderTenantResolveContributor>();
            //Configuration.MultiTenancy.Resolvers.Add<HttpCookieTenantResolveContributor>();

            //Configuration.MultiTenancy.Resolvers
            //Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            //{
            //    config.CreateMap<PmTenantsDto, ArCustomersDto>()
            //          .ForMember(u => u.Password, options => options.Ignore())
            //          .ForMember(u => u.Email, options => options.MapFrom(input => input.EmailAddress));
            //});

            Configuration.ReplaceService<IMailKitSmtpBuilder, ERPMailKitSmtpBuilder>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ERPApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
