using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonsDeduction.Dto
{
    [AutoMap(typeof(HrPersonsDeductionHd))]
    public class HrPersonsDeductionHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string DeductionNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string DeductionName { get; set; }

        public long PeriodId { get; set; }

        public long StatusLkpId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public GlPeriodsDetailsDto Periods { get; set; }

        public ICollection<HrPersonsDeductionTrDto> PersonsDeductionDetails { get; set; }
    }
}
