using Abp.Application.Services.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__HR._HrPaperRequest.Dto
{
   public  class HrPaperRequestAttachmentDto : EntityDto<long>, IDetailRowStatus
    {

        [Required]
        public long HrPaperRequestId { get; set; }
        [MaxLength(200)]
        public string AttachmentName { get; set; }

       
        [MaxLength(2000)]
        public string FilePath { get; set; }

        public long HrPersonId { get; set; }
        public long PaperReqTypeId { get; set; }

        public string rowStatus { get; set; }
    }
}
