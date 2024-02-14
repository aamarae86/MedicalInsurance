using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__Warehouses._IvItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Proc
{
    public  interface IItemQtyPerWarehouseRepository : IExecuteProcedure<IvItems, long, ItemQtyPerWarehouseInput, GetItemQtyPerWarehouseOutput>
    {
    }
}
