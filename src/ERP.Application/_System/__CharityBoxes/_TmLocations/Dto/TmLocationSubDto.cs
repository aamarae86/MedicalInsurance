using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmLocations.Dto
{
    [AutoMap(typeof(TmLocationSub))]
    public class TmLocationSubDto : EntityDto<long>, IDetailRowStatus
    {
        public long LocationId { get; set; }

        //public TmLocationsDto Location { get; set; }

        [MaxLength(30)]
        public string TmLocationSubNumber { get; set; }
        [Required]
        [MaxLength(200)]
        public string TmLocationSubName { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }
        public string rowStatus { get; set; }
    }
}
