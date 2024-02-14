using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApPdcInterface.ProcDto
{
    public  class GetItemMovementDataOutput
    {
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public DateTime? HdDate { get; set; }
        public decimal TRQTYSIN { get; set; }
        public decimal TrQtysOut { get; set; }
        public int? SourceCode { get; set; }
        public string HdInno { get; set; }
        public long HdInvId { get; set; }
        public string SourceId { get; set; }
        public long IvWarehouseId { get; set; }
        public long TrItemId { get; set; }
        public long HdStat { get; set; }
        public long TenantId { get; set; }
        public string CustVend { get; set; }
        public string TranType { get; set; }
        public decimal? TotalAmount { get; set; }


    }
}
