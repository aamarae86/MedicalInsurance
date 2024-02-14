using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTr;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModuleExtend._GlAccMapping.Dto
{
    [AutoMap(typeof(GlAccMappingTr))]
    public class GlAccMappingTrDto : EntityDto<long>, IDetailRowStatus
    {
        [MaxLength(200)]
        public string TrName { get; set; }

        public long GlAccMappingHdId { get; set; }

        public long? TrNo { get; set; }

        public int trDtlCount { get; set; }

        public string rowStatus { get; set; }

        public ICollection<GlAccMappingTrDtlDto> GlAccMappingTrDtlList { get; set; }
    }
}
