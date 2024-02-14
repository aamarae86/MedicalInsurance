using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;

namespace ERP._System.__CRM._CrmLeadsPersons.Dto
{
    public class CrmLeadsPersonsPagedDto  : PagedAndSortedResultRequestDto
    {
        public CrmLeadsPersonsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
