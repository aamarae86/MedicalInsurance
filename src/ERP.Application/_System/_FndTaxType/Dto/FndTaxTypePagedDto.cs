using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System._FndTaxType
{
    public class FndTaxTypePagedDto : PagedAndSortedResultRequestDto
    {
        public FndTaxTypeSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }


 
}
