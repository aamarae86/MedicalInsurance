using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    [AutoMap(typeof(PyPayrollOperations))]
    public class PyPayrollOperationsCreateDto
    {
        [MaxLength(20)]
        public string OperationNumber { get; set; }

        public string OperationDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long PeriodId { get; set; }

        public long PyPayrollTypeId { get; set; }

        public long? HrPersonId { get; set; }

        public long? JobLkpId { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_PyPayrollOperationsStatues);
    }
}
