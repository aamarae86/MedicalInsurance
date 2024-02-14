using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HRPaperRequest
{
  public   class PaperReqType : PostAuditedEntity<long>, IMustHaveTenant
    {
        public string PaperReqTypeName { get; protected set; }

        public int TenantId { get; set; }
    }
}
