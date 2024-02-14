using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System._ApPdcInterface.Dto;
using ERP._System.PostRecords.Dto;
using System.Threading.Tasks;

namespace ERP._System._ApPdcInterface
{
    public interface IApPdcInterfaceAppService : IAsyncCrudAppService<ApPdcInterfaceDto, long, PagedApPdcInterfaceResultRequestDto, CreateApPdcInterfaceDto, ApPdcInterfaceEditDto>
    {
        Task<ApPdcInterfaceDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostApPdcInterface(PostDto input);

        Task<PostOutput> RetrieveApPdcInterface(PostDto input);
    }
}
