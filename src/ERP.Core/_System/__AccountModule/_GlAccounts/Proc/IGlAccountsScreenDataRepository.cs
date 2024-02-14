using ERP._System.__AccountModule._GlAccounts.ProcDto;
using ERP._System._GlAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._GlAccounts.Proc
{
    public interface IGlAccountsScreenDataRepository: IExecuteProcedure<GlAccounts, long, GlAccountsScreenDataInput, GlAccountsScreenDataOutput>
    {
    }
}
