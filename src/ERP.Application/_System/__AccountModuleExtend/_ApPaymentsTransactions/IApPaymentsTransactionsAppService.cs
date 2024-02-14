using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto;
using ERP._System.PostRecords.Dto;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions
{
    public interface IApPaymentsTransactionsAppService : IAsyncCrudAppService<ApPaymentsTransactionsDto, long, PagedApPaymentsTransactionsResultRequestDto, ApPaymentsTransactionsCreateDto, ApPaymentsTransactionsEditDto>
    {
        Task<ApPaymentsTransactionsDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostApPaymentsTransactions(PostDto postDto);
    }
}
