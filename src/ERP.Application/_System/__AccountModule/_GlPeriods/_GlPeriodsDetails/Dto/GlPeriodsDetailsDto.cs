using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._GlPeriods.Dto
{
    [AutoMap(typeof(GlPeriodsDetails))]
    public class GlPeriodsDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public string PeriodNameAr { get; set; }

        public string PeriodNameEn { get; set; }

        public DateTime? StartDate { get; set; }

        [Required]
        public string StartDateStr { get; set; }

        public DateTime? EndDate { get; set; }

        public string EndDateStr { get; set; }

        public string StatusLkp { get; set; }


        public long? StatusLkpId { get;  set; }

        public FndLookupValues FndLookupValues { get; set; }
        public string rowStatus { get ; set ; }
    }

}
