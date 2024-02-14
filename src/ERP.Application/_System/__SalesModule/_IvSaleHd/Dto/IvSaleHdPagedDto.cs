using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__SalesModule._IvSaleHd.Dto
{
    public class IvSaleHdPagedDto : PagedAndSortedResultRequestDto
    {
        public IvSaleHdSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }

}
