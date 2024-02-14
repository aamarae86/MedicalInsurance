using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonVacations.Dto
{
    [AutoMap(typeof(HrPersonVacations))]
    public class HrPersonVacationsEditDto : EntityDto<long>
    {
        public decimal VacationBalance { get; set; }

        public string OperationDate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public long HrVacationsTypeId { get; set; }

        public long HrPersonId { get; set; }

        public int NoOfDays => ((DateTime)DateTimeController.ConvertToDateTime(this.EndDate)).Subtract((DateTime)DateTimeController.ConvertToDateTime(this.StartDate)).Days + 1;

        [MaxLength(4000)]
        public string Notes { get; set; }
    }
}
