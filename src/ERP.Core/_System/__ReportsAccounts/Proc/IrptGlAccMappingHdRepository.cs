using ERP._System.__AccountModule._GlAccMappingHd;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Proc
{
    public interface IGetRptGlAccMappingHdRepository :
        IExecuteProcedure<GlAccMappingHd, long, rptGlAccMappingHdInput, rptGlAccMappingHdOutput>
    {
    }
}
