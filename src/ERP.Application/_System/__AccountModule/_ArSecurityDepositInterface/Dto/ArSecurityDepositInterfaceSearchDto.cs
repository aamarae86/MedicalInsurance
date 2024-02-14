namespace ERP._System._ArSecurityDepositInterface.Dto
{
    public class ArSecurityDepositInterfaceSearchDto
    {

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public long StatusLkpId { get; set; }

        public long? ArCustomerId { get; set; }

        public long? SourceCodeLkpId { get; set; }

        public override string ToString()
         => $"Params.FromDate={FromDate}&Params.ToDate={ToDate}&Params.StatusLkpId={StatusLkpId}&Params.ArCustomerId={ArCustomerId}&Params.StatusLkpId={StatusLkpId}&Params.SourceCodeLkpId={SourceCodeLkpId}";

    }
}
