using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System._ItemQtyPerWarehouseReport.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ItemQtyPerWarehouseReport
{
    public class ItemQtyPerWarehouseAppService : ERPAppServiceBase, IItemQtyPerWarehouseAppService
    {
        private readonly IItemQtyPerWarehouseRepository _itemReportRepository;

        public ItemQtyPerWarehouseAppService(IItemQtyPerWarehouseRepository itemReportRepository)
        {
            _itemReportRepository = itemReportRepository;
        }

        public async Task<PagedResultDto<ItemQtyPerWarehouseDto>> GetItemQtyPerWarehouse(ItemQtyPerWarehousePagedDto input)
        {
            var mapped = ObjectMapper.Map<ItemQtyPerWarehouseInput>(input);

            try
            {

                var result = await _itemReportRepository.Execute(mapped, "rptIvWarehouseItemsOnHandQty");

                var list= result.ToList<GetItemQtyPerWarehouseOutput>();
                
                var PagedResultDto = new PagedResultDto<ItemQtyPerWarehouseDto>()
                {
                    Items = list as IReadOnlyList<ItemQtyPerWarehouseDto>,
                    TotalCount = list.Count
                };
                return PagedResultDto;
                //return items;
            }
            catch 
            {
                return null;               
            }

        }
  

    }
}
