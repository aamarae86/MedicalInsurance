using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._GlAccMappingHd;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModuleExtend._GlAccMapping.Dto
{
    [AutoMap(typeof(GlAccMappingHd))]
    public class GlAccMappingHdEditDto : EntityDto<long>
    {
        [MaxLength(200)]
        public string MapName { get; set; }

        public virtual ICollection<GlAccMappingTrDto> GlAccMappingTrList { get; set; }
    }
}
