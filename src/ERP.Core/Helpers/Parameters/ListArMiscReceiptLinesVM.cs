using ERP.Helpers.Core;

namespace ERP.Helpers.Parameters
{
    public class ListArMiscReceiptLinesVM : CodeComUtility, IDetailRowStatus
    {
        public int index { get; set; }

        public long? miscId { get; set; }

        public decimal? miscReceiptAmount { get; set; }

        public string notes { get; set; }

        public long? receiptTypeLkpId { get; set; }

        public long? arMiscReceiptLinesId { get; set; }

        public string manualReceiptNumber { get; set; }

        public long? sourceCodeLkpId { get; set; }

        public decimal? AdministrativePercent { get; set; }

        public long? SpContractDetailsId { get; set; }

        public string CaseName { get; set; }

        public string CaseNumber { get; set; }

        public string receiptTypeLkp { get; set; }
        public string rowStatus { get; set; }
    }
}
