using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModuleExtend._FaAssets;
using ERP._System.__AccountModuleExtend._FaAssets.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class FaAssetsPostRepository :
    ERPProcedureRepositoryBase<FaAssets, long, PostDto, PostOutput>,
    IFaAssetsPostRepository
    {
        public FaAssetsPostRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
