using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__Warehouses._PoPurchaseOrder;
using ERP._System.__Warehouses._PoPurchaseOrder.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class PoPurchaseOrderPostRepository :
    ERPProcedureRepositoryBase<PoPurchaseOrderHd, long, PostDto, PostOutput>,
    IPoPurchaseOrderPostRepository
    {
        public PoPurchaseOrderPostRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
