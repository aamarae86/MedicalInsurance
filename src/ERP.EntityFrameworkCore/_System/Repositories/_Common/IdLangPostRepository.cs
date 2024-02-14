using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._PyPayrollOperations.Input;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._Common
{
    public class IdLangPostRepository : ERPProcedureRepositoryBase<HrPersonsAdditionHd, long, IdLangInputDto, PostOutput>,
        IIdLangPostRepository
    {
        public IdLangPostRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider)
            : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
