using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__SalesModule._IvReturnSaleHd.Dto
{
    public class IvReturnSaleHdPagedDto : PagedAndSortedResultRequestDto
    {
        public IvReturnSaleHdSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
