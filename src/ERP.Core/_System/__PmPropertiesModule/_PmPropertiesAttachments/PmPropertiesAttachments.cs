using Abp.Domain.Entities;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._PmPropertiesAttachments
{
    public class PmPropertiesAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        public long PropertyId { get; protected set; }

        [ForeignKey(nameof(PropertyId))]
        public PmProperties PmProperties { get; protected set; }

        public int TenantId { get; set; }
    }
}
