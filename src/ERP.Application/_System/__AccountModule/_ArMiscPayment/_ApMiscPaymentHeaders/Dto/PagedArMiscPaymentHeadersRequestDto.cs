using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto
{
    public class PagedArMiscPaymentHeadersRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArMiscPaymentHeadersSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
