using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ArInvoiceHdRepository :
        ERPProcedureRepositoryBase<ArInvoiceHd, long, PostDto, PostOutput>
        ,
        IArInvoiceHdRepository
    {
        public ArInvoiceHdRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
