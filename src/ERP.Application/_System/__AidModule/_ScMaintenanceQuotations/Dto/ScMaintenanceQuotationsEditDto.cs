using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    [AutoMap(typeof(ScMaintenanceQuotations))]
    public class ScMaintenanceQuotationsEditDto : EditEntityDto<long>
    {
        public string QuotationDate { get; set; }

        public long VendorId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScMaintenanceQuotationDetailsDto> MaintenanceQuotationDetails { get; set; }

        public virtual ICollection<ScMaintenanceQuotationAttachmentsDto> MaintenanceQuotationAttachments { get; set; }
    }
}
