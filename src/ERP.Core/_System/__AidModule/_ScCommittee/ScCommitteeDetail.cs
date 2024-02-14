using Abp.Domain.Entities;
using ERP._System.__AidModule._ScCommitteesCheckDetails;
using ERP._System.__AidModule._ScDeliveryOtherAids;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScCommittee
{
    public class ScCommitteeDetail : PostAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long CommitteeId { get; protected set; }

        public long RequestStudyId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? AidAmount { get; protected set; }

        public int? NoOfMonths { get; protected set; }

        public long? OtherAidLkpId { get; protected set; }

        public int? OtherMonthNo { get; protected set; }

        public bool IsMedicine { get; protected set; }

        [MaxLength(200)]
        public string CashingTo { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [MaxLength(4000)]
        public string DecisionNotes { get; protected set; }

        [ForeignKey(nameof(CommitteeId))]
        public ScCommittee Committee { get; protected set; }

        [ForeignKey(nameof(RequestStudyId))]
        public ScPortalRequestStudy RequestStudy { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(OtherAidLkpId)), Column(Order = 1)]
        public FndLookupValues FndOtherAidLkp { get; protected set; }

        public virtual ICollection<ScCommitteesCheckDetails> ScCommitteesCheckDetails { get; protected set; }

        public virtual ICollection<ScDeliveryOtherAidDetails> ScDeliveryOtherAidDetails { get; protected set; }

        public virtual ICollection<ScCommitteeDetailsElectronicAid> ScCommitteeDetailsElectronicAid { get; protected set; }

        public virtual ICollection<ScMaintenanceTechnicalReport> ScMaintenanceTechnicalReport { get; protected set; }

        public void SetRefuseData(string refuseDescription) => DecisionNotes = refuseDescription;

        public void SetStatusId(long statuslkpId) => this.StatusLkpId = statuslkpId;
    }
}
