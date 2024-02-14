using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArDrCrHdVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.NotificationNumber), ResourceType = typeof(ArCustomers))]
        public string HdDrCrNumber { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.HdDate), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string HdDate { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.NotificationType), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? HdTypeLkpId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Notes), ResourceType = typeof(ArCustomers))]
        public string Comments { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Status), ResourceType = typeof(ArCustomers))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Currency), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int CurrencyId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.Rate), ResourceType = typeof(ArCustomers))]
        public decimal? CurrencyRate { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.CustNam), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? ArCustomerId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.SourceLkpId), ResourceType = typeof(ArCustomers))]
        public long? SourceLkpId { get; set; }

        public long? SourceId { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArCustomers.SourceNumber), ResourceType = typeof(ArCustomers))]
        public string SourceNo { get; set; }

        public string ListArDrCrTr { get; set; }

        public FndLookupValuesVM FndLookupValuesHdTypeLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesStatusLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesSourceLkp { get; set; }

        public CurrenciesVM Currency { get; set; }

        public ArCustomersVM ArCustomers { get; set; }

        public List<_System._ArDrCrTr.Dto.ArDrCrTrVM> ArDrCrTrList => string.IsNullOrEmpty(ListArDrCrTr) ? new List<_System._ArDrCrTr.Dto.ArDrCrTrVM>() :
            Helper<List<_System._ArDrCrTr.Dto.ArDrCrTrVM>>.Convert(ListArDrCrTr);

    }
}