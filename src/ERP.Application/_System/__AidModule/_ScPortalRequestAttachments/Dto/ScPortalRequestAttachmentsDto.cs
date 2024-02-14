using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequest;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScPortalRequestAttachments.Dto
{
    [AutoMap(typeof(ScPortalRequestAttachment))]
    public class ScPortalRequestAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        public string attchsBase64Str { get; set; }

        public string FilePath { get; set; }

        public long? protalAttachmentSettingId { get; set; }

        public string rowStatus { get; set; }
    }
}
