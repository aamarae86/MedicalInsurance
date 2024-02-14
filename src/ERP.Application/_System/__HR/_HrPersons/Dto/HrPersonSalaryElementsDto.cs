using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersons._HrPersonSalaryElements;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersons.Dto
{
    [AutoMap(typeof(HrPersonSalaryElements))]
    public class HrPersonSalaryElementsDto : EntityDto<long>, IDetailRowStatus
    {
        public long PyElementId { get; set; }

        public long StartPeriodId { get; set; }

        public long? EndPeriodId { get; set; }

        public long HrPersonId { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }


        public string PyElementName { get; set; }

        public string StartPeriodNameAr { get; set; }

        public string StartPeriodNameEn { get; set; }

        public string EndPeriodNameAr { get; set; }

        public string EndPeriodNameEn { get; set; }

        public string rowStatus { get; set; }

        public PeriodsDates startPeriod { get; set; }

        public PeriodsDates endPeriod { get; set; }
    }

    public class PeriodsDates
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
