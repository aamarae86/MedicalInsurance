using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArInvoiceHd.Dto
{
    public class ArInvoiceHdSearchDto
    {
        public string HdInvoiceNo { get;  set; }
        public string HdDate { get;  set; }
        public long? StatusLkpId { get;  set; }
        public long? ArCustomerId { get;  set; }
        public override string ToString() => $"Params.HdInvoiceNo={HdInvoiceNo}&Params.HdDate={HdDate}&Params.StatusLkpId={StatusLkpId}&Params.ArCustomerId={ArCustomerId}";
    }
}
