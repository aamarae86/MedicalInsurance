using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmSupervisors.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto
{
    [AutoMap(typeof(TmDamagedCharityBoxs))]
    public class TmDamagedCharityBoxsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string DamagedCharityBoxsDate { get; set; }

        [MaxLength(30)]
        public string DamagedCharityBoxsNumber { get; set; }

        public long TmSupervisorId { get; set; }

        public long StatusLkpId { get; set; }

        public TmSupervisorsDto TmSupervisors { get; set; }

        public FndLookupValuesDto FndStatusLookup { get; set; }

        public string Notes { get; set; }

        public ICollection<TmDamagedCharityBoxDetailsDto> DamagedCharityBoxDetails { get; set; }
    }
}
