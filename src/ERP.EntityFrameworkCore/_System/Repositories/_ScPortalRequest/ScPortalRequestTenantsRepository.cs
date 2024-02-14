using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System.__AidModule._ScPortalRequest.Proc;
using ERP._System.__AidModule._ScPortalRequest.Proc.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScPortalRequest
{
    public class ScPortalRequestTenantsRepository :
        ERPProcedureRepositoryBase<ScPortalRequest, long, AvailableTenantsDto, TenantsOutput>,
        IScPortalRequestTenantsRepository
    {
        public ScPortalRequestTenantsRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
