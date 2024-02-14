using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._GlPeriods.Dto
{
    [AutoMap(typeof(GlPeriodsYears))]
    public class GlPeriodsYearsEditDto : EntityDto<long>, ICodeComUtilityIds
    {
        [Required]
        public string PeriodYear { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        public long AccountId { get; set; }


        [Required]
        public ICollection<GlPeriodsDetailsDto> PeriodDetails { get; set; }

        public ICollection<long> DeletedDetailIds { get; set; }
        public string codeComUtilityIds { get; set; }
    }
}
