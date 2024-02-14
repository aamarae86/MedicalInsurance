using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._IvSaleHd.Proc
{
    public interface IGetSalesScreenDataRepository
        : IExecuteProcedure<IvSaleHd, long, IdLangInputDto, SalesScreenDataOutput>
    {
    }
}
