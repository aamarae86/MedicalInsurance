using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto
{
    public class ArInvoiceSettlementHdPagedDto : PagedAndSortedResultRequestDto
    {
        public ArInvoiceSettlementHdSearchDto Params { get; set; }
    }
}
