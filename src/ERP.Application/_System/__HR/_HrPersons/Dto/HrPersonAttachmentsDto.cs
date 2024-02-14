using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersons.Dto
{
    [AutoMap(typeof(HrPersonAttachments))]
    public class HrPersonAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        [MaxLength(200)]
        public string AttachmentName { get; set; }

        [Required]
        [MaxLength(2000)]
        public string FilePath { get; set; }

        public long HrPersonId { get; set; }

        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();
    }
}
