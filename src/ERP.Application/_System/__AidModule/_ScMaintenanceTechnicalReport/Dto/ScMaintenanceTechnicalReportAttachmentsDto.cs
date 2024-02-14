using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    [AutoMap(typeof(ScMaintenanceTechnicalReportAttachments))]
    public class ScMaintenanceTechnicalReportAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; }
       
        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; set; }

        public long ScMaintenanceTechnicalReportId { get; set; }

        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();
    }
}
