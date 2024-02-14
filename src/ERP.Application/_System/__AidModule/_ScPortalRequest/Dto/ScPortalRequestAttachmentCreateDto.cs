using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMapTo(typeof(ScPortalRequestAttachment))]
    public class ScPortalRequestAttachmentCreateDto : EntityDto<long>, IDetailRowStatus
    {
        public long PortalRequestId { get; set; }

        public string FilePath { get; set; }

        public long ProtalAttachmentSettingId { get; set; }

        public string rowStatus { get; set; }
    }
}
