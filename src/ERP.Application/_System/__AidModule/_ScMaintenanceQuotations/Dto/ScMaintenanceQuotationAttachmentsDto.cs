using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    [AutoMap(typeof(ScMaintenanceQuotationAttachments))]
    public class ScMaintenanceQuotationAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        [MaxLength(200)]
        public string AttachmentName { get; set; }

        [Required]
        [MaxLength(4000)]
        public string FilePath { get; set; }

        public long ScMaintenanceQuotationId { get; set; }

        public string rowStatus { get; set; }
    }
}
