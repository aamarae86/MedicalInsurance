using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System._GlAccHeaders.Dto
{
    [AutoMap(typeof(GlAccHeaders))]
    public class GlAccHeadersDto : AuditedEntityDto<long>
    {
        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string Code { get; set; }

        public bool IsHide { get; set; }

        public long AttributeLkpId { get; set; }
        public bool? CanUpdated { get; set; }
        public long? ParentId { get; set; }
    }
}
