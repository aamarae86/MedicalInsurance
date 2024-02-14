using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using ERP._System.__ReportsPms.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ReportsPms
{
    public class PmContractsRepository:
        ERPProcedureRepositoryBase<PmContract, long, PmContractsInput, PmContractsOutput>, IPmContractsRepository
    {
        public PmContractsRepository(
                 IDbContextProvider<ERPDbContext> dbContextProvider,
                 IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
