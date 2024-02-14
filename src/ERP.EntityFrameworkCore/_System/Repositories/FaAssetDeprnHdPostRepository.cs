using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._FaAssetDeprn;
using ERP._System.__AccountModule._FaAssetDeprn.Proc;
using ERP._System.__AccountModuleExtend._FaAssets;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class FaAssetDeprnHdPostRepository :
    ERPProcedureRepositoryBase<FaAssetDeprnHd, long, PostDto, PostOutput>,
    IFaAssetDeprnHdPostRepository
    {
        public FaAssetDeprnHdPostRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
