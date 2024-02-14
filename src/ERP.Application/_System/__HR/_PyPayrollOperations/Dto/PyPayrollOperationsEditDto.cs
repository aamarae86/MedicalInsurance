using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    [AutoMap(typeof(PyPayrollOperations))]
    public class PyPayrollOperationsEditDto : EntityDto<long>
    {
        public string OperationDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long PeriodId { get; set; }

        public long PyPayrollTypeId { get; set; }

        public long? HrPersonId { get; set; }

        public long? JobLkpId { get; set; }
    }
}
