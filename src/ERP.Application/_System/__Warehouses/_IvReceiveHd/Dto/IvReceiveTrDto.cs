using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    [AutoMap(typeof(IvReceiveTr))]
    public class IvReceiveTrDto : Entity<long>, IDetailRowStatus
    {
        public long? PoPurchaseOrderTrId { get; set; }

        public long IvReceiveHdId { get; set; }

        public long IvItemId { get; set; }

        public long IvUnitId { get; set; }

        public decimal Qty { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? TaxAmount { get; set; }

        public string Item { get; set; }

        public string ItemNumber { get; set; }

        public string Unit { get; set; }

        public string rowStatus { get; set; }

        public decimal Amount => this.Qty * this.UnitPrice;

        public decimal TotalAmount => this.Amount + this.TaxAmount ?? 0;
    }
}
