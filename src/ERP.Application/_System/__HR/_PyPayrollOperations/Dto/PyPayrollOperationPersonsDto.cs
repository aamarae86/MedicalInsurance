using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    [AutoMap(typeof(PyPayrollOperationPersons))]
    public class PyPayrollOperationPersonsDto : EntityDto<long>
    {
        public long PyPayrollOperationId { get; set; }

        public long? BankLkpId { get; set; }

        public long? HrPersonId { get; set; }

        public string AccountNumber { get; set; }

        public string HrPersonNumber { get; set; }

        public string FullName { get; set; }

        public string BankLkpNameAr { get; set; }

        public string BankLkpNameEn { get; set; }

        public decimal PayrollNetValue { get; set; }
    }
}
