using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions.Dto
{
    [AutoMap(typeof(TmCharityBoxActions))]
    public class TmCharityBoxActionsEditDto : EntityDto<long>
    {
        public string ActionsDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long TmSupervisorId { get; set; }

        public ICollection<TmCharityBoxActionDetailsDto> BoxActionsDetails { get; set; }
    }
}
