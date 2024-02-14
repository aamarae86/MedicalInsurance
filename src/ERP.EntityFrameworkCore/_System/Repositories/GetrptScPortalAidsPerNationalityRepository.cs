using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;
using ERP._System.__ReportsAids.Proc;
using ERP._System.__ReportsPms.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories
{
    public class GetrptScPortalAidsPerNationalityRepository :
    ERPProcedureRepositoryBase<PmPropertiesUnits, long, rptScPortalAidsPerNationalityInput, rptScPortalAidsPerNationalityOutput>, IGetrptScPortalAidsPerNationalityRepository
    {
        public GetrptScPortalAidsPerNationalityRepository(
            IDbContextProvider<ERPDbContext> dbContextProvider,
            IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
