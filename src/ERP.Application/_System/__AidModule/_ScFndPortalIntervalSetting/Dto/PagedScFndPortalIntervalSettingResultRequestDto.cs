using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScFndPortalIntervalSetting.Dto
{
    public class PagedScFndPortalIntervalSettingResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ScFndPortalIntervalSettingSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
