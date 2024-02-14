using Abp.AutoMapper;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    [AutoMap(typeof(ScMaintenanceQuotations))]
    public class ScMaintenanceQuotationsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string QuotationNumber { get; set; }

        public string QuotationDate { get; set; }

        public long StatusLkpId { get; set; }

        public long ScMaintenanceTechnicalReportId { get; set; }

        public long VendorId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string PortalRequestNumber { get; set; }

        public string PortalUserName { get; set; }

        public virtual ScMaintenanceTechnicalReportDto ScMaintenanceTechnicalReport { get; set; }

        public virtual FndLookupValuesDto FndStatusLkp { get; set; }

        public virtual ApVendorsDto ApVendors { get; set; }

        public virtual ICollection<ScMaintenanceQuotationDetailsDto> MaintenanceQuotationDetails { get; set; }

        public virtual ICollection<ScMaintenanceQuotationAttachmentsDto> MaintenanceQuotationAttachments { get; set; }
    }
}
