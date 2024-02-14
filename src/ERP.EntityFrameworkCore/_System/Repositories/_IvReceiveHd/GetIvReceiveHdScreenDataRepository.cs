using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System.__Warehouses._IvReceiveHd.Proc;
using ERP._System.__Warehouses._IvReceiveHd.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._IvReceiveHd
{
    public class GetIvReceiveHdScreenDataRepository : ERPProcedureRepositoryBase<IvReceiveHd, long, IdLangInputDto, IvReceiveHdScreenDataOutput>,
        IGetIvReceiveHdScreenDataRepository
    {
        public GetIvReceiveHdScreenDataRepository(
                      IDbContextProvider<ERPDbContext> dbContextProvider,
                      IActiveTransactionProvider activeTransactionProvider
                  ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
