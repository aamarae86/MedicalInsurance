using Abp.Domain.Entities;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System.__AidModule._ScCommitteesCheckDetails;
using ERP._System.__AidModule._ScDeliveryOtherAids;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision
{
    public class ScPortalRequestMgrDecision : PostAuditedEntity<long>, IMustHaveTenant
    {
        public DateTime? DecisionDate { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [MaxLength(200)]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long? RefuseLkpId { get; protected set; }

        public int? NumberOfMonths { get; protected set; }

        [MaxLength(4000)]
        public string RefuseDescription { get; protected set; }

        public long? PortalRequestStudyId { get; protected set; }

        [MaxLength(30)]
        public string DecisionNumer { get; protected set; }

        public long? OtherAidLkpId { get; protected set; }

        public int? OtherMonthNo { get; protected set; }

        public bool IsMedicine { get; protected set; }

        [MaxLength(4000)]
        public string RefuseForUpdateReason { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesStatusLkpId { get; protected set; }

        [ForeignKey(nameof(RefuseLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesRefuseLkpId { get; protected set; }

        [ForeignKey(nameof(OtherAidLkpId)), Column(Order = 2)]
        public FndLookupValues FndOtherAidLkp { get; protected set; }

        [ForeignKey(nameof(PortalRequestStudyId))]
        public ScPortalRequestStudy ScPortalRequestStudy { get; protected set; }

        public virtual ICollection<ScCommitteesCheckDetails> ScCommitteesCheckDetails { get; protected set; }

        public virtual ICollection<ScDeliveryOtherAidDetails> ScDeliveryOtherAidDetails { get; protected set; }

        public virtual ICollection<ScPRMgrDecisionElectronicAid> ScPRMgrDecisionElectronicAid { get; protected set; }
        public virtual ICollection<GeneralUnPost> GeneralUnPost { get; protected set; }

        protected ScPortalRequestMgrDecision() { }

        public void UpdateDate(decimal? amount, string decisionDate, string cashingTo, long? otherAidLkpId, int? otherMonthNo,
            bool isMedicine, int? numberOfMonths, string notes)
        {
            this.DecisionDate = DateTimeController.ConvertToDateTime(decisionDate);
            this.NumberOfMonths = numberOfMonths;
            this.OtherAidLkpId = otherAidLkpId;
            this.OtherMonthNo = otherMonthNo;
            this.IsMedicine = isMedicine;
            this.CashingTo = cashingTo;
            this.Amount = amount;
            this.Notes = notes;
        }

        public void UpdateRefuseForUpdateReason(string refuseForUpdateReason) => this.RefuseForUpdateReason = refuseForUpdateReason;
    }
}
