using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using ERP._System.__SpGuaranteesReports.Inputs;
using ERP._System.__SpGuaranteesReports.Outputs;
using ERP._System.__SpGuaranteesReports.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._SpCases
{
    public class GetSpCaseListrptRepository : ERPProcedureRepositoryBase<SpCaseOperations, long, GetSpCaseListrptInput, GetSpCaseListrptOutput>,
        IGetSpCaseListrptRepository
    {
        public GetSpCaseListrptRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
