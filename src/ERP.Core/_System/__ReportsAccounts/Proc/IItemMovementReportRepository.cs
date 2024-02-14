using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__Warehouses._IvItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Proc
{
    public  interface IItemMovementReportRepository : IExecuteProcedure<IvItems, long, ItemMovementInput, GetItemMovementDataOutput>
    {
    }
}
