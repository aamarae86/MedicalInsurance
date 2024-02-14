using Abp.AutoMapper;
using ERP._System.__AidModule._Portal.UserDuites;
using ERP._System.__AidModule._Portal.UserIncomes;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP._System._Portal.UserRelatives.Dto;
using ERP.Users.Dto;
using System.Collections.Generic;

namespace ERP._System.__AidModule._PortalUserData.Dto
{
    [AutoMap(typeof(PortalUserData))]
    public class PortalUserDataDto : PortalUserUnifiedBaseDto
    {
        public long PortalUserId { get; set; }

        public long IsZakat { get; set; }

        public PortalUserDto PortalUser { get; set; }

        public virtual ICollection<PortalUserIncomesDto> UserIncomes { get; set; }

        public virtual ICollection<PortalUserDutiesDto> UserDuties { get; set; }

        public virtual ICollection<PortalUserRelativesDto> Relatives { get; set; }
    }
}
