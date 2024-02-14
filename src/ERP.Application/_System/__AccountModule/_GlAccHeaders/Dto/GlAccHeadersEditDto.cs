using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._GlAccHeaders;

namespace ERP._System.__AccountModule._GlAccHeaders.Dto
{
    [AutoMap(typeof(GlAccHeaders))]
    public class GlAccHeadersEditDto : EntityDto<long>
    {
        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string Code { get; set; }

        public bool IsHide { get; set; }

        public long AttributeLkpId { get; set; }

        public long? ParentId { get; set; }

        public int ShowOrder { get; set; }
    }
}
