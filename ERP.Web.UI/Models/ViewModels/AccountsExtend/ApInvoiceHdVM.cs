using ERP._System.__AccountModule._ApInvoiceHd.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.AccountsExtend;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AccountsExtend
{
    public class ApInvoiceHdVM : BasePostAuditedVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ApInvoiceHd.VendorNumber), ResourceType = typeof(ApInvoiceHd))]
        public string VendorNo { get; set; }

        [Display(Name = nameof(ApInvoiceHd.HdInvNo), ResourceType = typeof(ApInvoiceHd))]
        public string HdInvNo { get; set; }

        [Display(Name = nameof(ApInvoiceHd.HdDate), ResourceType = typeof(ApInvoiceHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string HdDate { get; set; }

        [Display(Name = nameof(ApInvoiceHd.CurrencyRate), ResourceType = typeof(ApInvoiceHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal CurrencyRate { get; set; }

        [Display(Name = nameof(ApInvoiceHd.PrepaidAmount), ResourceType = typeof(ApInvoiceHd))]
        public decimal? PrepaidAmount { get; set; }

        [Display(Name = nameof(ApInvoiceHd.Comments), ResourceType = typeof(ApInvoiceHd))]
        public string Comments { get; set; }

        [Display(Name = nameof(ApInvoiceHd.PrepaidPeriod), ResourceType = typeof(ApInvoiceHd))]
        public int? PrepaidPeriod { get; set; }

        [Display(Name = nameof(ApInvoiceHd.StatusLkpId), ResourceType = typeof(ApInvoiceHd))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ApInvoiceHd.HdTypeLkpId), ResourceType = typeof(ApInvoiceHd))]
        public long HdTypeLkpId { get; set; }

        [Display(Name = nameof(ApInvoiceHd.VendorId), ResourceType = typeof(ApInvoiceHd))]
        public long VendorId { get; set; }

        [Display(Name = nameof(ApInvoiceHd.CurrencyId), ResourceType = typeof(ApInvoiceHd))]
        public int CurrencyId { get; set; }

        [Display(Name = nameof(ApInvoiceHd.Desc), ResourceType = typeof(ApInvoiceHd))]
        public string Desc { get; set; }

        [Display(Name = nameof(ApInvoiceHd.Amount), ResourceType = typeof(ApInvoiceHd))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(ApInvoiceHd.Total), ResourceType = typeof(ApInvoiceHd))]
        public decimal Total { get; set; }

        [Display(Name = nameof(ApInvoiceHd.TaxAmount), ResourceType = typeof(ApInvoiceHd))]
        public decimal TaxAmount { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApMiscPaymentHeaders.TaxPercent), ResourceType = typeof(ERP.ResourcePack.Accounts.ApMiscPaymentHeaders))]
        public long? TaxPercentageLkpId { get; set; }

        public long? FromAccountId { get; set; }

        public long? ToAccountId { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApMiscPaymentHeaders.TaxNo), ResourceType = typeof(ResourcePack.Accounts.ApMiscPaymentHeaders))]
        [MaxLength(400)]
        public string TaxNo { get; set; }

        public ApVendorsVM ApVendors { get; set; }

        public CurrenciesVM Currency { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndHdTypeLkp { get; set; }

        public string InvoiceDetailsListStr { get; set; }

        public ICollection<ApInvoiceTrDto> InvoiceDetails => string.IsNullOrEmpty(InvoiceDetailsListStr) ?
                new List<ApInvoiceTrDto>() :
                Helper<List<ApInvoiceTrDto>>.Convert(InvoiceDetailsListStr);

        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }

        public string codeComUtilityIds_alt1 { get; set; }
        public string codeComUtilityTexts_alt1 { get; set; }
    }
}