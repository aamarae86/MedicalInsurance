using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__AccountModule._ApInvoiceHd.ProcDto;
using ERP._System.__AccountModule._ApInvoiceHd.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class GetApInvoiceHdScreenDataRepository : ERPProcedureRepositoryBase<ApInvoiceHd, long, IdLangInputDto, ApInvoiceHdScreenDataOutput>,
        IGetApInvoiceHdScreenDataRepository
    {
        public GetApInvoiceHdScreenDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        {}
    }
}
