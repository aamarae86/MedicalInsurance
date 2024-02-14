
namespace ERP._System.__AccountModule._ApDrCrHd.Dto
{
    public class ApDrCrHdSearchDto
    {
        public string HdDrCrNumber { get; set; }
        public string HdDate { get; set; }
        public long? StatusLkpId { get; set; }
        public long? HdTypeLkpId { get; set; }
        public long? VendorId { get; set; }
        public override string ToString() => $"Params.HdDrCrNumber={HdDrCrNumber}&Params.HdDate={HdDate}&Params.StatusLkpId={StatusLkpId}&Params.HdTypeLkpId={HdTypeLkpId}&Params.VendorId={VendorId}";
    }
}
