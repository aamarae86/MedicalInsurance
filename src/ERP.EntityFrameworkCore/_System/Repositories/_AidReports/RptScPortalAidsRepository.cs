using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;
using ERP._System.__ReportsAids.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._AidReports
{
    public class RptScPortalAidsRepository : ERPProcedureRepositoryBase<PmPropertiesUnits, long, RptScPortalAidsInput, RptScPortalAidsOutput>,
        IRptScPortalAidsRepository
    {
        public RptScPortalAidsRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
