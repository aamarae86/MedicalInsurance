using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__HR._HrPersonVacations;
using ERP._System.__HR._HrPersonVacations.Input;
using ERP._System.__HR._HrPersonVacations.Output;
using ERP._System.__HR._HrPersonVacations.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._HR
{
    public class GetVacationsBalanceRepository : ERPProcedureRepositoryBase<HrPersonVacations, long, GetVacationsBalanceInput, GetVacationsBalanceOutput>,
        IGetVacationsBalanceRepository
    {
        public GetVacationsBalanceRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
