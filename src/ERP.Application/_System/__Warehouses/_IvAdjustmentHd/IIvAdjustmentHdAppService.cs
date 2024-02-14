using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses._IvAdjustmentHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvAdjustmentHd
{
    public interface IIvAdjustmentHdAppService : IAsyncCrudAppService<IvAdjustmentHdDto, long, PagedIvAdjustmentHdRequestDto, CreateIvAdjustmentHdDto, IvAdjustmentHdEditDto>
    {
        Task<(long id, string name)> GetAdjustmentHdAdjustmentStoredEntryType(string lang = "ar-EG");

        Task<PostOutput> PostIvAdjustmentHd(PostDto postDto);

        Task<IvAdjustmentHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<IvAdjustmentTrDto>> GetAllAdjustmentTr(EntityDto<long> input);

        Task<GetNumberQtyOutput> GetNumberQty(GetNumberQtyInput getNumberQtyInput);

        Task<Select2PagedResult> GetIvWarehousesByUserIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
