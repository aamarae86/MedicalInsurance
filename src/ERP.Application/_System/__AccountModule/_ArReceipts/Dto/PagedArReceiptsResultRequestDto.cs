using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ArReceipts.Dto
{
    [AutoMapFrom(typeof(ArReceipts))]
    public class PagedArReceiptsResultRequestDto : PagedAndSortedResultRequestDto, ISortModel
    {
        public ArReceiptsSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }

}
