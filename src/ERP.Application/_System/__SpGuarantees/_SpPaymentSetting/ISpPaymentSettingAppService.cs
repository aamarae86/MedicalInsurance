using Abp.Application.Services;
using ERP._System.__SpGuarantees._SpPaymentSetting.Dto;

namespace ERP._System.__SpGuarantees._SpPaymentSetting
{
    public interface ISpPaymentSettingAppService : IAsyncCrudAppService<SpPaymentSettingDto, long, SpPaymentSettingPagedDto, SpPaymentSettingCreateDto, SpPaymentSettingEditDto>
    {
    }
}
