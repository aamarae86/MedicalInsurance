using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonPermission
{
    public class HrPermissionType : PostAuditedEntity<long>, IMustHaveTenant
    {

        public string PermissionName { get; set; }

        public int TenantId { get; set; }
    }
}
