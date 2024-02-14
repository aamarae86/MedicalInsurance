namespace ERP._System.__HR._HrPersonsDeduction.Dto
{
    public class HrPersonsDeductionHdSearchDto
    {
        public string DeductionName { get; set; }

        public string DeductionNumber { get; set; }

        public long? PeriodId { get; set; }

        public long? StatusLkpId { get; set; }

        public override string ToString() => $"Params.DeductionName={DeductionName}&Params.DeductionNumber={DeductionNumber}&Params.PeriodId={PeriodId}&Params.StatusLkpId={StatusLkpId}";
    }
}
