using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmRegions.Dto
{
    [AutoMap(typeof(TmRegions))]
    public class TmRegionsDto : AuditedEntityDto<long>
    {
        public long CityLkpId { get; set; }

        [MaxLength(30)]
        public string RegionNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string RegionName { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }
    }
}
