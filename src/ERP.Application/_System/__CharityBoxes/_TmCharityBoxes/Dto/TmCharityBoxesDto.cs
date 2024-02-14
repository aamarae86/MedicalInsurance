using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._TmCharityBoxesType.Dto;
using ERP._System.__CharityBoxes._TmLocations.Dto;
using ERP._System.__CharityBoxes._TmSupervisors.Dto;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxes.Dto
{
    [AutoMap(typeof(TmCharityBoxes))]
    public class TmCharityBoxesDto : AuditedEntityDto<long>
    {
        public string CharityBoxNumber { get; set; }

        public string CharityBoxName { get; set; }

        public string CharityBoxBarcode { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        [Required]
        public long CharityTypeId { get; set; }

        public TmCharityBoxesTypeDto CharityBoxesType { get; set; }

        public long? TmSubLocationId { get; set; }

        public TmLocationSubDto TmSubLocation { get; set; }

        public long? TmSupervisorId { get; set; }

        public TmSupervisorsDto TmSupervisor { get; set; }

        public string CityName { get; set; }

        public string RegionName { get; set; }

        public string LocationName { get; set; }

        public string SubLocationName { get; set; }

    }
}
