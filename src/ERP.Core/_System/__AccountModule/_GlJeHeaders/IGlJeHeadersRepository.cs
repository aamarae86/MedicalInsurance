using ERP._System.PostRecords.Dto;

namespace ERP._System._GlJeHeaders
{
    public interface IGlJeHeadersRepository
         : IExecuteProcedure<GlJeHeaders, long, PostDto, PostOutput>
    {
    }
}
