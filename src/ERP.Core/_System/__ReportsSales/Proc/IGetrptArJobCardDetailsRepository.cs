using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using ERP._System.__ReportsSales.Input;
using ERP._System.__ReportsSales.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsSales.Proc
{
    public interface IGetrptArJobCardDetailsRepository:IExecuteProcedure<ArJobCardHd, long, ArJobCardDetailsInput, ArJobCardDetailsOutput>
    {
    }
}
