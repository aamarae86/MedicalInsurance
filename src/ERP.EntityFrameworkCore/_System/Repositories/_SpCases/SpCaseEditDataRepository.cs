using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__SpGuarantees._SpCaseEditData;
using ERP._System.__SpGuarantees._SpCases._SpCaseEditData.Proc;
using ERP._System.__SpGuarantees._SpCases._SpCaseEditData.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._SpCases
{
    public class SpCaseEditDataRepository : ERPProcedureRepositoryBase<SpCaseEditData, long, SpCaseEditDataInputDto, PostOutput>,
        ISpCaseEditDataRepository
    {
        public SpCaseEditDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
