using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__SalesModule._IvReturnSaleHd;
using ERP._System.__SalesModule._IvReturnSaleHd.Proc;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__SalesModule._IvSaleHd.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using ERP._System.__Warehouses._IvReturnReceiveHd.Proc;
using ERP._System.__Warehouses._IvReturnReceiveHd;

namespace ERP._System.Repositories._IvReturnReceiveHd
{
    public class IvReturnReceiveHdPostRepository : ERPProcedureRepositoryBase<IvReturnReceiveHd, long, PostDto, PostOutput>, IIvReturnReceiveHdPostRepository
    {
        public IvReturnReceiveHdPostRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }



   
}
