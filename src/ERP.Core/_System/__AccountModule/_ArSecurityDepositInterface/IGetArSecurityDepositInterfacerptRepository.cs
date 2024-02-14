using ERP._System.__AccountModule._ArSecurityDepositInterface.Input;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System._ArSecurityDepositInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArSecurityDepositInterface
{
    public interface IGetArSecurityDepositInterfacerptRepository:
        IExecuteProcedure<ArSecurityDepositInterface, long, GetArSecurityDepositInterfacerptInput, GetArSecurityDepositInterfacerptOutput>
    {
    }
}
