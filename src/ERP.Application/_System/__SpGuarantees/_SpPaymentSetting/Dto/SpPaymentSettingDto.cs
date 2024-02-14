using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;

namespace ERP._System.__SpGuarantees._SpPaymentSetting.Dto
{
    [AutoMap(typeof(SpPaymentSetting))]
    public class SpPaymentSettingDto : AuditedEntityDto<long>
    {
        public long SponsorCategoryLkpId { get; set; }

        public decimal ManagementPercentage { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public FndLookupValuesDto FndSponsorCategoryLkp { get; set; }
    }
}
