using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__AidModule._ScPortalRequestStudyAttachment.Dto
{
    [AutoMap(typeof(ScPortalRequestStudyAttachment))]
    public class ScPortalRequestStudyAttachmentDto : IDetailRowStatus
    {
        public long? Id { get; set; }

        public long? PortalRequestStudyId { get;  set; }

        [MaxLength(200)]
        public string attachmentName { get;  set; }

        [MaxLength(1000)]
        public string FilePath { get;  set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
