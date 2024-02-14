using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Proc
{
    public interface IPmContractNotRenewedRepository:
        IExecuteProcedure<PmContract, long, PmContractNotRenewedInput, PmContractNotRenewedOutput>
    {
    }
}
