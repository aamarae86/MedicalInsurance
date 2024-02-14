using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModuleExtend._GlAccMapping.Dto
{
    [AutoMap(typeof(GlAccMappingTrDtl))]
    public class GlAccMappingTrDtlDto : EntityDto<long>, IDetailRowStatus
    {
        public long GlAccMappingTrId { get; set; }

        public long? TypeLkpId { get; set; }

        public long? FromAccId { get; set; }

        public long? ToAccId { get; set; }

        public string TypeLkpNameAr { get; set; }

        public string TypeLkpNameEn { get; set; }

        public string FromAccDescriptionAr { get; set; }

        public string FromAccDescriptionEn { get; set; }

        public string ToAccDescriptionAr { get; set; }

        public string ToAccDescriptionEn { get; set; }

        public string rowStatus { get; set; }
    }
}
