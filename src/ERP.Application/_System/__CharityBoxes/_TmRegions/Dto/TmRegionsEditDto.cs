using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmRegions.Dto
{
    [AutoMap(typeof(TmRegions))]
    public class TmRegionsEditDto : EntityDto<long>
    {
        public long CityLkpId { get; set; }

        [Required]
        [MaxLength(200)]
        public string RegionName { get; set; }
    }
}
