using Abp.Domain.Entities;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.AccountsExtend;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AccountsExtend
{
    public class ApPrepaidVM : BasePostAuditedVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ApPrepaid.SourceId), ResourceType = typeof(ApPrepaid))]
        public string Source { get; set; }

        [Display(Name = nameof(ApPrepaid.SourceNo), ResourceType = typeof(ApPrepaid))]
        public string SourceNo { get; set; }

        [Display(Name = nameof(ApPrepaid.TransactionDate), ResourceType = typeof(ApPrepaid))]
        public string TransactionDate { get; set; }

        [Display(Name = nameof(ApPrepaid.Amount), ResourceType = typeof(ApPrepaid))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(ApPrepaid.DrAccountId), ResourceType = typeof(ApPrepaid))]
        public long? DrAccountId { get; set; }

        [Display(Name = nameof(ApPrepaid.CrAccountId), ResourceType = typeof(ApPrepaid))]
        public long? CrAccountId { get; set; }

        [Display(Name = nameof(ApPrepaid.SourceId), ResourceType = typeof(ApPrepaid))]
        public long? SourceId { get; set; }

        [Display(Name = nameof(ApPrepaid.StatusLkpId), ResourceType = typeof(ApPrepaid))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ApPrepaid.SourceCodeLkpId), ResourceType = typeof(ApPrepaid))]
        public long SourceCodeLkpId { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndSourceCodeLkp { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public string codeComUtilityIds_alt1 { get; set; }

        public string codeComUtilityTexts_alt1 { get; set; }
    }
}