using Abp.AutoMapper;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using System.Collections.Generic;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto
{
    [AutoMap(typeof(ArInvoiceSettlementHd))]
    public class ArInvoiceSettlementHdCreateDto
    {
        public string SettlementDate { get; set; }
        public long StatusLkpId { get; set; }
        public decimal SettlementAmount { get; set; }
        public string SettlementNumber { get; set; }
        public long ArCustomerId { get; set; }
        public string Description { get; set; }
        public int TenantId { get; set; }

        public virtual ICollection<ArInvoiceSettlementCrDto> ArInvoiceSettlementCr { get;  set; }
        public virtual ICollection<ArInvoiceSettlementDrDto> ArInvoiceSettlementDr { get;  set; }
    }
}
