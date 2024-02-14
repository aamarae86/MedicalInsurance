using ERP._System.__AidModule._ScCommittee.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScCommitteeVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(ScCommittee.CommitteeNumber), ResourceType = typeof(ScCommittee))]
        public string CommitteeNumber { get; set; }

        [Display(Name = nameof(ScCommittee.StatusLkpId), ResourceType = typeof(ScCommittee))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ScCommittee.Notes), ResourceType = typeof(ScCommittee))]
        public string Notes { get; set; }

        [Display(Name = nameof(ScCommittee.Name), ResourceType = typeof(ScCommittee))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string CommitteeName { get; set; }

        [Display(Name = nameof(ScCommittee.CommitteeDate), ResourceType = typeof(ScCommittee))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string CommitteeDate { get; set; }

        [Display(Name = nameof(ScCommittee.CommitteeDateFrom), ResourceType = typeof(ScCommittee))]
        public string CommitteeDateFrom { get; set; }

        [Display(Name = nameof(ScCommittee.CommitteeDateTo), ResourceType = typeof(ScCommittee))]
        public string CommitteeDateTo { get; set; }

        [Display(Name = nameof(ScCommittee.OtherCommittee), ResourceType = typeof(ScCommittee))]
        public long? OtherAidLkpId { get; set; }

        [Display(Name = nameof(ScCommittee.OtherCommitteeMonthNo), ResourceType = typeof(ScCommittee))]
        public int? OtherMonthNo { get; set; }

        [Display(Name = nameof(ScCommittee.IsMedicine), ResourceType = typeof(ScCommittee))]
        public bool IsMedicine { get; set; }

        public bool IsElectronic { get; set; }

        public string Status => ScCommittee.NewStatus;

        public FndLookupValuesVM FndLookupStatusValues { get; set; }

        public string ListScCommitteeDetail { get; set; }

        public virtual ICollection<ScCommitteeMemberDetailCreateDto> ListMembers { get; set; }

        public virtual ICollection<ScCommitteeDetailCreateDto> ListStudies { get; set; }

        public virtual ICollection<ScCommitteeMemberDetailEditDto> ListEditMembers { get; set; }

        public virtual ICollection<ScCommitteeDetailEditDto> ListEditStudies { get; set; }

        public string ListScCommitteeMemberDetail { get; set; }

        #region Details
        [Display(Name = nameof(ScCommittee.Details_PortalRequestNumber), ResourceType = typeof(ScCommittee))]
        public string Details_PortalRequestNumber { get; set; }

        [Display(Name = nameof(ScCommittee.PortalUsersId), ResourceType = typeof(ScCommittee))]
        public long PortalUsersId { get; set; }

        [Display(Name = nameof(ScCommittee.Details_PortalUser_Name), ResourceType = typeof(ScCommittee))]
        public string Details_PortalUser_Name { get; set; }

        [Display(Name = nameof(ScCommittee.Details_PortalUser_IdNumber), ResourceType = typeof(ScCommittee))]
        public string Details_PortalUser_IdNumber { get; set; }

        [Display(Name = nameof(ScCommittee.Details_CashingTo), ResourceType = typeof(ScCommittee))]
        public string Details_CashingTo { get; set; }

        [Display(Name = nameof(ScCommittee.Details_AidAmount), ResourceType = typeof(ScCommittee))]
        public decimal Details_AidAmount { get; set; }

        [Display(Name = nameof(ScCommittee.Details_NoOfMonths), ResourceType = typeof(ScCommittee))]
        public int Details_NoOfMonths { get; set; }

        [Display(Name = nameof(ScCommittee.Notes), ResourceType = typeof(ScCommittee))]
        public string Details_Notes { get; set; }
        #endregion

        #region Members
        [Display(Name = nameof(ScCommittee.Member_Number), ResourceType = typeof(ScCommittee))]
        public string Member_Number { get; set; }

        [Display(Name = nameof(ScCommittee.Member_Name), ResourceType = typeof(ScCommittee))]
        public string Member_Name { get; set; }

        [Display(Name = nameof(ScCommittee.Member_CategoryLkpId), ResourceType = typeof(ScCommittee))]
        public long Member_CategoryLkpId { get; set; }

        #endregion
    }
}