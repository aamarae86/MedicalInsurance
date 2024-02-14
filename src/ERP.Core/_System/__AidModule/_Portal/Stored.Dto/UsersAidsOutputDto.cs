using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._Portal.Stored.Dto
{
    public class UsersAidsOutputDto
    {
        public int sourceType { get; set; }
        public int tenantId { get; set; }
        public long portalRequestId { get; set; }
        public DateTime RequestDate { get; set; }

        public string TenantName { get; set; }

        public string SourceName { get; set; }

        public string RequestVal { get; set; }

        public string RequestType { get; set; }

    }
}
