using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using ERP._System._ArCustomers;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Events.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Events.Handlers
{
    public class PmTenantWithArCustomerEventHandler :
        IEventHandler<PmTenantAndArCustomerAreCreatedEventData>
        , ITransientDependency
    {
        private readonly IRepository<ArCustomers, long> _repoArCustomer;

        public PmTenantWithArCustomerEventHandler(
            IRepository<ArCustomers, long> repoArCustomer
            )
        {
            _repoArCustomer = repoArCustomer;
        }
        public async void HandleEvent(PmTenantAndArCustomerAreCreatedEventData eventData)
        {
            var customer = await _repoArCustomer.GetAsync(eventData.ArCustomerId);
            customer.SourceId = eventData.PmTenantId;
            _ = await _repoArCustomer.UpdateAsync(customer);
        }
    }
}
