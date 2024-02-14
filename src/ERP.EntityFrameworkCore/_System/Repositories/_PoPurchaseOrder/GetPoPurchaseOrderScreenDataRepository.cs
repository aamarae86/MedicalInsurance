using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__Warehouses._PoPurchaseOrder;
using ERP._System.__Warehouses._PoPurchaseOrder.Proc;
using ERP._System.__Warehouses._PoPurchaseOrder.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._PoPurchaseOrder
{
    public class GetPoPurchaseOrderScreenDataRepository : ERPProcedureRepositoryBase<PoPurchaseOrderHd, long, IdLangInputDto, PoPurchaseOrderScreenDataOutput>,
        IGetPoPurchaseOrderScreenDataRepository
    {
        public GetPoPurchaseOrderScreenDataRepository(
                   IDbContextProvider<ERPDbContext> dbContextProvider,
                   IActiveTransactionProvider activeTransactionProvider
               ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
