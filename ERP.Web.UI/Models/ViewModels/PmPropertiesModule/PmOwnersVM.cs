using ERP._System.__PmPropertiesModule._PmOwners.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.PmPropertiesModule;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmOwnersVM : BaseAuditedEntityVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(PmOwners.OwnerName), ResourceType = typeof(PmOwners))]
        public string OwnerName { get; set; }

        [Display(Name = nameof(PmOwners.OwnerNumber), ResourceType = typeof(PmOwners))]
        public string OwnerNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.OwnerNameAr), ResourceType = typeof(PmOwners))]
        public string OwnerNameAr { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.OwnerNameEn), ResourceType = typeof(PmOwners))]
        public string OwnerNameEn { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.StatusLkpId), ResourceType = typeof(PmOwners))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(PmOwners.IdNumber), ResourceType = typeof(PmOwners))]
        public string IdNumber { get; set; }

        [Display(Name = nameof(PmOwners.TaxNumber), ResourceType = typeof(PmOwners))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string TaxNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.NationalityLkpId), ResourceType = typeof(PmOwners))]
        public long NationalityLkpId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.CountryLkpId), ResourceType = typeof(PmOwners))]
        public long CountryLkpId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.CityLkpId), ResourceType = typeof(PmOwners))]
        public long CityLkpId { get; set; }

        [Display(Name = nameof(PmOwners.Address), ResourceType = typeof(PmOwners))]
        public string Address { get; set; }

        [Display(Name = nameof(PmOwners.HomePhoneNumber), ResourceType = typeof(PmOwners))]
        public string HomePhoneNumber { get; set; }

        [Display(Name = nameof(PmOwners.MobileNumber), ResourceType = typeof(PmOwners))]
        public string MobileNumber { get; set; }

        [Display(Name = nameof(PmOwners.WorkPhoneNumber), ResourceType = typeof(PmOwners))]
        public string WorkPhoneNumber { get; set; }

        [Display(Name = nameof(PmOwners.Fax), ResourceType = typeof(PmOwners))]
        public string Fax { get; set; }

        [Display(Name = nameof(PmOwners.Website), ResourceType = typeof(PmOwners))]
        public string Website { get; set; }

        [Display(Name = nameof(PmOwners.EmailAddress), ResourceType = typeof(PmOwners))]
        public string EmailAddress { get; set; }

        [Display(Name = nameof(PmOwners.JobName), ResourceType = typeof(PmOwners))]
        public string JobName { get; set; }

        [Display(Name = nameof(PmOwners.CompanyName), ResourceType = typeof(PmOwners))]
        public string CompanyName { get; set; }

        [Display(Name = nameof(PmOwners.PoBox), ResourceType = typeof(PmOwners))]
        public string PoBox { get; set; }

        [Display(Name = nameof(PmOwners.OtherAddress), ResourceType = typeof(PmOwners))]
        public string OtherAddress { get; set; }

        [Display(Name = nameof(PmOwners.Notes), ResourceType = typeof(PmOwners))]
        public string Notes { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.AccountId), ResourceType = typeof(PmOwners))]
        public long AccountId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.CurrentAccountId), ResourceType = typeof(PmOwners))]
        public long CurrentAccountId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.BankAccountId), ResourceType = typeof(PmOwners))]
        public long BankAccountId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.CashAccountId), ResourceType = typeof(PmOwners))]
        public long CashAccountId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmOwners.IsMainOwner), ResourceType = typeof(PmOwners))]
        public bool IsMainOwner { get; set; }
        public bool IsMainOwnerAlt { get; set; }


        [Display(Name = nameof(PmOwners.PmActivityTypeLkpId), ResourceType = typeof(PmOwners))]
        public long? PmActivityTypeLkpId { get; set; }
        public string FndPmActivityTypeStr { get; set; }

        [Range(0, 100)]
        [Display(Name = nameof(PmOwners.TaxPercentage), ResourceType = typeof(PmOwners))]
        public decimal TaxPercentage { get; set; }

        public ICollection<PmOwnersTaxDetailsDto> PmOwnersTaxDetails { get; set; }

        public ICollection<PmOwnersTaxDetailsDto> POTaxDetailsList => string.IsNullOrEmpty(PmOwnersTaxDetailsStr) ?
                new List<PmOwnersTaxDetailsDto>() : Helper<List<PmOwnersTaxDetailsDto>>.Convert(PmOwnersTaxDetailsStr);

        public string PmOwnersTaxDetailsStr { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndNationalityLkp { get; set; }

        public FndLookupValuesVM FndCountryLkp { get; set; }

        public FndLookupValuesVM FndCityLkp { get; set; }

        #region CodeComs

        [Required]
        public CodeComUtility Account { get; set; }

        [Required]
        public CodeComUtility CurrentAccount { get; set; }

        [Required]
        public ApBankAccountsVM BankAccount { get; set; }

        [Required]
        public ApBankAccountsVM CashAccount { get; set; }
        #endregion

    }
}