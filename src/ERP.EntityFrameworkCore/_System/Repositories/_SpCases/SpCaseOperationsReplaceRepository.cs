using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations.Proc;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._SpCases
{
    public class SpCaseOperationsReplaceRepository : ERPProcedureRepositoryBase<SpCaseOperations, long, SpCaseOperationsReplaceInputDto, PostOutput>,
        ISpCaseOperationsReplaceRepository
    {
        public SpCaseOperationsReplaceRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
