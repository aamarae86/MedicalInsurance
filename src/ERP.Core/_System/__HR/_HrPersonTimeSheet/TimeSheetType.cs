using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet
{
  public class TimeSheetType : PostAuditedEntity<long>, IMustHaveTenant
    {
        public string TimeSheetTypeName { get; set; }

        public int TenantId { get; set; }
    }
}
