using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument
{
   public class DocumentRequestType : PostAuditedEntity<long>, IMustHaveTenant
    {
        public string DocumentRequestName { get; set; }

        public int TenantId { get; set; }
    }
}
