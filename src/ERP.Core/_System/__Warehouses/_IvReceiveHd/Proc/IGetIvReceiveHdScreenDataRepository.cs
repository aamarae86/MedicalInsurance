using ERP._System.__Warehouses._IvReceiveHd.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvReceiveHd.Proc
{
    public interface IGetIvReceiveHdScreenDataRepository : IExecuteProcedure<IvReceiveHd, long, IdLangInputDto, IvReceiveHdScreenDataOutput>
    {
    }
}
