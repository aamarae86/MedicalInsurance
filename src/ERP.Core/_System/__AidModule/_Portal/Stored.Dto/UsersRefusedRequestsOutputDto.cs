using System;

namespace ERP._System.__AidModule._Portal.Stored.Dto
{
    public class UsersRefusedRequestsOutputDto
    {
        public DateTime requestDate { get; set; }

        public string requestNo { get; set; }

        public string aidType { get; set; }

        public string refuseReason { get; set; }

        public long portalRequestId { get; set; }
    }
}
