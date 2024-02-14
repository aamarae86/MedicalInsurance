using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ApInvoiceHd.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApInvoiceHd
{
    public interface IApInvoiceHdAppService : IAsyncCrudAppService<ApInvoiceHdDto, long, PagedApInvoiceHdResultRequestDto, ApInvoiceHdCreateDto, ApInvoiceHdEditDto>
    {
        Task<ApInvoiceHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ApInvoiceTrDto>> GetAllDetails(long id);

        Task<PostOutput> PostApInvoiceHd(PostDto postDto);
    }
}
