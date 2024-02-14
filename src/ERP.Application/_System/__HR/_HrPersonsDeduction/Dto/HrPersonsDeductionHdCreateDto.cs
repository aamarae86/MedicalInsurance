using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonsDeduction.Dto
{
    [AutoMap(typeof(HrPersonsDeductionHd))]
    public class HrPersonsDeductionHdCreateDto
    {
        public string DeductionNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string DeductionName { get; set; }

        public long PeriodId { get; set; }

        public long StatusLkpId => Convert.ToInt64(_FndLookupValues.Dto.FndEnum.FndLkps.New_HrPersonsDeductionHd);

        public ICollection<HrPersonsDeductionTrDto> PersonsDeductionDetails { get; set; }
    }
}
