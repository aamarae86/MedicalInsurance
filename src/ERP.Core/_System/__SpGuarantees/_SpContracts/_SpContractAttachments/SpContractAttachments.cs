using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpContracts._SpContractAttachments
{
    public class SpContractAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        public long SpContractId { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        [ForeignKey(nameof(SpContractId))]
        public SpContracts SpContracts { get; protected set; }

        public int TenantId { get; set; }
    }
}
