using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace ERP._System.__AidModule._ScFndPortalIntervalSetting
{
    public class ScFndPortalIntervalSetting : AuditedEntity<long>, IMustHaveTenant
    {
        public DateTime FromDate { get; protected set; }

        public DateTime ToDate { get; protected set; }

        public int NumberOfRequest { get; protected set; }

        public int TenantId { get; set; }

        protected ScFndPortalIntervalSetting() { }
    }
}
