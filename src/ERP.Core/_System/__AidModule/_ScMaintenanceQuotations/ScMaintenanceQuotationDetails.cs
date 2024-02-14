using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceQuotations
{
    public class ScMaintenanceQuotationDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long ScMaintenanceQuotationId { get; protected set; }

        public long ScMaintenanceTechnicalReportDetailId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceQuotationId))]
        public ScMaintenanceQuotations ScMaintenanceQuotations { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceTechnicalReportDetailId))]
        public ScMaintenanceTechnicalReportDetail ScMaintenanceTechnicalReportDetail { get; protected set; }

        public int TenantId { get; set; }
    }
}
