namespace ERP._System.__AccountModule._ApVendors.Dto
{
    public class ApVendorsSearchDto
    {
        public string VendorNumber { get; set; }

        public string VendorNameAr { get; set; }

        public string VendorNameEn { get; set; }

        public long? StatusLkpId { get; set; }

        public override string ToString() => $"Params.VendorNumber={VendorNumber}&Params.VendorNameAr={VendorNameAr}&Params.VendorNameEn={VendorNameEn}&Params.StatusLkpId={StatusLkpId}";
    }
}
