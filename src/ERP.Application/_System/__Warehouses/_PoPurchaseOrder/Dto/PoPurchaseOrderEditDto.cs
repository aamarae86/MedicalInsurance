using Abp.AutoMapper;
using System.Collections.Generic;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    [AutoMap(typeof(PoPurchaseOrderHd))]
    public class PoPurchaseOrderEditDto : PoPurchaseOrderBaseDto
    {
        public ICollection<PoPurchaseOrderDetailsEditDto> ListOfEditDetails { get; set; }
    }
}
