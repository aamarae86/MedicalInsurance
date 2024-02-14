using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport
{
    public class ScMaintenanceTechnicalReportDetail : AuditedEntity<long>, IMustHaveTenant
    {
        public long ScMaintenanceTechnicalReportId { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceTechnicalReportId))]
        public ScMaintenanceTechnicalReport ScMaintenanceTechnicalReports { get; protected set; }

        [MaxLength(4000)]
        public string ItemDescription { get; protected set; }

        public virtual ICollection<ScMaintenanceQuotationDetails> ScMaintenanceQuotationDetails { get; protected set; }

        public int TenantId { get; set; }
    }
}
