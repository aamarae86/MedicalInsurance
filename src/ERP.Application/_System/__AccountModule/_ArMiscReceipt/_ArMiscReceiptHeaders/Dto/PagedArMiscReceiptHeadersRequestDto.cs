using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto
{
    public class PagedArMiscReceiptHeadersRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArMiscReceiptHeadersSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
