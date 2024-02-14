using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpCasesAttachments;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__SpGuarantees._SpCases.Dto
{
    [AutoMap(typeof(SpCasesAttachments))]
    public class SpCasesAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        public long? SpCaseId { get; set; }
        //[MaxLength(200)]
        public string AttachmentName { get; set; }
        //[MaxLength(1000)]
        public string FilePath { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
