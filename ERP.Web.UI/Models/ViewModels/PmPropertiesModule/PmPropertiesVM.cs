using ERP._System.__PmPropertiesModule._PmPropertiesAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.PmPropertiesModule;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmPropertiesVM : BaseAuditedEntityVM<long>, IAttachmentListJSONString
    {
        public string EncId { get; set; }

        [Display(Name = nameof(PmProperties.PropertyId), ResourceType = typeof(PmProperties))]
        public long PropertyId { get; set; }

        [Display(Name = nameof(PmProperties.PropertyNameAr), ResourceType = typeof(PmProperties))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PropertyNameAr { get; set; }

        [Display(Name = nameof(PmProperties.PropertyNameEn), ResourceType = typeof(PmProperties))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PropertyNameEn { get; set; }

        [Display(Name = nameof(PmProperties.PropertyNumber), ResourceType = typeof(PmProperties))]
        public string PropertyNumber { get; set; }

        [Display(Name = nameof(PmProperties.LandNumber), ResourceType = typeof(PmProperties))]
        [MaxLength(30)]
        public string LandNumber { get; set; }

        [Display(Name = nameof(PmProperties.MilkiyaNumber), ResourceType = typeof(PmProperties))]
        [MaxLength(30)]
        public string MilkiyaNumber { get; set; }

        [Display(Name = nameof(PmProperties.Region), ResourceType = typeof(PmProperties))]
        public string Region { get; set; }

        [Display(Name = nameof(PmProperties.Address), ResourceType = typeof(PmProperties))]
        public string Address { get; set; }

        [Display(Name = nameof(PmProperties.Notes), ResourceType = typeof(PmProperties))]
        public string Notes { get; set; }

        [Display(Name = nameof(PmProperties.PropertyValue), ResourceType = typeof(PmProperties))]
        public decimal? PropertyValue { get; set; }

        [Display(Name = nameof(PmProperties.CommissionPercentage), ResourceType = typeof(PmProperties))]
        public decimal? CommissionPercentage { get; set; }

        [Display(Name = nameof(PmProperties.CompletionDate), ResourceType = typeof(PmProperties))]
        public string CompletionDate { get; set; }

        [Display(Name = nameof(PmProperties.NoOfFloors), ResourceType = typeof(PmProperties))]
        public int? NoOfFloors { get; set; }

        [Display(Name = nameof(PmProperties.PmOwnerId), ResourceType = typeof(PmProperties))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PmOwnerId { get; set; }

        [Display(Name = nameof(PmProperties.BankAccountId), ResourceType = typeof(PmProperties))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long BankAccountId { get; set; }

        [Display(Name = nameof(PmProperties.StatusLkpId), ResourceType = typeof(PmProperties))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(PmProperties.CountryLkpId), ResourceType = typeof(PmProperties))]
        public long? CountryLkpId { get; set; }

        [Display(Name = nameof(PmProperties.CityLkpId), ResourceType = typeof(PmProperties))]
        public long? CityLkpId { get; set; }

        [Display(Name = nameof(PmProperties.CommissionTypeLkpId), ResourceType = typeof(PmProperties))]
        public long? CommissionTypeLkpId { get; set; }

        [Display(Name = nameof(PmProperties.PmPurposeLkpId), ResourceType = typeof(PmProperties))]
        public long? PmPurposeLkpId { get; set; }

        public string AttachmentsListStr { get; set; }

        public PmOwnersVM PmOwners { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndCountryLkp { get; set; }

        public FndLookupValuesVM FndCityLkp { get; set; }

        public FndLookupValuesVM FndCommissionTypeLkp { get; set; }

        public FndLookupValuesVM FndPmPurposeLkp { get; set; }

        public ICollection<PmPropertiesAttachmentsDto> PropAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
                new List<PmPropertiesAttachmentsDto>() : Helper<List<PmPropertiesAttachmentsDto>>.Convert(AttachmentsListStr);

        public string RevenuesListStr { get; set; }

        public ICollection<PmPropertiesRevenueAccountsDto> PropRevenues => string.IsNullOrEmpty(RevenuesListStr) ?
                new List<PmPropertiesRevenueAccountsDto>() : Helper<List<PmPropertiesRevenueAccountsDto>>.Convert(RevenuesListStr);

        public string UnitsListStr { get; set; }

        public ICollection<PmPropertiesUnitsDto> PropUnits => string.IsNullOrEmpty(UnitsListStr) ?
                new List<PmPropertiesUnitsDto>() : Helper<List<PmPropertiesUnitsDto>>.Convert(UnitsListStr);


    }
}