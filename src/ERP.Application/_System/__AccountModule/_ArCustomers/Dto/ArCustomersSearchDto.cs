namespace ERP._System._ArCustomers.Dto
{
    public class ArCustomersSearchDto
    {
        public long? CustomerNumber { get; set; }
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
        public long? StatusLkp { get; set; }
        public long? SourceId { get; set; }
        public long? SourceCodeLkpId { get; set; }

        public override string ToString()
        {
            return $"Params.CustomerNumber={CustomerNumber}&Params.CustomerNameAr={CustomerNameAr}&Params.CustomerNameEn={CustomerNameEn}&Params.StatusLkp={StatusLkp}&Params.SourceCodeLkpId={SourceCodeLkpId}&Params.SourceId={SourceId}";
        }
    }
}
