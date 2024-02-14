namespace ERP._System._ArDrCrHd.Dto
{
    public class ArDrCrHdSearchDto
    {
        public string HdDrCrNumber { get; set; }
        public string HdDate { get; set; }
        public long? StatusLkpId { get; set; }
        public long? HdTypeLkpId { get; set; }
        public long? ArCustomerId { get; set; }
        public override string ToString() => $"Params.HdDrCrNumber={HdDrCrNumber}&Params.HdDate={HdDate}&Params.StatusLkpId={StatusLkpId}&Params.HdTypeLkpId={HdTypeLkpId}&Params.ArCustomerId={ArCustomerId}";
    }
}
