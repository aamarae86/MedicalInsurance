namespace ERP._System._ApPdcInterface.Dto
{
    public class ApPdcInterfaceSearchDto
    {
        public long? BankAccountId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CheckNumber { get; set; }
        public long? StatusLkpId { get; set; }
    }
}
