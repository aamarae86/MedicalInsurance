using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersons
{
    public class HrPersonAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        [Required]
        [MaxLength(2000)]
        public string FilePath { get; protected set; }

        public long HrPersonId { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        public int TenantId { get; set; }
    }
}
