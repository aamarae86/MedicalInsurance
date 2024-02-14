using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System._ApPdcInterface;
using ERP._System._ArPdcInterface;

namespace ERP._System.__AccountModule._ApPdcInterface.Proc
{
    public interface IGetApPdcInterfaceDataRepository : IExecuteProcedure<ApPdcInterface, long, GetApPdcInterfaceDataInput, GetApPdcInterfaceDataOutput>
    {}

    public interface IGetArPdcInterfaceDataRepository : IExecuteProcedure<ArPdcInterface, long, GetArPdcInterfaceDataInput, GetArPdcInterfaceDataOutput>
    { }
}
