using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__SalesModule._IvSaleHd.Proc;
using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._IvSalesHd
{
    public class GetSalesScreenDataRepository :
           ERPProcedureRepositoryBase<IvSaleHd, long, IdLangInputDto, SalesScreenDataOutput>,
        IGetSalesScreenDataRepository
    {

        public GetSalesScreenDataRepository(
              IDbContextProvider<ERPDbContext> dbContextProvider,
              IActiveTransactionProvider activeTransactionProvider
          ) : base(dbContextProvider, activeTransactionProvider)
        {
        }

    }
}
