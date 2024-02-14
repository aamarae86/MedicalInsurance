using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMap(typeof(ScPortalRequestAttachment))]
    public class ScPortalRequestAttachmentDto : EntityDto<long>, IDetailRowStatus
    {
        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; }

        public long PortalRequestId { get; set; }

        public long ProtalAttachmentSettingId { get; set; }

        public virtual ScFndProtalAttachmentSettingDto GetScFndProtalAttachmentSetting { get; set; }

        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();

        public int TenantId { get; set; }
    }
}
