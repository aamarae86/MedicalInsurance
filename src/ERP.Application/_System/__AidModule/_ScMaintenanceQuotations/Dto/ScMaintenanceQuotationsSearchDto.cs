namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    public class ScMaintenanceQuotationsSearchDto
    {
        public string QuotationNumber { get; set; }

        public string PortalRequestNumber { get; set; }

        public string QuotationDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? VendorId { get; set; }

        public long? PortalUserId { get; set; }

        public override string ToString() => $"Params.QuotationNumber={QuotationNumber}&Params.PortalRequestNumber={PortalRequestNumber}&Params.PortalUserId={PortalUserId}&Params.QuotationDate={QuotationDate}&Params.StatusLkpId={StatusLkpId}&Params.VendorId={VendorId}";
    }
}
