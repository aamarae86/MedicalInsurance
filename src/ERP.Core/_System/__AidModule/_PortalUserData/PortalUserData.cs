using Abp.Domain.Entities;
using ERP._System.__AidModule._Portal._PortalUserAttachments;
using ERP._System.__AidModule._Portal._PortalUserDuties;
using ERP._System.__AidModule._Portal._PortalUserIncomes;
using ERP._System.__AidModule._PortalUserUnified;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System._ApMiscPaymentLines;
using ERP._System._Portal;
using ERP.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._PortalUserData
{
    public class PortalUserData : PortalUserUnifiedBase, IMustHaveTenant
    {
        public long PortalUserId { get; protected set; }

        public long IsZakat { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(PortalUserId))]
        public PortalUser PortalUser { get; protected set; }

        //public virtual ICollection<ApMiscPaymentLines> ApMiscPaymentLines { get; protected set; }

        public virtual ICollection<PortalUserRelatives> Relatives { get; protected set; }

        //public virtual ICollection<ScPortalRequest> ScPortalRequest { get; protected set; }

        //public virtual ICollection<ScCampainsDetail> ScCampainsDetail { get; protected set; }

        public virtual ICollection<PortalUserIncomes> PortalUserIncomes { get; protected set; }

        public virtual ICollection<PortalUserDuties> PortalUserDuties { get; protected set; }

        public virtual ICollection<PortalUserAttachments> PortalUserAttachments { get; protected set; }

        public void SetPortalUserId(long portalUserId) => this.PortalUserId = portalUserId;
    }
}
