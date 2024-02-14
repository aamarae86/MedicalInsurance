using Abp.Application.Services.Dto;
using ERP._System._ItemSalesMonthlyAnalysis.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ItemSalesMonthlyAnalysis
{
   public interface IItemSalesMonthlyAnalysisAppService
    {
        Task<PagedResultDto<ItemSalesMonthlyAnalysisDto>> GetItemSalesMonthlyAnalysis(ItemSalesMonthlyAnalysisPagedDto input);
    }
}
