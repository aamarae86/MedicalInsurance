using ERP._System.__AidModule._ScPortalRequest;
using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    public class ScMaintenanceTechnicalReportBasePostAuditedEntityDto : PostAuditedEntityDto<long>
    {
        public string TechnicalReportDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long PortalRequestId { get; set; }
        public ScPortalRequest PortalRequest { get; set; }
    }
}
