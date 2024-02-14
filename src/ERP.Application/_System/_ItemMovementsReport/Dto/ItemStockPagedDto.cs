using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemMovementsReport.Dto
{
    public class ItemStockPagedDto : PagedAndSortedResultRequestDto
    {
        public ItemStockSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
