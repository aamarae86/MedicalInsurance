using Abp.Application.Services.Dto;

namespace ERP._System.__SpGuarantees._SpPaymentSetting.Dto
{
    public class SpPaymentSettingPagedDto : PagedAndSortedResultRequestDto
    {
        public SpPaymentSettingSearchDto Params { get; set; }
    }
}
