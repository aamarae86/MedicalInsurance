using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModuleExtend._FaAssets;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ReportsAccounts
{
    public class GetFaAssetListDataRepository :
        ERPProcedureRepositoryBase<FaAssets, long, GetFaAssetListDataInput, GetFaAssetListDataOutput>, IGetFaAssetListDataRepository
    {
        public GetFaAssetListDataRepository(
         IDbContextProvider<ERPDbContext> dbContextProvider,
         IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
