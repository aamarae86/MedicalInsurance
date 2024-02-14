using Abp.AutoMapper;
using ERP._System.__AccountModule._GlAccMappingHd;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModuleExtend._GlAccMapping.Dto
{
    [AutoMap(typeof(GlAccMappingHd))]
    public class GlAccMappingHdCreateDto
    {
        [MaxLength(200)]
        public string MapName { get; set; }

        public string MapNumber { get; set; }

        public virtual ICollection<GlAccMappingTrDto> GlAccMappingTrList { get; set; }
    }
}
