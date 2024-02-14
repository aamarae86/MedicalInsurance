using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    [AutoMap(typeof(PyPayrollOperationPersonDetails))]
    public class PyPayrollOperationPersonDetailsDto : EntityDto<long>
    {
        public long PyPayrollOperationPersonId { get; set; }

        public long SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        public string SourceName { get; set; }

        public decimal? EarningAmount { get; set; }

        public decimal? DeductionAmount { get; set; }

        public string PeriodNameAr { get; set; }

        public string PeriodNameEn { get; set; }

        public string BankNameAr { get; set; }

        public string BankNameEn { get; set; }

        public string HrPersonName { get; set; }

        public string HrPersonNumber { get; set; }

        public string PyPayrollTypeName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string AccountNumber { get; set; }

        public string PayrollNetValue { get; set; }
    }
}
