using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModuleExtend._ApPrepaid.Dto;
using ERP._System.PostRecords.Dto;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._ApPrepaid
{
    public interface IApPrepaidAppService : IAsyncCrudAppService<ApPrepaidDto, long, PagedApPrepaidResultRequestDto, ApPrepaidCreateDto, ApPrepaidEditDto>
    {
        Task<ApPrepaidDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostApPrepaid(PostDto idLangInputDto);

    }
}
