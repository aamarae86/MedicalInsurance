using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System._GlAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Proc
{
    public interface IGlAccountsScreenDatarptRepository:
        IExecuteProcedure<GlAccounts, long, GlAccountsScreenDatarptInput, GlAccountsScreenDatarptOutput>
    {
    }
}
