using Abp.AutoMapper;
using ERP._System.__AidModule._Portal._PortalUserAttachments;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__AidModule._Portal.UserAttachments
{
    [AutoMap(typeof(PortalUserAttachments))]
    public class PortalUserAttachmentsDto : AttachAuditedEntity, IDetailRowStatus
    {
        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; set; }

        public long PortalUserDataId { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
