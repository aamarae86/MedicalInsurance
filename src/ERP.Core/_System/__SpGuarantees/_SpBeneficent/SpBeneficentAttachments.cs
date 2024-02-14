using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ScComityMembers;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpBeneficent
{
    public class SpBeneficentAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long SpBeneficentId { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        [ForeignKey(nameof(SpBeneficentId))]
        public SpBeneficent Beneficent { get; protected set; }
    }
}
