using Abp.AutoMapper;
using ERP._System._ArMiscReceiptDetails;
using ERP.Helpers.Core;

namespace ERP.Helpers.Parameters
{
    [AutoMap(typeof(ArMiscReceiptDetails))]
    public class ListArMiscReceiptDetailsVM : IDetailRowStatus
    {
        public int index { get; set; }

        public string checkNumber { get; set; }

        public long? arMiscDetailId { get; set; }

        public string maturityDate { get; set; }

        public long? bankLkpId { get; set; }

        public decimal? amount { get; set; }

        public long? bankAccountId { get; set; }

        public long miscId { get; set; }

        public string bank { get; set; }
        public string bankAccount { get; set; }
        public string rowStatus { get; set; }
    }
}
