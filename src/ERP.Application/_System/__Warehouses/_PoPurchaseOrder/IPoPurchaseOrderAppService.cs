using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses._PoPurchaseOrder.Dto;
using ERP._System.__Warehouses._PoPurchaseOrder.ProcDto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._PoPurchaseOrder
{
    public interface IPoPurchaseOrderAppService : IAsyncCrudAppService<PoPurchaseOrderDto, long, PoPurchaseOrderPagedDto, PoPurchaseOrderCreateDto, PoPurchaseOrderEditDto>
    {
        Task<PoPurchaseOrderDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostPoPurchaseOrder(PostDto idLangInputDto);

        Task<List<PoPurchaseOrderScreenDataOutput>> GetPoPurchaseOrderScreenData(IdLangInputDto input);
    }
}
