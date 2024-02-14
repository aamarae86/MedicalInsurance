using Abp.AutoMapper;
using ERP.Authorization.Users;

namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    [AutoMap(typeof(PortalUser))]
    public class PortalUserUnifiedDto : PortalUserUnifiedBaseDto
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public bool hasNoRequests { get; set; } = true;
    }

    public class CheckIdNumbersDto
    {
        public long id { get; set; }
        public string IdNumber { get; set; }
        public string idNumberWifeHusband1 { get; set; }
        public string idNumberWife2 { get; set; }
        public string idNumberWife3 { get; set; }
        public string idNumberWife4 { get; set; }
    }
}
