using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto
{
    [AutoMap(typeof(ScFndProtalAttachmentSetting))]
    public class ScFndProtalAttachmentSettingEditDto : EntityDto<long>
    {
        public string AttachmentNameAr { get; set; }

        public string AttachmentNameEn { get; set; }

        public long RequestTypeId { get; set; }

        public string phyPath { get; set; }

        public string attchsBase64Str { get; set; }

        public string fileName { get; set; }

        public string fileExt { get; set; }

        public long? attchId { get; set; }

        public int OrderBy { get; set; }

        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }

        public string rowStatus { get; set; }
    }
}
