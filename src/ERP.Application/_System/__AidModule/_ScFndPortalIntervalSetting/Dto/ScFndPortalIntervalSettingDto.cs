using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__AidModule._ScFndPortalIntervalSetting.Dto
{
    [AutoMap(typeof(ScFndPortalIntervalSetting))]
    public class ScFndPortalIntervalSettingDto : AuditedEntityDto<long>
    {
        public string FromDate { get; set; }

        public string FromTime { get; set; }

        public string ToDate { get; set; }

        public string ToTime { get; set; }

        public int NumberOfRequest { get; set; }

        public bool dateRangeValidation { get; set; }
    }
}
