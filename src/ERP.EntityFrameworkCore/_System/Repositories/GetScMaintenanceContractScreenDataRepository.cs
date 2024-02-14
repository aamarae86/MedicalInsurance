using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScMaintenanceContract;
using ERP._System.__AidModule._ScMaintenanceContract.Proc;
using ERP._System.__AidModule._ScMaintenanceContract.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class GetScMaintenanceContractScreenDataRepository : ERPProcedureRepositoryBase<ScMaintenanceContract, long, IdLangInputDto, GetScMaintenanceContractScreenDataOutputDto>,
        IGetScMaintenanceContractScreenDataRepository
    {
        public GetScMaintenanceContractScreenDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        {}
    }
}
