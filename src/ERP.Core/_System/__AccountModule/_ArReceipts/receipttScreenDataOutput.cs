using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArReceipts
{
    public class receipttScreenDataOutput
    {
        public long id { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal amount { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string ReceiptType { get; set; }
        public string CheckNumber { get; set; }
        public DateTime MaturityDate { get; set; }
        public string Bank { get; set; }
        public decimal CheckAmount { get; set; }
        public string AmountTafqeet { get; set; }
        public string DType { get; set; }
        public string CustomerName { get; set; }
        public string DetailsNote { get; set; }
    }
}
