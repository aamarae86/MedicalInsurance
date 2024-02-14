using ERP._System.__AccountModuleExtend._FaAssets;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Proc
{
    public interface IGetFaAssetListDataRepository
        : IExecuteProcedure<FaAssets, long, GetFaAssetListDataInput, GetFaAssetListDataOutput>
    {
    }
}
