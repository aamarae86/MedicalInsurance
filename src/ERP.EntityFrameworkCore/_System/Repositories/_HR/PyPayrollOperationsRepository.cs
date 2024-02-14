using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__HR._PyPayrollOperations;
using ERP._System.__HR._PyPayrollOperations.Input;
using ERP._System.__HR._PyPayrollOperations.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._HR
{
    public class PyPayrollOperationsRepository : ERPProcedureRepositoryBase<PyPayrollOperations, long, StoredInput, PostOutput>,
        IPyPayrollOperationsRepository
    {
        public PyPayrollOperationsRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider)
            : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
