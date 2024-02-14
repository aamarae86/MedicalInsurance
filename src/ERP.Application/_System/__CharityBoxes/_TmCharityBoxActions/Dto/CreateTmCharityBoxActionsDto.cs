using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions.Dto
{
    [AutoMap(typeof(TmCharityBoxActions))]
    public class CreateTmCharityBoxActionsDto
    {
        public string ActionsDate { get; set; }

        [MaxLength(30)]
        public string ActionsNumber { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_TmCharityBoxActionsStatues);

        public long TmSupervisorId { get; set; }

        public ICollection<TmCharityBoxActionDetailsDto> BoxActionsDetails { get; set; }
    }
}
