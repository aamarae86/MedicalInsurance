using Abp.Domain.Entities.Auditing;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlAccountsVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.Code), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote("CheckIsExistsCode", "GlAccounts", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "codeExist", ErrorMessageResourceType = typeof(ArCustomers))]
        public string Code { get; set; }

        [Display(Name = nameof(ArCustomers.NameEn), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        //[Remote("CheckIsExistsDescriptionEn", "GlAccounts", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        [MaxLength(4000)]
        public string DescriptionEn { get; set; }

        [Display(Name = nameof(ArCustomers.NameAr), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        //[Remote("CheckIsExistsDescriptionAr", "GlAccounts", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        [MaxLength(4000)]
        public string DescriptionAr { get; set; }

        [Display(Name = nameof(ArCustomers.TrialBalance), ResourceType = typeof(ArCustomers))]
        public bool TrialBalance { get; set; }

        public bool TrialBalanceAlt { get; set; }

        [Display(Name = nameof(ArCustomers.CashFlow), ResourceType = typeof(ArCustomers))]
        public bool CashFlow { get; set; }

        public bool CashFlowAlt { get; set; }

        [Display(Name = nameof(ArCustomers.Expense), ResourceType = typeof(ArCustomers))]
        public bool Expense { get; set; }

        public bool ExpenseAlt { get; set; }

        [Display(Name = nameof(ArCustomers.Revenue), ResourceType = typeof(ArCustomers))]
        public bool Revenue { get; set; }

        public bool RevenueAlt { get; set; }

        [Display(Name = nameof(ArCustomers.Libility), ResourceType = typeof(ArCustomers))]
        public bool Libility { get; set; }

        public bool LibilityAlt { get; set; }

        [Display(Name = nameof(ArCustomers.Assets), ResourceType = typeof(ArCustomers))]
        public bool Assets { get; set; }

        public bool AssetsAlt { get; set; }

        [Display(Name = nameof(ArCustomers.ProfitLoss), ResourceType = typeof(ArCustomers))]
        public bool ProfitLoss { get; set; }

        public bool ProfitLossAlt { get; set; }

        [Display(Name = nameof(ArCustomers.BalanceSheet), ResourceType = typeof(ArCustomers))]
        public bool BalanceSheet { get; set; }

        public bool BalanceSheetAlt { get; set; }

        [Display(Name = nameof(ArCustomers.Disabled), ResourceType = typeof(ArCustomers))]
        public bool Disabled { get; set; }

        [Display(Name = nameof(ArCustomers.NatureOfAccountLkpId), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long NatureOfAccountLkpId { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }

        public bool DisabledAlt { get; set; }

        public long? ParentId { get; set; }

        [Display(Name = nameof(ArCustomers.ParentId), ResourceType = typeof(ArCustomers))]
        public string ParentPath { get; set; }
    }
}