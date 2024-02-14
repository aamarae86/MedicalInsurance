using Abp.Domain.Entities;

namespace ERP._System.__HrReports.Inputs
{
    public class PyPayrollDetailsInput : IMustHaveTenant
    {
        public long? PeriodId { get; set; }

        public long? PyPayrollTypeId { get; set; }

        public string Lang { get; set; }

        public int TenantId { get; set; }
    }
    public class PyPayrollDetailsInputHelper : IMustHaveTenant
    {
        public long? PeriodId { get; set; }
        public string PeriodIdtxt { get; set; }

        public long? PyPayrollTypeId { get; set; }
        public string PyPayrollTypeIdtxt { get; set; }

        public string Lang { get; set; }

        public int TenantId { get; set; }

        public override string ToString() => $"?Lang={Lang}&PeriodId={PeriodId}&PyPayrollTypeId={PyPayrollTypeId}";
    }
}
