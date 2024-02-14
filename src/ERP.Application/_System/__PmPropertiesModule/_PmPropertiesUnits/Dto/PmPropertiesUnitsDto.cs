using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.Collections.Generic;

namespace ERP._System.__PmPropertiesModule._PmPropertiesUnits.Dto
{
    [AutoMap(typeof(PmPropertiesUnits))]
    public class PmPropertiesUnitsDto : EntityDto<long>, IDetailRowStatus
    {
        public string UnitNo { get; set; }

        public string ElectricityNumber { get; set; }

        public string SewerageNumber { get; set; }

        public decimal? AreaSize { get; set; }

        public decimal YearlyRent { get; set; }

        public string FloorLevel { get; set; }

        public string Description { get; set; }

        public string FndStatusLkp { get; set; }

        public long PmUnitTypeLkpId { get; set; }

        public long? PmUnitDescLkpId { get; set; }

        public string PmUnitDescLkpNameAr { get; set; }

        public string PmUnitDescLkpNameEn { get; set; }

        public string PmUnitTypeLkp { get; set; }

        public long? StatusLkpId { get; set; }

        public string StatusLkp { get; set; }

        public long? ViewLkpId { get; set; }

        public string ViewLkp { get; set; }

        public long? FinishesLkpId { get; set; }

        public string FinishesLkp { get; set; }

        public long PropertyId { get; set; }

        public string rowStatus { get; set; }

        public virtual ICollection<PmPropertiesUnitsAttachmentsDto> PmUnitsAttachments { get; set; }
    }
}
