using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CharityBoxes._TmRegions.Dto
{
    [AutoMap(typeof(TmRegions))]
    public class CreateTmRegionsDto
    {
        public long CityLkpId { get; set; }
        [MaxLength(30)]
        public string RegionNumber { get; set; }
        [Required]
        [MaxLength(200)]
        public string RegionName { get; set; }
    }
}
