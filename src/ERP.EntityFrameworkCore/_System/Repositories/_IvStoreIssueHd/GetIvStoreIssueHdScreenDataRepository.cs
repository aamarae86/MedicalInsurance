using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__Warehouses._IvStoreIssue;
using ERP._System.__Warehouses.IvStoreIssue.Proc;
using ERP._System.__Warehouses.IvStoreIssue.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._IvStoreIssueHd
{
    public class GetIvStoreIssueHdScreenDataRepository:
        ERPProcedureRepositoryBase<IvStoreIssueHd, long, IdLangInputDto, IvStoreIssueHdScreenDataOutput>,
        IGetIvStoreIssueHdScreenDataRepository
    {
        public GetIvStoreIssueHdScreenDataRepository(
                    IDbContextProvider<ERPDbContext> dbContextProvider,
                    IActiveTransactionProvider activeTransactionProvider
                ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
