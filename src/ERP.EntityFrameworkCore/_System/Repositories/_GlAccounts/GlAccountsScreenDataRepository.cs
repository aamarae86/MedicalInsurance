using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._GlAccounts.Proc;
using ERP._System.__AccountModule._GlAccounts.ProcDto;
using ERP._System._GlAccounts;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._GlAccounts
{
    public class GlAccountsScreenDataRepository:
        ERPProcedureRepositoryBase<GlAccounts, long, GlAccountsScreenDataInput, GlAccountsScreenDataOutput>,
        IGlAccountsScreenDataRepository
    {
        public GlAccountsScreenDataRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
