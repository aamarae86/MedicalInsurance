using Abp.Events.Bus;
using ERP._System.__AidModule._ScPortalRequestStudy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Events.Data
{
    public class PmTenantAndArCustomerAreCreatedEventData : EventData
    {
        public long PmTenantId { get; set; }

        public long ArCustomerId { get; set; }
    }
}
