using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonsDeduction.Dto
{
    [AutoMap(typeof(HrPersonsDeductionHd))]
    public class HrPersonsDeductionHdEditDto : EntityDto<long>
    {
        [Required]
        [MaxLength(200)]
        public string DeductionName { get; set; }

        public long PeriodId { get; set; }

        public ICollection<HrPersonsDeductionTrDto> PersonsDeductionDetails { get; set; }
    }
}
