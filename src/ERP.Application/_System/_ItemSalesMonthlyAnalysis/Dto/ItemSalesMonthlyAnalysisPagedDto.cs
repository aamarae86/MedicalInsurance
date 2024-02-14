using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemSalesMonthlyAnalysis.Dto
{
   public class ItemSalesMonthlyAnalysisPagedDto : PagedAndSortedResultRequestDto
    {
        public ItemSalesMonthlyAnalysisSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
