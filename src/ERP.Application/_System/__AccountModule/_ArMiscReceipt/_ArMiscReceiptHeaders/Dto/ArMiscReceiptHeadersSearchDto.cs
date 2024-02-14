using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto
{
    public class ArMiscReceiptHeadersSearchDto
    {

        public string CheckNumber { get; set; }
        public string ReceiptNumber { get; set; }
        public long? PostedLkpId { get; set; }
        public decimal? Amount { get; set; }
        public long? BeneficentId { get; set; }
        public long? SourceCodeLkpId { get; set; }
        public long? SpContractDetailsId { get; set; }

        public override string ToString()
         => $"Params.CheckNumber={CheckNumber}&Params.SpContractDetailsId={SpContractDetailsId}&Params.ReceiptNumber={ReceiptNumber}&Params.PostedLkpId={PostedLkpId}&Params.Amount={Amount}&Params.BeneficentId={BeneficentId}&Params.SourceCodeLkpId={SourceCodeLkpId}";


    }
}
