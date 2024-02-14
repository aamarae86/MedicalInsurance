using ERP._System.__SpGuarantees._SpFamilies.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpFamiliesVM : BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(SpFamilies.FamilyName), ResourceType = typeof(SpFamilies))]
        public long? SpFamilyId { get; set; }

        [Display(Name = nameof(SpFamilies.GuardianName), ResourceType = typeof(SpFamilies))]
        public long? GuardianId { get; set; }

        [Display(Name = nameof(ScPortalRequests.NetValue), ResourceType = typeof(ScPortalRequests))]
        public decimal NetValue { get; set; }

        [Display(Name = nameof(SpFamilies.FamilyName), ResourceType = typeof(SpFamilies))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string FamilyName { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(SpFamilies.FamilyNumber), ResourceType = typeof(SpFamilies))]
        public string FamilyNumber { get; set; }


        [Display(Name = nameof(SpFamilies.RegistrationDate), ResourceType = typeof(SpFamilies))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string RegistrationDate { get; set; }

        [Display(Name = nameof(SpFamilies.GuardianName), ResourceType = typeof(SpFamilies))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string GuardianName { get; set; }


        [Display(Name = nameof(SpFamilies.BirthDate), ResourceType = typeof(SpFamilies))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string BirthDate { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(SpFamilies.PlaceOfBirth), ResourceType = typeof(SpFamilies))]
        public string PlaceOfBirth { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(SpFamilies.IdNumber), ResourceType = typeof(SpFamilies))]
        public string IdNumber { get; set; }

        [Display(Name = nameof(SpFamilies.IdExpirationDate), ResourceType = typeof(SpFamilies))]
        public string IdExpirationDate { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(SpFamilies.JobDescription), ResourceType = typeof(SpFamilies))]
        public string JobDescription { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(SpFamilies.Job), ResourceType = typeof(SpFamilies))]
        public string Job { get; set; }

        [Display(Name = nameof(SpFamilies.IsFatherDied), ResourceType = typeof(SpFamilies))]
        public bool IsFatherDied { get; set; }

        [Display(Name = nameof(SpFamilies.IsFatherDied), ResourceType = typeof(SpFamilies))]
        public bool IsFatherDiedAlt { get; set; }

        [Display(Name = nameof(SpFamilies.IsMotherDied), ResourceType = typeof(SpFamilies))]
        public bool IsMotherDied { get; set; }

        [Display(Name = nameof(SpFamilies.IsMotherDied), ResourceType = typeof(SpFamilies))]
        public bool IsMotherDiedAlt { get; set; }

        [Display(Name = nameof(SpFamilies.IsHasHouse), ResourceType = typeof(SpFamilies))]
        public bool IsHasHouse { get; set; }

        [Display(Name = nameof(SpFamilies.IsHasHouse), ResourceType = typeof(SpFamilies))]
        public bool IsHasHouseAlt { get; set; }

        [Display(Name = nameof(SpFamilies.FatherDiedDate), ResourceType = typeof(SpFamilies))]
        public string FatherDiedDate { get; set; }

        [Display(Name = nameof(SpFamilies.MotherDiedDate), ResourceType = typeof(SpFamilies))]
        public string MotherDiedDate { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(SpFamilies.FatherDiedReason), ResourceType = typeof(SpFamilies))]
        public string FatherDiedReason { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(SpFamilies.MotherDiedReason), ResourceType = typeof(SpFamilies))]
        public string MotherDiedReason { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(SpFamilies.Region), ResourceType = typeof(SpFamilies))]
        public string Region { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(SpFamilies.Address), ResourceType = typeof(SpFamilies))]
        public string Address { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(SpFamilies.MobileNumber1), ResourceType = typeof(SpFamilies))]
        public string MobileNumber1 { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(SpFamilies.MobileNumber2), ResourceType = typeof(SpFamilies))]
        public string MobileNumber2 { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(SpFamilies.AccountNumber), ResourceType = typeof(SpFamilies))]
        public string AccountNumber { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(SpFamilies.AccountOwner), ResourceType = typeof(SpFamilies))]
        public string AccountOwner { get; set; }

        [Display(Name = nameof(SpFamilies.BankLkpId), ResourceType = typeof(SpFamilies))]
        public long? BankLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.MaritalStatusLkpId), ResourceType = typeof(SpFamilies))]
        public long? MaritalStatusLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.RelativesTypeLkpId), ResourceType = typeof(SpFamilies))]
        public long? RelativesTypeLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.NationalityLkpId), ResourceType = typeof(SpFamilies))]
        public long? NationalityLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.HousingTypeLkpId), ResourceType = typeof(SpFamilies))]
        public long? HousingTypeLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.HousingStatusLkpId), ResourceType = typeof(SpFamilies))]
        public long? HousingStatusLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.CityLkpId), ResourceType = typeof(SpFamilies))]
        public long? CityLkpId { get; set; }

        public FndLookupValuesVM FndBankLkp { get; set; }

        public FndLookupValuesVM FndMaritalStatusLkp { get; set; }

        public FndLookupValuesVM FndRelativesTypeLkp { get; set; }

        public FndLookupValuesVM FndNationalityLkp { get; set; }

        public FndLookupValuesVM FndHousingTypeLkp { get; set; }

        public FndLookupValuesVM FndHousingStatusLkp { get; set; }

        public FndLookupValuesVM FndCityLkp { get; set; }

        [Display(Name = nameof(SpFamilies.CaseName), ResourceType = typeof(SpFamilies))]
        public string CaseName { get; set; }

        [Display(Name = nameof(SpFamilies.BirthDate), ResourceType = typeof(SpFamilies))]
        public string BirthCaseDate { get; set; }

        [Display(Name = nameof(SpFamilies.RelativesTypeLkpId), ResourceType = typeof(SpFamilies))]
        public long? RelativesCaseTypeLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.SponsorCategoryLkpId), ResourceType = typeof(SpFamilies))]
        public long? SponsorCategoryLkpId { get; set; }

        [Display(Name = nameof(SpFamilies.IncomeSourceName), ResourceType = typeof(SpFamilies))]
        public string IncomeSourceName { get; set; }

        [Display(Name = nameof(SpFamilies.MonthlyIncomeAmount), ResourceType = typeof(SpFamilies))]
        public decimal MonthlyIncomeAmount { get; set; }

        [Display(Name = nameof(SpFamilies.DutyType), ResourceType = typeof(SpFamilies))]
        public string DutyType { get; set; }

        [Display(Name = nameof(SpFamilies.DutyDescription), ResourceType = typeof(SpFamilies))]
        public string DutyDescription { get; set; }

        [Display(Name = nameof(SpFamilies.MonthlyAmount), ResourceType = typeof(SpFamilies))]
        public decimal MonthlyAmount { get; set; }

        [Display(Name = nameof(SpFamilies.Total), ResourceType = typeof(SpFamilies))]
        public decimal TotalAmount { get; set; }

        [Display(Name = nameof(ScPortalRequests.TotalDuties), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyOutcomeAmountTotal { get; set; }

        [Display(Name = nameof(ScPortalRequests.TotalIncomes), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyIncomeAmountTotal { get; set; }

        [Display(Name = nameof(ScPortalRequests.Total), ResourceType = typeof(ScPortalRequests))]
        public decimal Total { get; set; }


        public string FamilyCasesListStr { get; set; }
        public ICollection<SpFamilyCasesDto> FamilyCases => string.IsNullOrEmpty(FamilyCasesListStr) ?
                    new List<SpFamilyCasesDto>() : Helper<List<SpFamilyCasesDto>>.Convert(FamilyCasesListStr);

        public string FamilyIncomesListStr { get; set; }
        public ICollection<SpFamilyIncomesDto> FamilyIncomes => string.IsNullOrEmpty(FamilyIncomesListStr) ?
                    new List<SpFamilyIncomesDto>() : Helper<List<SpFamilyIncomesDto>>.Convert(FamilyIncomesListStr);

        public string FamilyDutiesListStr { get; set; }
        public ICollection<SpFamilyDutiesDto> FamilyDuties => string.IsNullOrEmpty(FamilyDutiesListStr) ?
                    new List<SpFamilyDutiesDto>() : Helper<List<SpFamilyDutiesDto>>.Convert(FamilyDutiesListStr);

    }
}