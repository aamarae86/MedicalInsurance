using Abp.Application.Services.Dto;
using ERP._System._ItemSalesAnalysis.Dto;
using ERP._System._ItemSalesMonthlyAnalysis.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ItemSalesAnalysis
{
   public interface IItemSalesAnalysisAppService
    {
        Task<PagedResultDto<ItemSalesAnalysisDto>> GetItemSalesAnalysis(ItemSalesAnalysisPagedDto input);
    }
}
