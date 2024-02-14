using Abp.Application.Services;
using ERP._System.__Warehouses._IvReturnReceiveHd.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvReturnReceiveHd
{
    public interface IIvReturnReceiveHdAppService : IAsyncCrudAppService<IvReturnReceiveHdDto, long, IvReturnReceiveHdPagedDto, IvReturnReceiveHdCreateDto, IvReturnReceiveHdEditDto>
    {
        //Task<IvReturnSaleHdDto> GetDetailAsync(EntityDto<long> input);
        //Task<PostRecords.Dto.PostOutput> PostReturnSale(PostRecords.Dto.PostDto postDto);
    }



    
}
