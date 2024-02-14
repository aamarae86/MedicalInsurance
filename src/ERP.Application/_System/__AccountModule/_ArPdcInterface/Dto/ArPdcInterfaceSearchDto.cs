using Abp.AutoMapper;

namespace ERP._System._ArPdcInterface.Dto
{
    public class ArPdcInterfaceSearchDto
    {
        public long? BankAccountId { get;  set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CheckNumber { get; set; }
        public decimal? Amount { get;  set; }
        public long? StatusLkpId { get; set; }

    }
}
