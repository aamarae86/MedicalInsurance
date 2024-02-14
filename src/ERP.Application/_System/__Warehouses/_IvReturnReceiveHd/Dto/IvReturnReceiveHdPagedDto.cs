using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._IvReturnReceiveHd.Dto
{
    public class IvReturnReceiveHdPagedDto : PagedAndSortedResultRequestDto
    {
        public IvReturnReceiveHdSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
   
}
