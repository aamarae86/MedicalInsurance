using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__SpGuarantees._SpPaymentSetting.Dto
{
    [AutoMap(typeof(SpPaymentSetting))]
    public class SpPaymentSettingEditDto : EntityDto<long>
    {
        public long SponsorCategoryLkpId { get; set; }

        public decimal ManagementPercentage { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}
