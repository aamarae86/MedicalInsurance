using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ArJobCardPaymentHdRepository : ERPProcedureRepositoryBase<ArJobCardPaymentHd, long, PostDto, PostOutput>,
                                                IArJobCardPaymentHdRepository
    {
        public ArJobCardPaymentHdRepository(IDbContextProvider<ERPDbContext> dbContextProvider,
                                            IActiveTransactionProvider activeTransactionProvider)
                                           : base(dbContextProvider, activeTransactionProvider)
        {

        }

    }

}
