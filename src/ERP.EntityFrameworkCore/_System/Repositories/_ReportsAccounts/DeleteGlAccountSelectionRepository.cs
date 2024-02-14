﻿using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System._GlAccDetails;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ReportsAccounts
{
    public class DeleteGlAccountSelectionRepository :
          ERPProcedureRepositoryBase<GlAccDetails, long, GlAccountSelectionDeleteInput, GlAccountSelectionOutput>, IDeleteGlAccountSelectionRepository
    {
        public DeleteGlAccountSelectionRepository(
            IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider)
            : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
