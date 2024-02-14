using ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto;
using ERP.Core.Helpers.Core;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScPortalRequestMgrDecisionVM : BasePostAuditedVM<long>, ICodeComUtilityTexts
    {
        public string EncId => Front.Helpers.Core.CipherStringController.Encrypt(this.Id.ToString());

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string DecisionDate { get; set; }

        public string FromStudyDate { get; set; }

        public string ToStudyDate { get; set; }

        [Display(Name = nameof(ResourcePack.AidModule.ScPortalRequestStudy.ManagerRefuseResaon), ResourceType = typeof(ScPortalRequestStudy))]
        public string RefuseForUpdateReason { get; set; }

        [Display(Name = nameof(ScCommittee.OtherCommittee), ResourceType = typeof(ScCommittee))]
        public long? OtherAidLkpId { get; set; }

        [Display(Name = nameof(ResourcePack.AidModule.ScPortalRequestStudy.NoOfMonths), ResourceType = typeof(ResourcePack.AidModule.ScPortalRequestStudy))]
        public int? NumberOfMonths { get; set; }

        [Display(Name = nameof(ScCommittee.OtherCommitteeMonthNo), ResourceType = typeof(ScCommittee))]
        public int? OtherMonthNo { get; set; }

        [Display(Name = nameof(ScCommittee.IsMedicine), ResourceType = typeof(ScCommittee))]
        public bool IsMedicine { get; set; }

        [Required(ErrorMessageResourceType = typeof(ScCommittee), ErrorMessageResourceName = nameof(ScCommittee.IsMedicine))]
        public bool IsMedicineAlt { get; set; }

        public long? StatusLkpId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? Amount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long? RefuseLkpId { get; set; }

        [MaxLength(4000)]
        public string RefuseDescription { get; set; }

        public long? PortalRequestStudyId { get; set; }

        [MaxLength(30)]
        public string DecisionNumer { get; set; }

        public string FinalAmount { get; set; }

        public long? CaseNameId { get; set; }

        public long? PortalRequestId { get; set; }

        public FndLookupValuesVM FndLookupValuesStatusLkpId { get; set; }

        public FndLookupValuesVM FndLookupValuesRefuseLkpId { get; set; }

        public FndLookupValuesVM FndOtherAidLkp { get; set; }

        public ScPortalRequestStudyVM ScPortalRequestStudy { get; set; }

        public string codeComUtilityTexts { get; set; }

        [Display(Name = nameof(ScCommittee.ElectronicTypeLkpId), ResourceType = typeof(ScCommittee))]
        public long ElectronicTypeLkpId { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ArCustomers.Amount), ResourceType = typeof(ResourcePack.Accounts.ArCustomers))]
        public decimal ElectronicAmount { get; set; }

        public bool IsElectronic { get; set; }

        public string MgrDecisionElectronicAidsListStr { get; set; }

        public virtual ICollection<ScPRMgrDecisionElectronicAidDto> MgrDecisionElectronicAids => string.IsNullOrEmpty(MgrDecisionElectronicAidsListStr) ?
          new List<ScPRMgrDecisionElectronicAidDto>() : Helper<List<ScPRMgrDecisionElectronicAidDto>>.Convert(MgrDecisionElectronicAidsListStr);

    }
}