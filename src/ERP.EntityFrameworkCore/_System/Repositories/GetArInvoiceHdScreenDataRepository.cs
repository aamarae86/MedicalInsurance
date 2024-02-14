using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__PmPropertiesModule._ArInvoiceHd.Proc;
using ERP._System.__PmPropertiesModule._ArInvoiceHd.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class GetArInvoiceHdScreenDataRepository : ERPProcedureRepositoryBase<ArInvoiceHd, long, IdLangInputDto, ArInvoiceHdScreenDataOutput>,
        IGetArInvoiceHdScreenDataRepository
    {
        public GetArInvoiceHdScreenDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
