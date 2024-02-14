using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._DocumentRequestType.Dto
{
   public class DocumentRequestTypePagedDto : PagedAndSortedResultRequestDto
    {
        public DocumentRequestTypeSearchedDto Params { get; set; }
    }
}
