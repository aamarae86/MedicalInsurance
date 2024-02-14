using ERP._System._Counters.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System._Counters.Procs
{
    public interface IGetCounterRepository : IExecuteProcedure<Counters, long, GetCounterInputDto, StringOutput>
    {
    }
}
