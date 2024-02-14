using Abp.Application.Services.Dto;
using ERP._System._ItemMovementsReport.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ItemMovementsReport
{
    public interface IItemMovementsAppService
    {
        Task<PagedResultDto<ItemMovementDto>> GetItemMovements(ItemMovementPagedDto input);
        Task<PagedResultDto<ItemMovementDto>> GetItemsMovementsReport(ItemMovementPagedDto obj);
        Task<PagedResultDto<dynamic>> GetItemStock(ItemStockPagedDto input);
    }
}
