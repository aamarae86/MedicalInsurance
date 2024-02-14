namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    public class SpPaymentsSearchDto
    {
        public string PaymentNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public long? SpCasesId { get; set; }

        public override string ToString() => $"Params.PaymentNumber={PaymentNumber}&Params.SpCasesId={SpCasesId}&Params.StatusLkpId={StatusLkpId}";
    }
}
