using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System._ArPdcInterface.Dto;
using ERP._System.PostRecords.Dto;
using System.Threading.Tasks;

namespace ERP._System._ArPdcInterface
{
    public interface IArPdcInterfaceAppService : IAsyncCrudAppService<ArPdcInterfaceDto, long, PagedArPdcInterfaceResultRequestDto, ArPdcInterfaceDto, ArPdcInterfaceEditDto>
    {
        Task<ArPdcInterfaceDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostArPdcInterface(PostDto input);

        Task<PostOutput> RetrieveArPdcInterface(PostDto input);
    }
}
