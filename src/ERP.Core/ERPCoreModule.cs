using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Configuration;
using ERP.Localization;
using ERP.MultiTenancy;
using ERP.Notifications;
using ERP.Timing;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;

namespace ERP
{
    [DependsOn(
        typeof(AbpZeroCoreModule)
        , typeof(AbpAspNetCoreSignalRModule)
        )]
    public class ERPCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            ERPLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ERPConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            Configuration.Notifications.Providers.Add<MyAppNotificationProvider>();

            Configuration.Notifications.Notifiers.Add<MySignalRRealTimeNotifier>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ERPCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<NotifyFor30DaysRemainOnContractWorker>());
        }
    }
}
