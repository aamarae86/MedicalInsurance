using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScFndAidRequestType.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto
{
    [AutoMap(typeof(ScFndProtalAttachmentSetting))]
    public class ScFndProtalAttachmentSettingDto : AuditedEntityDto<long>, IDetailRowStatus
    {
        public string AttachmentNameAr { get; set; }

        public string AttachmentNameEn { get; set; }

        public long RequestTypeId { get; set; }

        public string phyPath { get; set; }

        public string fileName { get; set; }

        public string filePath { get; set; }

        public long? attchId { get; set; }

        public int OrderBy { get; set; }

        public bool IsRequired { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }

        public ScFndAidRequestTypeDto ScFndAidRequestType { get; set; }

        public string rowStatus { get; set; }
    }
}
