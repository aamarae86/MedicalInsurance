using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System._GlPeriods.Dto
{
    [AutoMap(typeof(GlPeriodsYears))]
    public class PagedGlPeriodsYearsResultRequestDto : PagedAndSortedResultRequestDto, ISortModel
    {
        public GlPeriodsYearsSearchDto Params { get; set; }
        public SortModel OrderByValue { get ; set ; }
    }
}
