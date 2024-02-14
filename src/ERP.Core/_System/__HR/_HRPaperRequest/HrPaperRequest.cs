using Abp.Domain.Entities;
using ERP._System.__HR._HrPersons;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__HR._HRPaperRequest
{
    public class HrPaperRequest : PostAuditedEntity<long>, IMustHaveTenant
    {
        public string PaperReqNumber { get; protected set; }
        public DateTime PaperReqDate { get; protected set; }
      
        public string Notes { get; protected set; }
        public virtual ICollection<HrPaperRequestAttachment> HrPaperRequestAttachments { get; protected set; }

        public int TenantId { get; set; }
    }
}
