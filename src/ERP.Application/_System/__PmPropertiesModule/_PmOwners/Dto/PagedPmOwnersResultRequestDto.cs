using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmOwners.Dto
{
    [AutoMapFrom(typeof(PmOwners))]
    public class PagedPmOwnersResultRequestDto : PagedAndSortedResultRequestDto, ISortModel
    {
        public PmOwnersSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }
}
