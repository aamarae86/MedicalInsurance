using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._HR
{
    public class HrPersonsAdditionPostRepository : ERPProcedureRepositoryBase<HrPersonsAdditionHd, long, PostDto, PostOutput>,
    IHrPersonsAdditionPostRepository
    {
        public HrPersonsAdditionPostRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
