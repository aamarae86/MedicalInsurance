using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd.Dto
{
    public class PagedArJobCardPaymentHdResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArJobCardPaymentHdSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
