using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._GlAccDetails;

namespace ERP._System.__AccountModule._GlAccDetails.Dto
{
    [AutoMap(typeof(GlAccDetails))]
    public class GlAccDetailsEditDto : EntityDto<long>
    {
        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string Code { get; set; }

        public long GlAccHeaderId { get; set; }

        public bool IsDefault { get; set; }

        public long? UpdateParentId { get; set; }

        public bool NameExistBefore { get; set; }

        public bool CodeExistBefore { get; set; }
    }
}
