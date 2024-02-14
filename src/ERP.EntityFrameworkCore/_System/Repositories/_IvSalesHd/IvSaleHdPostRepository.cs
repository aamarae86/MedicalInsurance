using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__SalesModule._IvSaleHd.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._IvSalesHd
{ 
    public class IvSaleHdPostRepository : ERPProcedureRepositoryBase<IvSaleHd, long, PostDto, PostOutput>,IIvSaleHdPostRepository
    {
        public IvSaleHdPostRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
