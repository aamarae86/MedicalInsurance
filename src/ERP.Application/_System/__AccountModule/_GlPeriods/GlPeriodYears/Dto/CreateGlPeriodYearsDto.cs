using Abp.AutoMapper;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Helpers.Parameters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._GlPeriods.Dto
{
    [AutoMap(typeof(GlPeriodsYears))]
    public class CreateGlPeriodsYearsDto : CodeComUtility
    {
        public int PeriodYear { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        public long AccountId { get; set; }

        public ICollection<GlPeriodsDetailsDto> PeriodDetails { get; set; }
    }
}
