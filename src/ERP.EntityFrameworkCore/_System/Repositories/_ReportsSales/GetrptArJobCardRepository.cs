using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__ReportsSales.Input;
using ERP._System.__ReportsSales.Output;
using ERP._System.__ReportsSales.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ReportsSales
{
    public class GetrptArJobCardRepository: ERPProcedureRepositoryBase<ArJobCardHd, long, ArJobCardInput, ArJobCardOutput>, IGetrptArJobCardRepository
    {
        public GetrptArJobCardRepository(
                 IDbContextProvider<ERPDbContext> dbContextProvider,
                 IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
