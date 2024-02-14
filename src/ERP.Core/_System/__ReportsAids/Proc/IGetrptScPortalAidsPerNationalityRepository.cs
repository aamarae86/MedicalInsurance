using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAids.Proc
{
    public interface IGetrptScPortalAidsPerNationalityRepository:
        IExecuteProcedure<PmPropertiesUnits, long, rptScPortalAidsPerNationalityInput, rptScPortalAidsPerNationalityOutput>
    {
    }
}
