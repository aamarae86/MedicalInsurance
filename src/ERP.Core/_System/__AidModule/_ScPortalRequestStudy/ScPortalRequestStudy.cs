using Abp.Domain.Entities;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequestStudy
{
    public class ScPortalRequestStudy : PostAuditedEntity<long>, IMustHaveTenant
    {
        public DateTime? StudyDate { get; protected set; }

        [MaxLength(30)]
        public string StudyNumber { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [MaxLength(200)]
        public string CashingTo { get; protected set; }

        [MaxLength(4000)]
        public string StudyDetails { get; protected set; }

        [MaxLength(4000)]
        public string ResearcherDecision { get; protected set; }

        public long? RefuseLkpId { get; protected set; }

        public long? StudyLkpId { get; protected set; }

        public int? NumberOfMonths { get; protected set; }

        [MaxLength(4000)]
        public string RefuseDescription { get; protected set; }

        [MaxLength(4000)]
        public string RefuseForUpdateReason { get; protected set; }

        public long PortalRequestId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? SuggestedAmount { get; protected set; }

        public long? AccountId { get; protected set; }

        public long? OtherAidLkpId { get; protected set; }

        public int? OtherMonthNo { get; protected set; }

        public bool IsMedicine { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [ForeignKey(nameof(RefuseLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesRefuseLkp { get; protected set; }

        [ForeignKey(nameof(StudyLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesStudyLkp { get; protected set; }

        [ForeignKey(nameof(OtherAidLkpId)), Column(Order = 3)]
        public FndLookupValues FndOtherAidLkp { get; protected set; }

        [ForeignKey(nameof(PortalRequestId))]
        public ScPortalRequest ScPortalRequest { get; protected set; }

        public virtual ICollection<ScPortalRequestStudyAttachment> ScPortalRequestStudyAttachment { get; protected set; }
        public virtual ICollection<ScPortalRequestMgrDecision> ScPortalRequestMgrDecision { get; protected set; }
        public virtual ICollection<ScCommitteeDetail> ScCommitteeDetail { get; protected set; }

        public void SetRefuseData(long? refuseLkpId, string refuseDescription)
        {
            this.RefuseLkpId = refuseLkpId;
            this.RefuseDescription = refuseDescription;
        }

        public void SetAccountId(long? accountId) => this.AccountId = accountId;


        public void UpdateManagerData(string studyDetails, string researcherDecision)
        {
            this.StudyDetails = studyDetails;
            this.ResearcherDecision = researcherDecision;
        }
    }
}
