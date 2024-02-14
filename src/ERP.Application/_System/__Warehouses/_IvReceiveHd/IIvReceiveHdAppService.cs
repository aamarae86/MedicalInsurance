using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses._IvReceiveHd.Dto;
using ERP._System.__Warehouses._IvReceiveHd.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvReceiveHd
{
    public interface IIvReceiveHdAppService : IAsyncCrudAppService<IvReceiveHdDto, long, IvReceiveHdPagedDto, IvReceiveHdCreateDto, IvReceiveHdEditDto>
    {
        Task<PostOutput> PostIvReceiveHd(PostDto postDto);

        Task<IvReceiveHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<IvReceiveTrDto>> GetItemsPurchaseOrder(long purchaseOrderId, long receiveTypeLkpId);

        Task<List<IvReceiveTrDto>> GetIvReceiveTrDetails(EntityDto<long> input);

        Task<Select2PagedResult> GetIvItemsSelect2(long IvReceiveHdReceiveTypeId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetIvUnitsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPurchaseOrderSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetIvUserWarehousesPrivilegesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<List<IvReceiveHdScreenDataOutput>> GetIvReceiveHdScreenData(IdLangInputDto input);
    }
}
