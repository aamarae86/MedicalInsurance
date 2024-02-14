using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System._ScComityMembers.Dto;
using ERP.Helpers.Core;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    [AutoMapFrom(typeof(SpBeneficentAttachments))]
    public class SpBeneficentAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        public long BeneficentId { get; set; }

        public string AttachmentName { get; set; }

        public string FilePath { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }

}
