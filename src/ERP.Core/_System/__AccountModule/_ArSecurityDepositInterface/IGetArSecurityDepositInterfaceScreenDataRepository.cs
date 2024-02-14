using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System._ArSecurityDepositInterface;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArSecurityDepositInterface
{
    public interface IGetArSecurityDepositInterfaceScreenDataRepository :
        IExecuteProcedure<ArSecurityDepositInterface, long, IdLangInputDto, GetArSecurityDepositInterfaceScreenDataOutput>
    {
    }
}
