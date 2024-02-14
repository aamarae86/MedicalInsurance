using Abp.Application.Services;
using ERP._System.__AidModule._ScFndPortalIntervalSetting.Dto;

namespace ERP._System.__AidModule._ScFndPortalIntervalSetting
{
    public interface IScFndPortalIntervalSettingAppService : IAsyncCrudAppService<ScFndPortalIntervalSettingDto, long, PagedScFndPortalIntervalSettingResultRequestDto, CreateScFndPortalIntervalSettingDto, ScFndPortalIntervalSettingEditDto>
    {
    }
}
