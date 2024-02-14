using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmRegions.Dto;
using ERP.Core.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmLocations.Dto
{
    [AutoMap(typeof(TmLocations))]
    public class TmLocationsDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public long RegionId { get; set; }

        [MaxLength(30)]
        public string LocationNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string LocationName { get; set; }

        public TmRegionsDto Region { get; set; }

        public ICollection<TmLocationSubDto> LocationSubs { get; set; }

        public string ListLocationSubsStr { get; set; }
    }
}
