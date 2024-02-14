using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArSecurityDepositInterface;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System._ArSecurityDepositInterface;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories
{
    public class GetArSecurityDepositInterfaceScreenDataRepository : ERPProcedureRepositoryBase<ArSecurityDepositInterface, long, IdLangInputDto, GetArSecurityDepositInterfaceScreenDataOutput>,
              IGetArSecurityDepositInterfaceScreenDataRepository
    {
        public GetArSecurityDepositInterfaceScreenDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
