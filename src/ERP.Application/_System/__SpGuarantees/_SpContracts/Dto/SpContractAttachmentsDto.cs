using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpContracts._SpContractAttachments;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    [AutoMap(typeof(SpContractAttachments))]
    public class SpContractAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        public long SpContractId { get; set; }

        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; set; }

        [MaxLength(1000)]
        public string FilePath { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
