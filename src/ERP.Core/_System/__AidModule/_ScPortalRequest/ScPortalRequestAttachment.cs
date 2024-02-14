using Abp.Domain.Entities;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequest
{
    public class ScPortalRequestAttachment : AttachAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long PortalRequestId { get; protected set; }

        public long ProtalAttachmentSettingId { get; protected set; }

        [ForeignKey(nameof(PortalRequestId))]
        public virtual ScPortalRequest ScPortalRequest { get; protected set; }

        [ForeignKey(nameof(ProtalAttachmentSettingId))]
        public virtual ScFndProtalAttachmentSetting GetScFndProtalAttachmentSetting { get; protected set; }
    }
}
