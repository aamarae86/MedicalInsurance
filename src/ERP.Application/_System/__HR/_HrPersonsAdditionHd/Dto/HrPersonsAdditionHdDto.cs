using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonsAdditionHd.Dto
{
    [AutoMap(typeof(HrPersonsAdditionHd))]
    public class HrPersonsAdditionHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        [MaxLength(30)]
        public string AdditionNumber { get; set; }
        [MaxLength(200)]
        public string AdditionName { get; set; }
        public long? PeriodId { get; set; }
        public long? StatusLkpId { get; set; }

        public GlPeriodsDetailsDto GlPeriodsDetails { get; set; }

        public FndLookupValuesDto FndLookupValuesHrPersonsAdditionHdStatusLkp { get; set; }

        public virtual ICollection<HrPersonsAdditionTrDto> PersonsAdditionTr { get; set; }
    }
}
