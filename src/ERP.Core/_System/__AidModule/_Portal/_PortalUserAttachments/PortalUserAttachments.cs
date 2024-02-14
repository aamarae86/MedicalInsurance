using Abp.Domain.Entities;
using ERP._System.__AidModule._PortalUserData;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._Portal._PortalUserAttachments
{
    public class PortalUserAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        public long PortalUserDataId { get; protected set; }

        [ForeignKey(nameof(PortalUserDataId))]
        public PortalUserData PortalUserData { get; protected set; }

        public int TenantId { get; set; }
    }
}
