using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonVacations.Dto
{
    [AutoMap(typeof(HrPersonVacations))]
    public class HrPersonVacationsCreateDto
    {
        [MaxLength(30)]
        public string OperationNumber { get; set; }

        public decimal VacationBalance { get; set; }

        public string OperationDate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_HrPersonVacationsStatues);

        public long HrVacationsTypeId { get; set; }

        public long HrPersonId { get; set; }

        public int NoOfDays => ((DateTime)DateTimeController.ConvertToDateTime(this.EndDate)).Subtract((DateTime)DateTimeController.ConvertToDateTime(this.StartDate)).Days + 1;

        [MaxLength(4000)]
        public string Notes { get; set; }
    }
}
