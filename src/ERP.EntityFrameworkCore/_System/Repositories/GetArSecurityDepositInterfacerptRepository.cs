using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArSecurityDepositInterface;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Input;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System._ArSecurityDepositInterface;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories
{
    public class GetArSecurityDepositInterfacerptRepository : ERPProcedureRepositoryBase<ArSecurityDepositInterface, long, GetArSecurityDepositInterfacerptInput, GetArSecurityDepositInterfacerptOutput>,
              IGetArSecurityDepositInterfacerptRepository
    {
        public GetArSecurityDepositInterfacerptRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
