using Abp.AutoMapper;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto;
using ERP._System._FndLookupValues.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    [AutoMap(typeof(ScMaintenanceQuotations))]
    public class ScMaintenanceQuotationsCreateDto
    {
        [MaxLength(30)]
        public string QuotationNumber { get; set; }

        public string QuotationDate { get; set; }

        public long StatusLkpId => 942;

        public long ScMaintenanceTechnicalReportId { get; set; }

        public long VendorId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScMaintenanceQuotationDetailsDto> MaintenanceQuotationDetails { get; set; }

        public virtual ICollection<ScMaintenanceQuotationAttachmentsDto> MaintenanceQuotationAttachments { get; set; }
    }
}
