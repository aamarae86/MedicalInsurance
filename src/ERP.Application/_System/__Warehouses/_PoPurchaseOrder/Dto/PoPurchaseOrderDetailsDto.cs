using Abp.AutoMapper;
using System;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    [AutoMapFrom(typeof(PoPurchaseOrderTr))]
    public class PoPurchaseOrderDetailsDto : PoPurchaseOrderDetailsBaseDto
    {
        public string IvItemNumber { get; set; }
        public string IvItemName { get; set; }
        public string ReceivedDate { get; set; }
    }
}
