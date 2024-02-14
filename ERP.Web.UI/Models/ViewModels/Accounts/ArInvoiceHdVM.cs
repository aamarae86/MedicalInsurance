using ERP._System._ArInvoiceTr.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArInvoiceHdVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(ResourcePack.Accounts.ArCustomers.InvoiceNumber), ResourceType = typeof(ArCustomers))]
        [MaxLength(30)]
        public string HdInvoiceNo { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Date), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string HdDate { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Notes), ResourceType = typeof(ArCustomers))]
        [MaxLength(4000)]
        public string Comments { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Status), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Currency), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int? CurrancyId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Rate), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? CurrancyRate { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.CustomerName), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? ArCustomerId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.SourceLkpId), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? SourceLkpId { get; set; }

        public long? SourceId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.SourceNumber), ResourceType = typeof(ArCustomers))]
        [MaxLength(30)]
        public string SourceNo { get; set; }


        [MaxLength(4000)]
        public string Description { get; set; }

        public long? AccountId { get; set; }

        public decimal? Amount { get; set; }

        public decimal? TaxPercent { get; set; }

        public long? ArInvoiceHdId { get; set; }

        public FndLookupValuesVM FndLookupValuesArInvoiceHdStatusLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesArInvoiceHdSourceLkp { get; set; }

        public CurrenciesVM Currency { get; set; }

        public ArCustomersVM ArCustomers { get; set; }

        public string ListArInvoiceTr { get; set; }


        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Amount), ResourceType = typeof(ArCustomers))]
        public decimal? TotalAmount { get; set; }
        public List<ArInvoiceTrDto> ArInvoiceTrList => string.IsNullOrEmpty(ListArInvoiceTr) ? new List<ArInvoiceTrDto>() :
            Helper<List<ArInvoiceTrDto>>.Convert(ListArInvoiceTr);
    }
}