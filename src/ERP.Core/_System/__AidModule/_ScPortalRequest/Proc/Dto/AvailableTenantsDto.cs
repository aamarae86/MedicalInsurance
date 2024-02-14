using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequest.Proc.Dto
{
    public class AvailableTenantsDto
    {
        public DateTime FromDate { get; set; }
        public long TenantId { get; set; }

        public override string ToString() => $"?FromDate={FromDate}&TenantId={TenantId}";
    }
}
