using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ArInvoiceSettlementHdRepository :
        ERPProcedureRepositoryBase<ArInvoiceSettlementHd, long, PostDto, PostOutput>
        ,
        IArInvoiceSettlementHdRepository
    {
        public ArInvoiceSettlementHdRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
