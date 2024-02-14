using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PyElements.Dto
{
    public class PyElementsPagedDto : PagedAndSortedResultRequestDto
    {
        public PyElementsSearchDto Params { get; set; }
    }
}
