using ERP._System._GlJeHeaders.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System._GlJeHeaders.Procs
{
    public interface IJeNumberRepository
          : IExecuteProcedure<GlJeHeaders, long, JeNumberPostDto, StringOutput>
    { }
}
