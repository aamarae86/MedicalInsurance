using Abp.Application.Services;
using ERP._System.__SpGuarantees._SpPayments.Dto;
using ERP._System.PostRecords.Dto;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpPayments
{
    public interface ISpPaymentsAppService : IAsyncCrudAppService<SpPaymentsDto, long, SpPaymentsPagedDto, SpPaymentsCreateDto, SpPaymentsEditDto>
    {
        Task<PostOutput> SpPaymentsApprove(PostDto postDto);

        Task<PostOutput> SpPaymentsUnApprove(PostDto postDto);

        Task<PostOutput> SpPaymentsPost(PostDto postDto);
    }
}
