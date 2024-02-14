using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using ERP._System.__SpGuaranteesReports.Inputs;
using ERP._System.__SpGuaranteesReports.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuaranteesReports.Proc
{
    public interface IGetSpCaseListrptRepository : IExecuteProcedure<SpCaseOperations, long, GetSpCaseListrptInput, GetSpCaseListrptOutput>
    {
    }
}
