using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArJobCardHd.Dto
{
    [AutoMap(typeof(ArJobCardAttachments))]
    public class ArJobCardAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        [MaxLength(200)]
        public string AttachmentName { get; set; }

        [Required]
        [MaxLength(2000)]
        public string FilePath { get; set; }

        public long ArJobCardHdId { get; set; }

        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();
    }
}
