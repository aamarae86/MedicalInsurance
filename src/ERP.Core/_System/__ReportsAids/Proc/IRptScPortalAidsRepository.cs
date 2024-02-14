using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;

namespace ERP._System.__ReportsAids.Proc
{
    public interface IRptScPortalAidsRepository : IExecuteProcedure<PmPropertiesUnits, long, RptScPortalAidsInput, RptScPortalAidsOutput>
    { }
}
