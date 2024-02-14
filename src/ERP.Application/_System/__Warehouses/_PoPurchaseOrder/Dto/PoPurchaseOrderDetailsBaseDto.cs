using Abp.Application.Services.Dto;
using System;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    public class PoPurchaseOrderDetailsBaseDto : EntityDto<long>
    {
        public long PoPurchaseOrderId { get; set; }

        public long IvItemId { get; set; }

        public decimal QtyOrdered { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? ReceivedQty { get; set; }
    }
}
