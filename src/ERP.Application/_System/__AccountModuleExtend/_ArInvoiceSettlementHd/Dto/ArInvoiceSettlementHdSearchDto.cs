using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto
{
    public class ArInvoiceSettlementHdSearchDto
    {
        public string SettlementNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public decimal? SettlementAmount { get; set; }
        public string SettlementDate { get; set; }
        public long? ArCustomerId { get; set; }

        public override string ToString()
           => $"Params.SettlementNumber={SettlementNumber}&Params.StatusLkpId={StatusLkpId}&Params.SettlementAmount={SettlementAmount}&Params.SettlementDate={SettlementDate}&Params.ArCustomerId={ArCustomerId}";
    }
}
