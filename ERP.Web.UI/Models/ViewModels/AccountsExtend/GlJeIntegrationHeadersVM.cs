using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.AccountsExtend;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AccountsExtend
{
    public class GlJeIntegrationHeadersVM : BasePostAuditedVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(GlJeIntegrationHeaders.JeName), ResourceType = typeof(GlJeIntegrationHeaders))]
        public string JeName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(GlJeIntegrationHeaders.GlJeIntegrationNumber), ResourceType = typeof(GlJeIntegrationHeaders))]
        public string GlJeIntegrationNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(GlJeIntegrationHeaders.GlJeIntegrationDate), ResourceType = typeof(GlJeIntegrationHeaders))]
        public string GlJeIntegrationDate { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.CurrencyRate), ResourceType = typeof(GlJeIntegrationHeaders))]
        public decimal CurrencyRate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(GlJeIntegrationHeaders.GlJeIntegrationNotes), ResourceType = typeof(GlJeIntegrationHeaders))]
        public string GlJeIntegrationNotes { get; set; }

        [MaxLength(20)]
        [Display(Name = nameof(GlJeIntegrationHeaders.GlJeIntegrationSourceNo), ResourceType = typeof(GlJeIntegrationHeaders))]
        public string GlJeIntegrationSourceNo { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.PeriodId), ResourceType = typeof(GlJeIntegrationHeaders))]
        public long PeriodId { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.CurrencyId), ResourceType = typeof(GlJeIntegrationHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int CurrencyId { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.StatusLkpId), ResourceType = typeof(GlJeIntegrationHeaders))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.GlJeIntegrationSourceId), ResourceType = typeof(GlJeIntegrationHeaders))]
        public long? GlJeIntegrationSourceId { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.GlJeIntegrationSourceLkpId), ResourceType = typeof(GlJeIntegrationHeaders))]
        public long? GlJeIntegrationSourceLkpId { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.DebitAmount), ResourceType = typeof(GlJeIntegrationHeaders))]
        public decimal DebitAmount { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.CreditAmount), ResourceType = typeof(GlJeIntegrationHeaders))]
        public decimal CreditAmount { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.ApVendorId), ResourceType = typeof(GlJeIntegrationHeaders))]
        public long? ApVendorId { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.ArCustomerId), ResourceType = typeof(GlJeIntegrationHeaders))]
        public long? ArCustomerId { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.CustomerNumber), ResourceType = typeof(GlJeIntegrationHeaders))]
        public string CustomerNumber { get; set; }

        [Display(Name = nameof(GlJeIntegrationHeaders.VendorNumber), ResourceType = typeof(GlJeIntegrationHeaders))]
        public string VendorNumber { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public CurrenciesVM Currency { get; set; }

        public GlPeriodsDetailsVM GlPeriodsDetails { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndGlJeIntegrationSourceLkp { get; set; }

        public string AccountLinesListStr { get; set; }
        public string CustomerLinesListStr { get; set; }
        public string VendorLinesListStr { get; set; }

        public List<GlJeIntegrationAccountsLinesDto> GlJeIntegrationAccountsLines => string.IsNullOrEmpty(AccountLinesListStr) ?
           new List<GlJeIntegrationAccountsLinesDto>() : Helper<List<GlJeIntegrationAccountsLinesDto>>.Convert(AccountLinesListStr);

        public List<GlJeIntegrationCustomersLinesDto> GlJeIntegrationCustomersLines => string.IsNullOrEmpty(CustomerLinesListStr) ?
           new List<GlJeIntegrationCustomersLinesDto>() : Helper<List<GlJeIntegrationCustomersLinesDto>>.Convert(CustomerLinesListStr);

        public List<GlJeIntegrationVendorsLinesDto> GlJeIntegrationVendorsLines => string.IsNullOrEmpty(VendorLinesListStr) ?
           new List<GlJeIntegrationVendorsLinesDto>() : Helper<List<GlJeIntegrationVendorsLinesDto>>.Convert(VendorLinesListStr);

    }
}