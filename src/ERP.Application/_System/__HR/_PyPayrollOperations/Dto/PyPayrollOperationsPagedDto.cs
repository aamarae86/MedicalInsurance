using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    public class PyPayrollOperationsPagedDto : PagedAndSortedResultRequestDto, ISortModel
    {
        public PyPayrollOperationsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
