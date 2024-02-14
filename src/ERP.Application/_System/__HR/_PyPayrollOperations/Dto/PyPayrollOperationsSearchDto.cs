namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    public class PyPayrollOperationsSearchDto
    {
        public long? PeriodId { get; set; }

        public long? PyPayrollTypeId { get; set; }

        public long? HrPersonId { get; set; }

        public string HrPersonNumber { get; set; }

        public override string ToString()
            => $"Params.PeriodId={PeriodId}&Params.PyPayrollTypeId={PyPayrollTypeId}&Params.HrPersonId={HrPersonId}&Params.HrPersonNumber={HrPersonNumber}";
    }
}
