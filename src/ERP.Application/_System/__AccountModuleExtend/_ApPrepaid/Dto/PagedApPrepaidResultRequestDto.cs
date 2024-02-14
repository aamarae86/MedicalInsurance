using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModuleExtend._ApPrepaid.Dto
{
    public class PagedApPrepaidResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ApPrepaidSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }
}
