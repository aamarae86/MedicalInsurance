using Abp.Domain.Entities;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport
{
    public class ScMaintenanceTechnicalReportAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public string AttachmentName { get; set; }

        public long ScMaintenanceTechnicalReportId { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceTechnicalReportId))]
        public ScMaintenanceTechnicalReport ScMaintenanceTechnicalReports { get; protected set; }
    }
}
