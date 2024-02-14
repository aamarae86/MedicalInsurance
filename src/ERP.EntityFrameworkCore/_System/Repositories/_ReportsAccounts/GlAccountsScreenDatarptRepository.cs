using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System._GlAccounts;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ReportsAccounts
{
    public class GlAccountsScreenDatarptRepository:
        ERPProcedureRepositoryBase<GlAccounts, long, GlAccountsScreenDatarptInput, GlAccountsScreenDatarptOutput>, IGlAccountsScreenDatarptRepository
    {
        public GlAccountsScreenDatarptRepository(
         IDbContextProvider<ERPDbContext> dbContextProvider,
         IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
