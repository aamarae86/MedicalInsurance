using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmSupervisors.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions.Dto
{
    [AutoMap(typeof(TmCharityBoxActions))]
    public class TmCharityBoxActionsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string ActionsDate { get; set; }

        [MaxLength(30)]
        public string ActionsNumber { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long StatusLkpId { get; set; }

        public long TmSupervisorId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public TmSupervisorsDto TmSupervisors { get; set; }

        public ICollection<TmCharityBoxActionDetailsDto> BoxActionsDetails { get; set; }

    }

}
