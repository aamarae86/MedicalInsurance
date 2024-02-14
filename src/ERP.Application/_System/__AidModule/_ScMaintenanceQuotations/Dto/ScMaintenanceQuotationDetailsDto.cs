using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    [AutoMap(typeof(ScMaintenanceQuotationDetails))]
    public class ScMaintenanceQuotationDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long ScMaintenanceQuotationId { get; set; }

        public long ScMaintenanceTechnicalReportDetailId { get; set; }

        public decimal Amount { get; set; }

        public string MaintenanceTechnicalReportItemDescription { get; set; }

        public string rowStatus { get; set; }
    }
}
