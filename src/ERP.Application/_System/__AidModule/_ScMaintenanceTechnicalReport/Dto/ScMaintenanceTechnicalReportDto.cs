using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    [AutoMap(typeof(ScMaintenanceTechnicalReport))]
    public class ScMaintenanceTechnicalReportDto : PostAuditedEntityDto<long> //: ScMaintenanceTechnicalReportBasePostAuditedEntityDto
    {
        public string EncId => Core.Helpers.Core.CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string TechnicalReportNumber { get; set; }

        public string TechnicalReportDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long PortalRequestId { get; set; }

        public long? ScCommitteeDetailId { get;  set; }

        public ScPortalRequestDto PortalRequest { get; set; }

        public long? StatusLkpId { get; set; } //= 940;
        public FndLookupValuesDto FndStatusLkp { get; set; }

        public virtual ICollection<ScMaintenanceTechnicalReportDetailDto> ScMaintenanceTechnicalReportDetails { get; set; }

        public virtual ICollection<ScMaintenanceTechnicalReportAttachmentsDto> ScMaintenanceTechnicalReportAttachments { get; set; }
    }
}
