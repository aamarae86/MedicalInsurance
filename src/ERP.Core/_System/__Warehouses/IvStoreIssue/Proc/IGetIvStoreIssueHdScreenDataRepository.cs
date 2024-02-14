using ERP._System.__Warehouses._IvStoreIssue;
using ERP._System.__Warehouses.IvStoreIssue.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses.IvStoreIssue.Proc
{
    public interface IGetIvStoreIssueHdScreenDataRepository:
        IExecuteProcedure<IvStoreIssueHd, long, IdLangInputDto, IvStoreIssueHdScreenDataOutput>
    {
    }
}
