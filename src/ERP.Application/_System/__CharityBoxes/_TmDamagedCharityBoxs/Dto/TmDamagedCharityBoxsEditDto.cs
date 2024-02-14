using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto
{
    [AutoMap(typeof(TmDamagedCharityBoxs))]
    public class TmDamagedCharityBoxsEditDto : EntityDto<long>
    {
        public string DamagedCharityBoxsDate { get; set; }

        public long TmSupervisorId { get; set; }

        public string Notes { get; set; }

        public ICollection<TmDamagedCharityBoxDetailsDto> DamagedCharityBoxDetails { get; set; }
    }
}
