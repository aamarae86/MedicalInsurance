using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using ERP.MultiTenancy.Input;
using ERP.MultiTenancy.Output;
using ERP.MultiTenancy.Proc;

namespace ERP._System.Repositories._Common
{
    public class CheckDublicatedEmailAbpUserRepository : ERPProcedureRepositoryBase<User, long, CheckDublicatedEmailAbpUserInput, DublicatedEmailAbpUserOutput>, ICheckDublicatedEmailAbpUserRepository
    {
        public CheckDublicatedEmailAbpUserRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
