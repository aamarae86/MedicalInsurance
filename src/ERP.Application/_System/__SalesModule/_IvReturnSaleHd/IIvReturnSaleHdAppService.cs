using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__SalesModule._IvReturnSaleHd.Dto;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__SalesModule._IvReturnSaleHd
{
    public interface IIvReturnSaleHdAppService : IAsyncCrudAppService<IvReturnSaleHdDto, long, IvReturnSaleHdPagedDto, IvReturnSaleHdCreateDto, IvReturnSaleHdEditDto>
    {
        Task<IvReturnSaleHdDto> GetDetailAsync(EntityDto<long> input);
        Task<PostRecords.Dto.PostOutput> PostReturnSale(PostRecords.Dto.PostDto postDto);
    }
}
