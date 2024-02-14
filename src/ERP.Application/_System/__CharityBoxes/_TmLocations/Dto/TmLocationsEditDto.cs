using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmLocations.Dto
{
    [AutoMap(typeof(TmLocations))]
    public class TmLocationsEditDto : EntityDto<long>
    {
        public long RegionId { get; set; }

        [Required]
        [MaxLength(200)]
        public string LocationName { get; set; }

        public ICollection<TmLocationSubDto> InputCollection { get; set; }

        public string ListLocationSubsStr { get; set; }
    }
}
