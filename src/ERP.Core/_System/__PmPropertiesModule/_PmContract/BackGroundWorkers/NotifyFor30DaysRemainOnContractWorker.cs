using Abp;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Notifications;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.MultiTenancy;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers
{
    public class NotifyFor30DaysRemainOnContractWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IRepository<PmContract, long> _pmContractsRepository;
        private readonly INotificationPublisher _notificationPublisher;
        private readonly UserManager _userManager;
        private readonly TenantManager _tenantManager;
        private readonly IConfiguration _config;
        private string baseURL;

        public NotifyFor30DaysRemainOnContractWorker(
            AbpTimer timer
            , IRepository<PmContract, long> pmContractsRepository
            , INotificationPublisher notificationPublisher
            , UserManager userManager
            , TenantManager tenantManager
            , IConfiguration config
            )
            : base(timer)
        {
            _pmContractsRepository = pmContractsRepository;
            _notificationPublisher = notificationPublisher;
            _userManager = userManager;
            _tenantManager = tenantManager;
            _config = config;
            baseURL = _config.GetValue<string>("FrontURL");
            Timer.Period = 1000 * 60 * 60 * 24; // 1 day to start
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            var systemTenantIds = _tenantManager.Tenants.Select(t => t.Id).ToList();
            foreach (var tenantId in systemTenantIds)
            {
                using (CurrentUnitOfWork.SetTenantId(tenantId))
                {
                    var oneMonthAgo = Clock.Now.Subtract(TimeSpan.FromDays(30)).Date;

                    var contractsRemains30Days = _pmContractsRepository.GetAllList(u =>
                        u.StatusLkpId == 230 &&
                        u.ContractEndDate.Date == oneMonthAgo
                        );

                    var userIds = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_PmContract)
                        .Select(p => new UserIdentifier(tenantId, p.Id)).ToArray();

                    SendNotifications(contractsRemains30Days, userIds, _notificationPublisher, baseURL);
                }
            }
        }

        public static void SendNotifications(List<PmContract> ContractsList, UserIdentifier[] userIds, INotificationPublisher notificationPublisher, string baseURL)
        {
            foreach (var contract in ContractsList)
            {
                var encId = CipherStringController.Encrypt(contract.Id.ToString());
                var link = GenerateFormViewLinkForEmailBody("PmContrat", encId, baseURL);
                var msg = $"العقد رقم <u>{contract?.ContractNumber}</u> باسم <u>{contract?.PmTenants?.TenantNameAr}</u> سوف ينتهي في {contract?.ContractEndDate.Date.ToShortDateString()}, برجاء اتخاذ اللازم";
                var notif = new MessageNotificationData(msg);
                notif.Properties.Add("link", link);

                notificationPublisher.Publish("Contract to end in 30 days", notif, new EntityIdentifier(typeof(PmContract), contract.Id), userIds: userIds);
            }
        }

        public static string GetBaseURL(IConfiguration _config, string baseURL, string subDomain)
        {
            var URL = _config == null ?
                string.IsNullOrEmpty(baseURL) ? "https://tenxerp.com" : baseURL
                : _config.GetValue<string>("FrontURL");
            return URL.Replace("{0}", subDomain);
        }

        public static string GenerateFormViewLinkForEmailBody(string module, string encId, string baseURL = null, string subDomain = null, IConfiguration _config = null)
        {
            string baseLink = GetBaseURL(_config, baseURL,subDomain);
            return $"{baseLink}/{module}/FormView?id={encId}&t=28HR9KALoSpLQg3Lbhs-5A,,";
        }
    }
}
