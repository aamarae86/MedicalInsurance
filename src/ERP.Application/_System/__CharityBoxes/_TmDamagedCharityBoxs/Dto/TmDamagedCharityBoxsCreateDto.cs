using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto
{
    [AutoMap(typeof(TmDamagedCharityBoxs))]
    public class TmDamagedCharityBoxsCreateDto
    {
        public string DamagedCharityBoxsDate { get; set; }

        public string DamagedCharityBoxsNumber { get; set; }

        public long TmSupervisorId { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_TmDamagedCharityBoxsStatues);

        public string Notes { get; set; }

        public ICollection<TmDamagedCharityBoxDetailsDto> DamagedCharityBoxDetails { get; set; }
    }

}
