using Abp.AutoMapper;
using System.Collections.Generic;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    [AutoMap(typeof(PoPurchaseOrderHd))]
    public class PoPurchaseOrderCreateDto : PoPurchaseOrderBaseDto
    {
        public string PurchaseOrderNumber { get; set; }

        public long StatusLkpId => 739;

        public ICollection<PoPurchaseOrderDetailsCreateDto> ListOfCreateDetails { get; set; }
    }
}
