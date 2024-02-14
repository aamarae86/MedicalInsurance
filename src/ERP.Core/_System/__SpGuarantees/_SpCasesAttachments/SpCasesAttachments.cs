using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpCases;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpCasesAttachments
{
    public class SpCasesAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        public long? SpCaseId { get; protected set; }
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(SpCaseId))]
        public SpCases SpCase { get; protected set; }
    }
}
