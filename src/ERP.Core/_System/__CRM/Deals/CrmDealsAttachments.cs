using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CRM.Deals
{
    public class CrmDealsAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        [Required]
        [MaxLength(2000)]
        public string FilePath { get; protected set; }

        public long CrmDealsId { get; protected set; }

        [ForeignKey(nameof(CrmDealsId))]
        public CrmDeals CrmDeals { get; protected set; }

        public int TenantId { get; set; }
    }
}
