using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemSalesAnalysis.Dto
{
   public class ItemSalesAnalysisPagedDto : PagedAndSortedResultRequestDto
    {
        public ItemSalesAnalysisSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
