using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvItems.Dto
{
    public class IvItemsPagedDto : PagedAndSortedResultRequestDto
    {
        public IvItemsSearchDto Params { get; set; }
    }
}
