using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Proc
{
    public interface IPmPropertiesUnitsUnoccupiedRepository:
        IExecuteProcedure<PmPropertiesUnits, long, PmPropertiesUnitsUnoccupiedInput, PmPropertiesUnitsUnoccupiedOutput>
    {
    }
}
