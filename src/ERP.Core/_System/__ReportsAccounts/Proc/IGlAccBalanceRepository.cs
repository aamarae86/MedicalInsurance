using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System._GlAccDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Proc
{
    public interface IGlAccBalanceRepository
          : IExecuteProcedure<GlAccDetails, long, GlAccBalanceInput, GlAccBalanceOutput>  { }
}
