using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMap(typeof(ScPortalRequestAttachment))]
    public class ScPortalRequestAttachmentEditDto :EntityDto<long>
    {
        public int TenantId { get; set; }

        //public long PortalRequestId { get; set; }

        //[Required]
        public string FilePath { get; set; }

        public string attchsBase64Str { get; set; }

        public long ProtalAttachmentSettingId { get; set; }

        public string rowStatus { get; set; }

        public string FileExt { get; set; }
    }
}
