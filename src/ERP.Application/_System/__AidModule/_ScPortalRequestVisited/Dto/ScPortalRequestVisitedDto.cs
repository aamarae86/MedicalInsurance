using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScPortalRequestVisited.Dto
{
    [AutoMap(typeof(ScPortalRequestVisited))]
    public class ScPortalRequestVisitedDto : IDetailRowStatus, IMustHaveTenant
    {
        public long id { get; set; }

        public long PortalRequestId { get; set; }

        public string visitDate { get; set; }

        public string visitTime { get; set; }

        public long visitStatusLkpId { get; set; }

        public string mobileNumber { get; set; }

        public string visitStatusLkp { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        public ScPortalRequestDto ScPortalRequests { get; set; }

        public string rowStatus { get; set; }
        public int TenantId { get; set; }
    }
}
