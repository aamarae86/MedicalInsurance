using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmTenants.Dto
{
    [AutoMapFrom(typeof(PmTenants))]
    public class PagedPmTenantsResultRequestDto : PagedAndSortedResultRequestDto, ISortModel
    {
        public PmTenantsSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }
}
