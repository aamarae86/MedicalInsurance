using Abp.AutoMapper;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System._FndLookupValues.Dto;
using ERP._System._ScCampainsAid.Dto;
using ERP.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    [AutoMap(typeof(ScCampainsDetail))]
    public class MasterDetailDto
    {
        public long Id { get;  set; }
        public long CampainId { get;  set; }
        public long PortalFndUsersId { get;  set; }
        public long CampainAidId { get;  set; }
        public long StatusLkpId { get;  set; }
        public ScCampainsDto ScCampains { get;  set; }
        public PortalUserDto PortalFndUsers { get;  set; }
        public ScCampainsAidDto ScCampainsAid { get;  set; }
        public FndLookupValuesDto FndLookupValues { get;  set; }
    }
}
