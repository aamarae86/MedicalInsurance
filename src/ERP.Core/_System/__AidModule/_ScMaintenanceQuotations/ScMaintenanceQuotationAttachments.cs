using Abp.Domain.Entities;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceQuotations
{
    public class ScMaintenanceQuotationAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        [Required]
        [MaxLength(4000)]
        public string FilePath { get; protected set; }

        public long ScMaintenanceQuotationId { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceQuotationId))]
        public ScMaintenanceQuotations ScMaintenanceQuotations { get; protected set; }

        public int TenantId { get; set; }
    }
}
