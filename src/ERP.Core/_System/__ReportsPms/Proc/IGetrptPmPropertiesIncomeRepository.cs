using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Proc
{
    public interface IGetrptPmPropertiesIncomeRepository : IExecuteProcedure<PmProperties, long, rptPmPropertiesIncomeInput, rptPmPropertiesIncomeOutput>
    {
    }
}
