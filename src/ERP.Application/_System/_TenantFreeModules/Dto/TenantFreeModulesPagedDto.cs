using Abp.Application.Services.Dto;
using ERP._System._TenantFreeModules.Dto;
using ERP.Core.Helpers.Extensions;

namespace ERP._System._TenantFreeModules.Dto
{
    public class TenantFreeModulesPagedDto  : PagedAndSortedResultRequestDto
    {
        public TenantFreeModulesSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
