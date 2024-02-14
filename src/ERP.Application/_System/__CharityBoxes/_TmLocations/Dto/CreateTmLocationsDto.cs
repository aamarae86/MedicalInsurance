using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmRegions.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CharityBoxes._TmLocations.Dto
{
    [AutoMap(typeof(TmLocations))]
    public class CreateTmLocationsDto
    {
        public long RegionId { get; set; }

        [MaxLength(30)]
        public string LocationNumber { get; set; }
        [Required]
        [MaxLength(200)]
        public string LocationName { get; set; }

        public ICollection<TmLocationSubDto> InputCollection { get; set; }
        public string ListLocationSubsStr { get; set; }
    }
}
