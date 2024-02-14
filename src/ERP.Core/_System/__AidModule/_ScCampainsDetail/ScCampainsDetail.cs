using Abp.Domain.Entities;
using ERP._System.__AidModule._ScCampains;
using ERP._System._FndLookupValues;
using ERP._System._ScCampainsAid;
using ERP.Authorization.Users;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScCampainsDetail
{
    public class ScCampainsDetail : PostAuditedEntity<long>, IMustHaveTenant
    {
        #region Props
        public long CampainId { get; protected set; }
        public long PortalFndUsersId { get; protected set; }
        public long CampainAidId { get; protected set; }
        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [ForeignKey(nameof(CampainId))]
        public ScCampains ScCampains { get; protected set; }

        [ForeignKey(nameof(CampainAidId))]
        public ScCampainsAid ScCampainsAid { get; protected set; }

        [ForeignKey(nameof(PortalFndUsersId))]
        public PortalUser PortalFndUsers { get; protected set; }

        public int TenantId { get; set; }
        #endregion

        protected ScCampainsDetail() { }

        public void SetCampainId(long campainId)=> this.CampainId = campainId;

        public void SetStatusLkpId(long statusLkpId)=> this.StatusLkpId = statusLkpId;
    }
}
