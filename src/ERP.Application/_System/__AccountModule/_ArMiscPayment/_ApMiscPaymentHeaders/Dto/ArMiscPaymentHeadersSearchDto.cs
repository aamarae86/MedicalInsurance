namespace ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto
{
    public class ArMiscPaymentHeadersSearchDto
    {
        public string CheckNumber { get; set; }
        public string PaymentNumber { get; set; }
        public string CaseNumber { get; set; }
        public long? PostedLkpId { get; set; }
        public decimal? Amount { get; set; }
        public string BeneficentName { get; set; }
        public long? SourceCodeLkpId { get; set; }
        public long? PortalUsersId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public override string ToString()
         => $"Params.CheckNumber={CheckNumber}&Params.CaseNumber={CaseNumber}&Params.FromDate={FromDate}&Params.ToDate={ToDate}&Params.PortalUsersId={PortalUsersId}&Params.PaymentNumber={PaymentNumber}&Params.PostedLkpId={PostedLkpId}&Params.Amount={Amount}&Params.BeneficentName={BeneficentName}&Params.SourceCodeLkpId={SourceCodeLkpId}";
    }
}
