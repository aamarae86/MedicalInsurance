using Abp.AutoMapper;
using ERP._System.__AidModule._Portal.UserAttachments;
using ERP._System.__AidModule._Portal.UserDuites;
using ERP._System.__AidModule._Portal.UserIncomes;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP._System._Portal.UserRelatives.Dto;
using System.Collections.Generic;

namespace ERP._System.__AidModule._PortalUserData.Dto
{
    [AutoMap(typeof(PortalUserData))]
    public class PortalUserDataEditDto : PortalUserUnifiedEditBaseDto
    {
        public long IsZakat { get; set; }

        public virtual ICollection<PortalUserRelativesDto> UserRelatives { get; set; }

        public virtual ICollection<PortalUserDutiesDto> UserDuties { get; set; }

        public virtual ICollection<PortalUserIncomesDto> UserIncomes { get; set; }

        public virtual ICollection<PortalUserAttachmentsDto> UserAttachments { get; set; }
    }
}
