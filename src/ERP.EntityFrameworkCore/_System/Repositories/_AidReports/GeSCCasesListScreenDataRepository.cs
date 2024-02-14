using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;
using ERP._System.__ReportsAids.Proc;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._AidReports
{
    public class GeSCCasesListScreenDataRepository:
         ERPProcedureRepositoryBase<PortalUser, long, GeSCCasesListScreenDataInput, GeSCCasesListScreenDataOutput>, IGeSCCasesListScreenDataRepository
    {
        public GeSCCasesListScreenDataRepository(
            IDbContextProvider<ERPDbContext> dbContextProvider,
            IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
