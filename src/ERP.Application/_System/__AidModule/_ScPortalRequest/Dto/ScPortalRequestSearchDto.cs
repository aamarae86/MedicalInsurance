namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    public class ScPortalRequestSearchDto
    {
        public int? TenantId { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public long? SourceLkpId { get; set; }

        public long? PortalUsersId { get; set; }

        public long? StatusLkpId { get; set; }

        public long? AidRequestTypeId { get; set; }

        public string PortalRequestNumber { get; set; }

        public long? ResearcherId { get; set; }

        public override string ToString()
         => $"Params.FromDate={FromDate}&Params.ToDate={ToDate}" +
            $"&Params.SourceLkpId={SourceLkpId}&Params.ResearcherId={ResearcherId}&Params.PortalUsersId={PortalUsersId}" +
            $"&Params.AidRequestTypeId={AidRequestTypeId}&Params.PortalRequestNumber={PortalRequestNumber}" +
            $"&Params.StatusLkpId={StatusLkpId}";
    }
}
