using ERP._System.__Warehouses._PoPurchaseOrder.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Proc
{
    public interface IGetPoPurchaseOrderScreenDataRepository : IExecuteProcedure<PoPurchaseOrderHd, long, IdLangInputDto, PoPurchaseOrderScreenDataOutput>
    {
    }
}
