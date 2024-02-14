using Abp.Domain.Entities;
using ERP._System.__HR._HrPersons;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__HR._HRPaperRequest
{
  public class HrPaperRequestAttachment : AttachAuditedEntity, IMustHaveTenant
    {
        [Required]
        public long HrPaperRequestId { get; protected set; }
        [ForeignKey(nameof(HrPaperRequestId))]
        public HrPaperRequest HrPaperRequest { get; protected set; }

        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        [MaxLength(2000)]
        public string FilePath { get; protected set; }

        public long HrPersonId { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }
        public long PaperReqTypeId { get; protected set; }
       
        [ForeignKey(nameof(PaperReqTypeId))]
        public PaperReqType PaperReqType { get; protected set; }
        public int TenantId { get; set; }
    }
}
