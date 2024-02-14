using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApInvoiceHd.Dto
{
    public class PagedApInvoiceHdResultRequestDto : PagedResultRequestDto
    {
        public ApInvoiceHdSearchDto Params { get; set; }
    }
}
