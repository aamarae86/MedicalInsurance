using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    [AutoMap(typeof(ScMaintenanceTechnicalReportDetail))]
    public class ScMaintenanceTechnicalReportDetailDto : EntityDto<long>, IDetailRowStatus //: ScMaintenanceTechnicalReportDetailBaseDto
    {
        public long ScMaintenanceTechnicalReportId { get; set; }

        public string ItemDescription { get; set; }

        public string rowStatus { get; set; }
    }
}
