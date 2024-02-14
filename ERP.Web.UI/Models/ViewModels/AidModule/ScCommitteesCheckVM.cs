using ERP._System.__AidModule._ScCommitteesCheckDetails.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScCommitteesCheckVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.OperationNumber), ResourceType = typeof(ScCommitteesCheck))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string OperationNumber { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.OperationDate), ResourceType = typeof(ScCommitteesCheck))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string OperationDate { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.StatusLkpId), ResourceType = typeof(ScCommitteesCheck))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.CommitteeId), ResourceType = typeof(ScCommitteesCheck))]
        public long? CommitteeId { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ScCommitteesCheck.FromCheckNumber), ResourceType = typeof(ScCommitteesCheck))]
        public string FromCheckNumber { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.BankAccountId), ResourceType = typeof(ScCommitteesCheck))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? BankAccountId { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.MaturityDate), ResourceType = typeof(ScCommitteesCheck))]
        public string MaturityDate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScCommitteesCheck.Notes), ResourceType = typeof(ScCommitteesCheck))]
        public string Notes { get; set; }

        public long? CommitteeDetailsId { get; set; }

        public long? CommitteesCheckId { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.CheckNumber), ResourceType = typeof(ScCommitteesCheck))]
        public string CheckNumber { get; set; }

        public string Status { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }

        public ScCommitteeVM ScCommittee { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }

        public string ListScCommitteesCheckDetails { get; set; }

        public ICollection<ScCommitteesCheckDetailsDto> ScCommitteesCheckDetailsList => string.IsNullOrEmpty(ListScCommitteesCheckDetails) ?
                new List<ScCommitteesCheckDetailsDto>() : Helper<List<ScCommitteesCheckDetailsDto>>.Convert(ListScCommitteesCheckDetails);
    }
}