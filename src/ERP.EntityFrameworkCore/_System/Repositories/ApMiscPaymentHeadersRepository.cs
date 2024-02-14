using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ApMiscPaymentHeadersRepository :
        ERPProcedureRepositoryBase<ApMiscPaymentHeaders, long, PostDto, PostOutput>
        ,
        IApMiscPaymentHeadersRepository
    {
        public ApMiscPaymentHeadersRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
