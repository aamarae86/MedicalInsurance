using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument.Dto
{
    public class HrPersonRequestDocumentPagedDto : PagedAndSortedResultRequestDto
    {
        public HrPersonRequestDocumentSearchDto Params { get; set; }
    
    }
}
